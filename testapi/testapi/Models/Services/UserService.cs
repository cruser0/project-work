using API.Models.DTO;
using API.Models.Entities;
using API.Models.Entities.Preference;
using API.Models.Exceptions;
using API.Models.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;


namespace API.Models.Services
{
    public class UserService
    {
        private readonly IConfiguration _configuration;
        private readonly Progetto_FormativoContext _context;

        public UserService(IConfiguration conf, Progetto_FormativoContext ctx)
        {
            _context = ctx;
            _configuration = conf;
        }
        /*
         Creates a random Salt from the HMACSHA512 and and hashes the password
        */
        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        public bool VeryfyPasswordHash(string password, byte[] hash, byte[] salt)
        {
            using (var hmac = new HMACSHA512(salt))
            {

                var compuuteHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return compuuteHash.SequenceEqual(hash);
            }
        }
        public string CreateToken(UserRoleDTO user)
        {
            List<Claim> claims = new List<Claim>
    {
        new Claim(ClaimTypes.NameIdentifier, user.Email),
    };
            foreach (string role in user.Role)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtConfig:Secret"]));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(int.Parse(_configuration["JwtConfig:AccessTokenExpiration"])),
                signingCredentials: cred
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        internal async Task<RefreshToken> GetRefreshTokenByrefTokenString(string refToken)
        {
            RefreshToken dbRefToken = await _context.RefreshTokens.Where(x => x.Token.Equals(refToken)).FirstOrDefaultAsync();
            if (dbRefToken == null)
                throw new NotFoundTokenException("Token not Found");
            return dbRefToken;
        }

        public async Task<RefreshToken> GenerateRefreshToken(int userID)
        {
            var refreshToken = new RefreshToken
            {
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                Expires = DateTime.Now.AddDays(int.Parse(_configuration["JwtConfig:RefreshTokenExpiration"])),
                Created = DateTime.Now,
                UserID = userID
            };
            _context.RefreshTokens.Add(refreshToken);
            await _context.SaveChangesAsync();
            return refreshToken;
        }

        public async Task<RefreshToken> GetNewerRefreshToken(RefreshTokenDTO refTk)
        {
            User user = await _context.Users.Where(x => x.UserID == refTk.UserID).FirstOrDefaultAsync();
            if (user == null)
                throw new NotFoundException("User not found");
            RefreshToken refreshToken = await _context.RefreshTokens
                .Where(x => x.UserID == user.UserID)
                .OrderByDescending(x => x.Created)
                .FirstOrDefaultAsync();
            if (refreshToken == null)
                throw new NotFoundTokenException("User has no refresh tokens");
            return refreshToken;
        }

        public async Task<List<UserRole>> GetAllRolesByUserID(int id)
        {
            var data = await _context.UserRoles.Where(x => x.UserID == id).ToListAsync();
            if (!data.Any())
                throw new NotFoundException("User has no Roles");
            return data;
        }
        public async Task EditRoles(int? id, List<string> roles)
        {
            if (!roles.Any())
                throw new ErrorInputPropertyException("Each user needs to have at least one Role");
            if (!await _context.Users.AnyAsync(x => x.UserID == id))
                throw new NotFoundTokenException("User not Found");
            var rolesList = await GetAllRolesByUserID((int)id);
            _context.UserRoles.RemoveRange(rolesList);
            await _context.SaveChangesAsync();
            UserRole ur;
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                foreach (var role in roles)
                {

                    ur = new UserRole

                    {
                        RoleID = (await GetRole(role)).RoleID,
                        UserID = (int)id

                    };
                    _context.UserRoles.Add(ur);
                }
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new Exception(ex.InnerException.Message);
            }

        }


        internal async Task EditUser(int id, UserDTOEdit updateUser)
        {
            User user = await GetUserByID(id);
            user.Name = !string.IsNullOrEmpty(updateUser.Name) && updateUser.Name.Length <= 100 ? updateUser.Name : user.Name;
            user.LastName = !string.IsNullOrEmpty(updateUser.LastName) && updateUser.LastName.Length <= 100 ? updateUser.LastName : user.LastName;
            user.Email = !string.IsNullOrEmpty(updateUser.Email) && updateUser.Email.Length <= 100 ? updateUser.Email : user.Email;
            if (!string.IsNullOrEmpty(updateUser.Password))
            {
                CreatePasswordHash(updateUser.Password, out byte[] hash, out byte[] salt);
                user.PasswordHash = hash;
                user.PasswordSalt = salt;
            }
            _context.Users.Update(user);
            await _context.SaveChangesAsync();

        }

        internal async Task DeleteUser(int id)
        {
            var rolesList = await GetAllRolesByUserID(id);
            if (!_context.Users.Any(x => x.UserID == id))
                throw new NotFoundException("User not Found");
            _context.UserRoles.RemoveRange(rolesList);
            await _context.SaveChangesAsync();
            var user = await _context.Users.Where(x => x.UserID == id).FirstOrDefaultAsync();
            if (user == null)
                throw new NotFoundException("User not found!");
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        internal async Task<string> MassDeleteUser(List<int> userId)
        {
            int count = 0;
            foreach (int id in userId)
            {
                var rolesList = await GetAllRolesByUserID(id);
                if (!await _context.Users.AnyAsync(x => x.UserID == id))
                    continue; ;
                _context.UserRoles.RemoveRange(rolesList);
                await _context.SaveChangesAsync();
                var user = await _context.Users.Where(x => x.UserID == id).FirstOrDefaultAsync();
                if (user == null)
                    throw new NotFoundException("User not found!");
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                count++;
            }
            return $"{count} Users were deleted out of {userId.Count}";
        }

        internal async Task<string> MassUpdateUser(List<UserDTOGet> newUsers)
        {
            int count = 0;
            foreach (UserDTOGet updateUser in newUsers)
            {
                User user = await GetUserByID((int)updateUser.UserID);
                user.Name = !string.IsNullOrEmpty(updateUser.Name) && updateUser.Name.Length <= 100 ? updateUser.Name : user.Name;
                user.LastName = !string.IsNullOrEmpty(updateUser.LastName) && updateUser.LastName.Length <= 100 ? updateUser.LastName : user.LastName;
                user.Email = !string.IsNullOrEmpty(updateUser.Email) && updateUser.Email.Length <= 100 ? updateUser.Email : user.Email;

                _context.Users.Update(user);
                await _context.SaveChangesAsync();

                count++;
            }
            return $"{count} Users were updated out of {newUsers.Count}";
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var user = await _context.Users
                .Where(u => u.Email.Equals(email))
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .FirstOrDefaultAsync();
            if (user == null)
                throw new NotFoundException("User not Found");
            return user;
        }
        public async Task<User> GetUserByID(int id)
        {
            var user = await _context.Users
                .Where(u => u.UserID == id)
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .FirstOrDefaultAsync();
            if (user == null)
                throw new NotFoundException("User not Found");
            return user;
        }
        public async Task<UserRoleDTO> GetUserRoleDTOByID(int id)
        {
            var user = await _context.Users
                .Where(x => x.UserID == id)
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role).FirstOrDefaultAsync();

            if (user == null)
                throw new NotFoundException("User not Found");
            List<string> roleList = user.UserRoles.Select(x => x.Role.RoleName).ToList();
            return new UserRoleDTO(user, roleList);
        }
        public async Task<ICollection<UserRoleDTO>> GetAllUsers(UserFilter filter)
        {
            return await ApplyFilter(filter);
        }

        public async Task<int> CountUsers(UserFilter filter)
        {
            return (await ApplyFilter(filter)).Count;
        }

        private async Task<ICollection<UserRoleDTO>> ApplyFilter(UserFilter filter)
        {
            int itemsPage = 10;
            var query = _context.Users
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role).AsQueryable();


            if (!string.IsNullOrEmpty(filter.UserName))
                query = query.Where(s => s.Name.StartsWith(filter.UserName));
            if (!string.IsNullOrEmpty(filter.UserLastName))
                query = query.Where(s => s.LastName.StartsWith(filter.UserLastName));
            if (!string.IsNullOrEmpty(filter.UserEmail))
                query = query.Where(s => s.Email.StartsWith(filter.UserEmail));
            if (filter.UserRoles.Count > 0)
            {
                foreach (var role in filter.UserRoles)
                    query = query.Where(x => x.UserRoles.Any(x => x.Role.RoleName.Contains(role)));
            }
            if (filter.UserPage != null)
            {
                query = query.Skip(((int)filter.UserPage - 1) * itemsPage).Take(itemsPage);
            }

            List<User> userList = await query.ToListAsync();
            List<UserRoleDTO> returnList = new List<UserRoleDTO>();
            List<string> roleList;
            foreach (User user in userList)
            {
                roleList = user.UserRoles.Select(x => x.Role.RoleName).ToList();
                returnList.Add(new UserRoleDTO(user, roleList));
            }
            return returnList;
        }

        public async Task<Role> GetRole(string role)
        {
            var data = await _context.Roles.FirstOrDefaultAsync(x => x.RoleName == role);
            if (data == null)
                throw new Exception("Role not found");
            return data;

        }


        /*
         Registers a user with hashed password and the salt in the db
         */
        public async Task<User> CreateUser(UserDTOCreate user)
        {
            if (await _context.Users.AnyAsync(x => x.Email.Equals(user.Email)))
                throw new ErrorInputPropertyException("User is already registered");
            if (!user.Role.Any())
                throw new ErrorInputPropertyException("Can't create a User with no Roles");
            User returnUser = new User();
            if (!string.IsNullOrEmpty(user.Name))
                returnUser.Name = user.Name.Length <= 100 ? user.Name : throw new ErrorInputPropertyException("User Name needs to be shorter than 100 Character to be created");
            else
                throw new NullPropertyException("User Name can't be empty");
            if (!string.IsNullOrEmpty(user.LastName))
                returnUser.LastName = user.LastName.Length <= 100 ? user.LastName : throw new ErrorInputPropertyException("User Last Name needs to be shorter than 100 Character to be created");
            else
                throw new NullPropertyException("User Last Name can't be empty");
            if (!string.IsNullOrEmpty(user.Email))
                returnUser.Email = user.Email.Length <= 100 ? user.Email : throw new ErrorInputPropertyException("User Email needs to be shorter than 100 Character to be created");
            else
                throw new NullPropertyException("User Email can't be empty");
            if (string.IsNullOrEmpty(user.Password))
                throw new NullPropertyException("Password can't be empty");
            CreatePasswordHash(user.Password, out byte[] hash, out byte[] salt);
            returnUser.PasswordSalt = salt;
            returnUser.PasswordHash = hash;
            UserRole ur;
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                _context.Users.Add(returnUser);
                await _context.SaveChangesAsync();
                foreach (var role in user.Role)
                {

                    ur = new UserRole

                    {
                        RoleID = (await GetRole(role)).RoleID,
                        UserID = returnUser.UserID

                    };
                    _context.UserRoles.Add(ur);
                    await _context.SaveChangesAsync();
                }
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new Exception(ex.InnerException.Message);
            }
            await CreateUpdateCustomerDGV(new CustomerDGV { UserID = returnUser.UserID });
            await CreateUpdateCustomerInvoiceDGV(new CustomerInvoiceDGV { UserID = returnUser.UserID });
            await CreateUpdateCustomerInvoiceCostDGV(new CustomerInvoiceCostDGV { UserID = returnUser.UserID });
            await CreateUpdateSupplierDGV(new SupplierDGV { UserID = returnUser.UserID });
            await CreateUpdateSupplierInvoiceDGV(new SupplierInvoiceDGV { UserID = returnUser.UserID });
            await CreateUpdateSupplierInvoiceCostDGV(new SupplierInvoiceCostDGV { UserID = returnUser.UserID });
            await CreateUpdateSaleDGV(new SaleDGV { UserID = returnUser.UserID });
            await CreateUpdateUserDGV(new UserDGV { UserID = returnUser.UserID });
            return returnUser;

        }
        public async Task<CustomerDGV> GetCustomerDGV(int userId)
        {
            CustomerDGV? cdgv = await _context.CustomerDGV.Where(x => x.UserID == userId).FirstOrDefaultAsync();
            if (cdgv == null)
                throw new NotFoundException("Customer DGV not found");
            return cdgv;
        }
        public async Task<CustomerDGV> CreateUpdateCustomerDGV(CustomerDGV cdgv)
        {
            var cdgvDb = await _context.CustomerDGV.Where(x => x.UserID == cdgv.UserID).FirstOrDefaultAsync();
            if (cdgvDb == null)
            {
                _context.CustomerDGV.Add(cdgv);
                await _context.SaveChangesAsync();
                return cdgv;
            }
            else
            {
                cdgvDb.ShowOriginalID = cdgv.ShowOriginalID == null ? false : cdgv.ShowOriginalID;
                cdgvDb.ShowStatus = cdgv.ShowStatus == null ? true : cdgv.ShowStatus;
                cdgvDb.ShowID = cdgv.ShowID == null ? false : cdgv.ShowID;
                cdgvDb.ShowCountry = cdgv.ShowCountry == null ? true : cdgv.ShowCountry;
                cdgvDb.ShowDate = cdgv.ShowDate == null ? true : cdgv.ShowDate;
                cdgvDb.ShowName = cdgv.ShowName == null ? true : cdgv.ShowName;
                _context.CustomerDGV.Update(cdgvDb);
                await _context.SaveChangesAsync();
                return cdgvDb;
            }
        }

        public async Task<CustomerInvoiceDGV> GetCustomerInvoiceDGV(int userId)
        {
            var cdgv = await _context.CustomerInvoiceDGV.Where(x => x.UserID == userId).FirstOrDefaultAsync();
            if (cdgv == null)
                throw new NotFoundException("Customer Invoice DGV not found");
            return cdgv;
        }
        public async Task<CustomerInvoiceDGV> CreateUpdateCustomerInvoiceDGV(CustomerInvoiceDGV cdgv)
        {
            var cdgvDb = await _context.CustomerInvoiceDGV.Where(x => x.UserID == cdgv.UserID).FirstOrDefaultAsync();
            if (cdgvDb == null)
            {
                _context.CustomerInvoiceDGV.Add(cdgv);
                await _context.SaveChangesAsync();
                return cdgv;
            }
            else
            {
                cdgvDb.ShowDate = cdgv.ShowDate == null ? true : cdgv.ShowDate;
                cdgvDb.ShowStatus = cdgv.ShowStatus == null ? true : cdgv.ShowStatus;
                cdgvDb.ShowSaleID = cdgv.ShowSaleID == null ? false : cdgv.ShowSaleID;
                cdgvDb.ShowID = cdgv.ShowID == null ? false : cdgv.ShowID;
                cdgvDb.ShowInvoiceAmount = cdgv.ShowInvoiceAmount == null ? true : cdgv.ShowInvoiceAmount;
                _context.CustomerInvoiceDGV.Update(cdgvDb);
                await _context.SaveChangesAsync();
                return cdgvDb;
            }
        }
        public async Task<CustomerInvoiceCostDGV> GetCustomerInvoiceCostDGV(int userId)
        {
            var cdgv = await _context.CustomerInvoiceCostDGV.Where(x => x.UserID == userId).FirstOrDefaultAsync();
            if (cdgv == null)
                throw new NotFoundException("Customer Invoice DGV not found");
            return cdgv;
        }

        public async Task<CustomerInvoiceCostDGV> CreateUpdateCustomerInvoiceCostDGV(CustomerInvoiceCostDGV cdgv)
        {
            var cdgvDb = await _context.CustomerInvoiceCostDGV.Where(x => x.UserID == cdgv.UserID).FirstOrDefaultAsync();
            if (cdgvDb == null)
            {
                _context.CustomerInvoiceCostDGV.Add(cdgv);
                await _context.SaveChangesAsync();
                return cdgv;
            }
            else
            {
                cdgvDb.ShowID = cdgv.ShowID == null ? false : cdgv.ShowID;
                cdgvDb.ShowCost = cdgv.ShowCost == null ? true : cdgv.ShowCost;
                cdgvDb.ShowQuantity = cdgv.ShowQuantity == null ? true : cdgv.ShowQuantity;
                cdgvDb.ShowInvoiceID = cdgv.ShowInvoiceID == null ? false : cdgv.ShowInvoiceID;
                cdgvDb.ShowName = cdgv.ShowName == null ? true : cdgv.ShowName;
                _context.CustomerInvoiceCostDGV.Update(cdgvDb);
                await _context.SaveChangesAsync();
                return cdgvDb;
            }
        }
        public async Task<SupplierDGV> GetSupplierDGV(int userId)
        {
            var cdgv = await _context.SupplierDGV.Where(x => x.UserID == userId).FirstOrDefaultAsync();
            if (cdgv == null)
                throw new NotFoundException("Supplier DGV not found");
            return cdgv;
        }
        public async Task<SupplierDGV> CreateUpdateSupplierDGV(SupplierDGV cdgv)
        {
            var cdgvDb = await _context.SupplierDGV.Where(x => x.UserID == cdgv.UserID).FirstOrDefaultAsync();
            if (cdgvDb == null)
            {
                _context.SupplierDGV.Add(cdgv);
                await _context.SaveChangesAsync();
                return cdgv;
            }
            else
            {
                cdgvDb.ShowOriginalID = cdgv.ShowOriginalID == null ? false : cdgv.ShowOriginalID;
                cdgvDb.ShowStatus = cdgv.ShowStatus == null ? true : cdgv.ShowStatus;
                cdgvDb.ShowID = cdgv.ShowID == null ? false : cdgv.ShowID;
                cdgvDb.ShowCountry = cdgv.ShowCountry == true ? false : cdgv.ShowCountry;
                cdgvDb.ShowDate = cdgv.ShowDate == null ? true : cdgv.ShowDate;
                cdgvDb.ShowName = cdgv.ShowName == null ? true : cdgv.ShowName;
                _context.SupplierDGV.Update(cdgvDb);
                await _context.SaveChangesAsync();
                return cdgvDb;
            }
        }

        public async Task<SupplierInvoiceDGV> GetSupplierInvoiceDGV(int userId)
        {
            var cdgv = await _context.SupplierInvoiceDGV.Where(x => x.UserID == userId).FirstOrDefaultAsync();
            if (cdgv == null)
                throw new NotFoundException("Supplier Invoice DGV not found");
            return cdgv;
        }
        public async Task<SupplierInvoiceDGV> CreateUpdateSupplierInvoiceDGV(SupplierInvoiceDGV cdgv)
        {
            var cdgvDb = await _context.SupplierInvoiceDGV.Where(x => x.UserID == cdgv.UserID).FirstOrDefaultAsync();
            if (cdgvDb == null)
            {
                _context.SupplierInvoiceDGV.Add(cdgv);
                await _context.SaveChangesAsync();
                return cdgv;
            }
            else
            {
                cdgvDb.ShowInvoiceDate = cdgv.ShowInvoiceDate == null ? true : cdgv.ShowInvoiceDate;
                cdgvDb.ShowStatus = cdgv.ShowStatus == null ? true : cdgv.ShowStatus;
                cdgvDb.ShowSaleID = cdgv.ShowSaleID == null ? false : cdgv.ShowSaleID;
                cdgvDb.ShowID = cdgv.ShowID == null ? false : cdgv.ShowID;
                cdgvDb.ShowInvoiceAmount = cdgv.ShowInvoiceAmount == null ? true : cdgv.ShowInvoiceAmount;
                cdgvDb.ShowSupplierName = cdgv.ShowSupplierName == null ? true : cdgv.ShowSupplierName;
                cdgvDb.ShowSupplierID = cdgv.ShowSupplierID == null ? false : cdgv.ShowSupplierID;
                cdgvDb.ShowCountry = cdgv.ShowCountry == null ? true : cdgv.ShowCountry;

                _context.SupplierInvoiceDGV.Update(cdgvDb);
                await _context.SaveChangesAsync();
                return cdgvDb;
            }
        }
        public async Task<SupplierInvoiceCostDGV> GetSupplierInvoiceCostDGV(int userId)
        {
            var cdgv = await _context.SupplierInvoiceCostDGV.Where(x => x.UserID == userId).FirstOrDefaultAsync();
            if (cdgv == null)
                throw new NotFoundException("Supplier Invoice DGV not found");
            return cdgv;
        }

        public async Task<SupplierInvoiceCostDGV> CreateUpdateSupplierInvoiceCostDGV(SupplierInvoiceCostDGV cdgv)
        {
            var cdgvDb = await _context.SupplierInvoiceCostDGV.Where(x => x.UserID == cdgv.UserID).FirstOrDefaultAsync();
            if (cdgvDb == null)
            {
                _context.SupplierInvoiceCostDGV.Add(cdgv);
                await _context.SaveChangesAsync();
                return cdgv;
            }
            else
            {
                cdgvDb.ShowID = cdgv.ShowID == null ? false : cdgv.ShowID;
                cdgvDb.ShowCost = cdgv.ShowCost == null ? true : cdgv.ShowCost;
                cdgvDb.ShowQuantity = cdgv.ShowQuantity == null ? true : cdgv.ShowQuantity;
                cdgvDb.ShowSupplierInvoiceID = cdgv.ShowSupplierInvoiceID == null ? false : cdgv.ShowSupplierInvoiceID;
                cdgvDb.ShowName = cdgv.ShowName == null ? true : cdgv.ShowName;
                _context.SupplierInvoiceCostDGV.Update(cdgvDb);
                await _context.SaveChangesAsync();
                return cdgvDb;
            }
        }
        public async Task<SaleDGV> GetSaleDGV(int userId)
        {
            var cdgv = await _context.SaleDGV.Where(x => x.UserID == userId).FirstOrDefaultAsync();
            if (cdgv == null)
                throw new NotFoundException("Supplier Invoice DGV not found");
            return cdgv;
        }

        public async Task<SaleDGV> CreateUpdateSaleDGV(SaleDGV cdgv)
        {
            var cdgvDb = await _context.SaleDGV.Where(x => x.UserID == cdgv.UserID).FirstOrDefaultAsync();
            if (cdgvDb == null)
            {
                _context.SaleDGV.Add(cdgv);
                await _context.SaveChangesAsync();
                return cdgv;
            }
            else
            {
                cdgvDb.ShowID = cdgv.ShowID == null ? false : cdgv.ShowID;
                cdgvDb.ShowStatus = cdgv.ShowStatus == null ? true : cdgv.ShowStatus;
                cdgvDb.ShowBoL = cdgv.ShowBoL == null ? true : cdgv.ShowBoL;
                cdgvDb.ShowBKNumber = cdgv.ShowBKNumber == null ? true : cdgv.ShowBKNumber;
                cdgvDb.ShowCustomerName = cdgv.ShowCustomerName == null ? true : cdgv.ShowCustomerName;
                cdgvDb.ShowCustomerID = cdgv.ShowCustomerID == null ? false : cdgv.ShowCustomerID;
                cdgvDb.ShowCustomerCountry = cdgv.ShowCustomerCountry == null ? true : cdgv.ShowCustomerCountry;
                cdgvDb.ShowDate = cdgv.ShowDate == null ? true : cdgv.ShowDate;
                cdgvDb.ShowTotalRevenue = cdgv.ShowTotalRevenue == null ? true : cdgv.ShowTotalRevenue;
                _context.SaleDGV.Update(cdgvDb);
                await _context.SaveChangesAsync();
                return cdgvDb;
            }
        }
        public async Task<UserDGV> GetUserDGV(int userId)
        {
            var cdgv = await _context.UserDGV.Where(x => x.UserID == userId).FirstOrDefaultAsync();
            if (cdgv == null)
                throw new NotFoundException("Supplier Invoice DGV not found");
            return cdgv;
        }

        public async Task<UserDGV> CreateUpdateUserDGV(UserDGV cdgv)
        {
            var cdgvDb = await _context.UserDGV.Where(x => x.UserID == cdgv.UserID).FirstOrDefaultAsync();
            if (cdgvDb == null)
            {
                _context.UserDGV.Add(cdgv);
                await _context.SaveChangesAsync();
                return cdgv;
            }
            else
            {
                cdgvDb.ShowID = cdgv.ShowID == null ? false : cdgv.ShowID;
                cdgvDb.ShowRoles = cdgv.ShowRoles == null ? true : cdgv.ShowRoles;
                cdgvDb.ShowLastName = cdgv.ShowLastName == null ? true : cdgv.ShowLastName;
                cdgvDb.ShowEmail = cdgv.ShowEmail == null ? true : cdgv.ShowEmail;
                cdgvDb.ShowName = cdgv.ShowName == null ? true : cdgv.ShowName;
                _context.UserDGV.Update(cdgvDb);
                await _context.SaveChangesAsync();
                return cdgvDb;
            }
        }
        public async Task<FavouritePages> GetFavouritePages(string name)
        {
            var fp = await _context.FavouritePages.Where(x => x.Name == name).FirstOrDefaultAsync();
            if (fp == null)
                throw new NotFoundException("Page not Found");
            return fp;
        }
        public async Task<FavouritePages> GetFavouritePagesByID(int id)
        {
            var fp = await _context.FavouritePages.Where(x => x.FavouritePageID == id).FirstOrDefaultAsync();
            if (fp == null)
                throw new NotFoundException("Page not Found");
            return fp;
        }
        public async Task<List<string>> GetUserPreferredPages(int userID)
        {
            var ufp = _context.UserFavouritePage.Where(x => x.UserID == userID).ToList();
            if (!ufp.Any())
                return new List<string>();
            List<string> returnlist = new List<string>();
            foreach (var favPage in ufp)
            {
                returnlist.Add((await GetFavouritePagesByID((int)favPage.FavouritePageID)).Name);
            }
            return returnlist;
        }
        public async Task CreateFavouritePages(string name)
        {
            var fp = await _context.FavouritePages.Where(x => x.Name == name).FirstOrDefaultAsync();
            if (fp != null)
                throw new ErrorInputPropertyException("Page already exists");
            _context.FavouritePages.Add(new FavouritePages { Name = name });
            await _context.SaveChangesAsync();
        }
        public async Task AddFavouritePagesToUser(List<string> pageName, int userID)
        {
            FavouritePages fp;
            User user = await GetUserByID(userID);
            foreach (string page in pageName)
            {
                fp = await GetFavouritePages(page);
                _context.UserFavouritePage.Add(new UserFavouritePage { FavouritePageID = fp.FavouritePageID, UserID = user.UserID });
            }
            await _context.SaveChangesAsync();
        }
        public async Task RemoveFavouritePagesToUser(List<string> pageName, int userID)
        {
            FavouritePages fp;
            User user = await GetUserByID(userID);
            foreach (string page in pageName)
            {
                fp = await GetFavouritePages(page);
                var ufp = await _context.UserFavouritePage.Where(x => x.UserID == user.UserID).Where(x => x.FavouritePageID == fp.FavouritePageID).FirstOrDefaultAsync();
                if (ufp != null)
                    _context.UserFavouritePage.Remove(ufp);
            }
            await _context.SaveChangesAsync();
        }
    }
}

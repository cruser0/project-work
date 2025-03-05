using API.Models.DTO;
using API.Models.Entities;
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

        internal RefreshToken GetRefreshTokenByrefTokenString(string refToken)
        {
            RefreshToken dbRefToken = _context.RefreshTokens.Where(x => x.Token.Equals(refToken)).FirstOrDefault();
            if (dbRefToken == null)
                throw new Exception("Token not Found");
            return dbRefToken;
        }

        public RefreshToken GenerateRefreshToken(int userID)
        {
            var refreshToken = new RefreshToken
            {
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                Expires = DateTime.Now.AddDays(int.Parse(_configuration["JwtConfig:RefreshTokenExpiration"])),
                Created = DateTime.Now,
                UserID = userID
            };
            _context.RefreshTokens.Add(refreshToken);
            _context.SaveChanges();
            return refreshToken;
        }

        public RefreshToken GetNewerRefreshToken(RefreshTokenDTO refTk)
        {
            User user = _context.Users.Where(x => x.UserID == refTk.UserID).FirstOrDefault();
            if (user == null)
                throw new Exception("User not found");
            RefreshToken refreshToken = _context.RefreshTokens
                .Where(x => x.UserID == user.UserID)
                .OrderByDescending(x => x.Created)
                .FirstOrDefault();
            if (refreshToken == null)
                throw new Exception("User has no refresh tokens");
            return refreshToken;
        }

        public List<UserRole> GetAllRolesByUserID(int id)
        {
            var data = _context.UserRoles.Where(x => x.UserID == id).ToList();
            if (!data.Any())
                throw new Exception("User has no Roles");
            return data;
        }
        public void EditRoles(int? id, List<string> roles)
        {
            if (!roles.Any())
                throw new Exception("Each user needs to have at least one Role");
            if (!_context.Users.Any(x => x.UserID == id))
                throw new Exception("User not Found");
            var rolesList = GetAllRolesByUserID((int)id);
            _context.UserRoles.RemoveRange(rolesList);
            _context.SaveChanges();
            UserRole ur;
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                foreach (var role in roles)
                {

                    ur = new UserRole

                    {
                        RoleID = GetRole(role).RoleID,
                        UserID = (int)id

                    };
                    _context.UserRoles.Add(ur);
                }
                _context.SaveChanges();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception(ex.InnerException.Message);
            }

        }


        internal void EditUser(int id, UserDTOEdit updateUser)
        {
            User user = GetUserByID(id);
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
            _context.SaveChanges();

        }

        internal void DeleteUser(int id)
        {
            var rolesList = GetAllRolesByUserID(id);
            if (!_context.Users.Any(x => x.UserID == id))
                throw new Exception("User not Found");
            _context.UserRoles.RemoveRange(rolesList);
            _context.SaveChanges();
            var user = _context.Users.Where(x => x.UserID == id).FirstOrDefault();
            if (user == null)
                throw new Exception("User not found!");
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public User GetUserByEmail(string email)
        {
            var user = _context.Users
                .Where(u => u.Email.Equals(email))
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .FirstOrDefault();
            if (user == null)
                throw new Exception("User not Found");
            return user;
        }
        public User GetUserByID(int id)
        {
            var user = _context.Users
                .Where(u => u.UserID == id)
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .FirstOrDefault();
            if (user == null)
                throw new Exception("User not Found");
            return user;
        }
        public UserRoleDTO GetUserRoleDTOByID(int id)
        {
            var user = _context.Users
                .Where(x => x.UserID == id)
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role).FirstOrDefault();

            if (user == null)
                throw new Exception("User not Found");
            List<string> roleList = user.UserRoles.Select(x => x.Role.RoleName).ToList();
            return new UserRoleDTO(user, roleList);
        }
        public ICollection<UserRoleDTO> GetAllUsers(UserFilter filter)
        {
            return ApplyFilter(filter);
        }

        public int CountUsers(UserFilter filter)
        {
            return ApplyFilter(filter).Count();
        }

        private ICollection<UserRoleDTO> ApplyFilter(UserFilter filter)
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

            List<User> userList = query.ToList();
            List<UserRoleDTO> returnList = new List<UserRoleDTO>();
            List<string> roleList;
            Dictionary<string, string> prefList;
            foreach (User user in userList)
            {
                roleList = user.UserRoles.Select(x => x.Role.RoleName).ToList();
                returnList.Add(new UserRoleDTO(user, roleList));
            }
            return returnList;
        }

        public Role GetRole(string role)
        {
            var data = _context.Roles.FirstOrDefault(x => x.RoleName == role);
            if (data == null)
                throw new Exception("Role not found");
            return data;

        }

       
        /*
         Registers a user with hashed password and the salt in the db
         */
        public User CreateUser(UserDTOCreate user)
        {
            if (_context.Users.Any(x => x.Email.Equals(user.Email)))
                throw new Exception("User is already registered");
            if (!user.Role.Any())
                throw new Exception("Can't create a User with no Roles");
            User returnUser = new User();
            if (!string.IsNullOrEmpty(user.Name))
                returnUser.Name = user.Name.Length <= 100 ? user.Name : throw new Exception("User Name needs to be shorter than 100 Character to be created");
            else
                throw new Exception("User Name can't be empty");
            if (!string.IsNullOrEmpty(user.LastName))
                returnUser.LastName = user.LastName.Length <= 100 ? user.LastName : throw new Exception("User Last Name needs to be shorter than 100 Character to be created");
            else
                throw new Exception("User Last Name can't be empty");
            if (!string.IsNullOrEmpty(user.Email))
                returnUser.Email = user.Email.Length <= 100 ? user.Email : throw new Exception("User Email needs to be shorter than 100 Character to be created");
            else
                throw new Exception("User Email can't be empty");
            if (string.IsNullOrEmpty(user.Password))
                throw new Exception("Password can't be empty");
            CreatePasswordHash(user.Password, out byte[] hash, out byte[] salt);
            returnUser.PasswordSalt = salt;
            returnUser.PasswordHash = hash;
            UserRole ur;
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                _context.Users.Add(returnUser);
                _context.SaveChanges();
                foreach (var role in user.Role)
                {

                    ur = new UserRole

                    {
                        RoleID = GetRole(role).RoleID,
                        UserID = returnUser.UserID

                    };
                    _context.UserRoles.Add(ur);
                    _context.SaveChanges();
                }
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception(ex.InnerException.Message);
            }
            CreateUpdateCustomerDGV(new CustomerDGV { UserID=returnUser.UserID});
            CreateUpdateCustomerInvoiceDGV(new CustomerInvoiceDGV { UserID=returnUser.UserID});
            CreateUpdateCustomerInvoiceCostDGV(new CustomerInvoiceCostDGV { UserID=returnUser.UserID});
            CreateUpdateSupplierDGV(new SupplierDGV { UserID=returnUser.UserID});
            CreateUpdateSupplierInvoiceDGV(new SupplierInvoiceDGV { UserID=returnUser.UserID});
            CreateUpdateSupplierInvoiceCostDGV(new SupplierInvoiceCostDGV { UserID=returnUser.UserID});
            CreateUpdateSaleDGV(new SaleDGV { UserID=returnUser.UserID});
            CreateUpdateUserDGV(new UserDGV { UserID=returnUser.UserID});
            return returnUser;

        }
        public CustomerDGV GetCustomerDGV(int userId)
        {
            CustomerDGV? cdgv = _context.CustomerDGV.Where(x => x.UserID == userId).FirstOrDefault();
            if (cdgv == null)
                throw new Exception("Customer DGV not found");
            return cdgv;
        }
        public CustomerDGV CreateUpdateCustomerDGV(CustomerDGV cdgv)
        {
            CustomerDGV cdgvDb = _context.CustomerDGV.Where(x => x.UserID == cdgv.UserID).FirstOrDefault();
            if (cdgvDb == null)
            {
                _context.CustomerDGV.Add(cdgv);
                _context.SaveChanges();
                return cdgv;
            }
            else
            {
                cdgvDb.ShowOriginalID = cdgv.ShowOriginalID==null?false: cdgv.ShowOriginalID;
                cdgvDb.ShowStatus = cdgv.ShowStatus == null ? true :cdgv.ShowStatus;
                cdgvDb.ShowID = cdgv.ShowID == null ? false : cdgv.ShowID;
                cdgvDb.ShowCountry = cdgv.ShowCountry == null ? true : cdgv.ShowCountry;
                cdgvDb.ShowDate = cdgv.ShowDate == null ? true : cdgv.ShowDate;
                cdgvDb.ShowName = cdgv.ShowName == null ? true : cdgv.ShowName;
                _context.CustomerDGV.Update(cdgvDb);
                _context.SaveChanges();
                return cdgvDb;
            }
        }

        public CustomerInvoiceDGV GetCustomerInvoiceDGV(int userId)
        {
            CustomerInvoiceDGV cdgv = _context.CustomerInvoiceDGV.Where(x => x.UserID == userId).FirstOrDefault();
            if (cdgv == null)
                throw new Exception("Customer Invoice DGV not found");
            return cdgv;
        }
        public CustomerInvoiceDGV CreateUpdateCustomerInvoiceDGV(CustomerInvoiceDGV cdgv)
        {
            CustomerInvoiceDGV cdgvDb = _context.CustomerInvoiceDGV.Where(x => x.UserID == cdgv.UserID).FirstOrDefault();
            if (cdgvDb == null)
            {
                _context.CustomerInvoiceDGV.Add(cdgv);
                _context.SaveChanges();
                return cdgv;
            }
            else
            {
                cdgvDb.ShowDate = cdgv.ShowDate == null ? true : cdgv.ShowDate;
                cdgvDb.ShowStatus = cdgv.ShowStatus == null ? true : cdgv.ShowStatus;
                cdgvDb.ShowSaleID= cdgv.ShowSaleID == null ? false : cdgv.ShowSaleID;
                cdgvDb.ShowID = cdgv.ShowID == null ? false : cdgv.ShowID;
                cdgvDb.ShowInvoiceAmount = cdgv.ShowInvoiceAmount == null ? true : cdgv.ShowInvoiceAmount;
                _context.CustomerInvoiceDGV.Update(cdgvDb);
                _context.SaveChanges();
                return cdgvDb;
            }
        }
        public CustomerInvoiceCostDGV GetCustomerInvoiceCostDGV(int userId)
        {
            CustomerInvoiceCostDGV cdgv = _context.CustomerInvoiceCostDGV.Where(x => x.UserID == userId).FirstOrDefault();
            if (cdgv == null)
                throw new Exception("Customer Invoice DGV not found");
            return cdgv;
        }

        public CustomerInvoiceCostDGV CreateUpdateCustomerInvoiceCostDGV(CustomerInvoiceCostDGV cdgv)
        {
            CustomerInvoiceCostDGV cdgvDb = _context.CustomerInvoiceCostDGV.Where(x => x.UserID == cdgv.UserID).FirstOrDefault();
            if (cdgvDb == null)
            {
                _context.CustomerInvoiceCostDGV.Add(cdgv);
                _context.SaveChanges();
                return cdgv;
            }
            else
            {
                cdgvDb.ShowID= cdgv.ShowID == null ? false : cdgv.ShowID;
                cdgvDb.ShowCost= cdgv.ShowCost == null ? true : cdgv.ShowCost;
                cdgvDb.ShowQuantity= cdgv.ShowQuantity == null ? true : cdgv.ShowQuantity;
                cdgvDb.ShowInvoiceID= cdgv.ShowInvoiceID == null ? false : cdgv.ShowInvoiceID;
                cdgvDb.ShowName= cdgv.ShowName == null ? true : cdgv.ShowName;
                _context.CustomerInvoiceCostDGV.Update(cdgvDb);
                _context.SaveChanges();
                return cdgvDb;
            }
        }
        public SupplierDGV GetSupplierDGV(int userId)
        {
            SupplierDGV cdgv = _context.SupplierDGV.Where(x => x.UserID == userId).FirstOrDefault();
            if (cdgv == null)
                throw new Exception("Supplier DGV not found");
            return cdgv;
        }
        public SupplierDGV CreateUpdateSupplierDGV(SupplierDGV cdgv)
        {
            SupplierDGV cdgvDb = _context.SupplierDGV.Where(x => x.UserID == cdgv.UserID).FirstOrDefault();
            if (cdgvDb == null)
            {
                _context.SupplierDGV.Add(cdgv);
                _context.SaveChanges();
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
                _context.SaveChanges();
                return cdgvDb;
            }
        }

        public SupplierInvoiceDGV GetSupplierInvoiceDGV(int userId)
        {
            SupplierInvoiceDGV cdgv = _context.SupplierInvoiceDGV.Where(x => x.UserID == userId).FirstOrDefault();
            if (cdgv == null)
                throw new Exception("Supplier Invoice DGV not found");
            return cdgv;
        }
        public SupplierInvoiceDGV CreateUpdateSupplierInvoiceDGV(SupplierInvoiceDGV cdgv)
        {
            SupplierInvoiceDGV cdgvDb = _context.SupplierInvoiceDGV.Where(x => x.UserID == cdgv.UserID).FirstOrDefault();
            if (cdgvDb == null)
            {
                _context.SupplierInvoiceDGV.Add(cdgv);
                _context.SaveChanges();
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
                cdgvDb.ShowCountry= cdgv.ShowCountry == null ? true : cdgv.ShowCountry;

                _context.SupplierInvoiceDGV.Update(cdgvDb);
                _context.SaveChanges();
                return cdgvDb;
            }
        }
        public SupplierInvoiceCostDGV GetSupplierInvoiceCostDGV(int userId)
        {
            SupplierInvoiceCostDGV cdgv = _context.SupplierInvoiceCostDGV.Where(x => x.UserID == userId).FirstOrDefault();
            if (cdgv == null)
                throw new Exception("Supplier Invoice DGV not found");
            return cdgv;
        }

        public SupplierInvoiceCostDGV CreateUpdateSupplierInvoiceCostDGV(SupplierInvoiceCostDGV cdgv)
        {
            SupplierInvoiceCostDGV cdgvDb = _context.SupplierInvoiceCostDGV.Where(x => x.UserID == cdgv.UserID).FirstOrDefault();
            if (cdgvDb == null)
            {
                _context.SupplierInvoiceCostDGV.Add(cdgv);
                _context.SaveChanges();
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
                _context.SaveChanges();
                return cdgvDb;
            }
        }
        public SaleDGV GetSaleDGV(int userId)
        {
            SaleDGV cdgv = _context.SaleDGV.Where(x => x.UserID == userId).FirstOrDefault();
            if (cdgv == null)
                throw new Exception("Supplier Invoice DGV not found");
            return cdgv;
        }

        public SaleDGV CreateUpdateSaleDGV(SaleDGV cdgv)
        {
            SaleDGV cdgvDb = _context.SaleDGV.Where(x => x.UserID == cdgv.UserID).FirstOrDefault();
            if (cdgvDb == null)
            {
                _context.SaleDGV.Add(cdgv);
                _context.SaveChanges();
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
                _context.SaveChanges();
                return cdgvDb;
            }
        }
        public UserDGV GetUserDGV(int userId)
        {
            UserDGV cdgv = _context.UserDGV.Where(x => x.UserID == userId).FirstOrDefault();
            if (cdgv == null)
                throw new Exception("Supplier Invoice DGV not found");
            return cdgv;
        }

        public UserDGV CreateUpdateUserDGV(UserDGV cdgv)
        {
            UserDGV cdgvDb = _context.UserDGV.Where(x => x.UserID == cdgv.UserID).FirstOrDefault();
            if (cdgvDb == null)
            {
                _context.UserDGV.Add(cdgv);
                _context.SaveChanges();
                return cdgv;
            }
            else
            {
                cdgvDb.ShowID = cdgv.ShowID == null ? false : cdgv.ShowID;
                cdgvDb.ShowRoles = cdgv.ShowRoles == null ? true : cdgv.ShowRoles;
                cdgvDb.ShowLastName = cdgv.ShowLastName == null ? true : cdgv.ShowLastName;
                cdgvDb.ShowEmail=  cdgv.ShowEmail == null ? true : cdgv.ShowEmail;
                cdgvDb.ShowName = cdgv.ShowName == null ? true : cdgv.ShowName;
                _context.UserDGV.Update(cdgvDb);
                _context.SaveChanges();
                return cdgvDb;
            }
        }
        public FavouritePages GetFavouritePages(string name)
        {
            FavouritePages fp=_context.FavouritePages.Where(x => x.Name == name).FirstOrDefault();
            if (fp == null)
                throw new Exception("Page not Found");
            return fp;
        }

        public void CreateFavouritePages(string name)
        {
            FavouritePages fp = _context.FavouritePages.Where(x => x.Name == name).FirstOrDefault();
            if (fp != null)
                throw new Exception("Page already exists");
            _context.FavouritePages.Add(new FavouritePages { Name = name });
            _context.SaveChanges();
        }
        public void AddFavouritePagesToUser(List<string> pageName,int userID)
        {
            FavouritePages fp;
            User user=GetUserByID(userID);
            foreach(string page in pageName)
            {
            fp = GetFavouritePages(page);
            _context.UserFavouritePage.Add(new UserFavouritePage { FavouritePageID=fp.FavouritePageID,UserID=user.UserID });
            }
            _context.SaveChanges();
        }
        public void RemoveFavouritePagesToUser(List<string> pageName, int userID)
        {

        }
    }
}

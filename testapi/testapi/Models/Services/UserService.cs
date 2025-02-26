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
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: cred
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
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
                    _context.SaveChanges();
                }
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
            User user=GetUserByID(id);
            user.Name = !string.IsNullOrEmpty(updateUser.Name)&&updateUser.Name.Length<=100? updateUser.LastName : user.LastName;
            user.LastName = !string.IsNullOrEmpty(updateUser.LastName) && updateUser.LastName.Length <= 100 ? updateUser.LastName : user.LastName;
            user.Email = !string.IsNullOrEmpty(updateUser.Email) && updateUser.Email.Length <= 100 ? updateUser.Email : user.Email;
            if (!string.IsNullOrEmpty(updateUser.Password))
            {
                CreatePasswordHash(updateUser.Password, out byte[] hash, out byte[] salt);
                user.PasswordHash=hash;
                user.PasswordSalt=salt;
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
                .Where(u => u.UserID==id)
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
                .Where(x => x.UserID==id)
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role).FirstOrDefault();
            if (user == null)
                throw new Exception("User not Found");
            List<string> roleList=user.UserRoles.Select(x => x.Role.RoleName).ToList();
            return new UserRoleDTO(user,roleList);
        }
        public ICollection<UserRoleDTO> GetAllUsers(UserFilter filter)
        {
            // Retrieve all sales from the database and map each one to a SaleDTOGet
            return ApplyFilter(filter);
        }

        public int CountUsers(UserFilter filter)
        {
            // Retrieve all sales from the database and map each one to a SaleDTOGet
            return ApplyFilter(filter).Count();
        }

        private ICollection<UserRoleDTO> ApplyFilter(UserFilter filter)
        {
            int itemsPage = 10;
            var query = _context.Users
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role).AsQueryable();

            if (!string.IsNullOrEmpty(filter.Name))
                query = query.Where(s => s.Name.StartsWith(filter.Name));
            if (!string.IsNullOrEmpty(filter.LastName))
                query = query.Where(s => s.LastName.StartsWith(filter.LastName));
            if (!string.IsNullOrEmpty(filter.Email))
                query = query.Where(s => s.Email.StartsWith(filter.Email));
            if (filter.Roles.Count>0)
            {
                foreach (var role in filter.Roles)
                    query = query.Where(x => x.UserRoles.Any(x => x.Role.RoleName.Contains(role)));
            }
            if (filter.page != null)
            {
                query = query.Skip(((int)filter.page - 1) * itemsPage).Take(itemsPage);
            }
            
            List<User> userList = query.ToList();
            List<UserRoleDTO> returnList=new List<UserRoleDTO>();
            List<string> roleList;
            foreach(User user in userList)
            {
                roleList=user.UserRoles.Select(x=>x.Role.RoleName).ToList();
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
                returnUser.Email =user.Email.Length <= 100 ? user.Email : throw new Exception("User Email needs to be shorter than 100 Character to be created");
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

            return returnUser;

        }
    }
}

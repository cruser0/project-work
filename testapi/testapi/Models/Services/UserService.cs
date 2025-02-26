using API.Models.DTO;
using API.Models.Entities;
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
            foreach(string role in user.Role)
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


        public User GetUserByEmail(string email)
        {
            var user = _context.Users
                .Where(u => u.Email.Equals(email))
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .FirstOrDefault();
            foreach(var userRole in user.UserRoles)
            {
                Console.WriteLine(userRole.Role.RoleName);
            }

            return user;
        }
        public UserRoleDTO GetUserByID(int id)
        {
            List<string> data = _context.Users.Where(x => x.UserID==id).SelectMany(x => x.UserRoles.Select(ur => ur.Role.RoleName)).ToList();

            var user = _context.Users.FirstOrDefault(x => x.UserID==id);

            if (data == null || user == null)
                throw new Exception("User not found");

            return new UserRoleDTO(user, data);
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
            User returnUser = new User();
            CreatePasswordHash(user.Password, out byte[] hash, out byte[] salt);
            returnUser.Name = user.Name;
            returnUser.LastName = user.LastName;
            returnUser.Email = user.Email;
            returnUser.PasswordSalt = salt;
            returnUser.PasswordHash = hash;
            UserRole ur;
            using var transaction=_context.Database.BeginTransaction();
            try
            {
            _context.Users.Add(returnUser);
            _context.SaveChanges();
            foreach(var role in user.Role)
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
            }catch(Exception ex) {
                transaction.Rollback();
                throw new Exception(ex.InnerException.Message);
            }

            return returnUser;

        }
    }
}

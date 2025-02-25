using API.Models.DTO;
using API.Models.Entities;
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
        public string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
    {
        new Claim(ClaimTypes.NameIdentifier, user.Email),
        new Claim(ClaimTypes.Role, user.Role)
    };

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
            var data = _context.Users.Where(x => x.Email == email).FirstOrDefault();
            if (data == null)
                throw new Exception("User not found");
            return data;
        }
        public User GetUserByID(int id)
        {
            var data = _context.Users.Where(x => x.UserID == id).FirstOrDefault();
            if (data == null)
                throw new Exception("User not found");
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
            returnUser.Role = "User";
            _context.Users.Add(returnUser);
            _context.SaveChanges();
            return returnUser;
        }
    }
}

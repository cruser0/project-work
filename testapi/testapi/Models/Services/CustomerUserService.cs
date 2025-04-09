using API.Models.Exceptions;
using Entity_Validator.Entity.DTO;
using Entity_Validator.Entity.Entities;
using Entity_Validator.Entity.Filters;
using Entity_Validator.Entity.Procedures;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace API.Models.Services
{
    public interface ICustomerUser
    {
        bool VeryfyPasswordHash(string password, byte[] hash, byte[] salt);
        Task<string> CreateToken(CustomerUserRoleDTO customerUser);
        Task<RefreshToken> GetRefreshTokenByrefTokenString(string refToken);
        Task<RefreshToken> GenerateRefreshToken(int userID,bool isCustomer=true);
        Task<RefreshToken> GetNewerRefreshToken(RefreshTokenDTO refTk);
        Task<List<CustomerUser>> GetCustomerUserByCustomerID(int id);

        Task EditCustomerUser(int id, CustomerUserDTOEdit updateUser);
        Task DeleteCustomerUser(int id);
        Task<string> MassDeleteCustomerUser(List<int> userId);
        Task<CustomerUser> GetCustomerUserByEmail(string email);
        Task<CustomerUser> GetCustomerUserByID(int id);
        Task<CustomerUserRoleDTO> GetCustomerUserRoleDTOByID(int id);
        Task<ICollection<CustomerUserRoleDTO>> GetAllCustomerUsers(CustomerUserFilter filter);
        Task<int> CountCustomerUsers(CustomerUserFilter filter);
        Task<Role> GetRole(string role);
        Task<CustomerUser> CreateCustomerUser(CustomerUserDTOCreate user);
    }
    public class CustomerUserService : ICustomerUser
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        private readonly Progetto_FormativoContext _context;


        public CustomerUserService(IUserService us,IConfiguration c,Progetto_FormativoContext ctx)
        {
            _userService=us;
            _configuration=c;
            _context=ctx;
        }
        public async Task<string> CreateToken(CustomerUserRoleDTO customerUser)
        {
            Customer? customer=await _context.Customers.Where(x => x.CustomerID == customerUser.CustomerID).Include(x=>x.Country).FirstOrDefaultAsync();
            if (customer == null)
                throw new NotFoundException("Customer not Found");
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Role, customerUser.Role));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, customerUser.Email));
            claims.Add(new Claim(ClaimTypes.Name, customer.CustomerName));
            claims.Add(new Claim(ClaimTypes.Country, customer.Country.CountryName));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtConfig:Secret"]));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(int.Parse(_configuration["JwtConfig:AccessTokenExpiration"])),
                signingCredentials: cred
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        public async Task<RefreshToken> GetRefreshTokenByrefTokenString(string refToken)
        {
            return await _userService.GetRefreshTokenByrefTokenString(refToken);
        }

        public async Task<RefreshToken> GenerateRefreshToken(int id, bool isCustomer=true)
        {
            return await _userService.GenerateRefreshToken(id, isCustomer);
        }

        public async Task<RefreshToken> GetNewerRefreshToken(RefreshTokenDTO refTk)
        {
            return await _userService.GetNewerRefreshToken(refTk);
        }

        public async Task DeleteCustomerUser(int id)
        {
            if (!await _context.CustomerUsers.AnyAsync(x => x.CustomerUserID == id))
                throw new NotFoundException("User not Found");
            var user = await _context.CustomerUsers.Where(x => x.CustomerUserID == id).FirstOrDefaultAsync();
            if (user == null)
                throw new NotFoundException("User not found!");
            _context.CustomerUsers.Remove(user);
            await _context.SaveChangesAsync();
            HMailInitializer.RemoveCustomersEmail(user);
        }

        public async Task<string> MassDeleteCustomerUser(List<int> userId)
        {
            int count = 0;
            foreach (int id in userId)
            {
                await DeleteCustomerUser(id);
                count++;
            }
            return $"{count} Users were deleted out of {userId.Count}";
        }


        public async Task<CustomerUser> GetCustomerUserByEmail(string email)
        {
            var user = await _context.CustomerUsers
                .Where(u => u.Email.Equals(email))
                .Include(u => u.Role)
                .FirstOrDefaultAsync();
            if (user == null)
                throw new NotFoundException("User not Found");
            return user;
        }
        public async Task<CustomerUser> GetCustomerUserByID(int id)
        {
            var user = await _context.CustomerUsers
                .Where(u => u.CustomerUserID == id)
                .Include(u => u.Role)
                .FirstOrDefaultAsync();
            if (user == null)
                throw new NotFoundException("User not Found");
            return user;
        }
        public async Task<List<CustomerUser>> GetCustomerUserByCustomerID(int id)
        {
            var user = await _context.CustomerUsers
                .Where(u => u.CustomerID == id)
                .Include(u=>u.Role)
                .ToListAsync();
            if (user == null)
                throw new NotFoundException("Users not Found");
            return user;
        }
        public async Task<CustomerUserRoleDTO> GetCustomerUserRoleDTOByID(int id)
        {
            var customerUser = await _context.CustomerUsers
                .Where(x => x.CustomerUserID == id)
                .Include(u => u.Role).FirstOrDefaultAsync();

            if (customerUser == null)
                throw new NotFoundException("User not Found");
            return new CustomerUserRoleDTO(customerUser);
        }

        public async Task<int> CountCustomerUsers(CustomerUserFilter filter)
        {
            return (await ApplyFilter(filter)).Count;
        }

        private async Task<ICollection<CustomerUserRoleDTO>> ApplyFilter(CustomerUserFilter filter)
        {
            int itemsPage = 10;
            var query = _context.CustomerUsers.AsQueryable();


            if (!string.IsNullOrEmpty(filter.CustomerUserName))
                query = query.Where(s => s.Customer.CustomerName.StartsWith(filter.CustomerName)); 
            if (!string.IsNullOrEmpty(filter.CustomerUserLastName))
                query = query.Where(s => s.Customer.CustomerName.StartsWith(filter.CustomerName));
            if (!string.IsNullOrEmpty(filter.CustomerUserEmail))
                query = query.Where(s => s.Customer.CustomerName.StartsWith(filter.CustomerName));

            query = query
                .Include(u => u.Role).Include(x => x.Customer).ThenInclude(x => x.Country);

            if (!string.IsNullOrEmpty(filter.CustomerName))
                query = query.Where(s => s.Customer.CustomerName.StartsWith(filter.CustomerName));
            if (!string.IsNullOrEmpty(filter.CustomerCountry))
                query = query.Where(s => s.Customer.Country.CountryName.StartsWith(filter.CustomerCountry));

            if (!string.IsNullOrEmpty(filter.CustomerUserRole))
                query = query.Where(s => s.Role.RoleName.Equals(filter.CustomerUserRole));

            if (filter.CustomerUserPage != null)
            {
                query = query.Skip(((int)filter.CustomerUserPage - 1) * itemsPage).Take(itemsPage);
            }

            List<CustomerUser> userList = await query.ToListAsync();
            List<CustomerUserRoleDTO> returnList = new List<CustomerUserRoleDTO>();
            List<string> roleList;
            foreach (CustomerUser user in userList)
            {
                returnList.Add(new CustomerUserRoleDTO(user));
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


        public async Task<CustomerUser> CreateCustomerUser(CustomerUserDTOCreate user)
        {
            if (await _context.CustomerUsers.AnyAsync(x => x.Email.Equals(user.Email)))
                throw new ErrorInputPropertyException("User is already registered");
            if (!user.Role.Any())
                throw new ErrorInputPropertyException("Can't create a User with no Roles");
            CustomerUser returnUser = new CustomerUser();
            returnUser.Name = user.Name;
            returnUser.LastName = user.LastName;
            returnUser.Email = user.Email;
            if (user.CustomerID == null)
                throw new NullPropertyException("Customer cannot be null");
            returnUser.CustomerID = (int)user.CustomerID!;
            returnUser.RoleID = (await _userService.GetRole(user.Role)).RoleID;
            _userService.CreatePasswordHash(user.Password, out byte[] hash, out byte[] salt);
            returnUser.PasswordSalt = salt;
            returnUser.PasswordHash = hash;
            _context.CustomerUsers.Add(returnUser);
            await _context.SaveChangesAsync();
            HMailInitializer.AddCustomersEmail(new List<CustomerUserDTOCreate> { user });
            return returnUser;

        }

        public async Task EditCustomerUser(int id, CustomerUserDTOEdit updateUser)
        {
            CustomerUser user = await GetCustomerUserByID(id);
            user.Name = !string.IsNullOrEmpty(updateUser.Name) ? updateUser.Name : user.Name;
            user.LastName = !string.IsNullOrEmpty(updateUser.LastName) ? updateUser.LastName : user.LastName;
            user.Email = !string.IsNullOrEmpty(updateUser.Email) ? updateUser.Email : user.Email;
            if (!string.IsNullOrEmpty(updateUser.Password))
            {
                _userService.CreatePasswordHash(updateUser.Password, out byte[] hash, out byte[] salt);
                user.PasswordHash = hash;
                user.PasswordSalt = salt;
            }
            _context.CustomerUsers.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<CustomerUserRoleDTO>> GetAllCustomerUsers(CustomerUserFilter filter)
        {
            return await ApplyFilter(filter);
        }
        public bool VeryfyPasswordHash(string password, byte[] hash, byte[] salt)
        {
            using (var hmac = new HMACSHA512(salt))
            {

                var compuuteHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return compuuteHash.SequenceEqual(hash);
            }
        }

    }
}

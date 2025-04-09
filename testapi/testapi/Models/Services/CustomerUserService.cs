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
        string CreateToken(CustomerUserRoleDTO customerUser);
        Task<RefreshToken> GetRefreshTokenByrefTokenString(string refToken);
        Task<RefreshToken> GenerateRefreshToken(int userID,bool isCustomer=true);
        Task<RefreshToken> GetNewerRefreshToken(RefreshTokenDTO refTk);
        Task<List<CustomerUser>> GetCustomerUserByCustomerID(int id);

        Task EditCustomerUser(int id, UserDTOEdit updateUser);
        Task DeleteCustomerUser(int id);
        Task<string> MassDeleteCustomerUser(List<int> userId);
        Task<CustomerUser> GetUserByEmail(string email);
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
        public string CreateToken(CustomerUserRoleDTO customerUser)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Role, customerUser.Role));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, customerUser.Email));

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

        public async Task DeleteCustomerUser(int id)
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

        public async Task<string> MassDeleteCustomerUser(List<int> userId)
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


        public async Task<CustomerUser> GetUserByEmail(string email)
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
        public async Task<ICollection<CustomerUserRoleDTO>> GetAllCustomerUsers(CustomerCustomerUserFilter filter)
        {
            return await ApplyFilter(filter);
        }

        public async Task<int> CountCustomerUsers(CustomerUserFilter filter)
        {
            return (await ApplyFilter(filter)).Count;
        }

        private async Task<ICollection<UserRoleDTO>> ApplyFilter(CustomerUserFilter filter)
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
                
            return returnUser;

        }

        public Task EditCustomerUser(int id, UserDTOEdit updateUser)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<CustomerUserRoleDTO>> GetAllCustomerUsers(CustomerUserFilter filter)
        {
            throw new NotImplementedException();
        }

    }
}

using API.Models.Exceptions;
using API.Models.Services;
using Entity_Validator;
using Entity_Validator.Entity.DTO;
using Entity_Validator.Entity.Entities;
using Entity_Validator.Entity.Procedures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserService _authenticationService;
        private object supplierInvoiceCost;

        public AuthenticationController(UserService auth)
        {
            _authenticationService = auth;
        }



        [HttpPost("register")]
        public async Task<ActionResult<string>> Register(UserDTOCreate request)
        {
            User user = await _authenticationService.CreateUser(request);
            return Ok("User Registered Successfully ");

        }



        [HttpPost("login")]
        public async Task<ActionResult<UserAccessInfoDTO>> Login(UserDTO request)
        {
            request.IsPost = true;
            var result = ValidatorEntity.Validate(supplierInvoiceCost);
            if (result.Any())
            {
                throw new ValidateException(result[0].ToString());
            }
            User user = await _authenticationService.GetUserByEmail(request.Email);
            if (!_authenticationService.VeryfyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
                return Unauthorized("Wrong Password!");
            List<string> roles = new List<string>();
            foreach (var role in user.UserRoles)
            {
                roles.Add(role.Role.RoleName);
            }
            UserRoleDTO userDTO = new UserRoleDTO(user, roles);
            string token = _authenticationService.CreateToken(userDTO);
            var refreshToken = await _authenticationService.GenerateRefreshToken(user.UserID);
            return Ok(new UserAccessInfoDTO(userDTO, token, refreshToken));
        }

        [HttpPost("refresh-token")]
        public async Task<ActionResult<UserAccessInfoDTO>> RefreshToken(string refToken)
        {
            RefreshTokenDTO dbRefToken = new RefreshTokenDTO(await _authenticationService.GetRefreshTokenByrefTokenString(refToken));
            RefreshToken refreshToken = await _authenticationService.GetNewerRefreshToken(dbRefToken);
            if (!refreshToken.Token.Equals(refToken))
                return Unauthorized("Invalid Refresh Token");
            else if (refreshToken.Expires < DateTime.Now)
            {
                return Unauthorized("Outdated Refresh Token");
            }
            UserRoleDTO userDTO = await _authenticationService.GetUserRoleDTOByID(dbRefToken.UserID);
            string token = _authenticationService.CreateToken(userDTO);
            return Ok(new UserAccessInfoDTO(userDTO, token, refreshToken));
        }


        [Authorize(Roles = "Admin,UserAdmin")]
        [HttpPut("user/assign-roles")]
        public async Task<ActionResult<string>> AssignRoles(AssignRoleDTO assignRole)
        {
            request.IsPost = false;
            var result = ValidatorEntity.Validate(supplierInvoiceCost);
            if (result.Any())
            {
                throw new ValidateException(result[0].ToString());
            }
            if (assignRole.UserID != null)
                await _authenticationService.EditRoles(assignRole.UserID, assignRole.Roles);
            return Ok("User Role Updated");
        }



        [Authorize(Roles = "Admin,UserAdmin")]
        [HttpDelete("user/delete-user/{id}")]
        public async Task<ActionResult<string>> DeleteUser(int id)
        {
            await _authenticationService.DeleteUser(id);
            return Ok("User Deleted Successfully");
        }



        [Authorize(Roles = "Admin,UserAdmin")]
        [HttpDelete("user/mass-delete")]
        public async Task<ActionResult<string>> MassDeleteUser([FromQuery] List<int> id)
        {
            var data = await _authenticationService.MassDeleteUser(id);
            return Ok(data);
        }

        [Authorize(Roles = "Admin,UserAdmin")]
        [HttpPut("user/mass-update")]
        public async Task<ActionResult<string>> MassUpdateUser([FromQuery] List<UserDTOGet> newUsers)
        {
            var data = await _authenticationService.MassUpdateUser(newUsers);
            return Ok(data);
        }

        //[Authorize(Roles = "Admin,UserAdmin,UserWrite")]
        [HttpPut("user/edit-user/{id}")]
        public async Task<ActionResult<string>> EditUser(int id, [FromBody] UserDTOEdit updateUser)
        {
            await _authenticationService.EditUser(id, updateUser);
            return Ok("User Updated Successfully");
        }



        [Authorize(Roles = "Admin,UserAdmin,UserRead,UserWrite")]
        [HttpGet("user/get-all-users")]
        public async Task<IActionResult> Get([FromQuery] UserFilter filter)
        {
            var result = await _authenticationService.GetAllUsers(filter);
            if (result.Any())
            {
                return Ok(result);
            }
            else return Ok(new List<UserRoleDTO>());
        }



        [Authorize(Roles = "Admin,UserAdmin,UserRead,UserWrite")]
        [HttpGet("user/count")]
        public async Task<IActionResult> GetCount([FromQuery] UserFilter filter)
        {
            var data = await _authenticationService.CountUsers(filter);
            return Ok(data);
        }



        // [Authorize(Roles = "Admin,UserAdmin,UserRead,UserWrite")]
        [HttpGet("user/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            UserRoleDTO data = await _authenticationService.GetUserRoleDTOByID(id);
            if (data == null)
                throw new NotFoundException("User not found");
            return Ok(data);
        }
    }
}

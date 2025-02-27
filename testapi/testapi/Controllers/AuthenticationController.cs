using API.Models.DTO;
using API.Models.Entities;
using API.Models.Filters;
using API.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace API.Controllers
{
    [Route("api/")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserService _authenticationService;
        public AuthenticationController(UserService auth)
        {
            _authenticationService = auth;
        }



        [HttpPost("register")]
        public async Task<ActionResult<string>> Register(UserDTOCreate request)
        {
            User user;
            try
            {
               user= _authenticationService.CreateUser(request);
            }catch (Exception ex) { return BadRequest(ex.Message); }

            return Ok("User Registered Successfully ");
        }



        [HttpPost("login")]
        public async Task<ActionResult<UserAccessInfoDTO>> Login(UserDTO request)
        {
            User user;
            try
            {
            user=_authenticationService.GetUserByEmail(request.Email);
            }catch (Exception ex) {return BadRequest(ex.Message);}
            if (!_authenticationService.VeryfyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
                return BadRequest("Wrong Password!");
            List<string> roles=new List<string>();
            foreach (var role in user.UserRoles)
            {
                roles.Add(role.Role.RoleName);
            }
            UserRoleDTO userDTO = new UserRoleDTO(user, roles);
            string token=_authenticationService.CreateToken(userDTO);
            return Ok(new UserAccessInfoDTO(userDTO, token));
        }


        [Authorize(Roles = "Admin,UserAdmin")]
        [HttpPut("user/assign-roles")]
        public async Task<ActionResult<string>> AssignRoles(AssignRoleDTO assignRole)
        {
            try
            {
                if(assignRole.UserID!=null)
                    _authenticationService.EditRoles(assignRole.UserID, assignRole.Roles);
            }catch(Exception ex) { return BadRequest(ex.Message); }
            return Ok("User Role Updated");
        }
        [Authorize(Roles = "Admin,UserAdmin")]
        [HttpDelete("user/delete-user/{id}")]
        public async Task<ActionResult<string>> DeleteUser(int id)
        {
            try
            {
                _authenticationService.DeleteUser(id);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
            return Ok("User Deleted Successfully");
        }

        [Authorize(Roles = "Admin,UserAdmin,UserWrite")]
        [HttpPut("user/edit-user/{id}")]
        public async Task<ActionResult<string>> EditUser(int id, [FromBody] UserDTOEdit updateUser)
        {
            try
            {
                _authenticationService.EditUser(id,updateUser);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
            return Ok("User Updated Successfully");
        }
        [Authorize(Roles = "Admin,UserAdmin,UserRead,UserWrite")]

        [HttpGet("user/get-all-users")]
        public IActionResult Get([FromQuery] UserFilter filter)
        {
            try
            {
                var result = _authenticationService.GetAllUsers(filter);
                if (result.Any())
                {
                    return Ok(result);
                }
                else throw new Exception("Users not found");
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [Authorize(Roles = "Admin,UserAdmin,UserRead,UserWrite")]
        [HttpGet("user/count")]
        public IActionResult GetCount([FromQuery] UserFilter filter)
        {
            var data = _authenticationService.CountUsers(filter);
            return Ok(data);
        }
        [Authorize(Roles = "Admin,UserAdmin,UserRead,UserWrite")]
        [HttpGet("user/{id}")]
        public IActionResult Get(int id)
        {
            UserRoleDTO data;
            try
            {
                data = _authenticationService.GetUserRoleDTOByID(id);
                if (data == null)
                    throw new Exception("Customer Invoices not found");
            }
            catch (Exception ae) { return BadRequest(ae.Message); }
            return Ok(data);
        }

    }
}

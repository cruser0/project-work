using API.Models.DTO;
using API.Models.Entities;
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
        //[Authorize(Roles ="Admin")]
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
            return Ok(new UserAccessInfoDTO(user,token));
        }
        
    }
}

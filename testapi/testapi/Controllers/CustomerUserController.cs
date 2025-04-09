
using API.Models.Exceptions;
using API.Models.Services;
using Entity_Validator;
using Entity_Validator.Entity.DTO;
using Entity_Validator.Entity.Entities;
using Entity_Validator.Entity.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/")]
    [ApiController]
    public class CustomerUserController : ControllerBase
    {
            private readonly ICustomerUser _authenticationService;
            public CustomerUserController(ICustomerUser auth)
            {
                _authenticationService = auth;
            }



            [HttpPost("register-web")]
            public async Task<ActionResult<string>> Register(CustomerUserDTOCreate request)
            {
                CustomerUser user = await _authenticationService.CreateCustomerUser(request);
                return Ok("CustomerUser Registered Successfully ");

            }
     
            [HttpPost("login-web")]
            public async Task<ActionResult> LoginWeb(CustomerUserDTO request)
            {
                request.IsPost = true;
                var result = ValidatorEntity.Validate(request);
                if (result.Any())
                {
                    throw new ValidateException(result[0].ToString());
                }

                CustomerUser user = await _authenticationService.GetCustomerUserByEmail(request.Email);
                if (!_authenticationService.VeryfyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
                    return Unauthorized("Wrong Password!");


                CustomerUserRoleDTO userDTO = new CustomerUserRoleDTO(user);
                string accessToken =await _authenticationService.CreateToken(userDTO);
                var refreshToken = await _authenticationService.GenerateRefreshToken(user.CustomerUserID);

                SetAccessTokenCookie(accessToken);
                SetRefreshTokenCookie(refreshToken.Token, (DateTime)refreshToken.Expires!);

                return Ok();
            }
            [Authorize(Roles = "Admin,CustomerUserAdmin")]
            [HttpPost("refresh-token-web")]
            public async Task<ActionResult> RefreshTokenWeb()
            {
                var refToken = Request.Cookies["refreshToken"];
                if (string.IsNullOrEmpty(refToken))
                    return Unauthorized("Missing Refresh Token");

                RefreshTokenDTO dbRefToken = new RefreshTokenDTO(await _authenticationService.GetRefreshTokenByrefTokenString(refToken));
                RefreshToken refreshToken = await _authenticationService.GetNewerRefreshToken(dbRefToken);

                if (!refreshToken.Token.Equals(refToken))
                    return Unauthorized("Invalid Refresh Token");

                if (refreshToken.Expires < DateTime.Now)
                    return Unauthorized("Outdated Refresh Token");

                CustomerUserRoleDTO userDTO = await _authenticationService.GetCustomerUserRoleDTOByID((int)dbRefToken.CustomerUserID!);
                string newAccessToken =await  _authenticationService.CreateToken(userDTO);

                SetAccessTokenCookie(newAccessToken);
                SetRefreshTokenCookie(refreshToken.Token, (DateTime)refreshToken.Expires!);

                return Ok();
            }
            private void SetAccessTokenCookie(string token)
            {
                var cookieOptions = new CookieOptions
                {
                    HttpOnly = false,
                    Expires = DateTime.UtcNow.AddMinutes(15)
                };
                Response.Cookies.Append("accessToken", token, cookieOptions);
            }

            private void SetRefreshTokenCookie(string refreshToken, DateTime expires)
            {
                var cookieOptions = new CookieOptions
                {
                    HttpOnly = false,
                    Expires = expires
                };
                Response.Cookies.Append("refreshToken", refreshToken, cookieOptions);
            }

            [Authorize(Roles = "Admin,CustomerUserAdmin")]
            [HttpDelete("customer-user/delete-customer-user/{id}")]
            public async Task<ActionResult<string>> DeleteCustomerUser(int id)
            {
                await _authenticationService.DeleteCustomerUser(id);
                return Ok("CustomerUser Deleted Successfully");
            }



            [Authorize(Roles = "Admin,CustomerUserAdmin")]
            [HttpDelete("customer-user/mass-delete")]
            public async Task<ActionResult<string>> MassDeleteCustomerUser([FromQuery] List<int> id)
            {
                var data = await _authenticationService.MassDeleteCustomerUser(id);
                return Ok(data);
            }

            //[Authorize(Roles = "Admin,CustomerUserAdmin,CustomerUserWrite")]
            [HttpPut("customer-user/edit-customer-user/{id}")]
            public async Task<ActionResult<string>> EditCustomerUser(int id, [FromBody] CustomerUserDTOEdit updateCustomerUser)
            {
                await _authenticationService.EditCustomerUser(id, updateCustomerUser);
                return Ok("CustomerUser Updated Successfully");
            }



            [Authorize(Roles = "Admin,CustomerUserAdmin,CustomerUserRead,CustomerUserWrite")]
            [HttpGet("customer-user/get-all-customer-users")]
            public async Task<IActionResult> Get([FromQuery] CustomerUserFilter filter)
            {
                var result = await _authenticationService.GetAllCustomerUsers(filter);
                if (result.Any())
                {
                    return Ok(result);
                }
                else return Ok(new List<CustomerUserRoleDTO>());
            }



            [Authorize(Roles = "Admin,CustomerUserAdmin,CustomerUserRead,CustomerUserWrite")]
            [HttpGet("customer-user/count")]
            public async Task<IActionResult> GetCount([FromQuery] CustomerUserFilter filter)
            {
                var data = await _authenticationService.CountCustomerUsers(filter);
                return Ok(data);
            }



            // [Authorize(Roles = "Admin,CustomerUserAdmin,CustomerUserRead,CustomerUserWrite")]
            [HttpGet("customer-user/{id}")]
            public async Task<IActionResult> Get(int id)
            {
                CustomerUserRoleDTO data = await _authenticationService.GetCustomerUserRoleDTOByID(id);
                if (data == null)
                    throw new NotFoundException("CustomerUser not found");
                return Ok(data);
            }
    }
}




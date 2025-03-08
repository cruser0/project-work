﻿using API.Models.DTO;
using API.Models.Entities;
using API.Models.Exceptions;
using API.Models.Filters;
using API.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
                user = await _authenticationService.CreateUser(request);
                return Ok("User Registered Successfully ");
            }
            catch (NotFoundException ex) { return NotFound(ex.Message); }
            catch (ErrorInputPropertyException ex) { return UnprocessableEntity(ex.Message); }
            catch (NullPropertyException ex) { return UnprocessableEntity(ex.Message); }
            catch (NotFoundTokenException ex) { return Unauthorized(ex.Message); }
        }



        [HttpPost("login")]
        public async Task<ActionResult<UserAccessInfoDTO>> Login(UserDTO request)
        {
            User user;
            try
            {
                user = await _authenticationService.GetUserByEmail(request.Email);
            }
            catch (NotFoundException ex) { return NotFound(ex.Message); }
            catch (ErrorInputPropertyException ex) { return UnprocessableEntity(ex.Message); }
            catch (NullPropertyException ex) { return UnprocessableEntity(ex.Message); }
            catch (NotFoundTokenException ex) { return Unauthorized(ex.Message); }

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
            try
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
            catch (NotFoundException ex) { return NotFound(ex.Message); }
            catch (ErrorInputPropertyException ex) { return UnprocessableEntity(ex.Message); }
            catch (NullPropertyException ex) { return UnprocessableEntity(ex.Message); }
            catch (NotFoundTokenException ex) { return Unauthorized(ex.Message); }

        }


        [Authorize(Roles = "Admin,UserAdmin")]
        [HttpPut("user/assign-roles")]
        public async Task<ActionResult<string>> AssignRoles(AssignRoleDTO assignRole)
        {
            try
            {
                if (assignRole.UserID != null)
                    await _authenticationService.EditRoles(assignRole.UserID, assignRole.Roles);
                return Ok("User Role Updated");
            }
            catch (NotFoundException ex) { return NotFound(ex.Message); }
            catch (ErrorInputPropertyException ex) { return UnprocessableEntity(ex.Message); }
            catch (NullPropertyException ex) { return UnprocessableEntity(ex.Message); }
            catch (NotFoundTokenException ex) { return Unauthorized(ex.Message); }
        }



        [Authorize(Roles = "Admin,UserAdmin")]
        [HttpDelete("user/delete-user/{id}")]
        public async Task<ActionResult<string>> DeleteUser(int id)
        {
            try
            {
                await _authenticationService.DeleteUser(id);
                return Ok("User Deleted Successfully");
            }
            catch (NotFoundException ex) { return NotFound(ex.Message); }
            catch (ErrorInputPropertyException ex) { return UnprocessableEntity(ex.Message); }
            catch (NullPropertyException ex) { return UnprocessableEntity(ex.Message); }
            catch (NotFoundTokenException ex) { return Unauthorized(ex.Message); }
        }

        //[Authorize(Roles = "Admin,UserAdmin,UserWrite")]
        [HttpPut("user/edit-user/{id}")]
        public async Task<ActionResult<string>> EditUser(int id, [FromBody] UserDTOEdit updateUser)
        {
            try
            {
                await _authenticationService.EditUser(id, updateUser);
                return Ok("User Updated Successfully");
            }
            catch (NotFoundException ex) { return NotFound(ex.Message); }
            catch (ErrorInputPropertyException ex) { return UnprocessableEntity(ex.Message); }
            catch (NullPropertyException ex) { return UnprocessableEntity(ex.Message); }
            catch (NotFoundTokenException ex) { return Unauthorized(ex.Message); }
        }

        [Authorize(Roles = "Admin,UserAdmin,UserRead,UserWrite")]
        [HttpGet("user/get-all-users")]
        public async Task<IActionResult> Get([FromQuery] UserFilter filter)
        {
            try
            {
                var result = await _authenticationService.GetAllUsers(filter);
                if (result.Any())
                {
                    return Ok(result);
                }
                else throw new NotFoundException("Users not found");
            }
            catch (NotFoundException ex) { return NotFound(ex.Message); }
            catch (ErrorInputPropertyException ex) { return UnprocessableEntity(ex.Message); }
            catch (NullPropertyException ex) { return UnprocessableEntity(ex.Message); }
            catch (NotFoundTokenException ex) { return Unauthorized(ex.Message); }
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
            UserRoleDTO data;
            try
            {
                data = await _authenticationService.GetUserRoleDTOByID(id);
                if (data == null)
                    throw new NotFoundException("User not found");
            }
            catch (NotFoundException ex) { return NotFound(ex.Message); }
            catch (ErrorInputPropertyException ex) { return UnprocessableEntity(ex.Message); }
            catch (NullPropertyException ex) { return UnprocessableEntity(ex.Message); }
            catch (NotFoundTokenException ex) { return Unauthorized(ex.Message); }
            return Ok(data);
        }
    }
}

﻿
using Entity_Validator.Entity.Entities;
using System;
using System.Collections.Generic;

namespace Entity_Validator.Entity.DTO
{
    public class UserAccessInfoDTO
    {
        public UserAccessInfoDTO()
        {

        }
        public UserAccessInfoDTO(UserRoleDTO user, string token, RefreshToken refreshToken)
        {
            Token = token;
            Name = user.Name;
            LastName = user.LastName;
            Email = user.Email;
            Role = user.Role;
            RefreshUserID = (int)refreshToken.UserID;
            RefreshExpires = refreshToken.Expires;
            RefreshCreated = refreshToken.Created;
            RefreshToken = refreshToken.Token;
            RefreshTokenID = refreshToken.TokenID;
        }
        public string Token { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<string> Role { get; set; }
        public int RefreshTokenID { get; set; }
        public int RefreshUserID { get; set; }
        public string RefreshToken { get; set; }
        public DateTime? RefreshCreated { get; set; }
        public DateTime? RefreshExpires { get; set; }
    }
}

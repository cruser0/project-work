using Entity_Validator.CustomAttributes;
using Entity_Validator.Entity.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entity_Validator.Entity.DTO
{ 
        public class CustomerUserDTO
        {
            [RequiredIf("IsPost", true)]
            [RegularExpression("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$", ErrorMessage = "Email is Invalid.")]
            [MaxLength(100, ErrorMessage = "Must be at most {1} characters.")]
            public string Email { get; set; }

            [RequiredIf("IsPost", true)]
            public string Password { get; set; }

            public bool IsPost { get; set; }
        }

        public class CustomerUserDTOEdit : CustomerUserDTO
        {
            public int? CustomerUserID { get; set; }
            public int? CustomerID { get; set; }
            [RequiredIf("IsPost", true)]
            [MaxLength(100, ErrorMessage = "Must be at most {1} characters.")]
            public string Name { get; set; }

            [RequiredIf("IsPost", true)]
            [MaxLength(100, ErrorMessage = "Must be at most {1} characters.")]
            public string LastName { get; set; }
            [RequiredIf("IsPost", true)]
            [MaxLength(100, ErrorMessage = "Must be at most {1} characters.")]
            public string Role { get; set; }
            public CustomerUserDTOEdit(CustomerUser user)
            {
                CustomerUserID = user.CustomerUserID;
                CustomerID = user.CustomerID;
                Email = user.Email;
                Name = user.Name;
                LastName = user.LastName;
                Role = user.Role.RoleName;
                IsPost = false;
            }
        }

        public class CustomerUserDTOCreate : CustomerUserDTOEdit
        {
            public CustomerUserDTOCreate(CustomerUser user):base(user)
            {
                IsPost=true;
            }
        }

        public class CustomerUserDTOGet
        {
            public int? CustomerID { get; set; }
            public int? CustomerUserID { get; set; }
            public string CustomerName { get; set; }
            public string CustomerCountry { get; set; }

            [RequiredIf("IsPost", true)]
            [RegularExpression("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$", ErrorMessage = "Email is Invalid.")]
            [MaxLength(100, ErrorMessage = "Must be at most {1} characters.")]
            public string Email { get; set; }

            [RequiredIf("IsPost", true)]
            [MaxLength(100, ErrorMessage = "Must be at most {1} characters.")]
            public string Name { get; set; }

            [RequiredIf("IsPost", true)]
            [MaxLength(100, ErrorMessage = "Must be at most {1} characters.")]
            public string LastName { get; set; }
        }

        public class CustomerUserRoleDTO : CustomerUserDTOGet
        {
            public CustomerUserRoleDTO()
            {

            }
            public CustomerUserRoleDTO(CustomerUser user)
            {
                CustomerUserID = user.CustomerUserID;
                Email = user.Email;
                Name = user.Name;
                LastName = user.LastName;
                Role = user.Role.RoleName;
            }

            [RequiredIf("IsPost", true)]
            public string Role { get; set; }
        }



}




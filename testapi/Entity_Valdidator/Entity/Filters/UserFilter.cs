using System.Collections.Generic;

namespace Entity_Validator.Entity.Procedures
{
    public class UserFilter
    {

        public string UserName { get; set; }
        public string UserLastName { get; set; }
        public string UserEmail { get; set; }
        public List<string> UserRoles { get; set; } = new List<string>();
        public List<string> UserPreferences { get; set; } = new List<string>();
        public int? UserPage { get; set; }
    }
}

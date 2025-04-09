using System;
using System.Collections.Generic;
using System.Text;

namespace Entity_Validator.Entity.Filters
{
    public class CustomerUserFilter
    {
        public string CustomerUserName { get; set; }
        public string CustomerUserLastName { get; set; }
        public string CustomerName { get; set; }
        public string CustomerCountry { get; set; }
        public string CustomerUserEmail { get; set; }
        public string CustomerUserRole { get; set; }
        public int? CustomerUserPage { get; set; }
    }
}

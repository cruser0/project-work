using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winform.Entities.DTO
{
    internal class SaleCustomerDTO:Sale
    {
        public string? CustomerName { get; set; }
        public string? Country { get; set; }

    }
}

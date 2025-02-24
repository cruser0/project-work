using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winform.Entities.DTO
{
    internal class SupplierInvoiceSupplierDTO:SupplierInvoice
    {
        public string? SupplierName { get; set; }
        public string? Country { get; set; }
    }
}

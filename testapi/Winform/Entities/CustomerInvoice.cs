using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winform.Entities
{
    public class CustomerInvoice
    {

        public int CustomerInvoiceId { get; set; }
        public int? SaleId { get; set; }
        public decimal? InvoiceAmount { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string? Status { get; set; }

    }
}

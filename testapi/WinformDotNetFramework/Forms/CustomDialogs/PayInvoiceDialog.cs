using Entity_Validator.Entity.DTO;
using System;
using System.Windows.Forms;
using WinformDotNetFramework.Services;

namespace WinformDotNetFramework.Forms.CustomDialogs
{
    public partial class PayInvoiceDialog : Form
    {
        CustomerInvoiceAmountPaidService _customerInvoiceAmountPaidService;
        CustomerInvoiceDTOGet invoice;

        public PayInvoiceDialog(CustomerInvoiceDTOGet ci)
        {
            invoice = ci;
            InitializeComponent();
            //BkBtc = invoice.SaleBookingNumber.ToString();
        }

        private void PayBtn_Click(object sender, EventArgs e)
        {

        }

        private void QuitBtn_Click(object sender, EventArgs e)
        {

        }
    }
}

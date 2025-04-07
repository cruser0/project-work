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
            _customerInvoiceAmountPaidService = new CustomerInvoiceAmountPaidService();

            if (!DesignMode)
                Init(ci);
        }

        private async void Init(CustomerInvoiceDTOGet ci)
        {

            var alreadyPaid = await _customerInvoiceAmountPaidService.GetById((int)ci.CustomerInvoiceId);


            invoice = ci;
            InitializeComponent();
            BkBtc.SetPropName("SaleBookingNumber");
            BkBtc.PropTxt.Text = invoice.SaleBookingNumber;

            BolBtc.SetPropName("SaleBoL");
            BolBtc.PropTxt.Text = invoice.SaleBoL;

            InvoiceCodeBtc.SetPropName("CustomerInvoiceCode");
            InvoiceCodeBtc.PropTxt.Text = invoice.CustomerInvoiceCode;

            InvoiceAmountBtc.SetPropName("MaximumAmount");
            InvoiceAmountBtc.PropTxt.Text = invoice.InvoiceAmount.ToString();

            AlreadyPaidBtc.SetPropName("AlreadyPaid");
            AlreadyPaidBtc.PropTxt.Text = alreadyPaid.AmountPaid.ToString();

            AmountToPayBtc.SetPropName("AmountToPay");
            AmountToPayBtc.PropTxt.Text = (invoice.InvoiceAmount - alreadyPaid.AmountPaid).ToString();
        }

        private async void PayBtn_Click(object sender, EventArgs e)
        {
            CustomerInvoiceAmountPaidDTOGet amount = new CustomerInvoiceAmountPaidDTOGet()
            {
                AmountPaid = decimal.Parse(AmountToPayBtc.PropTxt.Text),
                MaximumAmount = invoice.InvoiceAmount,
                CustomerInvoiceID = invoice.CustomerInvoiceId
            };
            try
            {
                var ret = await _customerInvoiceAmountPaidService.PayInvoice((int)invoice.CustomerInvoiceId, amount);
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void QuitBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}

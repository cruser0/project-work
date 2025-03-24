using System;
using System.Linq;
using System.Windows.Forms;
using WinformDotNetFramework.Entities;
using WinformDotNetFramework.Forms.GridForms;
using WinformDotNetFramework.Services;

namespace WinformDotNetFramework.Forms.AddForms
{
    public partial class CreateCustomerInvoiceForm : Form
    {
        CustomerInvoiceService _customerInvoiceService;
        int id;
        public CreateCustomerInvoiceForm()
        {
            _customerInvoiceService = new CustomerInvoiceService();
            InitializeComponent();
        }

        private async void SaveBtn_Click(object sender, EventArgs e)
        {
            CustomerInvoice customerInvoice = new CustomerInvoice()
            {
                SaleId = id,
                InvoiceDate = dateTimePicker1.Value,
                Status = "Unpaid"
            };
            try
            {
                await _customerInvoiceService.Create(customerInvoice);
                MessageBox.Show("Customer Invoice Created Succesfully");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void NameTxt_TextChanged(object sender, EventArgs e)
        {
            SaveBtn.Enabled = CustomerInvoiceBkTxt.TextLength > 0 && CustomerInvoiceBolTxt.TextLength > 0 && dateTimePicker1.Checked;
        }

        private void OpenSale_Click(object sender, EventArgs e)
        {
            UtilityFunctions.OpenFormDetails<SaleGridForm>(sender, e, this);
        }

        public void SetSaleID(string idSale)
        {
            id= int.Parse(idSale);
        }
        public void SetSaleBkBol(string bk,string bol)
        {
            CustomerInvoiceBkTxt.Text = bk;
            CustomerInvoiceBolTxt.Text = bol;
        }
    }
}

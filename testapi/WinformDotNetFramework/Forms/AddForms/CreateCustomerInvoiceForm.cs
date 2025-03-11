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
        MainForm mainForm = Application.OpenForms.OfType<MainForm>().First();
        CustomerInvoiceService _customerInvoiceService;
        public CreateCustomerInvoiceForm()
        {
            _customerInvoiceService = new CustomerInvoiceService();
            InitializeComponent();
            integerTextBoxUserControl1.ValueChanged += NameTxt_TextChanged;
        }

        private async void SaveBtn_Click(object sender, EventArgs e)
        {
            CustomerInvoice customerInvoice = new CustomerInvoice()
            {
                SaleId = int.Parse(integerTextBoxUserControl1.GetText()),
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
            SaveBtn.Enabled = integerTextBoxUserControl1.GetText().Length > 0 && dateTimePicker1.Checked;
        }

        private void OpenSale_Click(object sender, EventArgs e)
        {
            UtilityFunctions.OpenFormDetails<SaleGridForm>(sender, e, this);
        }

        public void SetSaleID(string id)
        {
            integerTextBoxUserControl1.SetText(id);
        }
    }
}

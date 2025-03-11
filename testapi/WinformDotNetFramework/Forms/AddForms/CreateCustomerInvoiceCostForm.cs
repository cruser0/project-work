using System;
using System.Linq;
using System.Windows.Forms;
using WinformDotNetFramework.Entities;
using WinformDotNetFramework.Forms.GridForms;
using WinformDotNetFramework.Services;

namespace WinformDotNetFramework.Forms.AddForms
{
    public partial class CreateCustomerInvoiceCostForm : Form
    {
        MainForm mainForm = Application.OpenForms.OfType<MainForm>().First();
        CustomerInvoiceCostService _customerInvoiceCostService;
        public CreateCustomerInvoiceCostForm()
        {
            _customerInvoiceCostService = new CustomerInvoiceCostService();
            InitializeComponent();
            CustomerInvoiceIdTxt.ValueChanged += NameTxt_TextChanged;
            CostTxt.ValueChanged += NameTxt_TextChanged;
            QuantityTxt.ValueChanged += NameTxt_TextChanged;
        }

        private async void SaveBtn_Click(object sender, EventArgs e)
        {
            CustomerInvoiceCost customerInvoiceCost = new CustomerInvoiceCost()
            {
                CustomerInvoiceId = int.Parse(CustomerInvoiceIdTxt.GetText()),
                Cost = decimal.Parse(CostTxt.GetText()),
                Quantity = int.Parse(QuantityTxt.GetText()),
                Name = NameTxt.Text
            };


            try
            {
                await _customerInvoiceCostService.Create(customerInvoiceCost);
                MessageBox.Show("Customer Invoice Cost Created Succesfully");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void NameTxt_TextChanged(object sender, EventArgs e)
        {
            SaveBtn.Enabled =
                CustomerInvoiceIdTxt.GetText().Length > 0 &&
                CostTxt.GetText().Length > 0 &&
                QuantityTxt.GetText().Length > 0 &&
                NameTxt.Text.Length > 0;
        }

        private void OpenSale_Click(object sender, EventArgs e)
        {
            UtilityFunctions.OpenFormDetails<CustomerInvoiceGridForm>(sender, e, this);
        }

        public void SetCustomerInvoiceID(string id)
        {
            CustomerInvoiceIdTxt.SetText(id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WinformDotNetFramework.Entities;
using WinformDotNetFramework.Entities.Filters;
using WinformDotNetFramework.Forms.GridForms;
using WinformDotNetFramework.Services;

namespace WinformDotNetFramework.Forms.AddForms
{
    public partial class CreateCustomerInvoiceCostForm : Form
    {
        CustomerInvoiceCostService _customerInvoiceCostService;
        CustomerInvoiceService _customerInvoiceService;
        List<string> customerInvoiceCodes;
        private int id = 0;
        List<CostRegistry> list;
        public CreateCustomerInvoiceCostForm()
        {
            _customerInvoiceCostService = new CustomerInvoiceCostService();
            _customerInvoiceService = new CustomerInvoiceService();
            InitializeComponent();
            CostTxt.ValueChanged += NameTxt_TextChanged;
            QuantityTxt.ValueChanged += NameTxt_TextChanged;
            timer.Interval = 500;
        }

        private async void SaveBtn_Click(object sender, EventArgs e)
        {
            CostRegistry cr;
            if (!CostRegistryCmbx.Text.Equals("All"))
                cr = list.Where(x => x.CostRegistryUniqueCode.Equals(CostRegistryCmbx.Text)).FirstOrDefault();
            else
            {
                MessageBox.Show("You need to select a Cost Registry");
                return;
            }
            CustomerInvoiceCost customerInvoiceCost = new CustomerInvoiceCost()
            {
                CustomerInvoiceId = id,

                Cost = string.IsNullOrEmpty(CostTxt.GetText()) ? cr.CostRegistryPrice : decimal.Parse(CostTxt.GetText()),
                Quantity = string.IsNullOrEmpty(QuantityTxt.GetText()) ? cr.CostRegistryQuantity : int.Parse(QuantityTxt.GetText()),
                Name = string.IsNullOrEmpty(NameTxt.Text) ? cr.CostRegistryName : NameTxt.Text,
            };
            if (!string.IsNullOrEmpty(CustomerInvoiceCodeCmbx.Text))
                customerInvoiceCost.CustomerInvoiceCode = CustomerInvoiceCodeCmbx.Text;
            else
            {
                MessageBox.Show("You need to choose a Customer Invoice Code");
                return;
            }
            if (!string.IsNullOrEmpty(CostRegistryCmbx.Text) && !CostRegistryCmbx.Text.Equals("All"))
                customerInvoiceCost.CostRegistryCode = CostRegistryCmbx.Text;
            else
            {
                MessageBox.Show("You need to choose a Customer Invoice Code");
                return;
            }


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
                !string.IsNullOrEmpty(CustomerInvoiceCodeCmbx.Text) && !CustomerInvoiceCodeCmbx.Text.Equals("All");
        }

        private void OpenSale_Click(object sender, EventArgs e)
        {
            UtilityFunctions.OpenFormDetails<CustomerInvoiceGridForm>(sender, e, this);
        }

        public void SetCustomerInvoiceCode(string code)
        {
            CustomerInvoiceCodeCmbx.Text = code;
        }
        public void SetCustomerInvoiceID(string idFromForm)
        {
            id = int.Parse(idFromForm);
        }

        private async void CreateCustomerInvoiceCostForm_Load(object sender, EventArgs e)
        {
            list = await UtilityFunctions.GetCostRegistry();
        }

        private void CustomerInvoiceCodeCmbx_TextChanged(object sender, EventArgs e)
        {
            timer.Start();
            timer.Stop();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();

            CostRegistryCmbx.DataSource = _customerInvoiceService.GetAll(new CustomerInvoiceFilter()
            {
                CustomerInvoiceCode = string.IsNullOrEmpty(CustomerInvoiceCodeCmbx.Text) ? null : CustomerInvoiceCodeCmbx.Text
            });
        }
    }
}

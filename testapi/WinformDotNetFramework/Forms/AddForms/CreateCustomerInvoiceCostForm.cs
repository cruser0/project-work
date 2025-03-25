using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
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
        private int id=0;
        bool isSelecting=false;
        List<CostRegistry> list;
        public CreateCustomerInvoiceCostForm()
        {
            _customerInvoiceCostService = new CustomerInvoiceCostService();
            _customerInvoiceService = new CustomerInvoiceService();
            InitializeComponent();
            timer.Interval = 500;
        }

        private async void SaveBtn_Click(object sender, EventArgs e)
        {
            CostRegistry cr;
            CustomerInvoice listItems1;
            if (!string.IsNullOrEmpty(InvoiceCodeCmbxUC.Cmbx.Text))
            {
                listItems1= (await _customerInvoiceService.GetAll(new CustomerInvoiceFilter() { CustomerInvoiceCode= InvoiceCodeCmbxUC.Cmbx.Text})).FirstOrDefault();
                id = listItems1.CustomerInvoiceId;
            }
            else
            {
                MessageBox.Show("You need to select an Invoice Code");
                return;
            }
            if (!CostRegistryCmbx.Text.Equals("All"))
                cr=list.Where(x=>x.CostRegistryUniqueCode.Equals(CostRegistryCmbx.Text)).FirstOrDefault();
            else
            {
                MessageBox.Show("You need to select a Cost Registry");
                return;
            }
            CustomerInvoiceCost customerInvoiceCost = new CustomerInvoiceCost()
            {
                CustomerInvoiceId = id,
                CostRegistryCode = CostRegistryCmbx.Text,
                CustomerInvoiceCode = InvoiceCodeCmbxUC.Cmbx.Text,
                Cost = string.IsNullOrEmpty(CostTxt.GetText()) ? cr.CostRegistryPrice : decimal.Parse(CostTxt.GetText()),
                Quantity = string.IsNullOrEmpty(QuantityTxt.GetText()) ? cr.CostRegistryQuantity : int.Parse(QuantityTxt.GetText()),
                Name = string.IsNullOrEmpty(NameTxt.Text) ? cr.CostRegistryName : NameTxt.Text,
            };
            if (!string.IsNullOrEmpty(InvoiceCodeCmbxUC.Cmbx.Text))
                customerInvoiceCost.CustomerInvoiceCode = InvoiceCodeCmbxUC.Cmbx.Text;
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

        private void OpenSale_Click(object sender, EventArgs e)
        {
            UtilityFunctions.OpenFormDetails<CustomerInvoiceGridForm>(sender, e, this);
        }

        public void SetCustomerInvoiceCode(string code)
        {
            InvoiceCodeCmbxUC.Cmbx.Text=code;
        }
        public void SetCustomerInvoiceID(string idFromForm)
        {
            id = int.Parse(idFromForm);
        }

        private async void CreateCustomerInvoiceCostForm_Load(object sender, EventArgs e)
        {
            list = await UtilityFunctions.GetCostRegistry();
            CostRegistryCmbx.DataSource=list.Select(x=>x.CostRegistryUniqueCode).ToList();
        }

        public async Task SetList(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                InvoiceCodeCmbxUC.Cmbx.DroppedDown = false;
                return;
            }
            var listFiltered = await _customerInvoiceService.GetAll(new CustomerInvoiceFilter()
            {
                CustomerInvoiceCode = text
            });

            var listItems = listFiltered.Select(x => x.CustomerInvoiceCode).ToList();
            InvoiceCodeCmbxUC.listItemsDropCmbx = listItems;
        }
    }
}

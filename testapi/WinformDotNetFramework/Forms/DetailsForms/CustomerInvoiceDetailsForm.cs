using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinformDotNetFramework.Entities;
using WinformDotNetFramework.Entities.Filters;
using WinformDotNetFramework.Forms.AddForms;
using WinformDotNetFramework.Services;

namespace WinformDotNetFramework.Forms.DetailsForms
{
    public partial class CustomerInvoiceDetailsForm : Form
    {

        CustomerInvoiceService _customerInvoiceService;
        CustomerInvoiceCostService _customerInvoiceCostService;
        CustomerInvoice customerInvoice;
        SaleService _saleService;
        string bol;
        string bk;
        int saleID;
        public CustomerInvoiceDetailsForm(int id)
        {
            Init(id);

        }
        private async void Init(int id)
        {
            InitializeComponent();
            _saleService = new SaleService();
            _customerInvoiceService = new CustomerInvoiceService();
            _customerInvoiceCostService = new CustomerInvoiceCostService();

            customerInvoice = await _customerInvoiceService.GetById(id);

            textBox1.Text = customerInvoice.CustomerInvoiceCode;
            InvoiceAmountTxt.Text = customerInvoice.InvoiceAmount.ToString();

            BKCmbxUC.Cmbx.TextChanged -= BKCmbxUC.Cmbx_TextChanged;
            BoLCmbxUC.Cmbx.TextChanged -= BoLCmbxUC.Cmbx_TextChanged;

            BKCmbxUC.Cmbx.Text = customerInvoice.SaleBookingNumber;
            BoLCmbxUC.Cmbx.Text = customerInvoice.SaleBoL;

            BKCmbxUC.Cmbx.TextChanged += BKCmbxUC.Cmbx_TextChanged;
            BoLCmbxUC.Cmbx.TextChanged += BoLCmbxUC.Cmbx_TextChanged;

            InvoiceDateDTP.Value = (DateTime)customerInvoice.InvoiceDate;
            StatusCB.Text = customerInvoice.Status;

            List<CustomerInvoiceCost> data = (await _customerInvoiceCostService
                .GetAll(new CustomerInvoiceCostFilter() { CustomerInvoiceCostCustomerInvoiceCode = customerInvoice.CustomerInvoiceCode })).ToList();
            dataGridView1.DataSource = data;

            textBox1.Enabled = false;
            InvoiceAmountTxt.Enabled = false;
            StatusCB.Enabled = false;
            BKCmbxUC.Cmbx.Enabled = false;
            BoLCmbxUC.Cmbx.Enabled = false;
            InvoiceDateDTP.Enabled = false;
            button1.Enabled = false;
            List<string> authRolesWrite = new List<string>
            {
                "CustomerInvoiceWrite",
                "CustomerInvoiceAdmin",
                "Admin"
            };
            List<string> authRoles = new List<string>
            {
                "CustomerInvoiceAdmin",
                "Admin"
            };
            if (!Authorize(authRolesWrite))
            {
                checkBox1.Visible = false;
                button1.Visible = false;
            }
        }

        private bool Authorize(List<string> allowedRoles)
        {
            return allowedRoles.Any(role => UserAccessInfo.Role.Contains(role));
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            saleID = (await _saleService.GetAll(new SaleFilter() { SaleBoLnumber = BoLCmbxUC.Cmbx.Text, SaleBookingNumber = BKCmbxUC.Cmbx.Text })).FirstOrDefault().SaleId;

            CustomerInvoice si = new CustomerInvoice
            {
                SaleId = saleID,
                Status = StatusCB.Text,
                InvoiceDate = InvoiceDateDTP.Value,
                InvoiceAmount = 0
            };
            try
            {
                await _customerInvoiceService.Update(customerInvoice.CustomerInvoiceId, si);
                MessageBox.Show("Customer updated successfully!");

                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            InvoiceAmountTxt.Enabled = checkBox1.Checked;
            StatusCB.Enabled = checkBox1.Checked;
            BKCmbxUC.Cmbx.Enabled = checkBox1.Checked;
            BoLCmbxUC.Cmbx.Enabled = checkBox1.Checked;
            InvoiceDateDTP.Enabled = checkBox1.Checked;
        }





        private async void DeleteBtn_Click_1(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
           "This action is permanent and it will delete all the history bound to this Customer Invoice!",
           "Confirm Deletion?",
           MessageBoxButtons.YesNo,
           MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    await _customerInvoiceService.Delete(customerInvoice.CustomerInvoiceId);
                    MessageBox.Show("Customer Invoice has been deleted.");
                    this.Close();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            else
            {
                MessageBox.Show("Action canceled.");
            }
        }

        public async Task SetList()
        {


            // Get the current text values from both comboboxes
            bk = BKCmbxUC.Cmbx.Text;
            bol = BoLCmbxUC.Cmbx.Text;

            // If both comboboxes are empty, clear the suggestions
            if (string.IsNullOrEmpty(bk) && string.IsNullOrEmpty(bol))
            {
                BKCmbxUC.listItemsDropCmbx = new List<string>();
                BoLCmbxUC.listItemsDropCmbx = new List<string>();
                return;
            }

            // Fetch all sales based on the current filter conditions
            var listFiltered = await _saleService.GetAll(new SaleFilter()
            {
                // Only apply filters if at least one combobox has a value
                SaleBookingNumber = !string.IsNullOrEmpty(bk) ? bk : null,
                SaleBoLnumber = !string.IsNullOrEmpty(bol) ? bol : null
            });



            // Filter Booking Number suggestions
            var listItemsBk = listFiltered
                .Where(x => string.IsNullOrEmpty(bol) || x.BoLnumber == bol)
                .Select(x => x.BookingNumber)
                .Distinct()
                .ToList();

            // Filter BoL Number suggestions
            var listItemsBol = listFiltered
                .Where(x => string.IsNullOrEmpty(bk) || x.BookingNumber == bk)
                .Select(x => x.BoLnumber)
                .Distinct()
                .ToList();

            // Update combobox suggestions
            BKCmbxUC.listItemsDropCmbx = listItemsBk;
            BoLCmbxUC.listItemsDropCmbx = listItemsBol;
        }

        private void AddCostBtn_Click(object sender, EventArgs e)
        {
            UtilityFunctions.CreateFromDetails<CreateCustomerInvoiceCostForm>(sender, e, customerInvoice.CustomerInvoiceCode);
        }
    }
}

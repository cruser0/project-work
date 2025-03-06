using Winform.Entities;
using Winform.Services;

namespace Winform.Forms
{
    public partial class CustomerInvoiceDetailsForm : Form
    {

        CustomerInvoiceService _customerInvoiceService;
        public CustomerInvoiceDetailsForm(int id)
        {
            Init(id);

        }
        private async void Init(int id)
        {
            InitializeComponent();

            _customerInvoiceService = new CustomerInvoiceService();
            CustomerInvoice customer = await _customerInvoiceService.GetById(id);

            CustomerInvoiceIdTxt.Text = customer.CustomerInvoiceId.ToString();
            InvoiceAmountTxt.Text = customer.InvoiceAmount.ToString();
            SaleIdTxt.SetText(customer.SaleId.ToString());
            InvoiceDateDTP.Value = (DateTime)customer.InvoiceDate;
            StatusCB.Text = customer.Status;

            CustomerInvoiceIdTxt.Enabled = false;
            InvoiceAmountTxt.Enabled = false;
            StatusCB.Enabled = false;
            SaleIdTxt.Enabled = false;
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
            if (!Authorize(authRoles))
                DeleteBtn.Visible = false;
        }

        private bool Authorize(List<string> allowedRoles)
        {
            return allowedRoles.Any(role => UserAccessInfo.Role.Contains(role));
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            CustomerInvoice si = new CustomerInvoice
            {
                SaleId = int.Parse(SaleIdTxt.GetText()),
                Status = StatusCB.Text,
                InvoiceDate = InvoiceDateDTP.Value,
                InvoiceAmount = 0
            };
            try
            {
                await _customerInvoiceService.Update(int.Parse(CustomerInvoiceIdTxt.Text), si);
                MessageBox.Show("Customer updated successfully!");

                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            StatusCB.Enabled = !StatusCB.Enabled;
            SaleIdTxt.Enabled = !SaleIdTxt.Enabled;
            InvoiceDateDTP.Enabled = !InvoiceDateDTP.Enabled;
            button1.Enabled = !button1.Enabled;
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
                    await _customerInvoiceService.Delete(int.Parse(CustomerInvoiceIdTxt.Text));
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
    }
}

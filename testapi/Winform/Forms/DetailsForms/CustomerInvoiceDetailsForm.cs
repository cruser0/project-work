using Winform.Entities;
using Winform.Services;

namespace Winform.Forms
{
    public partial class CustomerInvoiceDetailsForm : Form
    {

        CustomerInvoiceService _customerInvoiceService;
        public CustomerInvoiceDetailsForm(int id)
        {
            InitializeComponent();

            _customerInvoiceService = new CustomerInvoiceService();
            CustomerInvoice customer = _customerInvoiceService.GetById(id);

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


        }

        private void EditCustomerCbx_CheckedChanged(object sender, EventArgs e)
        {

            StatusCB.Enabled = !StatusCB.Enabled;
            SaleIdTxt.Enabled = !SaleIdTxt.Enabled;
            InvoiceDateDTP.Enabled = !InvoiceDateDTP.Enabled;
            button1.Enabled = !button1.Enabled;

        }

        private void SaveEditCustomerBtn_Click(object sender, EventArgs e)
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
                _customerInvoiceService.Update(int.Parse(CustomerInvoiceIdTxt.Text), si);
                MessageBox.Show("Customer updated successfully!");

                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
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
                    _customerInvoiceService.Delete(int.Parse(CustomerInvoiceIdTxt.Text));
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

using Winform.Entities;
using Winform.Services;

namespace Winform.Forms
{
    public partial class CustomerDetailsForm : Form
    {
        CustomerService _customerService;
        public CustomerDetailsForm(int id)
        {
            InitializeComponent();
            _customerService = new CustomerService();
            Customer customer = _customerService.GetById(id);
            IdCustomerTxt.Text = customer.CustomerId.ToString();
            if (customer.Deprecated != null)
            {
                if ((bool)customer.Deprecated)
                    StatusTxt.Text = "Deprecated";
                else
                    StatusTxt.Text = "Active";
            }
            NameCustomerTxt.Text = customer.CustomerName;
            CountryCustomerTxt.Text = customer.Country;
            IdCustomerTxt.Enabled = false;
            NameCustomerTxt.Enabled = false;
            CountryCustomerTxt.Enabled = false;
            StatusTxt.Enabled = false;
        }

        private void EditCustomerCbx_CheckedChanged(object sender, EventArgs e)
        {
            if (EditCustomerCbx.Checked)
            {
                NameCustomerTxt.Enabled = true;
                CountryCustomerTxt.Enabled = true;
            }
            else
            {
                NameCustomerTxt.Enabled = false;
                CountryCustomerTxt.Enabled = false;
            }
        }

        private void SaveEditCustomerBtn_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer { CustomerName = NameCustomerTxt.Text, Country = CountryCustomerTxt.Text };
            try
            {
                _customerService.Update(int.Parse(IdCustomerTxt.Text), customer);
                MessageBox.Show("Customer updated successfully!");

                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void CountryCustomerLbl_Click(object sender, EventArgs e)
        {

        }
    }
}

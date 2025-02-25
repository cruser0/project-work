using Winform.Entities;
using Winform.Services;

namespace Winform.Forms
{
    public partial class CreateCustomerForm : Form
    {
        CustomerService _customerService;
        public CreateCustomerForm()
        {
            _customerService = new CustomerService();
            InitializeComponent();
        }



        private void SaveBtn_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer()
            {
                CustomerName = NameTxt.Text,
                Country = CountryTxt.Text
            };

            try
            {
                _customerService.Create(customer);
                MessageBox.Show("Customer Created Succesfully");
                Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void NameTxt_TextChanged(object sender, EventArgs e)
        {
            SaveBtn.Enabled = NameTxt.Text.Length > 0 && CountryTxt.Text.Length > 0;
        }
    }
}

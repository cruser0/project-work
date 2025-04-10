using Entity_Validator.Entity.DTO;
using System;
using System.Windows.Forms;
using WinformDotNetFramework.Services;

namespace WinformDotNetFramework.Forms.SelectionForm
{
    public partial class RegisterUserCustomerForm : Form
    {
        CustomerUserService _customerUserService = new CustomerUserService();
        int _customerId;
        public RegisterUserCustomerForm(int customerId, string customerName, string customerCountry)
        {
            _customerId = customerId;

            InitializeComponent();
            CountryNameCtb.SetPropName("Country");
            CountryNameCtb.PropTxt.Text = customerCountry;
            CountryNameCtb.PropTxt.Enabled = false;

            CustomerNameCtb.SetPropName("Customer");
            CustomerNameCtb.PropTxt.Text = customerName;
            CustomerNameCtb.PropTxt.Enabled = false;

            CustomerEmailCtb.SetPropName("Email");
            CustomerLastNameCtb.SetPropName("LastName", "Last Name");
            CustomerPasswordCtb.SetPropName("Password");
            CustomerUserNameCtb.SetPropName("Name", "First Name");
        }

        private async void SaveBtn_Click(object sender, System.EventArgs e)
        {
            CustomerUserDTOCreate customer = new CustomerUserDTOCreate()
            {
                CustomerID = _customerId,
                Email = CustomerEmailCtb.PropTxt.Text,
                Name = CustomerUserNameCtb.PropTxt.Text,
                LastName = CustomerLastNameCtb.PropTxt.Text,
                Password = CustomerPasswordCtb.PropTxt.Text,
                Role = "Admin",
            };
            try
            {
                await _customerUserService.Register(customer);
                MessageBox.Show("Customer user created!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

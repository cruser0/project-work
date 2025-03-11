using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WinformDotNetFramework.Entities;
using WinformDotNetFramework.Services;

namespace WinformDotNetFramework.Forms.AddForms
{
    public partial class CreateCustomerForm : Form
    {
        CustomerService _customerService;
        UserService _userService;
        ICollection<string> prefUserPages;
        public CreateCustomerForm()
        {
            Init();
        }

        private async void Init()
        {
            _userService = new UserService();
            _customerService = new CustomerService();
            InitializeComponent();
            prefUserPages = await _userService.GetAllPreferredPagesUser();
        }

        private async void SaveBtn_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer()
            {
                CustomerName = NameTxt.Text,
                Country = CountryTxt.Text
            };

            try
            {
                await _customerService.Create(customer);
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

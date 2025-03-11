using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WinformDotNetFramework.Entities;
using WinformDotNetFramework.Services;

namespace WinformDotNetFramework.Forms.DetailsForms
{
    public partial class CustomerDetailsForm : Form
    {
        CustomerService _customerService;
        public CustomerDetailsForm(int id)
        {
            Init(id);
        }

        private async void Init(int id)
        {
            InitializeComponent();
            _customerService = new CustomerService();
            Customer customer = await _customerService.GetById(id);
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

            List<string> authRolesWrite = new List<string>
            {
                "CustomerWrite",
                "CustomerAdmin",
                "Admin"
            };
            List<string> authRoles = new List<string>
            {
                "CustomerAdmin",
                "Admin"
            };
            if (!Authorize(authRolesWrite))
            {
                EditCustomerCbx.Visible = false;
                SaveEditCustomerBtn.Visible = false;
            }
            //if (!Authorize(authRoles))
            //    DeleteBtn.Visible = false;
        }

        private bool Authorize(List<string> allowedRoles)
        {
            return allowedRoles.Any(role => UserAccessInfo.Role.Contains(role));
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

        private async void SaveEditCustomerBtn_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer { CustomerName = NameCustomerTxt.Text, Country = CountryCustomerTxt.Text };
            try
            {
                await _customerService.Update(int.Parse(IdCustomerTxt.Text), customer);
                MessageBox.Show("Customer updated successfully!");

                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void CountryCustomerLbl_Click(object sender, EventArgs e)
        {

        }

        private async void DeleteBtn_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
           "This action is permanent and it will delete all the history bound to this Customer!",
           "Confirm Deletion?",
           MessageBoxButtons.YesNo,
           MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    await _customerService.Delete(int.Parse(IdCustomerTxt.Text));
                    MessageBox.Show("Customer has been deleted.");
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

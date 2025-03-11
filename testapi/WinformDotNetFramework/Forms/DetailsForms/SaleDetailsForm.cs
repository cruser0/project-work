using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WinformDotNetFramework.Entities;
using WinformDotNetFramework.Services;

namespace WinformDotNetFramework.Forms.DetailsForms
{
    public partial class SaleDetailsForm : Form
    {
        SaleService _saleService;
        public SaleDetailsForm(int id)
        {
            Init(id);
        }

        private async void Init(int id)
        {
            InitializeComponent();
            _saleService = new SaleService();
            Sale sale = await _saleService.GetById(id);
            SaleIdtxt.Text = id.ToString();
            bntxt.Text = sale.BookingNumber;
            boltxt.Text = sale.BoLnumber;
            saleDateDtp.Value = sale.SaleDate.Value;
            CustomerIdtxt.SetText(sale.CustomerId.ToString());
            RevenueTxt.SetText(sale.TotalRevenue.ToString());
            StatusTxt.Text = sale.Status.ToString();

            SaleIdtxt.Enabled = false;
            bntxt.Enabled = false;
            boltxt.Enabled = false;
            saleDateDtp.Enabled = false;
            CustomerIdtxt.Enabled = false;
            RevenueTxt.Enabled = false;
            StatusTxt.Enabled = false;
            saveBtn.Enabled = false;
            List<string> authRolesWrite = new List<string>
            {
                "SaleWrite",
                "SaleAdmin",
                "Admin"
            };
            List<string> authRoles = new List<string>
            {
                "SaleAdmin",
                "Admin"
            };
            if (!Authorize(authRolesWrite))
            {
                saveBtn.Visible = false;
                EditCB.Visible = false;
            }
            //if (!Authorize(authRoles))
            //    DeleteBtn.Visible = false;
        }

        private bool Authorize(List<string> allowedRoles)
        {
            return allowedRoles.Any(role => UserAccessInfo.Role.Contains(role));
        }

        private void EditCB_CheckedChanged(object sender, EventArgs e)
        {
            bntxt.Enabled = !bntxt.Enabled;
            boltxt.Enabled = !boltxt.Enabled;
            saleDateDtp.Enabled = !saleDateDtp.Enabled;
            CustomerIdtxt.Enabled = !CustomerIdtxt.Enabled;
            StatusTxt.Enabled = !StatusTxt.Enabled;
            saveBtn.Enabled = !saveBtn.Enabled;
        }

        private async void saveBtn_Click(object sender, EventArgs e)
        {
            Sale sale = new Sale
            {
                BookingNumber = bntxt.Text,
                BoLnumber = boltxt.Text,
                SaleDate = saleDateDtp.Value,
                CustomerId = int.Parse(CustomerIdtxt.GetText()),
                Status = StatusTxt.Text
            };
            try
            {
                await _saleService.Update(int.Parse(SaleIdtxt.Text), sale);
                MessageBox.Show("Sale updated successfully!");

                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private async void DeleteBtn_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
          "This action is permanent and it will delete all the history bound to this Sale!",
          "Confirm Deletion?",
          MessageBoxButtons.YesNo,
          MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    await _saleService.Delete(int.Parse(SaleIdtxt.Text));
                    MessageBox.Show("Sale has been deleted.");
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WinformDotNetFramework.Entities;
using WinformDotNetFramework.Services;

namespace WinformDotNetFramework.Forms.DetailsForms
{
    public partial class SupplierInvoiceDetailsForm : Form
    {
        SupplierInvoiceService _supplierInvoiceService;
        public SupplierInvoiceDetailsForm(int id)
        {
            Init(id);
        }

        private async void Init(int id)
        {
            InitializeComponent();
            _supplierInvoiceService = new SupplierInvoiceService();
            SupplierInvoice supplier = await _supplierInvoiceService.GetById(id);

            IdTxt.Text = supplier.InvoiceId.ToString();
            SaleIDTxt1.SetText(supplier.SaleId.ToString());
            SupplierIDTxt1.SetText(supplier.SupplierId.ToString());
            DateClnd.Value = (DateTime)supplier.InvoiceDate;
            StatusCmbx.Text = supplier.Status;

            IdTxt.Enabled = false;
            StatusCmbx.Enabled = false;
            SaleIDTxt1.Enabled = false;
            DateClnd.Enabled = false;
            SupplierIDTxt1.Enabled = false;

            List<string> authRolesWrite = new List<string>
            {
                "SupplierInvoiceWrite",
                "SupplierInvoiceAdmin",
                "Admin"
            };
            List<string> authRoles = new List<string>
            {
                "SupplierInvoiceAdmin",
                "Admin"
            };
            if (!Authorize(authRolesWrite))
            {
                SaveEditCustomerBtn.Visible = false;
                EditCbx.Visible = false;
            }
            if (!Authorize(authRoles))
                DeleteBtn.Visible = false;
        }

        private bool Authorize(List<string> allowedRoles)
        {
            return allowedRoles.Any(role => UserAccessInfo.Role.Contains(role));
        }

        private void EditCustomerCbx_CheckedChanged(object sender, EventArgs e)
        {
            if (EditCbx.Checked)
            {
                StatusCmbx.Enabled = true;
                SaleIDTxt1.Enabled = true;
                DateClnd.Enabled = true;
                SupplierIDTxt1.Enabled = true;
            }
            else
            {
                StatusCmbx.Enabled = false;
                SaleIDTxt1.Enabled = false;
                DateClnd.Enabled = false;
                SupplierIDTxt1.Enabled = false;

            }
        }

        private async void SaveEditCustomerBtn_Click(object sender, EventArgs e)
        {
            SupplierInvoice si = new SupplierInvoice
            {
                SaleId = int.Parse(SaleIDTxt1.GetText()),
                Status = StatusCmbx.Text,
                InvoiceDate = DateClnd.Value,
                SupplierId = int.Parse(SupplierIDTxt1.GetText()),
                InvoiceAmount = 0
            };
            try
            {
                await _supplierInvoiceService.Update(int.Parse(IdTxt.Text), si);
                MessageBox.Show("Customer updated successfully!");

                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private async void DeleteBtn_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
           "This action is permanent and it will delete all the history bound to this Supplier Invoice!",
           "Confirm Deletion?",
           MessageBoxButtons.YesNo,
           MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    await _supplierInvoiceService.Delete(int.Parse(IdTxt.Text));
                    MessageBox.Show("Supplier Invoice has been deleted.");
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

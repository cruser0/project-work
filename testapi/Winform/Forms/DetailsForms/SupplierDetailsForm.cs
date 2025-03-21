﻿using Winform.Entities;
using Winform.Services;

namespace Winform.Forms
{
    public partial class SupplierDetailsForm : Form
    {
        SupplierService _supplierService;
        public SupplierDetailsForm(int id)
        {
            Init(id);
        }

        private async void Init(int id)
        {
            InitializeComponent();
            _supplierService = new SupplierService();
            Supplier supplier = await _supplierService.GetById(id);
            IdSupplierTxt.Text = supplier.SupplierId.ToString();
            NameSupplierTxt.Text = supplier.SupplierName;
            CountrySupplierTxt.Text = supplier.Country;
            IdSupplierTxt.Enabled = false;
            NameSupplierTxt.Enabled = false;
            CountrySupplierTxt.Enabled = false;
            List<string> authRolesWrite = new List<string>
            {
                "SupplierWrite",
                "SupplierAdmin",
                "Admin"
            };
            List<string> authRoles = new List<string>
            {
                "SupplierAdmin",
                "Admin"
            };
            if (!Authorize(authRolesWrite))
            {
                SaveEditSupplierBtn.Visible = false;
                EditSupplierCbx.Visible = false;
            }
            if (!Authorize(authRoles))
                DeleteBtn.Visible = false;
        }

        private bool Authorize(List<string> allowedRoles)
        {
            return allowedRoles.Any(role => UserAccessInfo.Role.Contains(role));
        }

        private void EditSupplierCbx_CheckedChanged(object sender, EventArgs e)
        {
            if (EditSupplierCbx.Checked)
            {
                NameSupplierTxt.Enabled = true;
                CountrySupplierTxt.Enabled = true;
            }
            else
            {
                NameSupplierTxt.Enabled = false;
                CountrySupplierTxt.Enabled = false;
            }
        }

        private async void SaveEditSupplierBtn_Click(object sender, EventArgs e)
        {
            Supplier supplier = new Supplier { SupplierName = NameSupplierTxt.Text, Country = CountrySupplierTxt.Text };
            try
            {
                await _supplierService.Update(int.Parse(IdSupplierTxt.Text), supplier);
                MessageBox.Show("Supplier updated successfully!");

                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void SupplierGetInvoiceBtn_Click(object sender, EventArgs e)
        {
            /*
            // Close all existing MDI child forms
            var mainForm = Application.OpenForms["MainForm"] as MainForm;
            foreach (Control ctrl in mainForm.CenterPanel.Controls)
            {
                if (ctrl is Form existingForm)
                {
                    existingForm.Close();
                    existingForm.Dispose();
                }
            }
            SupplierInvoiceGridForm child = new SupplierInvoiceGridForm(IdSupplierTxt.Text);
            // Set the new form as an MDI child
            mainForm.CenterPanel.Controls.Clear();

            child.TopLevel = false;
            child.FormBorderStyle = FormBorderStyle.None;
            child.Dock = DockStyle.Fill;

            mainForm.CenterPanel.Controls.Add(child);
            child.Show();*/
        }

        private async void DeleteBtn_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
           "This action is permanent and it will delete all the history bound to this Supplier!",
           "Confirm Deletion?",
           MessageBoxButtons.YesNo,
           MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    await _supplierService.Delete(int.Parse(IdSupplierTxt.Text));
                    MessageBox.Show("Supplier has been deleted.");
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

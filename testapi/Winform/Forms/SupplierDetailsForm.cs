using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Winform.Entities;
using Winform.Services;

namespace Winform.Forms
{
    public partial class SupplierDetailsForm : Form
    {
        SupplierService _supplierService;
        public SupplierDetailsForm(int id)
        {
            InitializeComponent();
            _supplierService = new SupplierService();
            Supplier supplier = _supplierService.GetById(id);
            IdSupplierTxt.Text = supplier.SupplierId.ToString();
            NameSupplierTxt.Text = supplier.SupplierName;
            CountrySupplierTxt.Text = supplier.Country;
            IdSupplierTxt.Enabled = false;
            NameSupplierTxt.Enabled = false;
            CountrySupplierTxt.Enabled = false;
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

        private void SaveEditSupplierBtn_Click(object sender, EventArgs e)
        {
           Supplier supplier = new Supplier { SupplierName=NameSupplierTxt.Text,Country=CountrySupplierTxt.Text};
            try
            {
                _supplierService.Update(int.Parse(IdSupplierTxt.Text), supplier);
                MessageBox.Show("Supplier updated successfully!");

                this.Close();
            }catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void SupplierGetInvoiceBtn_Click(object sender, EventArgs e)
        {
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
            SupplierInvoiceForm child = new SupplierInvoiceForm(IdSupplierTxt.Text);
            // Set the new form as an MDI child
            mainForm.CenterPanel.Controls.Clear();

            child.TopLevel = false;
            child.FormBorderStyle = FormBorderStyle.None;
            child.Dock = DockStyle.Fill;

            mainForm.CenterPanel.Controls.Add(child);
            child.Show();
        }
    }
}

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
    public partial class SupplierInvoiceDetailsForm : Form
    {
        SupplierInvoiceService _supplierInvoiceService;
        public SupplierInvoiceDetailsForm(int id)
        {
            InitializeComponent();
            _supplierInvoiceService = new SupplierInvoiceService();
            SupplierInvoice supplier = _supplierInvoiceService.GetById(id);

            IdTxt.Text = supplier.InvoiceId.ToString();
            SaleIDTxt.Text = supplier.SaleId.ToString();
            SupplierIDTxt.Text = supplier.SupplierId.ToString();
            DateClnd.Value =(DateTime)supplier.InvoiceDate;
            StatusCmbx.Text= supplier.Status;

            IdTxt.Enabled = false;
            StatusCmbx.Enabled = false;
            SaleIDTxt.Enabled = false;
            DateClnd.Enabled = false;
            SupplierIDTxt.Enabled=false;
            
        }

        private void EditCustomerCbx_CheckedChanged(object sender, EventArgs e)
        {
            if (EditCbx.Checked)
            {
                StatusCmbx.Enabled = true;
                SaleIDTxt.Enabled = true;
                DateClnd.Enabled = true;
                SupplierIDTxt.Enabled = true;
            }
            else {
                StatusCmbx.Enabled =false;
                SaleIDTxt.Enabled = false;
                DateClnd.Enabled = false;
                SupplierIDTxt.Enabled = false;
            
            }
         }

        private void SaveEditCustomerBtn_Click(object sender, EventArgs e)
        {
            SupplierInvoice si = new SupplierInvoice { SaleId = int.Parse(SaleIDTxt.Text), Status = StatusCmbx.Text, InvoiceDate = DateClnd.Value, SupplierId = int.Parse(SupplierIDTxt.Text), InvoiceAmount = 0 };
            try
            {
                _supplierInvoiceService.Update(int.Parse(IdTxt.Text), si);
                MessageBox.Show("Customer updated successfully!");

                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}

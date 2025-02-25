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

namespace Winform.Forms.AddForms
{
    public partial class CreateSupplierInvoiceCostForm : Form
    {
        SupplierInvoiceCostService _supplierInvoiceCostService;
        public CreateSupplierInvoiceCostForm()
        {
            _supplierInvoiceCostService=new SupplierInvoiceCostService();
            InitializeComponent();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            SupplierInvoiceCost supplierInvoiceCost = new SupplierInvoiceCost
            {
                SupplierInvoiceId = int.Parse(SupplierInvoiceIDIntegerTxt.GetText()),
                Cost = decimal.Parse(CostIntegerTxt.GetText()),
                Quantity = int.Parse(QuantityIntegerTxt.GetText()),
                Name = NameTxt.Text,
            };
            try
            {
                _supplierInvoiceCostService.Create(supplierInvoiceCost);
                MessageBox.Show("Supplier Invoice Cost created successfully!");

                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void OpenSupplierInvoice_Click(object sender, EventArgs e)
        {
            SupplierInvoiceGridForm sgf = new SupplierInvoiceGridForm(this);
            sgf.ShowDialog();
        }
        public void SetSupplierID(string id)
        {
            SupplierInvoiceIDIntegerTxt.SetText(id);
        }

    }
}

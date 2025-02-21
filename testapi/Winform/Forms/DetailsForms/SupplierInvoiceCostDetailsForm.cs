using Winform.Entities;
using Winform.Services;

namespace Winform.Forms
{
    public partial class SupplierInvoiceCostDetailsForm : Form
    {
        SupplierInvoiceCostService _supplierInvoiceCostService;
        public SupplierInvoiceCostDetailsForm(int id)
        {
            InitializeComponent();

            _supplierInvoiceCostService = new SupplierInvoiceCostService();
            SupplierInvoiceCost supplierInvoiceCost = _supplierInvoiceCostService.GetById(id);
            SupplierInvoiceCostIDtxt.Text = id.ToString();
            QuantityTxt.SetText(supplierInvoiceCost.Quantity.ToString());
            CostTxt.SetText(supplierInvoiceCost.Cost.ToString());
            SupplierInvoiceIDtxt.SetText(supplierInvoiceCost.SupplierInvoiceId.ToString());


            SupplierInvoiceCostIDtxt.Enabled = false;
            QuantityTxt.Enabled = false;
            CostTxt.Enabled = false;
            SupplierInvoiceIDtxt.Enabled = false;
            button1.Enabled = false;

        }

        private void EditCB_CheckedChanged(object sender, EventArgs e)
        {
            QuantityTxt.Enabled = !QuantityTxt.Enabled;
            CostTxt.Enabled = !CostTxt.Enabled;
            SupplierInvoiceIDtxt.Enabled = !SupplierInvoiceIDtxt.Enabled;
            button1.Enabled = !button1.Enabled;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            SupplierInvoiceCost supplierInvoiceCost = new SupplierInvoiceCost
            {
                SupplierInvoiceId = int.Parse(SupplierInvoiceIDtxt.GetText()),
                Cost = decimal.Parse(CostTxt.GetText()),
                Quantity = int.Parse(QuantityTxt.GetText())
            };
            try
            {
                _supplierInvoiceCostService.Update(int.Parse(SupplierInvoiceCostIDtxt.Text), supplierInvoiceCost);
                MessageBox.Show("Supplier Invoice Cost updated successfully!");

                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
          "This action is permanent and it will delete all the history bound to this SupplierInvoiceCost!",
          "Confirm Deletion?",
          MessageBoxButtons.YesNo,
          MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    _supplierInvoiceCostService.Delete(int.Parse(SupplierInvoiceCostIDtxt.Text));
                    MessageBox.Show("Supplier Invoice Cost has been deleted.");
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

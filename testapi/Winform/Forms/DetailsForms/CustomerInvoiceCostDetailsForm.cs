using Winform.Entities;
using Winform.Services;

namespace Winform.Forms.DetailsForms
{
    public partial class CustomerInvoiceCostDetailsForm : Form
    {
        CustomerInvoiceCostService _customerInvoiceCostService;
        public CustomerInvoiceCostDetailsForm(int id)
        {
            InitializeComponent();

            _customerInvoiceCostService = new CustomerInvoiceCostService();
            CustomerInvoiceCost customerInvoiceCost = _customerInvoiceCostService.GetById(id);
            CustomerInvoiceCostIDtxt.Text = id.ToString();
            QuantityTxt.SetText(customerInvoiceCost.Quantity.ToString());
            CostTxt.SetText(customerInvoiceCost.Cost.ToString());
            CustomerInvoiceIDtxt.SetText(customerInvoiceCost.CustomerInvoiceId.ToString());


            CustomerInvoiceCostIDtxt.Enabled = false;
            QuantityTxt.Enabled = false;
            CostTxt.Enabled = false;
            CustomerInvoiceIDtxt.Enabled = false;
            button1.Enabled = false;

        }

        private void EditCB_CheckedChanged(object sender, EventArgs e)
        {
            QuantityTxt.Enabled = !QuantityTxt.Enabled;
            CostTxt.Enabled = !CostTxt.Enabled;
            CustomerInvoiceIDtxt.Enabled = !CustomerInvoiceIDtxt.Enabled;
            button1.Enabled = !button1.Enabled;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            CustomerInvoiceCost customerInvoiceCost = new CustomerInvoiceCost
            {
                CustomerInvoiceId = int.Parse(CustomerInvoiceIDtxt.GetText()),
                Cost = decimal.Parse(CostTxt.GetText()),
                Quantity = int.Parse(QuantityTxt.GetText())
            };
            try
            {
                _customerInvoiceCostService.Update(int.Parse(CustomerInvoiceCostIDtxt.Text), customerInvoiceCost);
                MessageBox.Show("Customer Invoice Cost updated successfully!");

                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
          "This action is permanent and it will delete all the history bound to this CustomerInvoiceCost!",
          "Confirm Deletion?",
          MessageBoxButtons.YesNo,
          MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    _customerInvoiceCostService.Delete(int.Parse(CustomerInvoiceCostIDtxt.Text));
                    MessageBox.Show("Customer Invoice Cost has been deleted.");
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

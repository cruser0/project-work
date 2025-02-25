using Winform.Entities;
using Winform.Services;

namespace Winform.Forms.AddForms
{
    public partial class CreateCustomerInvoiceForm : Form
    {
        CustomerInvoiceService _customerInvoiceService;
        public CreateCustomerInvoiceForm()
        {
            _customerInvoiceService = new CustomerInvoiceService();
            InitializeComponent();
            integerTextBoxUserControl1.ValueChanged += NameTxt_TextChanged;
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            CustomerInvoice customerInvoice = new CustomerInvoice()
            {
                SaleId = int.Parse(integerTextBoxUserControl1.GetText()),
                InvoiceDate = dateTimePicker1.Value,
                Status = "Unpaid"
            };
            try
            {
                _customerInvoiceService.Create(customerInvoice);
                MessageBox.Show("Customer Invoice Created Succesfully");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void NameTxt_TextChanged(object sender, EventArgs e)
        {
            SaveBtn.Enabled = integerTextBoxUserControl1.GetText().Length > 0 && dateTimePicker1.Checked;
        }
    }
}

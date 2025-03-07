using Winform.Entities;
using Winform.Services;

namespace Winform.Forms.AddForms
{
    public partial class CreateSupplierInvoiceCostForm : Form
    {
        MainForm mainForm = Application.OpenForms.OfType<MainForm>().First();
        SupplierInvoiceCostService _supplierInvoiceCostService;
        public CreateSupplierInvoiceCostForm()
        {
            _supplierInvoiceCostService = new SupplierInvoiceCostService();
            InitializeComponent();
        }

        private async void SaveBtn_Click(object sender, EventArgs e)
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
                await _supplierInvoiceCostService.Create(supplierInvoiceCost);
                MessageBox.Show("Supplier Invoice Cost created successfully!");

                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void OpenSupplierInvoice_Click(object sender, EventArgs e)
        {
            UtilityFunctions.OpenFormDetails<SupplierInvoiceGridForm>(sender, e, this);

        }

        public void SetSupplierID(string id)
        {
            SupplierInvoiceIDIntegerTxt.SetText(id);
        }

    }
}

using Winform.Entities;
using Winform.Services;

namespace Winform.Forms.AddForms
{
    public partial class CreateSaleForm : Form
    {
        MainForm mainForm = Application.OpenForms.OfType<MainForm>().First();
        SaleService _saleService;
        public CreateSaleForm()
        {
            _saleService = new SaleService();
            InitializeComponent();
        }

        private async void SaveBtn_Click(object sender, EventArgs e)
        {
            Sale sale = new Sale
            {
                BookingNumber = bntxt.Text,
                BoLnumber = boltxt.Text,
                SaleDate = saleDateDtp.Value,
                CustomerId = int.Parse(CustomerIdtxt.GetText()),
                Status = StatusCmbx.Text
            };
            try
            {
                await _saleService.Create(sale);
                MessageBox.Show("Sale Created successfully!");

                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void OpenSale_Click(object sender, EventArgs e)
        {
            UtilityFunctions.OpenFormDetails<CustomerGridForm>(sender, e, this);

        }
        public void SetCustomerID(string id)
        {
            CustomerIdtxt.SetText(id);
        }
    }
}

using Winform.Entities;
using Winform.Services;

namespace Winform.Forms
{
    public partial class SaleDetailsForm : Form
    {
        SaleService _saleService;
        public SaleDetailsForm(int id)
        {
            InitializeComponent();
            _saleService = new SaleService();
            Sale sale = _saleService.GetById(id);
            SaleIdtxt.Text = id.ToString();
            bntxt.Text = sale.BookingNumber;
            boltxt.Text = sale.BoLnumber;
            saleDateDtp.Value = sale.SaleDate.Value;
            CustomerIdtxt.SetText(sale.CustomerId.ToString());
            RevenueTxt.SetText(sale.TotalRevenue.ToString());
            StatusTxt.Text = sale.Status.ToString();

            SaleIdtxt.Enabled = false;
            bntxt.Enabled = false;
            boltxt.Enabled = false;
            saleDateDtp.Enabled = false;
            CustomerIdtxt.Enabled = false;
            RevenueTxt.Enabled = false;
            StatusTxt.Enabled = false;
            saveBtn.Enabled = false;
        }

        private void EditCB_CheckedChanged(object sender, EventArgs e)
        {
            bntxt.Enabled = !bntxt.Enabled;
            boltxt.Enabled = !boltxt.Enabled;
            saleDateDtp.Enabled = !saleDateDtp.Enabled;
            CustomerIdtxt.Enabled = !CustomerIdtxt.Enabled;
            StatusTxt.Enabled = !StatusTxt.Enabled;
            saveBtn.Enabled = !saveBtn.Enabled;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            Sale sale = new Sale
            {
                BookingNumber = bntxt.Text,
                BoLnumber = boltxt.Text,
                SaleDate = saleDateDtp.Value,
                CustomerId = int.Parse(CustomerIdtxt.GetText()),
                Status = StatusTxt.Text
            };
            try
            {
                _saleService.Update(int.Parse(SaleIdtxt.Text), sale);
                MessageBox.Show("Sale updated successfully!");

                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}

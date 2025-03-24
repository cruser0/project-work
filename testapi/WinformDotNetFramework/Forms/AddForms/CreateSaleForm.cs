using System;
using System.Linq;
using System.Windows.Forms;
using WinformDotNetFramework.Entities;
using WinformDotNetFramework.Forms.GridForms;
using WinformDotNetFramework.Services;

namespace WinformDotNetFramework.Forms.AddForms
{
    public partial class CreateSaleForm : Form
    {
        SaleService _saleService;
        int id;
        public CreateSaleForm()
        {
            _saleService = new SaleService();
            InitializeComponent();
        }

        private async void SaveBtn_Click(object sender, EventArgs e)
        {
            if (!saleDateDtp.Checked)
            {
                MessageBox.Show("Select a date");
                return;
            }
            Sale sale = new Sale
            {
                BookingNumber = bntxt.Text,
                BoLnumber = boltxt.Text,
                SaleDate = saleDateDtp.Value,
                CustomerId = id,
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
        private void NameTxt_TextChanged(object sender, EventArgs e)
        {
            SaveBtn.Enabled = boltxt.TextLength > 0 && bntxt.TextLength > 0 && saleDateDtp.Checked && CustomerNameTxt.TextLength>0 && CustomerCountryTxt.TextLength > 0&&!string.IsNullOrEmpty(StatusCmbx.Text);
        }

        private void OpenSale_Click(object sender, EventArgs e)
        {
            UtilityFunctions.OpenFormDetails<CustomerGridForm>(sender, e, this);

        }
        public void SetCustomerID(string idCustomer)
        {
            id= int.Parse(idCustomer);
        }
        public void SetCustomerNameCountry(string name,string country)
        {
            CustomerNameTxt.Text = name;
            CustomerCountryTxt.Text = country;
        }
    }
}

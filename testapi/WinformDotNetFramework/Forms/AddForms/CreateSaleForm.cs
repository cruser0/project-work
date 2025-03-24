using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinformDotNetFramework.Entities;
using WinformDotNetFramework.Entities.Filters;
using WinformDotNetFramework.Forms.GridForms;
using WinformDotNetFramework.Services;

namespace WinformDotNetFramework.Forms.AddForms
{
    public partial class CreateSaleForm : Form
    {
        SaleService _saleService;
        CustomerService _customerService;
        int id;
        public CreateSaleForm()
        {
            _customerService = new CustomerService();
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
            SaveBtn.Enabled = boltxt.TextLength > 0 && bntxt.TextLength > 0 && saleDateDtp.Checked && !string.IsNullOrEmpty(NameCmbxUC.Cmbx.Text) && !string.IsNullOrEmpty(CountryCmbxUC.Cmbx.Text) && !string.IsNullOrEmpty(StatusCmbx.Text);
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
            NameCmbxUC.Cmbx.Text = name;
            CountryCmbxUC.Cmbx.Text = country;
        }
        string cname;
        string ccountry;
        public async Task SetList()
        {
            cname = NameCmbxUC.Cmbx.Text;
            ccountry = CountryCmbxUC.Cmbx.Text;
            var listFiltered = await _customerService.GetAll(new CustomerFilter()
            {
                CustomerName = string.IsNullOrEmpty(cname) ? null : cname,
                CustomerCountry = string.IsNullOrEmpty(ccountry) ? null : ccountry
            });

            var listItemsName = listFiltered.Select(x => x.CustomerName).ToList();
            var listItemsCountry = listFiltered.Select(x => x.Country).ToList();
            NameCmbxUC.listItemsDropCmbx = listItemsName;
            CountryCmbxUC.listItemsDropCmbx = listItemsCountry;
        }
    }
}

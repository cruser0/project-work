using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinformDotNetFramework.Entities;
using WinformDotNetFramework.Entities.Filters;
using WinformDotNetFramework.Forms.GridForms;
using WinformDotNetFramework.Services;

namespace WinformDotNetFramework.Forms.AddForms
{
    public partial class CreateCustomerInvoiceForm : Form
    {
        CustomerInvoiceService _customerInvoiceService;
        SaleService _saleService;
        int id=-1;
        string bol;
        string bk;
        public CreateCustomerInvoiceForm()
        {
            _saleService = new SaleService();
            _customerInvoiceService = new CustomerInvoiceService();
            InitializeComponent();
        }

        private async void SaveBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(BoLCmbxUC.Cmbx.Text) || string.IsNullOrEmpty(BKCmbxUC.Cmbx.Text) || !dateTimePicker1.Checked)
            {
                MessageBox.Show("All the fields must be filled");
                return;
            }
            if(id==-1)
                id=(await _saleService.GetAll(new SaleFilter() { SaleBoLnumber=BoLCmbxUC.Cmbx.Text,SaleBookingNumber = BKCmbxUC.Cmbx.Text })).FirstOrDefault().SaleId;
            CustomerInvoice customerInvoice = new CustomerInvoice()
            {
                SaleId = id,
                InvoiceDate = dateTimePicker1.Value,
                Status = "Unpaid",
                CustomerInvoiceCode = (bk+bol).GetHashCode().ToString(),
            };
            try
            {
                await _customerInvoiceService.Create(customerInvoice);
                MessageBox.Show("Customer Invoice Created Succesfully");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OpenSale_Click(object sender, EventArgs e)
        {
            UtilityFunctions.OpenFormDetails<SaleGridForm>(sender, e, this);
        }

        public void SetSaleID(string idSale)
        {
            id= int.Parse(idSale);
        }
        public void SetSaleBkBol(string bk,string bol)
        {
            BKCmbxUC.Cmbx.Text = bk;
            BoLCmbxUC.Cmbx.Text = bol;
        }

        public async Task SetList()
        {
            bk = BKCmbxUC.Cmbx.Text;
            bol = BoLCmbxUC.Cmbx.Text;
            var listFiltered = await _saleService.GetAll(new SaleFilter()
            {
                SaleBookingNumber = string.IsNullOrEmpty(bk)?null:bk,
                SaleBoLnumber = string.IsNullOrEmpty(bol) ? null : bol
            });

            var listItemsBk = listFiltered.Select(x => x.BookingNumber).ToList();
            var listItemsBol = listFiltered.Select(x => x.BoLnumber).ToList();
            BKCmbxUC.listItemsDropCmbx = listItemsBk;
            BoLCmbxUC.listItemsDropCmbx = listItemsBol;
        }
    }
}

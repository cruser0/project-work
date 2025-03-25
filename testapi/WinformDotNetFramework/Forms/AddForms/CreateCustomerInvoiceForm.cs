using System;
using System.Linq;
using System.Threading.Tasks;

namespace WinformDotNetFramework.Forms.AddForms
{
    public partial class CreateCustomerInvoiceForm : Form
    {
        CustomerInvoiceService _customerInvoiceService;
        SaleService _saleService;
        public int id { get; set; } = -1;
        public string bol { get; set; }
        public string bk { get; set; }
        public CreateCustomerInvoiceForm()
        {
            _saleService = new SaleService();
            _customerInvoiceService = new CustomerInvoiceService();
            InitializeComponent();
        }

        public virtual async void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                await Save();
                Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        public async Task<CustomerInvoice> Save()
        {
            if (string.IsNullOrEmpty(BoLCmbxUC.Cmbx.Text) || string.IsNullOrEmpty(BKCmbxUC.Cmbx.Text) || !dateTimePicker1.Checked)
            {
                MessageBox.Show("All the fields must be filled");
                return null;
            }
            if (id == -1)
                id = (await _saleService.GetAll(new SaleFilter() { SaleBoLnumber = BoLCmbxUC.Cmbx.Text, SaleBookingNumber = BKCmbxUC.Cmbx.Text })).FirstOrDefault().SaleId;
            CustomerInvoice customerInvoice = new CustomerInvoice()
            {
                SaleId = id,
                InvoiceDate = dateTimePicker1.Value,
                Status = "Unpaid",
                CustomerInvoiceCode = Guid.NewGuid().ToString("N").Substring(0, 20),
            };

            await _customerInvoiceService.Create(customerInvoice);
            MessageBox.Show("Customer Invoice Created Succesfully");
            return customerInvoice;

        }
        private void OpenSale_Click(object sender, EventArgs e)
        {
            UtilityFunctions.OpenFormDetails<SaleGridForm>(sender, e, this);
        }

        public void SetSaleID(string idSale)
        {
            id = int.Parse(idSale);
        }
        public void SetSaleBkBol(string bk, string bol)
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
                SaleBookingNumber = string.IsNullOrEmpty(bk) ? null : bk,
                SaleBoLnumber = string.IsNullOrEmpty(bol) ? null : bol
            });

            var listItemsBk = listFiltered.Select(x => x.BookingNumber).ToList();
            var listItemsBol = listFiltered.Select(x => x.BoLnumber).ToList();
            BKCmbxUC.listItemsDropCmbx = listItemsBk;
            BoLCmbxUC.listItemsDropCmbx = listItemsBol;
        }
    }
}

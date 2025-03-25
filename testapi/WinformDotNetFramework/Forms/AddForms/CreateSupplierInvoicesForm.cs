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
    public partial class CreateSupplierInvoicesForm : Form
    {
        SupplierInvoiceService _service;
        SaleService _saleService;
        SupplierService _supplierService;
        int saleId=-1;
        int supplierId=-1;

        public CreateSupplierInvoicesForm()
        {
            _saleService = new SaleService();
            _supplierService = new SupplierService();
            _service = new SupplierInvoiceService();
            InitializeComponent();

        }

        private async void SaveEditCustomerBtn_Click(object sender, EventArgs e)
        {

            List<string> err = new List<string>();
            if (string.IsNullOrEmpty(BKCmbxUC.Cmbx.Text))
                err.Add("BookingNumber");
            if (string.IsNullOrEmpty(BoLCmbxUC.Cmbx.Text))
                err.Add("BookingNumber");
            if (string.IsNullOrEmpty(NameCmbxUC.Cmbx.Text))
                err.Add("SupplierName");
            if (string.IsNullOrEmpty(CountryCmbxUC.Cmbx.Text))
                err.Add("SupplierCountry");
            if (string.IsNullOrEmpty(StatusCmbx.Text))
                err.Add("Status");
            if (DateClnd.Value == null)
                err.Add("Date");
            if (saleId == -1)
            {
                try
                {
                saleId=(await _saleService.GetAll(new SaleFilter() { SaleBoLnumber=BoLCmbxUC.Cmbx.Text,SaleBookingNumber=BKCmbxUC.Cmbx.Text})).FirstOrDefault().SaleId;

                }catch (Exception) { MessageBox.Show("Invalid input for the sale");return; }

            }
            if (supplierId == -1)
            {
                try
                {
                    supplierId = (await _supplierService.GetAll(new SupplierFilter() { SupplierName = NameCmbxUC.Cmbx.Text, SupplierCountry = CountryCmbxUC.Cmbx.Text })).FirstOrDefault().SupplierId;
                }catch (Exception) { MessageBox.Show("Invalid input for the sale"); return; }
            }
            if (err.Count > 0)
                MessageBox.Show("Gli attributi : " + string.Join(",", err) + "\n Sono errati!");
            else
            {
                try
                {
                    SupplierInvoice si = new SupplierInvoice { InvoiceDate = DateClnd.Value, SaleId = saleId, SupplierId = supplierId, Status = StatusCmbx.Text,SupplierInvoiceCode= Guid.NewGuid().ToString("N").Substring(0, 20), };
                    await _service.Create(si);
                    MessageBox.Show("Supplier Invoice created Successfully!");

                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }

        }
        public void SetSupplierID(string id)
        {
            supplierId=int.Parse(id);
        }
        public void SetSaleID(string id)
        {
            saleId = int.Parse(id);
        }
        public void SetSaleBkBol(string bol,string bk)
        {
            BoLCmbxUC.Cmbx.Text = bol;
            BKCmbxUC.Cmbx.Text = bk;
        }
        public void SetSupplierNameCoutnry(string name, string country)
        {
            NameCmbxUC.Cmbx.Text = name;
            CountryCmbxUC.Cmbx.Text = country;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UtilityFunctions.OpenFormDetails<SupplierGridForm>(sender, e, this);
        }
        private void OpenSale_Click(object sender, EventArgs e)
        {
            UtilityFunctions.OpenFormDetails<SaleGridForm>(sender, e, this);
        }
        string sname;
        string scountry;
        string sbol;
        string sbk;

        public async Task SetList()
        {
            sname = NameCmbxUC.Cmbx.Text;
            scountry = CountryCmbxUC.Cmbx.Text;
            sbol = BoLCmbxUC.Cmbx.Text;
            sbk = BKCmbxUC.Cmbx.Text;
            var listFilteredSupplier = await _supplierService.GetAll(new SupplierFilter()
            {
                SupplierName = string.IsNullOrEmpty(sname) ? null : sname,
                SupplierCountry = string.IsNullOrEmpty(scountry) ? null : scountry
            });
            var listFilteredSale = await _saleService.GetAll(new SaleFilter()
            {
                SaleBoLnumber = string.IsNullOrEmpty(sbol) ? null : sbol,
                SaleBookingNumber = string.IsNullOrEmpty(sbk) ? null : sbk
            });
            NameCmbxUC.listItemsDropCmbx = listFilteredSupplier.Select(x => x.SupplierName).ToList();
            CountryCmbxUC.listItemsDropCmbx = listFilteredSupplier.Select(x => x.Country).ToList();
            BoLCmbxUC.listItemsDropCmbx=listFilteredSale.Select(x=>x.BoLnumber).ToList();
            BKCmbxUC.listItemsDropCmbx=listFilteredSale.Select(x=>x.BookingNumber).ToList();
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinformDotNetFramework.Entities;
using WinformDotNetFramework.Entities.DTO;
using WinformDotNetFramework.Entities.Filters;
using WinformDotNetFramework.Services;

namespace WinformDotNetFramework.Forms.DetailsForms
{
    public partial class SaleDetailsForm : Form
    {
        SaleService _saleService;
        CustomerInvoiceService _customerInvoiceService;
        CustomerService _customerService;
        SupplierInvoiceService _supplierInvoiceService;

        SaleCustomerDTO sale;

        public SaleDetailsForm(int id)
        {
            Init(id);
        }

        private async void Init(int id)
        {
            InitializeComponent();
            _saleService = new SaleService();
            _customerInvoiceService = new CustomerInvoiceService();
            _supplierInvoiceService = new SupplierInvoiceService();
            _customerService = new CustomerService();
            sale = await _saleService.GetById(id);

            List<CustomerInvoice> ci = (await _customerInvoiceService
                .GetAll(new CustomerInvoiceFilter()
                {
                    CustomerInvoiceSaleID = id

                })).ToList();
            CuInDgv.DataSource = ci;

            List<SupplierInvoiceSupplierDTO> si = (await _supplierInvoiceService
                .GetAll(new SupplierInvoiceFilter()
                {
                    SupplierInvoiceSaleID = id
                })).ToList();
            SuInDgv.DataSource = si;

            NameCmbxUC.Cmbx.TextChanged -= NameCmbxUC.Cmbx_TextChanged;
            CountryCmbxUC.Cmbx.TextChanged -= CountryCmbxUC.Cmbx_TextChanged;

            NameCmbxUC.Cmbx.Text = sale.CustomerName;
            CountryCmbxUC.Cmbx.Text = sale.Country;

            NameCmbxUC.Cmbx.TextChanged += NameCmbxUC.Cmbx_TextChanged;
            CountryCmbxUC.Cmbx.TextChanged += CountryCmbxUC.Cmbx_TextChanged;

            bntxt.Text = sale.BookingNumber;
            boltxt.Text = sale.BoLnumber;
            saleDateDtp.Value = sale.SaleDate.Value;
            RevenueTxt.SetText(sale.TotalRevenue.ToString());
            StatusCmbx.Text = sale.Status.ToString();

            NameCmbxUC.Cmbx.Enabled = false;
            CountryCmbxUC.Cmbx.Enabled = false;
            bntxt.Enabled = false;
            boltxt.Enabled = false;
            saleDateDtp.Enabled = false;
            RevenueTxt.Enabled = false;
            StatusCmbx.Enabled = false;

            saveBtn.Enabled = false;
            List<string> authRolesWrite = new List<string>
            {
                "SaleWrite",
                "SaleAdmin",
                "Admin"
            };
            List<string> authRoles = new List<string>
            {
                "SaleAdmin",
                "Admin"
            };
            if (!Authorize(authRolesWrite))
            {
                saveBtn.Visible = false;
                EditCB.Visible = false;
            }

        }

        private bool Authorize(List<string> allowedRoles)
        {
            return allowedRoles.Any(role => UserAccessInfo.Role.Contains(role));
        }

        private void EditCB_CheckedChanged(object sender, EventArgs e)
        {
            NameCmbxUC.Cmbx.Enabled = EditCB.Checked;
            CountryCmbxUC.Cmbx.Enabled = EditCB.Checked;
            bntxt.Enabled = EditCB.Checked;
            boltxt.Enabled = EditCB.Checked;
            saleDateDtp.Enabled = EditCB.Checked;
            RevenueTxt.Enabled = EditCB.Checked;
            StatusCmbx.Enabled = EditCB.Checked;
            saveBtn.Enabled = EditCB.Checked;
        }

        private async void saveBtn_Click(object sender, EventArgs e)
        {
            int customerId = (await _customerService.GetAll(new CustomerFilter()
            {
                CustomerName = NameCmbxUC.Cmbx.Text,
                CustomerCountry = CountryCmbxUC.Cmbx.Text
            })).FirstOrDefault().CustomerId;

            Sale sale = new Sale
            {
                BookingNumber = bntxt.Text,
                BoLnumber = boltxt.Text,
                SaleDate = saleDateDtp.Value,
                CustomerId = customerId,
                Status = StatusCmbx.Text
            };
            try
            {
                await _saleService.Update(sale.SaleId, sale);
                MessageBox.Show("Sale updated successfully!");

                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
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

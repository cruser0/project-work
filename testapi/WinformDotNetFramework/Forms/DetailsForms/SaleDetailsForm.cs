using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinformDotNetFramework.Entities;
using WinformDotNetFramework.Entities.DTO;
using WinformDotNetFramework.Entities.Filters;
using WinformDotNetFramework.Forms.AddForms;
using WinformDotNetFramework.Forms.GridForms;
using WinformDotNetFramework.Services;

namespace WinformDotNetFramework.Forms.DetailsForms
{
    public partial class SaleDetailsForm : Form
    {
        SaleService _saleService;
        CustomerInvoiceService _customerInvoiceService;
        CustomerService _customerService;
        SupplierInvoiceService _supplierInvoiceService;
        int id = -1;

        SaleCustomerDTO sale;
        bool detailsOnly=false;
        public SaleDetailsForm()
        {
            Init(null);
        }
        public SaleDetailsForm(int id)
        {
            Init(id);
        }

        private async void Init(int? id)
        {
            _saleService = new SaleService();
            _customerInvoiceService = new CustomerInvoiceService();
            _supplierInvoiceService = new SupplierInvoiceService();
            _customerService = new CustomerService();
            InitializeComponent();
            if (id != null)
            {
                detailsOnly = true;
                int intId=(int)id;
                sale = await _saleService.GetById(intId);
                List<CustomerInvoice> ci = (await _customerInvoiceService
                    .GetAll(new CustomerInvoiceFilter()
                    {
                        CustomerInvoiceSaleID = intId

                    })).ToList();
                CuInDgv.DataSource = ci;

                List<SupplierInvoiceSupplierDTO> si = (await _supplierInvoiceService
                    .GetAll(new SupplierInvoiceFilter()
                    {
                        SupplierInvoiceSaleID = intId
                    })).ToList();
                SuInDgv.DataSource = si;
                UtilityFunctions.SetDropdownText(NameCmbxUC, sale.CustomerName);
                UtilityFunctions.SetDropdownText(CountryCmbxUC, sale.Country);
                bntxt.Text = sale.BookingNumber;
                boltxt.Text = sale.BoLnumber;
                saleDateDtp.Value = sale.SaleDate.Value;
                RevenueTxt.SetText(sale.TotalRevenue.ToString());
                StatusCmbx.Text = sale.Status.ToString();
            }
            else
            {
                detailsOnly=false;
                SetVisibility();
            }

            SetEnable();



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
        private void SetVisibility()
        {
            EditCB.Visible = detailsOnly;
            label6.Visible = detailsOnly;
            RevenueTxt.Visible = detailsOnly;
            button1.Visible = detailsOnly;
            button2.Visible = detailsOnly;
        }
        private void SetEnable()
        {
            saveBtn.Enabled = !detailsOnly;
            NameCmbxUC.Cmbx.Enabled = !detailsOnly;
            CountryCmbxUC.Cmbx.Enabled = !detailsOnly;
            bntxt.Enabled = !detailsOnly;
            boltxt.Enabled = !detailsOnly;
            saleDateDtp.Enabled = !detailsOnly;
            RevenueTxt.Enabled = !detailsOnly;
            StatusCmbx.Enabled = !detailsOnly;
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
            if (boltxt.TextLength <1 || bntxt.TextLength < 1 || !saleDateDtp.Checked || string.IsNullOrEmpty(NameCmbxUC.Cmbx.Text) || string.IsNullOrEmpty(CountryCmbxUC.Cmbx.Text) || string.IsNullOrEmpty(StatusCmbx.Text))
            {
                MessageBox.Show("Every field must be filled");
                return;
            }
            if (detailsOnly)
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
            else
            {
                try
                {
                    if (!saleDateDtp.Checked)
                    {
                        MessageBox.Show("Select a date");
                        return;
                    }
                    if (id == -1)
                    {
                        var customer = (await _customerService.GetAll(new CustomerFilter() { CustomerName = NameCmbxUC.Cmbx.Text, CustomerCountry = CountryCmbxUC.Cmbx.Text })).FirstOrDefault();
                        id = customer.CustomerId;
                    }
                    Sale sale1 = new Sale
                    {
                        BookingNumber = bntxt.Text,
                        BoLnumber = boltxt.Text,
                        SaleDate = saleDateDtp.Value,
                        CustomerId = id,
                        Status = StatusCmbx.Text
                    };
                    Sale saleReturn=await _saleService.Create(sale1);
                    MessageBox.Show("Sale Created successfully!");
                    sale = (await _saleService.GetAll(new SaleFilter() { SaleBoLnumber = boltxt.Text, SaleBookingNumber = bntxt.Text })).FirstOrDefault();
                    detailsOnly = true;
                    SetVisibility();
                    RevenueTxt.Text = saleReturn.TotalRevenue.ToString();
                    RevenueTxt.Enabled = false;
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }
        private void OpenSale_Click(object sender, EventArgs e)
        {
            UtilityFunctions.OpenFormDetails<CustomerGridForm>(sender, e, this);

        }
        public void SetCustomerID(string idCustomer)
        {
            id = int.Parse(idCustomer);
        }
        public void SetCustomerNameCountry(string name, string country)
        {
            UtilityFunctions.SetDropdownText(NameCmbxUC, name);
            UtilityFunctions.SetDropdownText(CountryCmbxUC, country);
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

        private void CustomerInvoiceBtn_click(object sender, EventArgs e)
        {
            UtilityFunctions.CreateFromDetails<CustomerInvoiceDetailsForm>(sender, e, this, sale);
        }
        private void SupplierInvoiceBtn_click(object sender, EventArgs e)
        {
            UtilityFunctions.CreateFromDetails<SupplierInvoiceDetailsForm>(sender, e, this, sale);

        }
        public async Task RefreshDgvCustomer()
        {
            List<CustomerInvoice> data = (await _customerInvoiceService
               .GetAll(new CustomerInvoiceFilter()
               {CustomerInvoiceSaleBoL = sale.BoLnumber,CustomerInvoiceSaleBk=sale.BookingNumber }))
               .ToList();
            CuInDgv.DataSource = data;
        }
        public async Task RefreshDgvSupplier()
        {
            List<SupplierInvoiceSupplierDTO> data = (await _supplierInvoiceService
               .GetAll(new SupplierInvoiceFilter()
               { SupplierInvoiceSaleBoL = sale.BoLnumber, SupplierInvoiceSaleBk = sale.BookingNumber }))
               .ToList();
            SuInDgv.DataSource = data;
        }
    }
}

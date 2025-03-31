using Entity_Validator.Entity.DTO;
using Entity_Validator.Entity.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinformDotNetFramework.Forms.GridForms;
using WinformDotNetFramework.Services;

namespace WinformDotNetFramework.Forms.DetailsForms
{
    public partial class CreateDetailsSaleForm : Form
    {
        SaleService _saleService;
        CustomerInvoiceService _customerInvoiceService;
        CustomerService _customerService;
        SupplierInvoiceService _supplierInvoiceService;
        int _id = -1;
        int _saleId;

        SaleCustomerDTO sale;
        bool detailsOnly = false;
        public CreateDetailsSaleForm()
        {
            Init(null);
        }
        public CreateDetailsSaleForm(int id)
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
                _saleId = (int)id;
                detailsOnly = true;
                int intId = (int)id;
                sale = await _saleService.GetById(intId);
                List<CustomerInvoiceDTOGet> ci = (await _customerInvoiceService
                    .GetAll(new CustomerInvoiceFilter()
                    {
                        CustomerInvoiceSaleID = intId

                    })).ToList();
                CuInDgv.DataSource = ci;

                List<SupplierInvoiceSupplierDTO> si = (await _supplierInvoiceService
                    .GetAll(new SupplierInvoiceSupplierFilter()
                    {
                        SupplierInvoiceSaleID = intId
                    })).ToList();
                SuInDgv.DataSource = si;
                UtilityFunctions.SetDropdownText(NameCmbxUC, sale.CustomerName + $" - {sale.Country}");
                bntxt.Text = sale.BookingNumber;
                boltxt.Text = sale.BoLnumber;
                saleDateDtp.Value = sale.SaleDate.Value;
                RevenueTxt.SetText(sale.TotalRevenue.ToString());
                StatusCmbx.Text = sale.Status.ToString();
            }
            else
            {
                detailsOnly = false;
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
            bntxt.Enabled = EditCB.Checked;
            boltxt.Enabled = EditCB.Checked;
            saleDateDtp.Enabled = EditCB.Checked;
            RevenueTxt.Enabled = EditCB.Checked;
            StatusCmbx.Enabled = EditCB.Checked;
            saveBtn.Enabled = EditCB.Checked;
        }


        private void OpenSale_Click(object sender, EventArgs e)
        {
            UtilityFunctions.OpenFormDetails<CustomerGridForm>(sender, e, this);

        }
        public void SetCustomerID(string idCustomer)
        {
            _id = int.Parse(idCustomer);
        }
        public void SetCustomerNameCountry(string name, string country)
        {
            UtilityFunctions.SetDropdownText(NameCmbxUC, name + $" - {country}");
        }
        string cname;
        public async Task SetList()
        {
            cname = NameCmbxUC.Cmbx.Text;
            var CustomerListFiltered = await _customerService.GetAllCountryName(cname);
            NameCmbxUC.listItemsDropCmbx = CustomerListFiltered.ToList();

        }

        private void CustomerInvoiceBtn_click(object sender, EventArgs e)
        {
            UtilityFunctions.CreateFromDetails<CreateDetailsCustomerInvoiceForm>(sender, e, this, sale);
        }
        private void SupplierInvoiceBtn_click(object sender, EventArgs e)
        {
            UtilityFunctions.CreateFromDetails<CreateDetailsSupplierInvoiceForm>(sender, e, this, sale);

        }
        public async Task RefreshDgvCustomer()
        {
            List<CustomerInvoiceDTOGet> data = (await _customerInvoiceService
               .GetAll(new CustomerInvoiceFilter()
               { CustomerInvoiceSaleBoL = sale.BoLnumber, CustomerInvoiceSaleBk = sale.BookingNumber }))
               .ToList();
            CuInDgv.DataSource = data;
        }
        public async Task RefreshDgvSupplier()
        {
            List<SupplierInvoiceSupplierDTO> data = (await _supplierInvoiceService
               .GetAll(new SupplierInvoiceSupplierFilter()
               { SupplierInvoiceSaleBoL = sale.BoLnumber, SupplierInvoiceSaleBk = sale.BookingNumber }))
               .ToList();
            SuInDgv.DataSource = data;
        }

        private void SuInDgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (sender is DataGridView dgv)
            {
                if (e.RowIndex == -1)
                    return;

                SupplierInvoiceDTOGet supplierInvoice = (SupplierInvoiceDTOGet)dgv.CurrentRow.DataBoundItem;

                UtilityFunctions.OpenFormDetails<CreateDetailsSupplierInvoiceForm>(sender, e, (int)supplierInvoice.InvoiceId);

            }
        }

        private void CuInDgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (sender is DataGridView dgv)
            {
                if (e.RowIndex == -1)
                    return;
                CustomerInvoiceDTOGet customerInvoice = (CustomerInvoiceDTOGet)dgv.CurrentRow.DataBoundItem;

                UtilityFunctions.OpenFormDetails<CreateDetailsCustomerInvoiceForm>(sender, e, customerInvoice.CustomerInvoiceId);

            }
        }

        private async Task UpdateClick(bool quit = false)
        {
            string name = NameCmbxUC.Cmbx.Text;
            string country = "";

            int lastIndex = name.LastIndexOf(" - ");

            if (lastIndex != -1 && lastIndex != name.Length - 3)
            {
                country = name.Substring(lastIndex + 3);

                name = name.Substring(0, lastIndex);
            }


            int customerId = (await _customerService.GetAll(new CustomerFilter()
            {
                CustomerName = name,
                CustomerCountry = country
            })).FirstOrDefault().CustomerId;

            SaleDTOGet sale = new SaleDTOGet
            {
                BookingNumber = bntxt.Text,
                BoLnumber = boltxt.Text,
                SaleDate = saleDateDtp.Value,
                CustomerId = customerId,
                Status = StatusCmbx.Text
            };
            try
            {
                await _saleService.Update(_saleId, sale);
                MessageBox.Show("Sale updated successfully!");
                if (quit) Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private async Task CreateClick(bool quit = false)
        {
            try
            {
                if (!saleDateDtp.Checked)
                {
                    MessageBox.Show("Select a date");
                    return;
                }
                if (_id == -1)
                {
                    string name = NameCmbxUC.Cmbx.Text;
                    string country = "";

                    int lastIndex = name.LastIndexOf(" - ");

                    if (lastIndex != -1 && lastIndex != name.Length - 3)
                    {
                        country = name.Substring(lastIndex + 3);

                        name = name.Substring(0, lastIndex);
                    }


                    int customerId = (await _customerService.GetAll(new CustomerFilter()
                    {
                        CustomerName = name,
                        CustomerCountry = country
                    })).FirstOrDefault().CustomerId;

                    _id = customerId;
                }
                SaleDTOGet sale1 = new SaleDTOGet
                {
                    BookingNumber = bntxt.Text,
                    BoLnumber = boltxt.Text,
                    SaleDate = saleDateDtp.Value,
                    CustomerId = _id,
                    Status = StatusCmbx.Text
                };
                SaleDTOGet saleReturn = await _saleService.Create(sale1);
                _saleId = saleReturn.SaleId;
                MessageBox.Show("Sale Created successfully!");
                if (quit) Close();

                sale = (await _saleService.GetAll(new SaleFilter() { SaleBoLnumber = boltxt.Text, SaleBookingNumber = bntxt.Text })).FirstOrDefault();
                detailsOnly = true;
                SetVisibility();
                RevenueTxt.Text = saleReturn.TotalRevenue.ToString();
                RevenueTxt.Enabled = false;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private async void saveBtn_Click(object sender, EventArgs e)
        {
            if (boltxt.TextLength < 1 || bntxt.TextLength < 1 ||
                !saleDateDtp.Checked || string.IsNullOrEmpty(NameCmbxUC.Cmbx.Text) ||
                string.IsNullOrEmpty(StatusCmbx.Text))
            {
                MessageBox.Show("Every field must be filled");
                return;
            }
            if (detailsOnly)
            {
                await UpdateClick();
            }
            else
            {
                await CreateClick();
            }
        }

        private async void SaveQuitButton_Click(object sender, EventArgs e)
        {
            if (boltxt.TextLength < 1 || bntxt.TextLength < 1 ||
                !saleDateDtp.Checked || string.IsNullOrEmpty(NameCmbxUC.Cmbx.Text) ||
                string.IsNullOrEmpty(StatusCmbx.Text))
            {
                MessageBox.Show("Every field must be filled");
                return;
            }
            if (detailsOnly)
            {
                await UpdateClick(true);
            }
            else
            {
                await CreateClick(true);
            }
        }
    }
}

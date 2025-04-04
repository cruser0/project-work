using Entity_Validator;
using Entity_Validator.Entity.DTO;
using Entity_Validator.Entity.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinformDotNetFramework.Forms.GridForms;
using WinformDotNetFramework.Forms.SelectionForm;
using WinformDotNetFramework.Services;

namespace WinformDotNetFramework.Forms.DetailsForms
{
    public partial class CreateDetailsSaleForm : Form
    {
        SaleService _saleService;
        CustomerInvoiceService _customerInvoiceService;
        CustomerService _customerService;
        SupplierInvoiceService _supplierInvoiceService;
        CustomerInvoiceAmountPaidService _customerInvoiceAmountPaidService;
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
            _customerInvoiceAmountPaidService = new CustomerInvoiceAmountPaidService();
            _customerService = new CustomerService();
            InitializeComponent();
            StatusCmbx.SelectedIndex = 0;
            NameCmbxUC.Cmbx.SetTiltes("Customer");

            BkCtb.SetPropName("BookingNumber");
            BolCtb.SetPropName("BoLnumber");
            RevenueCtb.SetPropName("TotalRevenue");


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
                BkCtb.PropTxt.Text = sale.BookingNumber;
                BolCtb.PropTxt.Text = sale.BoLnumber;
                saleDateDtp.Value = sale.SaleDate.Value;
                RevenueCtb.PropTxt.Text = sale.TotalRevenue.ToString();
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
            RevenueCtb.Visible = detailsOnly;
            button1.Visible = detailsOnly;
            button2.Visible = detailsOnly;
        }
        private void SetEnable()
        {
            saveBtn.Enabled = !detailsOnly;
            NameCmbxUC.Cmbx.Enabled = !detailsOnly;
            BkCtb.PropTxt.Enabled = !detailsOnly;
            BolCtb.PropTxt.Enabled = !detailsOnly;
            saleDateDtp.Enabled = !detailsOnly;
            RevenueCtb.PropTxt.Enabled = !detailsOnly;
            StatusCmbx.Enabled = !detailsOnly;
        }
        private bool Authorize(List<string> allowedRoles)
        {
            return allowedRoles.Any(role => UserAccessInfo.Role.Contains(role));
        }

        private void EditCB_CheckedChanged(object sender, EventArgs e)
        {
            NameCmbxUC.Cmbx.Enabled = EditCB.Checked;
            BkCtb.PropTxt.Enabled = EditCB.Checked;
            BolCtb.PropTxt.Enabled = EditCB.Checked;
            saleDateDtp.Enabled = EditCB.Checked;
            RevenueCtb.PropTxt.Enabled = EditCB.Checked;
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
            cname = NameCmbxUC.Cmbx.PropTxt.Text;
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

                UtilityFunctions.OpenFormDetails<CreateDetailsSupplierInvoiceForm>(sender, e, (int)supplierInvoice.SupplierInvoiceId);

            }
        }

        private void CuInDgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (sender is DataGridView dgv)
            {
                if (e.RowIndex == -1)
                    return;
                CustomerInvoiceDTOGet customerInvoice = (CustomerInvoiceDTOGet)dgv.CurrentRow.DataBoundItem;

                UtilityFunctions.OpenFormDetails<CreateDetailsCustomerInvoiceForm>(sender, e, (int)customerInvoice.CustomerInvoiceId);

            }
        }

        private async Task UpdateClick(bool quit = false)
        {
            NameCmbxUC.Cmbx.SetBorderColorBlack();
            bool exit = false;
            string name = NameCmbxUC.Cmbx.PropTxt.Text;
            string country = "";

            int lastIndex = name.LastIndexOf(" - ");

            if (lastIndex != -1 && lastIndex != name.Length - 3)
            {
                country = name.Substring(lastIndex + 3);

                name = name.Substring(0, lastIndex);
            }
            int customerId = -1;
            try
            {
                if (string.IsNullOrEmpty(country) || string.IsNullOrEmpty(name))
                    throw new Exception();
                customerId = (int)(await _customerService.GetAll(new CustomerFilter()
                {
                    CustomerName = name,
                    CustomerCountry = country
                })).FirstOrDefault().CustomerId;
            }
            catch (Exception) { NameCmbxUC.Cmbx.SetBorderColorRed("Customer not found."); exit = false; }

            DateTime? selectedDate = saleDateDtp.Checked ? (DateTime?)saleDateDtp.Value : null;

            SaleDTOGet sale = new SaleDTOGet
            {
                BookingNumber = BkCtb.PropTxt.Text,
                BoLnumber = BolCtb.PropTxt.Text,
                SaleDate = selectedDate,
                CustomerId = customerId,
                Status = StatusCmbx.Text
            };

            sale.IsPost = false;
            var result = ValidatorEntity.Validate(sale);
            if (result.Any())
            {
                UtilityFunctions.ValidateTextBoxes(panel6, sale);
                return;
            }
            if (exit)
                return;
            await _saleService.Update(_saleId, sale);
            MessageBox.Show("Sale updated successfully!");
            if (quit) Close();
        }

        private async Task CreateClick(bool quit = false)
        {
            NameCmbxUC.Cmbx.SetBorderColorBlack();
            bool exit = false;

            if (!saleDateDtp.Checked)
            {
                MessageBox.Show("Select a date");
                return;
            }
            string name = NameCmbxUC.Cmbx.PropTxt.Text;
            string country = "";

            int lastIndex = name.LastIndexOf(" - ");

            if (lastIndex != -1 && lastIndex != name.Length - 3)
            {
                country = name.Substring(lastIndex + 3);

                name = name.Substring(0, lastIndex);
            }
            int customerId = -1;
            try
            {
                if (string.IsNullOrEmpty(country) || string.IsNullOrEmpty(name))
                    throw new Exception();
                customerId = (int)(await _customerService.GetAll(new CustomerFilter()
                {
                    CustomerName = name,
                    CustomerCountry = country
                })).FirstOrDefault().CustomerId;
            }
            catch (Exception) { NameCmbxUC.Cmbx.SetBorderColorRed("Customer not found."); exit = false; }

            _id = customerId;

            DateTime? selectedDate = saleDateDtp.Checked ? (DateTime?)saleDateDtp.Value : null;

            SaleDTOGet sale1 = new SaleDTOGet
            {
                BookingNumber = BkCtb.PropTxt.Text,
                BoLnumber = BolCtb.PropTxt.Text,
                SaleDate = selectedDate,
                CustomerId = _id,
                Status = StatusCmbx.Text
            };

            sale1.IsPost = true;
            var result = ValidatorEntity.Validate(sale1);
            if (result.Any())
            {
                UtilityFunctions.ValidateTextBoxes(panel6, sale1);
                return;
            }

            if (exit)
                return;
            SaleDTOGet saleReturn = await _saleService.Create(sale1);
            _saleId = (int)saleReturn.SaleId;
            MessageBox.Show("Sale Created successfully!");
            if (quit) Close();

            sale = (await _saleService.GetAll(new SaleCustomerFilter() { SaleBoLnumber = BolCtb.PropTxt.Text, SaleBookingNumber = BkCtb.PropTxt.Text })).FirstOrDefault();
            detailsOnly = true;
            SetVisibility();
            RevenueCtb.PropTxt.Text = saleReturn.TotalRevenue.ToString();
            RevenueCtb.PropTxt.Enabled = false;

        }

        private async void saveBtn_Click(object sender, EventArgs e)
        {
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

            if (detailsOnly)
            {
                await UpdateClick(true);
            }
            else
            {
                await CreateClick(true);
            }
        }

        private void convertSupplierInvoicesBtn_Click(object sender, EventArgs e)
        {
            UtilityFunctions.OpenFormDetails<SelectSupplierInvoicesForm>(sender, e, sale);
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            List<CustomerInvoiceDTOGet> ci = (await _customerInvoiceService
                                .GetAll(new CustomerInvoiceFilter()
                                {
                                    CustomerInvoiceSaleID = _saleId

                                })).ToList();
            CuInDgv.DataSource = ci;

            List<SupplierInvoiceSupplierDTO> si = (await _supplierInvoiceService
                .GetAll(new SupplierInvoiceSupplierFilter()
                {
                    SupplierInvoiceSaleID = _saleId
                })).ToList();
            SuInDgv.DataSource = si;
        }

        private async void CuInDgv_DataSourceChanged(object sender, EventArgs e)
        {
            CustomerInvoiceAmountPaidFilter filter = new CustomerInvoiceAmountPaidFilter()
            {
                PaidCustomerSaleID = _saleId
            };

            decimal amountPaid = (decimal)(await _customerInvoiceAmountPaidService
                .GetAllSale(filter)).Select(x => x.AmountPaid).Sum();

            PaidLabel.Text = $"{amountPaid}€/{sale.TotalRevenue}€";
        }
    }
}

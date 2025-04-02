using Entity_Validator;
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
    public partial class CreateDetailsSupplierInvoiceForm : Form
    {
        SupplierInvoiceService _supplierInvoiceService;
        SupplierInvoiceCostService _supplierInvoiceCostService;
        SaleService _saleService;
        SupplierService _supplierService;
        SupplierInvoiceSupplierDTO supplierInvoice;
        int saleId = -1;
        int supplierId = -1;

        string bkString;
        string bolString;
        bool detailsOnly = false;
        Form _father;

        public CreateDetailsSupplierInvoiceForm()
        {
            Init(null);
        }
        public CreateDetailsSupplierInvoiceForm(CreateDetailsSaleForm father, object sale)
        {
            SaleCustomerDTO saleCustomerDTO = (SaleCustomerDTO)sale;
            _father = father;
            Init(null);
            UtilityFunctions.SetDropdownText(BoLCmbxUC, saleCustomerDTO.BoLnumber);
            UtilityFunctions.SetDropdownText(BKCmbxUC, saleCustomerDTO.BookingNumber);
            BKCmbxUC.Enabled = false;
            BoLCmbxUC.Enabled = false;
            OpenSale.Enabled = false;
            FlushCreateBtn.Visible = true;

        }
        public CreateDetailsSupplierInvoiceForm(int id)
        {
            Init(id);
        }

        private async void Init(int? id)
        {
            InitializeComponent();
            BKCmbxUC.Cmbx.SetTiltes("Booking Number");
            BoLCmbxUC.Cmbx.SetTiltes("Bill of Lading");
            NameCmbxUC.Cmbx.SetTiltes("Supplier");

            _saleService = new SaleService();
            _supplierService = new SupplierService();
            _supplierInvoiceService = new SupplierInvoiceService();
            _supplierInvoiceCostService = new SupplierInvoiceCostService();
            comboBox1.SelectedIndex = 1;
            if (id != null)
            {
                detailsOnly = true;
                int idInt = (int)id;
                supplierInvoice = await _supplierInvoiceService.GetById(idInt);

                if (supplierInvoice.Status == "Approved")
                    dataGridView1.CellDoubleClick -= dataGridView1_CellDoubleClick;

                InvoiceCodeCtb.PropTxt.Text = supplierInvoice.SupplierInvoiceCode;

                UtilityFunctions.SetDropdownText(BKCmbxUC, supplierInvoice.SaleBookingNumber);
                UtilityFunctions.SetDropdownText(BoLCmbxUC, supplierInvoice.SaleBoL);
                UtilityFunctions.SetDropdownText(NameCmbxUC, supplierInvoice.SupplierName + $" - {supplierInvoice.Country}");

                comboBox1.Text = supplierInvoice.Status;
                DateClnd.Value = (DateTime)supplierInvoice.InvoiceDate;
                List<SupplierInvoiceCostDTOGet> data = (await _supplierInvoiceCostService
                    .GetAll(new SupplierInvoiceCostFilter()
                    { SupplierInvoiceCostSupplierInvoiceCode = supplierInvoice.SupplierInvoiceCode }))
                    .ToList();
                dataGridView1.DataSource = data;
                InvoiceCodeCtb.PropTxt.Enabled = false;
                BKCmbxUC.Cmbx.Enabled = false;
                BoLCmbxUC.Cmbx.Enabled = false;
                NameCmbxUC.Cmbx.Enabled = false;
                comboBox1.Enabled = false;
                DateClnd.Enabled = false;
            }
            else
                detailsOnly = false;

            SetVisibility();
            SetEnableForTxt();
            List<string> authRolesWrite = new List<string>
            {
                "SupplierInvoiceWrite",
                "SupplierInvoiceAdmin",
                "Admin"
            };
            List<string> authRoles = new List<string>
            {
                "SupplierInvoiceAdmin",
                "Admin"
            };
            if (!Authorize(authRolesWrite))
            {
                SaveEditCustomerBtn.Visible = false;
                EditCbx.Visible = false;
            }
        }
        private void SetVisibility()
        {
            button1.Visible = detailsOnly;
            InvoiceCodeCtb.PropLbl.Visible = detailsOnly;
            EditCbx.Visible = detailsOnly;
            InvoiceCodeCtb.PropTxt.Visible = detailsOnly;

        }
        private void SetEnableForTxt()
        {
            InvoiceCodeCtb.PropTxt.Enabled = !detailsOnly;
            BKCmbxUC.Cmbx.Enabled = !detailsOnly;
            BoLCmbxUC.Cmbx.Enabled = !detailsOnly;
            NameCmbxUC.Cmbx.Enabled = !detailsOnly;
            comboBox1.Enabled = !detailsOnly;
            DateClnd.Enabled = !detailsOnly;
        }
        public async Task RefreshDGV()
        {
            List<SupplierInvoiceCostDTOGet> data = (await _supplierInvoiceCostService
                .GetAll(new SupplierInvoiceCostFilter()
                { SupplierInvoiceCostSupplierInvoiceCode = supplierInvoice.SupplierInvoiceCode }))
                .ToList();
            dataGridView1.DataSource = data;
        }
        public void SetSupplierID(string id)
        {
            supplierId = int.Parse(id);
        }
        public void SetSaleID(string id)
        {
            saleId = int.Parse(id);
        }
        public void SetSaleBkBol(string bol, string bk)
        {
            BoLCmbxUC.Cmbx.PropTxt.Text = bol;
            BKCmbxUC.Cmbx.PropTxt.Text = bk;
        }
        public void SetSupplierNameCountry(string name, string country)
        {
            NameCmbxUC.Cmbx.PropTxt.Text = name + $" - {country}";
        }
        private void SupplierFillBtn_Click(object sender, EventArgs e)
        {
            UtilityFunctions.OpenFormDetails<SupplierGridForm>(sender, e, this);
        }
        private void SaleFillBtn_Click(object sender, EventArgs e)
        {
            UtilityFunctions.OpenFormDetails<SaleGridForm>(sender, e, this);
        }
        private bool Authorize(List<string> allowedRoles)
        {
            return allowedRoles.Any(role => UserAccessInfo.Role.Contains(role));
        }

        private void EditCustomerCbx_CheckedChanged(object sender, EventArgs e)
        {
            NameCmbxUC.Enabled = EditCbx.Checked;
            comboBox1.Enabled = EditCbx.Checked;
            DateClnd.Enabled = EditCbx.Checked;
            button2.Enabled = EditCbx.Checked;
            if (_father == null)
            {
                BKCmbxUC.Enabled = EditCbx.Checked;
                BoLCmbxUC.Enabled = EditCbx.Checked;
                OpenSale.Enabled = EditCbx.Checked;
            }


            if (!EditCbx.Checked)
            {
                UtilityFunctions.SetDropdownText(BKCmbxUC, supplierInvoice.SaleBookingNumber);
                UtilityFunctions.SetDropdownText(BoLCmbxUC, supplierInvoice.SaleBoL);
                UtilityFunctions.SetDropdownText(NameCmbxUC, supplierInvoice.SupplierName + $" - {supplierInvoice.Country}");
                comboBox1.Text = supplierInvoice.Status;
                DateClnd.Value = (DateTime)supplierInvoice.InvoiceDate;
            }
        }

        public async Task SetList()
        {
            string nameInput = NameCmbxUC.Cmbx.PropTxt.Text;


            bkString = BKCmbxUC.Cmbx.PropTxt.Text;
            bolString = BoLCmbxUC.Cmbx.PropTxt.Text;
            if (string.IsNullOrEmpty(bkString) && string.IsNullOrEmpty(bolString) &&
                string.IsNullOrEmpty(nameInput))
            {
                BKCmbxUC.listItemsDropCmbx = new List<string>();
                BoLCmbxUC.listItemsDropCmbx = new List<string>();
                NameCmbxUC.listItemsDropCmbx = new List<string>();
                return;
            }

            var SaleListFiltered = await _saleService.GetAll(new SaleCustomerFilter()
            {
                SaleBookingNumber = !string.IsNullOrEmpty(bkString) ? bkString : null,
                SaleBoLnumber = !string.IsNullOrEmpty(bolString) ? bolString : null,
                SaleStatus = "Active"
            });

            var SupplierListFiltered = await _supplierService.GetAllCountryName(nameInput);

            var listItemsBk = SaleListFiltered
                .Where(x => string.IsNullOrEmpty(bolString) || x.BoLnumber == bolString)
                .Select(x => x.BookingNumber)
                .Distinct()
                .ToList();

            var listItemsBol = SaleListFiltered
                .Where(x => string.IsNullOrEmpty(bkString) || x.BookingNumber == bkString)
                .Select(x => x.BoLnumber)
                .Distinct()
                .ToList();


            BKCmbxUC.listItemsDropCmbx = listItemsBk;
            BoLCmbxUC.listItemsDropCmbx = listItemsBol;
            NameCmbxUC.listItemsDropCmbx = SupplierListFiltered.ToList();
        }


        private void AddCostBtn_Click(object sender, EventArgs e)
        {
            UtilityFunctions.CreateFromDetails<CreateDetailsSupplierInvoiceCostForm>(sender, e, this, supplierInvoice.SupplierInvoiceCode);
        }

        private void FlushCreateBtn_Click(object sender, EventArgs e)
        {
            detailsOnly = false;
            SetVisibility();
            SetEnableForTxt();
            UtilityFunctions.SetDropdownText(NameCmbxUC, "");
            comboBox1.SelectedIndex = 1;
            InvoiceCodeCtb.PropTxt.Text = "";
            dataGridView1.DataSource = new List<SupplierInvoiceCostDTOGet>();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (sender is DataGridView dgv)
            {
                if (e.RowIndex == -1)
                    return;

                UtilityFunctions.CreateFromDetails<CreateDetailsSupplierInvoiceCostForm>(sender, e, this, dgv.CurrentRow.DataBoundItem);

            }
        }
        private void SetAllCmbxUCBlack()
        {
            NameCmbxUC.Cmbx.SetBorderColorBlack();
            BoLCmbxUC.Cmbx.SetBorderColorBlack();
            BKCmbxUC.Cmbx.SetBorderColorBlack();
        }
        private async Task UpdateExistingSupplierInvoice(bool quit = false)
        {
            bool exit = false;
            SetAllCmbxUCBlack();
            try
            {
                string name = NameCmbxUC.Cmbx.PropTxt.Text;
                string country = "";

                int lastIndex = name.LastIndexOf(" - ");

                if (lastIndex != -1 && lastIndex != name.Length - 3)
                {
                    country = name.Substring(lastIndex + 3);
                    name = name.Substring(0, lastIndex);
                }
                try
                {
                    if (string.IsNullOrEmpty(BoLCmbxUC.Cmbx.PropTxt.Text) || string.IsNullOrEmpty(BKCmbxUC.Cmbx.PropTxt.Text))
                        throw new Exception();
                    saleId = (int)(await _saleService
                    .GetAll(new SaleCustomerFilter() { SaleBoLnumber = BoLCmbxUC.Cmbx.PropTxt.Text, SaleBookingNumber = BKCmbxUC.Cmbx.PropTxt.Text }))
                    .FirstOrDefault().SaleId;
                }
                catch (Exception)
                {
                    BoLCmbxUC.Cmbx.SetBorderColorRed("Sale not found.");
                    BKCmbxUC.Cmbx.SetBorderColorRed("Sale not found.");
                    exit = true;
                }
                try
                {
                    if (string.IsNullOrEmpty(NameCmbxUC.Cmbx.PropTxt.Text))
                        throw new Exception();
                    supplierId = (int)(await _supplierService
                    .GetAll(new SupplierFilter() { SupplierName = name, SupplierCountry = country }))
                    .FirstOrDefault().SupplierId;
                }
                catch (Exception)
                {
                    NameCmbxUC.Cmbx.SetBorderColorRed("Supplier not found.");
                    exit = true;
                }

                SupplierInvoiceDTOGet si = new SupplierInvoiceDTOGet
                {
                    SaleId = saleId,
                    Status = comboBox1.Text,
                    InvoiceDate = DateClnd.Value,
                    SupplierId = supplierId,
                };

                si.IsPost = false;
                var validated = ValidatorEntity.Validate(si);
                if (validated.Any())
                {
                    UtilityFunctions.ValidateTextBoxes(panel6, si);
                    return;
                }
                if (exit)
                    return;
                await _supplierInvoiceService.Update((int)supplierInvoice.SupplierInvoiceId, si);
                MessageBox.Show("Customer updated successfully!");
                if (quit) Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async Task CreateNewSupplierInvoice(bool quit = false)
        {
            bool exit = false;
            SetAllCmbxUCBlack();
            if (saleId == -1)
            {
                try
                {
                    if (string.IsNullOrEmpty(BoLCmbxUC.Cmbx.PropTxt.Text) || string.IsNullOrEmpty(BKCmbxUC.Cmbx.PropTxt.Text))
                        throw new Exception();
                    saleId = (int)(await _saleService.GetAll(new SaleCustomerFilter()
                    {
                        SaleBoLnumber = BoLCmbxUC.Cmbx.PropTxt.Text,
                        SaleBookingNumber = BKCmbxUC.Cmbx.PropTxt.Text
                    })).FirstOrDefault().SaleId;
                }
                catch (Exception)
                {
                    BoLCmbxUC.Cmbx.SetBorderColorRed("Sale not found.");
                    BKCmbxUC.Cmbx.SetBorderColorRed("Sale not found.");
                    exit = true;
                }
            }

            if (supplierId == -1)
            {
                try
                {
                    if (string.IsNullOrEmpty(NameCmbxUC.Cmbx.PropTxt.Text))
                        throw new Exception();
                    string name = NameCmbxUC.Cmbx.PropTxt.Text;
                    string country = "";

                    int lastIndex = name.LastIndexOf(" - ");

                    if (lastIndex != -1 && lastIndex != name.Length - 3)
                    {
                        country = name.Substring(lastIndex + 3);
                        name = name.Substring(0, lastIndex);
                    }

                    supplierId = (int)(await _supplierService.GetAll(new SupplierFilter()
                    {
                        SupplierName = name,
                        SupplierCountry = country
                    })).FirstOrDefault().SupplierId;
                }
                catch (Exception)
                {
                    NameCmbxUC.Cmbx.SetBorderColorRed("Invalid supplier.");
                    exit = true;
                }
            }


            try
            {
                SupplierInvoiceDTOGet si = new SupplierInvoiceDTOGet
                {
                    InvoiceDate = DateClnd.Value,
                    SaleId = saleId,
                    SaleBoL = BoLCmbxUC.Cmbx.PropTxt.Text,
                    SaleBookingNumber = BKCmbxUC.Cmbx.PropTxt.Text,
                    SupplierInvoiceCode = "",
                    SupplierId = supplierId,
                    Status = comboBox1.Text
                };
                si.IsPost = true;
                var validated = ValidatorEntity.Validate(si);
                if (validated.Any())
                {
                    UtilityFunctions.ValidateTextBoxes(panel6, si);
                    return;
                }
                if (exit)
                    return;
                SupplierInvoiceDTOGet newSI = await _supplierInvoiceService.Create(si);
                MessageBox.Show("Supplier Invoice created Successfully!");
                if (quit) Close();

                detailsOnly = true;
                SetVisibility();

                supplierInvoice = (await _supplierInvoiceService.GetAll(new SupplierInvoiceSupplierFilter
                {
                    SupplierInvoiceCode = newSI.SupplierInvoiceCode
                })).FirstOrDefault();

                InvoiceCodeCtb.PropTxt.Text = supplierInvoice.SupplierInvoiceCode;
                InvoiceCodeCtb.PropTxt.Enabled = false;
                NameCmbxUC.Enabled = false;
                comboBox1.Enabled = false;
                DateClnd.Enabled = false;
                button2.Enabled = false;
                BoLCmbxUC.Enabled = false;
                BKCmbxUC.Enabled = false;
                OpenSale.Enabled = false;

                await RefreshDGV();

                if (_father != null)
                {
                    if (_father is CreateDetailsSaleForm sdf)
                    {
                        await sdf.RefreshDgvCustomer();
                        await sdf.RefreshDgvSupplier();
                    }
                    await RefreshDGV();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                supplierId = -1;
            }
        }

        private async void SaveEditCustomerBtn_Click(object sender, EventArgs e)
        {
            if (detailsOnly)
            {
                await UpdateExistingSupplierInvoice();
            }
            else
            {
                await CreateNewSupplierInvoice();
            }
        }


        private async void SaveQuitBtn_Click(object sender, EventArgs e)
        {
            if (detailsOnly)
            {
                await UpdateExistingSupplierInvoice(true);
            }
            else
            {
                await CreateNewSupplierInvoice(true);
            }
        }
    }
}

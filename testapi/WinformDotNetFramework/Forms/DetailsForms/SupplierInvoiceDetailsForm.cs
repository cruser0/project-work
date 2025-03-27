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
    public partial class SupplierInvoiceDetailsForm : Form
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
        string nameString;
        string countryString;
        bool detailsOnly=false;

        public SupplierInvoiceDetailsForm()
        {
            Init(null);
        }

        public SupplierInvoiceDetailsForm(int id)
        {
            Init(id);
        }

        private async void Init(int? id)
        {
            InitializeComponent();
            _saleService = new SaleService();
            _supplierService = new SupplierService();
            _supplierInvoiceService = new SupplierInvoiceService();
            _supplierInvoiceCostService = new SupplierInvoiceCostService();
            if(id != null)
            {
                detailsOnly = true;
                int idInt = (int)id;
                supplierInvoice = await _supplierInvoiceService.GetById(idInt);
                textBox1.Text = supplierInvoice.SupplierInvoiceCode;
                BKCmbxUC.Cmbx.TextChanged -= BKCmbxUC.Cmbx_TextChanged;
                BoLCmbxUC.Cmbx.TextChanged -= BoLCmbxUC.Cmbx_TextChanged;
                NameCmbxUC.Cmbx.TextChanged -= NameCmbxUC.Cmbx_TextChanged;
                CountryCmbxUC.Cmbx.TextChanged -= CountryCmbxUC.Cmbx_TextChanged;

                BKCmbxUC.Cmbx.Text = supplierInvoice.SaleBookingNumber;
                BoLCmbxUC.Cmbx.Text = supplierInvoice.SaleBoL;
                NameCmbxUC.Cmbx.Text = supplierInvoice.SupplierName;
                CountryCmbxUC.Cmbx.Text = supplierInvoice.Country;

                BKCmbxUC.Cmbx.TextChanged += BKCmbxUC.Cmbx_TextChanged;
                BoLCmbxUC.Cmbx.TextChanged += BoLCmbxUC.Cmbx_TextChanged;
                NameCmbxUC.Cmbx.TextChanged += NameCmbxUC.Cmbx_TextChanged;
                CountryCmbxUC.Cmbx.TextChanged += CountryCmbxUC.Cmbx_TextChanged;
                comboBox1.Text = supplierInvoice.Status;
                DateClnd.Value = (DateTime)supplierInvoice.InvoiceDate;
                List<SupplierInvoiceCost> data = (await _supplierInvoiceCostService
                    .GetAll(new SupplierInvoiceCostFilter()
                    { SupplierInvoiceCostSupplierInvoiceCode = supplierInvoice.SupplierInvoiceCode }))
                    .ToList();
                dataGridView1.DataSource = data;
                textBox1.Enabled = false;
                BKCmbxUC.Cmbx.Enabled = false;
                BoLCmbxUC.Cmbx.Enabled = false;
                NameCmbxUC.Cmbx.Enabled = false;
                CountryCmbxUC.Cmbx.Enabled = false;
                comboBox1.Enabled = false;
                DateClnd.Enabled = false;
            }else
                detailsOnly = false;







            SetVisibility();
            SetVisibilityForTxt();
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
            label3.Visible = detailsOnly;
            EditCbx.Visible = detailsOnly;
        }
        private void SetVisibilityForTxt()
        {
            textBox1.Enabled = !detailsOnly;
            BKCmbxUC.Cmbx.Enabled = !detailsOnly;
            BoLCmbxUC.Cmbx.Enabled = !detailsOnly;
            NameCmbxUC.Cmbx.Enabled = !detailsOnly;
            CountryCmbxUC.Cmbx.Enabled = !detailsOnly;
            comboBox1.Enabled = !detailsOnly;
            DateClnd.Enabled = !detailsOnly;
        }
        public async Task RefreshDGV()
        {
            List<SupplierInvoiceCost> data = (await _supplierInvoiceCostService
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
            BoLCmbxUC.Cmbx.Text = bol;
            BKCmbxUC.Cmbx.Text = bk;
        }
        public void SetSupplierNameCoutnry(string name, string country)
        {
            NameCmbxUC.Cmbx.Text = name+$"({country})";
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
            BKCmbxUC.Cmbx.Enabled = EditCbx.Checked;
            BoLCmbxUC.Cmbx.Enabled = EditCbx.Checked;
            NameCmbxUC.Cmbx.Enabled = EditCbx.Checked;
            CountryCmbxUC.Cmbx.Enabled = EditCbx.Checked;
            comboBox1.Enabled = EditCbx.Checked;
            DateClnd.Enabled = EditCbx.Checked;

            if (!EditCbx.Checked)
            {
                BKCmbxUC.Cmbx.Text = supplierInvoice.SaleBookingNumber;
                BoLCmbxUC.Cmbx.Text = supplierInvoice.SaleBoL;
                NameCmbxUC.Cmbx.Text = supplierInvoice.SupplierName;
                CountryCmbxUC.Cmbx.Text = supplierInvoice.Country;
                comboBox1.Text = supplierInvoice.Status;
                DateClnd.Value = (DateTime)supplierInvoice.InvoiceDate;
            }
        }

        private async void SaveEditCustomerBtn_Click(object sender, EventArgs e)
        {
            if (detailsOnly)
            {

            
                try
                {
                    saleId = (await _saleService
                    .GetAll(new SaleFilter() { SaleBoLnumber = BoLCmbxUC.Cmbx.Text, SaleBookingNumber = BKCmbxUC.Cmbx.Text }))
                    .FirstOrDefault().SaleId;

                    supplierId = (await _supplierService
                        .GetAll(new SupplierFilter() { SupplierName = NameCmbxUC.Cmbx.Text, SupplierCountry = CountryCmbxUC.Cmbx.Text }))
                        .FirstOrDefault().SupplierId;

                    SupplierInvoice si = new SupplierInvoice
                    {
                        SaleId = saleId,
                        Status = comboBox1.Text,
                        InvoiceDate = DateClnd.Value,
                        SupplierId = supplierId,
                        InvoiceAmount = 0
                    };

                    await _supplierInvoiceService.Update(supplierInvoice.InvoiceId, si);
                    MessageBox.Show("Customer updated successfully!");

                    //FORSE DA TOGLIERE
                    Close();
                    //FORSE DA TOGLIERE
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            else
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
                if (string.IsNullOrEmpty(comboBox1.Text))
                    err.Add("Status");
                if (DateClnd.Value == null)
                    err.Add("Date");
                if (saleId == -1)
                {
                    try
                    {
                        saleId = (await _saleService.GetAll(new SaleFilter() { SaleBoLnumber = BoLCmbxUC.Cmbx.Text, SaleBookingNumber = BKCmbxUC.Cmbx.Text })).FirstOrDefault().SaleId;

                    }
                    catch (Exception) { MessageBox.Show("Invalid input for the sale"); return; }

                }
                if (supplierId == -1)
                {
                    try
                    {
                        supplierId = (await _supplierService.GetAll(new SupplierFilter() { SupplierName = NameCmbxUC.Cmbx.Text, SupplierCountry = CountryCmbxUC.Cmbx.Text })).FirstOrDefault().SupplierId;
                    }
                    catch (Exception) { MessageBox.Show("Invalid input for the sale"); return; }
                }
                if (err.Count > 0)
                    MessageBox.Show("Gli attributi : " + string.Join(",", err) + "\n Sono errati!");
                else
                {
                    try
                    {
                        var code = Guid.NewGuid().ToString("N").Substring(0, 20);
                        SupplierInvoice si = new SupplierInvoice { InvoiceDate = DateClnd.Value, SaleId = saleId, SupplierId = supplierId, Status = comboBox1.Text, SupplierInvoiceCode = code, };
                        await _supplierInvoiceService.Create(si);
                        MessageBox.Show("Supplier Invoice created Successfully!");
                          
                        detailsOnly = true;
                        SetVisibility();
                        supplierInvoice = (await _supplierInvoiceService.GetAll(new SupplierInvoiceFilter {SupplierInvoiceCode=code } )).FirstOrDefault();
                        textBox1.Text = code;
                        RefreshDGV();
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                }

            }
        }

       

        public async Task SetList()
        {
            bkString = BKCmbxUC.Cmbx.Text;
            bolString = BoLCmbxUC.Cmbx.Text;
            nameString = NameCmbxUC.Cmbx.Text;
            countryString = CountryCmbxUC.Cmbx.Text;


            if (string.IsNullOrEmpty(bkString) && string.IsNullOrEmpty(bolString) &&
                string.IsNullOrEmpty(nameString) && string.IsNullOrEmpty(countryString))
            {
                BKCmbxUC.listItemsDropCmbx = new List<string>();
                BoLCmbxUC.listItemsDropCmbx = new List<string>();
                NameCmbxUC.listItemsDropCmbx = new List<string>();
                CountryCmbxUC.listItemsDropCmbx = new List<string>();
                return;
            }

            // Fetch all sales based on the current filter conditions
            var SaleListFiltered = await _saleService.GetAll(new SaleFilter()
            {
                // Only apply filters if at least one combobox has a value
                SaleBookingNumber = !string.IsNullOrEmpty(bkString) ? bkString : null,
                SaleBoLnumber = !string.IsNullOrEmpty(bolString) ? bolString : null
            });

            var SupplierListFiltered = await _supplierService.GetAll(new SupplierFilter()
            {
                // Only apply filters if at least one combobox has a value
                SupplierName = !string.IsNullOrEmpty(nameString) ? nameString : null,
                SupplierCountry = !string.IsNullOrEmpty(countryString) ? countryString : null
            });

            // Filter Booking Number suggestions
            var listItemsBk = SaleListFiltered
                .Where(x => string.IsNullOrEmpty(bolString) || x.BoLnumber == bolString)
                .Select(x => x.BookingNumber)
                .Distinct()
                .ToList();

            // Filter BoL Number suggestions
            var listItemsBol = SaleListFiltered
                .Where(x => string.IsNullOrEmpty(bkString) || x.BookingNumber == bkString)
                .Select(x => x.BoLnumber)
                .Distinct()
                .ToList();

            var listItemsName = SupplierListFiltered
                .Where(x => string.IsNullOrEmpty(countryString) || x.Country == countryString)
                .Select(x => x.SupplierName)
                .Distinct()
                .ToList();

            var listItemsCountry = SupplierListFiltered
                .Where(x => string.IsNullOrEmpty(nameString) || x.SupplierName == nameString)
                .Select(x => x.Country)
                .Distinct()
                .ToList();

            // Update combobox suggestions
            BKCmbxUC.listItemsDropCmbx = listItemsBk;
            BoLCmbxUC.listItemsDropCmbx = listItemsBol;
            NameCmbxUC.listItemsDropCmbx = listItemsName;
            CountryCmbxUC.listItemsDropCmbx = listItemsCountry;
        }

        private void AddCostBtn_Click(object sender, EventArgs e)
        {
            UtilityFunctions.CreateFromDetails<CreateSupplierInvoiceCostForm>(sender, e,this, supplierInvoice.SupplierInvoiceCode);
        }
    }
}

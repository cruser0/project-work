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
        string nameString;
        string countryString;
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

                textBox1.Text = supplierInvoice.SupplierInvoiceCode;

                UtilityFunctions.SetDropdownText(BKCmbxUC, supplierInvoice.SaleBookingNumber);
                UtilityFunctions.SetDropdownText(BoLCmbxUC, supplierInvoice.SaleBoL);
                UtilityFunctions.SetDropdownText(NameCmbxUC, supplierInvoice.SupplierName + $" - {supplierInvoice.Country}");

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
            label3.Visible = detailsOnly;
            EditCbx.Visible = detailsOnly;
            textBox1.Visible = detailsOnly;

        }
        private void SetEnableForTxt()
        {
            textBox1.Enabled = !detailsOnly;
            BKCmbxUC.Cmbx.Enabled = !detailsOnly;
            BoLCmbxUC.Cmbx.Enabled = !detailsOnly;
            NameCmbxUC.Cmbx.Enabled = !detailsOnly;
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
        public void SetSupplierNameCountry(string name, string country)
        {
            NameCmbxUC.Cmbx.Text = name + $" - {country}";
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
                OpenSale.Enabled=EditCbx.Checked;
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

        private async void SaveEditCustomerBtn_Click(object sender, EventArgs e)
        {
            if (detailsOnly)
            {


                try
                {
                    string name = NameCmbxUC.Cmbx.Text;
                    string country = "";

                    int lastIndex = name.LastIndexOf(" - ");

                    if (lastIndex != -1 && lastIndex != name.Length - 3)
                    {
                        country = name.Substring(lastIndex + 3);

                        name = name.Substring(0, lastIndex);
                    }
                    saleId = (await _saleService
                    .GetAll(new SaleFilter() { SaleBoLnumber = BoLCmbxUC.Cmbx.Text, SaleBookingNumber = BKCmbxUC.Cmbx.Text }))
                    .FirstOrDefault().SaleId;

                    supplierId = (await _supplierService
                        .GetAll(new SupplierFilter() { SupplierName = name, SupplierCountry = country }))
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
                        string name = NameCmbxUC.Cmbx.Text;
                        string country = "";

                        int lastIndex = name.LastIndexOf(" - ");

                        if (lastIndex != -1 && lastIndex != name.Length - 3)
                        {
                            country = name.Substring(lastIndex + 3);

                            name = name.Substring(0, lastIndex);
                        }

                        supplierId = (await _supplierService.GetAll(new SupplierFilter() { SupplierName = name, SupplierCountry = country })).FirstOrDefault().SupplierId;
                    }
                    catch (Exception) { MessageBox.Show("Invalid input for the sale"); return; }
                }
                if (err.Count > 0)
                    MessageBox.Show("Gli attributi : " + string.Join(",", err) + "\n Sono errati!");
                else
                {
                    try
                    {
                        SupplierInvoice si = new SupplierInvoice { InvoiceDate = DateClnd.Value, SaleId = saleId, SupplierId = supplierId, Status = comboBox1.Text };
                        SupplierInvoice newSI = await _supplierInvoiceService.Create(si);
                        MessageBox.Show("Supplier Invoice created Successfully!");
                            detailsOnly = true;
                            SetVisibility();
                            supplierInvoice = (await _supplierInvoiceService.GetAll(new SupplierInvoiceFilter {SupplierInvoiceCode= newSI.SupplierInvoiceCode } )).FirstOrDefault();
                            textBox1.Text = supplierInvoice.SupplierInvoiceCode;
                            textBox1.Enabled = false;
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
                    catch (Exception ex) { MessageBox.Show(ex.Message); supplierId = -1; }
                }

            }
        }



        public async Task SetList()
        {
            string nameInput = NameCmbxUC.Cmbx.Text;
            

            bkString = BKCmbxUC.Cmbx.Text;
            bolString = BoLCmbxUC.Cmbx.Text;
            if (string.IsNullOrEmpty(bkString) && string.IsNullOrEmpty(bolString) &&
                string.IsNullOrEmpty(nameInput))
            {
                BKCmbxUC.listItemsDropCmbx = new List<string>();
                BoLCmbxUC.listItemsDropCmbx = new List<string>();
                NameCmbxUC.listItemsDropCmbx = new List<string>();
                return;
            }

            var SaleListFiltered = await _saleService.GetAll(new SaleFilter()
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
            textBox1.Text = "";
            dataGridView1.DataSource = new List<SupplierInvoiceCost>();
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
    }
}

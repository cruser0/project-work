﻿using Entity_Validator;
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
    public partial class CreateDetailsCustomerInvoiceForm : Form
    {

        CustomerInvoiceService _customerInvoiceService;
        CustomerInvoiceCostService _customerInvoiceCostService;
        CustomerInvoiceDTOGet customerInvoice;
        SaleService _saleService;
        string bol;
        string bk;
        int saleID;

        bool detailsOnly = false;
        Form _father;
        public CreateDetailsCustomerInvoiceForm()
        {
            Init();
            InitCreate();


        }
        public CreateDetailsCustomerInvoiceForm(int id)
        {
            Init();
            InitDetails(id);
            ButtonOpenSales.Visible = false;

        }
        public CreateDetailsCustomerInvoiceForm(CreateDetailsSaleForm father, object sale)
        {
            SaleCustomerDTO saleCustomerDTO = (SaleCustomerDTO)sale;
            _father = father;
            Init();
            InitCreate();
            UtilityFunctions.SetDropdownText(BKCmbxUC, saleCustomerDTO.BookingNumber);
            UtilityFunctions.SetDropdownText(BoLCmbxUC, saleCustomerDTO.BoLnumber);
            BKCmbxUC.Enabled = false;
            BoLCmbxUC.Enabled = false;

        }
        private async void InitCreate()
        {
            dataGridView1.DataSource = new CustomerInvoiceCostDTOGet();
            checkBox1.Visible = false;
            CustomerInvoiceCodeCtb.Visible = false;
            InvoiceAmountCtb.Visible = false;
            AddCostBtn.Enabled = false;
        }
        private async void InitDetails(int id)
        {
            customerInvoice = await _customerInvoiceService.GetById(id);

            CustomerInvoiceCodeCtb.PropTxt.Text = customerInvoice.CustomerInvoiceCode;
            InvoiceAmountCtb.PropTxt.Text = customerInvoice.InvoiceAmount.ToString();

            UtilityFunctions.SetDropdownText(BKCmbxUC, customerInvoice.SaleBookingNumber);
            UtilityFunctions.SetDropdownText(BoLCmbxUC, customerInvoice.SaleBoL);

            InvoiceDateDTP.Value = (DateTime)customerInvoice.InvoiceDate;
            StatusCB.Text = customerInvoice.Status;

            List<CustomerInvoiceCostDTOGet> data = (await _customerInvoiceCostService
                .GetAll(new CustomerInvoiceCostFilter() { CustomerInvoiceCostCustomerInvoiceCode = customerInvoice.CustomerInvoiceCode })).ToList();
            dataGridView1.DataSource = data;
            InvoiceAmountCtb.PropTxt.Enabled = false;
            CustomerInvoiceCodeCtb.PropTxt.Enabled = false;
            StatusCB.Enabled = false;
            BKCmbxUC.Cmbx.Enabled = false;
            BoLCmbxUC.Cmbx.Enabled = false;
            InvoiceDateDTP.Enabled = false;
            SaveBtn.Enabled = false;
            detailsOnly = true;
        }
        private async void Init()
        {
            InitializeComponent();
            StatusCB.SelectedIndex = 1;
            BKCmbxUC.Cmbx.SetTiltes("Booking Number");
            BoLCmbxUC.Cmbx.SetTiltes("Bill of Lading");
            CustomerInvoiceCodeCtb.SetPropName("CustomerInvoiceCode");
            InvoiceAmountCtb.SetPropName("InvoiceAmount");


            _saleService = new SaleService();
            _customerInvoiceService = new CustomerInvoiceService();
            _customerInvoiceCostService = new CustomerInvoiceCostService();

            List<string> authRolesWrite = new List<string>
            {
                "CustomerInvoiceWrite",
                "CustomerInvoiceAdmin",
                "Admin"
            };
            List<string> authRoles = new List<string>
            {
                "CustomerInvoiceAdmin",
                "Admin"
            };
            if (!Authorize(authRolesWrite))
            {
                checkBox1.Visible = false;
                SaveBtn.Visible = false;
            }
        }

        private bool Authorize(List<string> allowedRoles)
        {
            return allowedRoles.Any(role => UserAccessInfo.Role.Contains(role));
        }


        public void SetSaleID(string id)
        {
            saleID = int.Parse(id);
        }
        public void SetSaleBkBol(string bol, string bk)
        {
            UtilityFunctions.SetDropdownText(BKCmbxUC, bk);
            UtilityFunctions.SetDropdownText(BoLCmbxUC, bol);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            StatusCB.Enabled = checkBox1.Checked;
            BKCmbxUC.Cmbx.Enabled = checkBox1.Checked;
            BoLCmbxUC.Cmbx.Enabled = checkBox1.Checked;
            InvoiceDateDTP.Enabled = checkBox1.Checked;
            SaveBtn.Enabled = checkBox1.Checked;

            if (!checkBox1.Checked)
            {
                CustomerInvoiceCodeCtb.PropTxt.Text = customerInvoice.CustomerInvoiceCode;
                InvoiceAmountCtb.PropTxt.Text = customerInvoice.InvoiceAmount.ToString();

                UtilityFunctions.SetDropdownText(BKCmbxUC, customerInvoice.SaleBookingNumber);
                UtilityFunctions.SetDropdownText(BoLCmbxUC, customerInvoice.SaleBoL);

                InvoiceDateDTP.Value = (DateTime)customerInvoice.InvoiceDate;
                StatusCB.Text = customerInvoice.Status;
            }
        }

        public async void UpdateDgv(string code)
        {
            List<CustomerInvoiceCostDTOGet> data = (await _customerInvoiceCostService
                .GetAll(new CustomerInvoiceCostFilter() { CustomerInvoiceCostCustomerInvoiceCode = code })).ToList();
            dataGridView1.DataSource = data;

            InvoiceAmountCtb.PropTxt.Text = data.Select(x => x.Quantity * x.Cost).Sum().ToString();
        }
        public async Task SetList()
        {


            // Get the current text values from both comboboxes
            bk = BKCmbxUC.Cmbx.PropTxt.Text;
            bol = BoLCmbxUC.Cmbx.PropTxt.Text;

            // If both comboboxes are empty, clear the suggestions
            if (string.IsNullOrEmpty(bk) && string.IsNullOrEmpty(bol))
            {
                BKCmbxUC.listItemsDropCmbx = new List<string>();
                BoLCmbxUC.listItemsDropCmbx = new List<string>();
                return;
            }

            // Fetch all sales based on the current filter conditions
            var listFiltered = await _saleService.GetAll(new SaleCustomerFilter()
            {
                // Only apply filters if at least one combobox has a value
                SaleBookingNumber = !string.IsNullOrEmpty(bk) ? bk : null,
                SaleBoLnumber = !string.IsNullOrEmpty(bol) ? bol : null
            });



            // Filter Booking Number suggestions
            var listItemsBk = listFiltered
                .Where(x => string.IsNullOrEmpty(bol) || x.BoLnumber == bol)
                .Select(x => x.BookingNumber)
                .Distinct()
                .ToList();

            // Filter BoL Number suggestions
            var listItemsBol = listFiltered
                .Where(x => string.IsNullOrEmpty(bk) || x.BookingNumber == bk)
                .Select(x => x.BoLnumber)
                .Distinct()
                .ToList();

            // Update combobox suggestions
            BKCmbxUC.listItemsDropCmbx = listItemsBk;
            BoLCmbxUC.listItemsDropCmbx = listItemsBol;
        }

        private void AddCostBtn_Click(object sender, EventArgs e)
        {
            if (detailsOnly)
                UtilityFunctions.CreateFromDetails<CreateDetailsCustomerInvoiceCostForm>(sender, e, this, customerInvoice.CustomerInvoiceCode);
            else
                UtilityFunctions.CreateFromDetails<CreateDetailsCustomerInvoiceCostForm>(sender, e, this, customerInvoice.CustomerInvoiceCode);

        }

        private void OpenSaleButton_Click(object sender, EventArgs e)
        {
            UtilityFunctions.OpenFormDetails<SaleGridForm>(sender, e, this);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (sender is DataGridView dgv)
            {
                if (e.RowIndex == -1)
                    return;

                UtilityFunctions.CreateFromDetails<CreateDetailsCustomerInvoiceCostForm>(sender, e, this, dgv.CurrentRow.DataBoundItem);

            }
        }

        private async Task UpdateClick(bool quit = false, bool validateBeforeExiting = false)
        {
            DateTime? selectedDate = InvoiceDateDTP.Checked ? (DateTime?)InvoiceDateDTP.Value : null;

            CustomerInvoiceDTOGet invoice = new CustomerInvoiceDTOGet
            {
                SaleID = saleID,
                Status = StatusCB.Text,
                InvoiceDate = selectedDate
            };
            try
            {
                invoice.IsPost = false;
                var result = ValidatorEntity.Validate(invoice);
                if (result.Any())
                {
                    UtilityFunctions.ValidateTextBoxes(panel6, invoice);
                    return;
                }
                if (validateBeforeExiting)
                    return;
                await _customerInvoiceService.Update((int)customerInvoice.CustomerInvoiceId, invoice);
                MessageBox.Show("Customer Invoice Updated successfully!");
                if (quit) Close();

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void SetAllCmbxUCBlack()
        {
            BoLCmbxUC.Cmbx.SetBorderColorBlack();
            BKCmbxUC.Cmbx.SetBorderColorBlack();
        }
        private async Task CreateClick(bool quit = false, bool validateBeforeExiting = false)
        {
            DateTime? selectedDate = InvoiceDateDTP.Checked ? (DateTime?)InvoiceDateDTP.Value : null;

            CustomerInvoiceDTOGet invoice = new CustomerInvoiceDTOGet
            {
                SaleID = saleID,
                InvoiceDate = selectedDate,
                SaleBoL = BoLCmbxUC.Cmbx.PropTxt.Text,
                SaleBookingNumber = BKCmbxUC.Cmbx.PropTxt.Text,
                Status = StatusCB.Text,
            };


            invoice.IsPost = true;
            var result = ValidatorEntity.Validate(invoice);
            if (result.Any())
            {
                UtilityFunctions.ValidateTextBoxes(panel6, invoice);
                SaveBtn.Enabled = true;
                return;
            }
            if (validateBeforeExiting)
                return;
            customerInvoice = await _customerInvoiceService.Create(invoice);
            SaveBtn.Enabled = false;
            MessageBox.Show("Customer Invoice Created Succesfully\nNow you can add Costs");
            if (quit) Close();

            InitDetails((int)customerInvoice.CustomerInvoiceId);

            AddCostBtn.Enabled = true;
            checkBox1.Visible = true;
            CustomerInvoiceCodeCtb.Visible = true;
            StatusCB.Visible = true;
            StatusLbl.Visible = true;
            InvoiceAmountCtb.Visible = true;


        }

        private async void Savebutton_Click(object sender, EventArgs e)
        {
            SetAllCmbxUCBlack();
            bool exit = false;
            try
            {
                if (string.IsNullOrEmpty(BoLCmbxUC.Cmbx.PropTxt.Text) || string.IsNullOrEmpty(BKCmbxUC.Cmbx.PropTxt.Text))
                    throw new Exception();
                saleID = (int)(await _saleService
                .GetAll(new SaleCustomerFilter()
                {
                    SaleBoLnumber = BoLCmbxUC.Cmbx.PropTxt.Text,
                    SaleBookingNumber = BKCmbxUC.Cmbx.PropTxt.Text
                }))
                .First().SaleId;
            }
            catch (Exception)
            {
                saleID = -1;
                BoLCmbxUC.Cmbx.SetBorderColorRed("Sale not found.");
                BKCmbxUC.Cmbx.SetBorderColorRed("Sale not found.");
                exit = true;
            }

            if (detailsOnly)
            {
                await UpdateClick(false, exit);
            }
            else
            {
                await CreateClick(false, exit);
            }
        }

        private async void SaveQuitButton_Click(object sender, EventArgs e)
        {
            SetAllCmbxUCBlack();

            bool exit = false;
            try
            {
                if (string.IsNullOrEmpty(BoLCmbxUC.Cmbx.PropTxt.Text) || string.IsNullOrEmpty(BKCmbxUC.Cmbx.PropTxt.Text))
                    throw new Exception();
                saleID = (int)(await _saleService
                .GetAll(new SaleCustomerFilter() { SaleBoLnumber = BoLCmbxUC.Cmbx.PropTxt.Text, SaleBookingNumber = BKCmbxUC.Cmbx.PropTxt.Text }))
                .FirstOrDefault().SaleId;
            }
            catch (Exception)
            {
                saleID = -1;
                BoLCmbxUC.Cmbx.SetBorderColorRed("Sale not found.");
                BKCmbxUC.Cmbx.SetBorderColorRed("Sale not found.");
                exit = true;
            }

            if (detailsOnly)
            {
                await UpdateClick(true, exit);
            }
            else
            {
                await CreateClick(true, exit);
            }
        }

        private void PdfButton_Click(object sender, EventArgs e)
        {
            PdfInvoiceForm form = new PdfInvoiceForm((int)customerInvoice.SaleID, customerInvoice);
            form.MdiParent = MdiParent;
            form.Show();
        }
    }
}

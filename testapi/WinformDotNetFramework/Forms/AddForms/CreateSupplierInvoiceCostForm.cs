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
    public partial class CreateSupplierInvoiceCostForm : Form
    {
        SupplierInvoiceCostService _supplierInvoiceCostService;
        SupplierInvoiceService _supplierInvoiceService;
        List<string> customerInvoiceCodes;
        private int id = -1;
        bool isSelecting = false;
        CostRegistry cr;
        string InvoiceCode;
        List<CostRegistry> list;
        public CreateSupplierInvoiceCostForm()
        {
            Init();
        }
        public CreateSupplierInvoiceCostForm(object data)
        {
            Init();
            InvoiceCode = data as string;
            InvoiceCodeCmbxUC.Cmbx.Text = InvoiceCode;
        }

        private async void Init()
        {
            _supplierInvoiceService = new SupplierInvoiceService();
            _supplierInvoiceCostService = new SupplierInvoiceCostService();
            InitializeComponent();
        }


        private async void SaveBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(InvoiceCodeCmbxUC.Cmbx.Text))
            {
                MessageBox.Show("You need to choose an invoice Code");
                return;
            }
            if (!CostRegistryCmbx.Text.Equals("All"))
                cr = list.Where(x => x.CostRegistryUniqueCode.Equals(CostRegistryCmbx.Text)).FirstOrDefault();
            else
            {
                MessageBox.Show("You need to choose a Cost Regitry");
                return;
            }
            if (id == -1)
            {
                try
                {
                    id = (await _supplierInvoiceService.GetAll(new SupplierInvoiceFilter() { SupplierInvoiceCode = InvoiceCodeCmbxUC.Cmbx.Text })).FirstOrDefault().InvoiceId;

                }
                catch (Exception) { MessageBox.Show("Invalid Invoice Code"); return; }
            }
            SupplierInvoiceCost supplierInvoiceCost = new SupplierInvoiceCost
            {
                SupplierInvoiceId = id,
                CostRegistryCode = CostRegistryCmbx.Text,
                SupplierInvoiceCode = InvoiceCodeCmbxUC.Cmbx.Text,
                Cost = string.IsNullOrEmpty(CostIntegerTxt.GetText()) ? cr.CostRegistryPrice : decimal.Parse(CostIntegerTxt.GetText()),
                Quantity = string.IsNullOrEmpty(QuantityIntegerTxt.GetText()) ? cr.CostRegistryQuantity : int.Parse(QuantityIntegerTxt.GetText()),
                Name = string.IsNullOrEmpty(NameTxt.Text) ? cr.CostRegistryName : NameTxt.Text,
            };
            try
            {
                await _supplierInvoiceCostService.Create(supplierInvoiceCost);
                MessageBox.Show("Supplier Invoice Cost created successfully!");

                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void OpenSupplierInvoice_Click(object sender, EventArgs e)
        {
            UtilityFunctions.OpenFormDetails<SupplierInvoiceGridForm>(sender, e, this);

        }
        private async void CreateSupplierInvoiceCostForm_Load(object sender, EventArgs e)
        {
            list = await UtilityFunctions.GetCostRegistry();
            CostRegistryCmbx.DataSource = list.Select(x => x.CostRegistryUniqueCode).ToList();
        }

        public void SetSupplierID(string idSup)
        {
            id = int.Parse(idSup);
        }
        public void SetSupplierCode(string SupCode)
        {
            InvoiceCodeCmbxUC.Cmbx.Text = SupCode;
        }
        public async Task SetList()
        {
            if (string.IsNullOrWhiteSpace(InvoiceCodeCmbxUC.Cmbx.Text))
            {
                InvoiceCodeCmbxUC.Cmbx.DroppedDown = false;
                return;
            }
            var listFiltered = await _supplierInvoiceService.GetAll(new SupplierInvoiceFilter()
            {
                SupplierInvoiceCode = InvoiceCodeCmbxUC.Cmbx.Text
            });

            var listItems = listFiltered.Select(x => x.SupplierInvoiceCode).ToList();
            InvoiceCodeCmbxUC.listItemsDropCmbx = listItems;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinformDotNetFramework.Entities;
using WinformDotNetFramework.Entities.Filters;
using WinformDotNetFramework.Forms.DetailsForms;
using WinformDotNetFramework.Forms.GridForms;
using WinformDotNetFramework.Services;

namespace WinformDotNetFramework.Forms.AddForms
{
    public partial class CreateSupplierInvoiceCostForm : Form
    {
        SupplierInvoiceCostService _supplierInvoiceCostService;
        SupplierInvoiceService _supplierInvoiceService;
        Form _father;
        SupplierInvoiceCost detailsSupplierInvoiceCost;
        private int id = -1;
        CostRegistry cr;
        string InvoiceCode;
        List<CostRegistry> list;
        public CreateSupplierInvoiceCostForm()
        {
            Init(null);
        }
        public CreateSupplierInvoiceCostForm(int idDetails)
        {
            Init(idDetails);
        }
        public CreateSupplierInvoiceCostForm(object data)
        {
            Init(null);
            InvoiceCode = data as string;
            UtilityFunctions.SetDropdownText(InvoiceCodeCmbxUC, InvoiceCode);
            InvoiceCodeCmbxUC.Enabled = false;
        }
        public CreateSupplierInvoiceCostForm(SupplierInvoiceDetailsForm father ,object data)
        {
            _father=father;
            Init(null);
            InvoiceCode = data as string;
            UtilityFunctions.SetDropdownText(InvoiceCodeCmbxUC, InvoiceCode);
            InvoiceCodeCmbxUC.Enabled = false;
            OpenSupplierInvoice.Enabled = false;

        }
        bool detailsOnly=false;
        private async void Init(int? idDetails)
        {
            _supplierInvoiceService = new SupplierInvoiceService();
            _supplierInvoiceCostService = new SupplierInvoiceCostService();
            InitializeComponent();
            if (idDetails != null)
            {
                detailsOnly = true;
                int idInt = (int)idDetails;
                SupplierInvoiceCost supplierInvoiceCost = await _supplierInvoiceCostService.GetById(idInt);
                UtilityFunctions.SetDropdownText(InvoiceCodeCmbxUC, supplierInvoiceCost.SupplierInvoiceCode);
                QuantityIntegerTxt.SetText(supplierInvoiceCost.Quantity.ToString());
                CostIntegerTxt.SetText(supplierInvoiceCost.Cost.ToString());
                NameTxt.Text = supplierInvoiceCost.Name;
                CostRegistryCmbx.Text = supplierInvoiceCost.CostRegistryCode;
                SetEnable();
                detailsSupplierInvoiceCost = supplierInvoiceCost;
            }
            else
            {
                detailsOnly = false;
                SetEnable();
            }

            SetVisible();
            List<string> authRolesWrite = new List<string>
                {
                    "SupplierInvoiceCostWrite",
                    "SupplierInvoiceCostAdmin",
                    "Admin"
                };
            List<string> authRoles = new List<string>
                {
                    "SupplierInvoiceCostAdmin",
                    "Admin"
                };
            if (!Authorize(authRolesWrite))
            {
                SaveBtn.Visible = false;
                checkBox1.Visible = false;
            }

        }
        private bool Authorize(List<string> allowedRoles)
        {
            return allowedRoles.Any(role => UserAccessInfo.Role.Contains(role));
        }
        private void SetVisible()
        {
            checkBox1.Visible = detailsOnly;
        }
        private void SetEnable()
        {
            InvoiceCodeCmbxUC.Enabled = !detailsOnly;
            QuantityIntegerTxt.Enabled = !detailsOnly;
            CostIntegerTxt.Enabled = !detailsOnly;
            NameTxt.Enabled = !detailsOnly;
            CostRegistryCmbx.Enabled = !detailsOnly;
            SaveBtn.Enabled = !detailsOnly;
            OpenSupplierInvoice.Enabled = !detailsOnly;
        }
        private void EditCB_CheckedChanged(object sender, EventArgs e)
        {
            InvoiceCodeCmbxUC.Enabled = !InvoiceCodeCmbxUC.Enabled;
            QuantityIntegerTxt.Enabled = !QuantityIntegerTxt.Enabled;
            CostIntegerTxt.Enabled = !CostIntegerTxt.Enabled;
            NameTxt.Enabled = !NameTxt.Enabled;
            CostRegistryCmbx.Enabled = !CostRegistryCmbx.Enabled;
            SaveBtn.Enabled = !SaveBtn.Enabled;
            OpenSupplierInvoice.Enabled = !OpenSupplierInvoice.Enabled;

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
            if (!detailsOnly)
            {


                
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
                    if (_father is SupplierInvoiceDetailsForm sidf)
                        await sidf.RefreshDGV();
                    detailsOnly = true;

                    this.Close();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            else
            {
                
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
                    await _supplierInvoiceCostService.Update(detailsSupplierInvoiceCost.SupplierInvoiceCostsId, supplierInvoiceCost);
                    MessageBox.Show("Supplier Invoice Cost updated successfully!");

                    this.Close();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
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
            UtilityFunctions.SetDropdownText(InvoiceCodeCmbxUC, SupCode);
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

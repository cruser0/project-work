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
    public partial class CreateDetailsSupplierInvoiceCostForm : Form
    {
        SupplierInvoiceCostService _supplierInvoiceCostService;
        SupplierInvoiceService _supplierInvoiceService;
        Form _father;
        SupplierInvoiceCostDTOGet detailsSupplierInvoiceCost;
        private int id = -1;
        CostRegistryDTO cr;
        string InvoiceCode;
        List<CostRegistryDTO> list;
        SupplierInvoiceCostDTOGet _updateCost;

        public CreateDetailsSupplierInvoiceCostForm()
        {
            Init(null);
        }
        public CreateDetailsSupplierInvoiceCostForm(int idDetails)
        {
            Init(idDetails);
        }
        public CreateDetailsSupplierInvoiceCostForm(object data)
        {
            Init(null);
            InvoiceCode = data as string;
            UtilityFunctions.SetDropdownText(SupplierInvoiceCmbxUC, InvoiceCode);
            SupplierInvoiceCmbxUC.Enabled = false;
        }
        public CreateDetailsSupplierInvoiceCostForm(CreateDetailsSupplierInvoiceForm father, object data)
        {
            Init(null);
            _father = father;
            // Handle the generic object data appropriately
            if (data is SupplierInvoiceCostDTOGet supplierInvoiceCost)
            {
                // Populate form with supplierInvoiceCost data
                _updateCost = supplierInvoiceCost;
                UtilityFunctions.SetDropdownText(SupplierInvoiceCmbxUC, _updateCost.SupplierInvoiceCode);
                CostRegistryCmbx.Text = _updateCost.CostRegistryCode;
                NameCtb.PropTxt.Text = _updateCost.Name;
                CostCtb.PropTxt.Text = _updateCost.Cost.ToString();
                QuantityCtb.PropTxt.Text = _updateCost.Quantity.ToString();

            }
            else if (data is string invoiceCode)
            {
                // Handle string invoice code scenario
                InvoiceCode = invoiceCode;
                UtilityFunctions.SetDropdownText(SupplierInvoiceCmbxUC, InvoiceCode);
            }
        }

        bool detailsOnly = false;
        private async void Init(int? idDetails)
        {
            _supplierInvoiceService = new SupplierInvoiceService();
            _supplierInvoiceCostService = new SupplierInvoiceCostService();
            InitializeComponent();

            SupplierInvoiceCmbxUC.Cmbx.SetTiltes("SupplierInvoiceCode");
            NameCtb.SetPropName("Name");
            QuantityCtb.SetPropName("Quantity");
            CostCtb.SetPropName("Cost");


            if (idDetails != null)
            {
                detailsOnly = true;
                int idInt = (int)idDetails;
                SupplierInvoiceCostDTOGet supplierInvoiceCost = await _supplierInvoiceCostService.GetById(idInt);
                UtilityFunctions.SetDropdownText(SupplierInvoiceCmbxUC, supplierInvoiceCost.SupplierInvoiceCode);
                QuantityCtb.PropTxt.Text = supplierInvoiceCost.Quantity.ToString();
                CostCtb.PropTxt.Text = supplierInvoiceCost.Cost.ToString();
                NameCtb.PropTxt.Text = supplierInvoiceCost.Name;
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
            SupplierInvoiceCmbxUC.Enabled = !detailsOnly;
            QuantityCtb.PropTxt.Enabled = !detailsOnly;
            CostCtb.PropTxt.Enabled = !detailsOnly;
            NameCtb.PropTxt.Enabled = !detailsOnly;
            CostRegistryCmbx.Enabled = !detailsOnly;
            SaveBtn.Enabled = !detailsOnly;
            OpenSupplierInvoice.Enabled = !detailsOnly;
        }
        private void EditCB_CheckedChanged(object sender, EventArgs e)
        {
            SupplierInvoiceCmbxUC.Enabled = !SupplierInvoiceCmbxUC.Enabled;
            QuantityCtb.PropTxt.Enabled = !QuantityCtb.PropTxt.Enabled;
            CostCtb.PropTxt.Enabled = !CostCtb.PropTxt.Enabled;
            NameCtb.PropTxt.Enabled = !NameCtb.PropTxt.Enabled;
            CostRegistryCmbx.Enabled = !CostRegistryCmbx.Enabled;
            SaveBtn.Enabled = !SaveBtn.Enabled;
            OpenSupplierInvoice.Enabled = !OpenSupplierInvoice.Enabled;

        }


        private void OpenSupplierInvoice_Click(object sender, EventArgs e)
        {
            UtilityFunctions.OpenFormDetails<SupplierInvoiceGridForm>(sender, e, this);

        }
        private async void CreateSupplierInvoiceCostForm_Load(object sender, EventArgs e)
        {
            list = await UtilityFunctions.GetCostRegistry();
            CostRegistryCmbx.DataSource = list.Select(x => x.CostRegistryUniqueCode).Skip(1).ToList();
            SetTxtByRC();
        }
        private void SetTxtByRC()
        {
            cr = list.FirstOrDefault(x => x.CostRegistryUniqueCode.Equals(CostRegistryCmbx.Text));
            NameCtb.PropTxt.Text = cr.CostRegistryName;
            QuantityCtb.PropTxt.Text = cr.CostRegistryQuantity.ToString();
            CostCtb.PropTxt.Text = cr.CostRegistryPrice.ToString();
        }
        public void SetSupplierID(string idSup)
        {
            id = int.Parse(idSup);
        }
        public void SetSupplierCode(string SupCode)
        {
            UtilityFunctions.SetDropdownText(SupplierInvoiceCmbxUC, SupCode);
        }
        public async Task SetList()
        {
            if (string.IsNullOrWhiteSpace(SupplierInvoiceCmbxUC.Cmbx.PropTxt.Text))
            {
                SupplierInvoiceCmbxUC.Cmbx.PropTxt.DroppedDown = false;
                return;
            }
            var listFiltered = await _supplierInvoiceService.GetAll(new SupplierInvoiceSupplierFilter()
            {

                SupplierInvoiceCode = SupplierInvoiceCmbxUC.Cmbx.PropTxt.Text
            });

            var listItems = listFiltered.Select(x => x.SupplierInvoiceCode).ToList();
            SupplierInvoiceCmbxUC.listItemsDropCmbx = listItems;
        }

        private async void SaveBtn_Click(object sender, EventArgs e)
        {
            bool exit = false;
            SupplierInvoiceCmbxUC.Cmbx.SetBorderColorBlack();
            if (string.IsNullOrEmpty(SupplierInvoiceCmbxUC.Cmbx.PropTxt.Text))
            {
                SupplierInvoiceCmbxUC.Cmbx.SetBorderColorRed("Invoice not found.");
                exit = true;
            }
            SetTxtByRC();

            if (id == -1)
            {
                try
                {
                    id = (int)(await _supplierInvoiceService.GetAll(new SupplierInvoiceSupplierFilter() { SupplierInvoiceCode = SupplierInvoiceCmbxUC.Cmbx.PropTxt.Text })).FirstOrDefault().SupplierInvoiceId;

                }
                catch (Exception)
                {
                    SupplierInvoiceCmbxUC.Cmbx.SetBorderColorRed("Invoice not found.");
                    exit = true;
                }
            }
            if (!detailsOnly)
            {
                SupplierInvoiceCostDTOGet supplierInvoiceCost = new SupplierInvoiceCostDTOGet
                {
                    SupplierInvoiceId = id,
                    CostRegistryCode = CostRegistryCmbx.Text,
                    SupplierInvoiceCode = SupplierInvoiceCmbxUC.Cmbx.PropTxt.Text,
                    Cost = string.IsNullOrEmpty(CostCtb.PropTxt.Text) ? cr.CostRegistryPrice : decimal.Parse(CostCtb.PropTxt.Text),
                    Quantity = string.IsNullOrEmpty(QuantityCtb.PropTxt.Text) ? cr.CostRegistryQuantity : int.Parse(QuantityCtb.PropTxt.Text),
                    Name = string.IsNullOrEmpty(NameCtb.PropTxt.Text) ? cr.CostRegistryName : NameCtb.PropTxt.Text,
                    IsPost = _updateCost == null
                };

                var result = ValidatorEntity.Validate(supplierInvoiceCost);
                if (result.Any())
                {
                    UtilityFunctions.ValidateTextBoxes(panel1, supplierInvoiceCost);
                    return;
                }

                try
                {
                    var validated = ValidatorEntity.Validate(supplierInvoiceCost);
                    if (validated.Any())
                    {
                        return;
                    }
                    if (exit)
                        return;
                    await _supplierInvoiceCostService.Create(supplierInvoiceCost);
                    MessageBox.Show("Supplier Invoice Cost created successfully!");

                    if (_father is CreateDetailsSupplierInvoiceForm sidf)
                        await sidf.RefreshDGV();
                    detailsOnly = true;

                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            else
            {
                SupplierInvoiceCostDTOGet supplierInvoiceCost = new SupplierInvoiceCostDTOGet
                {
                    SupplierInvoiceId = id,
                    CostRegistryCode = CostRegistryCmbx.Text,
                    SupplierInvoiceCode = SupplierInvoiceCmbxUC.Cmbx.PropTxt.Text,
                    Cost = string.IsNullOrEmpty(CostCtb.PropTxt.Text) ? cr.CostRegistryPrice : decimal.Parse(CostCtb.PropTxt.Text),
                    Quantity = string.IsNullOrEmpty(QuantityCtb.PropTxt.Text) ? cr.CostRegistryQuantity : int.Parse(QuantityCtb.PropTxt.Text),
                    Name = string.IsNullOrEmpty(NameCtb.PropTxt.Text) ? cr.CostRegistryName : NameCtb.PropTxt.Text,
                };
                var validated = ValidatorEntity.Validate(supplierInvoiceCost);
                if (validated.Any())
                {
                    return;
                }
                if (exit)
                    return;
                try
                {
                    await _supplierInvoiceCostService.Update((int)detailsSupplierInvoiceCost.SupplierInvoiceCostsId, supplierInvoiceCost);
                    MessageBox.Show("Supplier Invoice Cost updated successfully!");

                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void SaveQuitButton_Click(object sender, EventArgs e)
        {
            SaveBtn.PerformClick();
            Close();
        }

        private void CostRegistryCmbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetTxtByRC();
        }
    }
}

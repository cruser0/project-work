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
            UtilityFunctions.SetDropdownText(InvoiceCodeCmbxUC, InvoiceCode);
            InvoiceCodeCmbxUC.Enabled = false;
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
                UtilityFunctions.SetDropdownText(InvoiceCodeCmbxUC, _updateCost.SupplierInvoiceCode);
                CostRegistryCmbx.Text = _updateCost.CostRegistryCode;
                NameTxt.Text = _updateCost.Name;
                CostIntegerTxt.SetText(_updateCost.Cost.ToString());
                QuantityIntegerTxt.SetText(_updateCost.Quantity.ToString());

            }
            else if (data is string invoiceCode)
            {
                // Handle string invoice code scenario
                InvoiceCode = invoiceCode;
                UtilityFunctions.SetDropdownText(InvoiceCodeCmbxUC, InvoiceCode);
            }
        }

        bool detailsOnly = false;
        private async void Init(int? idDetails)
        {
            _supplierInvoiceService = new SupplierInvoiceService();
            _supplierInvoiceCostService = new SupplierInvoiceCostService();
            InitializeComponent();
            if (idDetails != null)
            {
                detailsOnly = true;
                int idInt = (int)idDetails;
                SupplierInvoiceCostDTOGet supplierInvoiceCost = await _supplierInvoiceCostService.GetById(idInt);
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
            var listFiltered = await _supplierInvoiceService.GetAll(new SupplierInvoiceSupplierFilter()
            {

                SupplierInvoiceCode = InvoiceCodeCmbxUC.Cmbx.Text
            });

            var listItems = listFiltered.Select(x => x.SupplierInvoiceCode).ToList();
            InvoiceCodeCmbxUC.listItemsDropCmbx = listItems;
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
                MessageBox.Show("You need to choose a Cost Registry");
                return;
            }
            if (id == -1)
            {
                try
                {
                    id = (int)(await _supplierInvoiceService.GetAll(new SupplierInvoiceSupplierFilter() { SupplierInvoiceCode = InvoiceCodeCmbxUC.Cmbx.Text })).FirstOrDefault().InvoiceId;

                }
                catch (Exception) { MessageBox.Show("Invalid Invoice Code"); return; }
            }
            if (!detailsOnly)
            {
                SupplierInvoiceCostDTOGet supplierInvoiceCost = new SupplierInvoiceCostDTOGet
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
                    if (_updateCost != null)
                    {
                        await _supplierInvoiceCostService.Update((int)_updateCost.SupplierInvoiceCostsId, supplierInvoiceCost);
                        MessageBox.Show("Supplier Invoice Cost Updated Succesfully");

                    }
                    else
                    {
                        await _supplierInvoiceCostService.Create(supplierInvoiceCost);
                        MessageBox.Show("Supplier Invoice Cost created successfully!");
                    }

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
                    SupplierInvoiceCode = InvoiceCodeCmbxUC.Cmbx.Text,
                    Cost = string.IsNullOrEmpty(CostIntegerTxt.GetText()) ? cr.CostRegistryPrice : decimal.Parse(CostIntegerTxt.GetText()),
                    Quantity = string.IsNullOrEmpty(QuantityIntegerTxt.GetText()) ? cr.CostRegistryQuantity : int.Parse(QuantityIntegerTxt.GetText()),
                    Name = string.IsNullOrEmpty(NameTxt.Text) ? cr.CostRegistryName : NameTxt.Text,
                };
                try
                {
                    await _supplierInvoiceCostService.Update((int)detailsSupplierInvoiceCost.SupplierInvoiceCostsId, supplierInvoiceCost);
                    MessageBox.Show("Supplier Invoice Cost updated successfully!");

                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private async void SaveQuitButton_Click(object sender, EventArgs e)
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
                MessageBox.Show("You need to choose a Cost Registry");
                return;
            }
            if (id == -1)
            {
                try
                {
                    id = (int)(await _supplierInvoiceService.GetAll(new SupplierInvoiceSupplierFilter() { SupplierInvoiceCode = InvoiceCodeCmbxUC.Cmbx.Text })).FirstOrDefault().InvoiceId;

                }
                catch (Exception) { MessageBox.Show("Invalid Invoice Code"); return; }
            }
            if (!detailsOnly)
            {
                SupplierInvoiceCostDTOGet supplierInvoiceCost = new SupplierInvoiceCostDTOGet
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
                    if (_updateCost != null)
                    {
                        await _supplierInvoiceCostService.Update((int)_updateCost.SupplierInvoiceCostsId, supplierInvoiceCost);
                        MessageBox.Show("Supplier Invoice Cost Updated Succesfully");

                    }
                    else
                    {
                        await _supplierInvoiceCostService.Create(supplierInvoiceCost);
                        MessageBox.Show("Supplier Invoice Cost created successfully!");
                    }

                    Close();
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
                    SupplierInvoiceCode = InvoiceCodeCmbxUC.Cmbx.Text,
                    Cost = string.IsNullOrEmpty(CostIntegerTxt.GetText()) ? cr.CostRegistryPrice : decimal.Parse(CostIntegerTxt.GetText()),
                    Quantity = string.IsNullOrEmpty(QuantityIntegerTxt.GetText()) ? cr.CostRegistryQuantity : int.Parse(QuantityIntegerTxt.GetText()),
                    Name = string.IsNullOrEmpty(NameTxt.Text) ? cr.CostRegistryName : NameTxt.Text,
                };
                try
                {
                    await _supplierInvoiceCostService.Update((int)detailsSupplierInvoiceCost.SupplierInvoiceCostsId, supplierInvoiceCost);
                    MessageBox.Show("Supplier Invoice Cost updated successfully!");
                    Close();

                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }
    }
}

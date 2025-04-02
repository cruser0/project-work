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
    public partial class CreateDetailsCustomerInvoiceCostForm : Form
    {
        CustomerInvoiceCostService _customerInvoiceCostService;
        CustomerInvoiceService _customerInvoiceService;
        private int id = 0;
        List<CostRegistryDTO> list;
        string InvoiceCode;
        CustomerInvoiceCostDTOGet _updateCost;
        CostRegistryDTO cr;

        public CreateDetailsCustomerInvoiceCostForm()
        {
            Init();
        }

        public CreateDetailsCustomerInvoiceCostForm(object data)
        {
            Init();
            InvoiceCode = data as string;
            InvoiceCodeCmbxUC.Cmbx.PropTxt.Text = InvoiceCode;

        }
        Form _father;
        public CreateDetailsCustomerInvoiceCostForm(Form father, CustomerInvoiceCostDTOGet data)
        {
            Init();
            _father = father;
            _updateCost = data;
            UtilityFunctions.SetDropdownText(InvoiceCodeCmbxUC, _updateCost.CustomerInvoiceCode);
            CostRegistryCmbx.Text = _updateCost.CostRegistryCode;

            NameCtb.PropTxt.Text = _updateCost.Name;
            CostCtb.PropTxt.Text = _updateCost.Cost.ToString();
            QuantityCtb.PropTxt.Text = _updateCost.Quantity.ToString();

            SaveBtn.Visible = false;

        }
        public CreateDetailsCustomerInvoiceCostForm(Form father, object data)
        {
            Init();
            _father = father;
            InvoiceCode = data as string;

            UtilityFunctions.SetDropdownText(InvoiceCodeCmbxUC, InvoiceCode);
        }

        private void Init()
        {
            _customerInvoiceCostService = new CustomerInvoiceCostService();
            _customerInvoiceService = new CustomerInvoiceService();
            InitializeComponent();

            NameCtb.SetPropName("Name");
            CostCtb.SetPropName("Cost");
            QuantityCtb.SetPropName("Quantity");

            timer.Interval = 500;
        }



        private void OpenSale_Click(object sender, EventArgs e)
        {
            UtilityFunctions.OpenFormDetails<CustomerInvoiceGridForm>(sender, e, this);
        }

        public void SetCustomerInvoiceCode(string code)
        {
            InvoiceCodeCmbxUC.Cmbx.PropTxt.Text = code;
        }
        public void SetCustomerInvoiceID(string idFromForm)
        {
            id = int.Parse(idFromForm);
        }

        private async void CreateCustomerInvoiceCostForm_Load(object sender, EventArgs e)
        {
            list = await UtilityFunctions.GetCostRegistry();
            CostRegistryCmbx.SelectedIndexChanged -= CostRegistryCmbx_SelectedIndexChanged;
            CostRegistryCmbx.DataSource = list.Select(x => x.CostRegistryUniqueCode).Skip(1).ToList();
            CostRegistryCmbx.SelectedIndexChanged += CostRegistryCmbx_SelectedIndexChanged;
        }

        public async Task SetList(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                InvoiceCodeCmbxUC.Cmbx.PropTxt.DroppedDown = false;
                return;
            }
            var listFiltered = await _customerInvoiceService.GetAll(new CustomerInvoiceFilter()
            {
                CustomerInvoiceCode = text
            });

            var listItems = listFiltered.Select(x => x.CustomerInvoiceCode).ToList();
            InvoiceCodeCmbxUC.listItemsDropCmbx = listItems;
        }
        private void SaveQuit_Click(object sender, EventArgs e)
        {
            SaveBtn.PerformClick();
            Close();
        }

        private async void SaveBtn_Click(object sender, EventArgs e)
        {

            CustomerInvoiceDTOGet listItems1;
            if (!string.IsNullOrEmpty(InvoiceCodeCmbxUC.Cmbx.PropTxt.Text))
            {
                listItems1 = (await _customerInvoiceService
                    .GetAll(new CustomerInvoiceFilter()
                    {
                        CustomerInvoiceCode = InvoiceCodeCmbxUC.Cmbx.PropTxt.Text
                    })).FirstOrDefault();
                id = (int)listItems1.CustomerInvoiceId;
            }
            else
            {
                MessageBox.Show("You need to select an Invoice Code");
                return;
            }
            CustomerInvoiceCostDTOGet customerInvoiceCost = new CustomerInvoiceCostDTOGet()
            {
                CustomerInvoiceId = id,
                CostRegistryCode = CostRegistryCmbx.Text,
                CustomerInvoiceCode = InvoiceCodeCmbxUC.Cmbx.PropTxt.Text,
                Cost = decimal.TryParse(CostCtb.PropTxt.Text, out decimal price) ? price : (decimal?)null,
                Quantity = int.TryParse(QuantityCtb.PropTxt.Text, out int quantity) ? quantity : (int?)null,
                Name = NameCtb.PropTxt.Text,
            };
            if (!string.IsNullOrEmpty(InvoiceCodeCmbxUC.Cmbx.PropTxt.Text))
                customerInvoiceCost.CustomerInvoiceCode = InvoiceCodeCmbxUC.Cmbx.PropTxt.Text;
            else
            {
                MessageBox.Show("You need to choose a Customer Invoice Code");
                return;
            }
            if (!string.IsNullOrEmpty(CostRegistryCmbx.Text) && !CostRegistryCmbx.Text.Equals("All"))
                customerInvoiceCost.CostRegistryCode = CostRegistryCmbx.Text;
            else
            {
                MessageBox.Show("You need to choose a Customer Invoice Code");
                return;
            }


            try
            {
                if (_updateCost != null)
                {
                    customerInvoiceCost.IsPost = false;
                    var result = ValidatorEntity.Validate(customerInvoiceCost);
                    if (result.Any())
                    {
                        UtilityFunctions.ValidateTextBoxes(PanelCreateCustomerInvoiceCost, customerInvoiceCost);
                        return;
                    }

                    await _customerInvoiceCostService.Update((int)_updateCost.CustomerInvoiceCostsId, customerInvoiceCost);
                    MessageBox.Show("Customer Invoice Cost Updated Succesfully");

                }
                else
                {
                    customerInvoiceCost.IsPost = true;
                    var result = ValidatorEntity.Validate(customerInvoiceCost);
                    if (result.Any())
                    {
                        UtilityFunctions.ValidateTextBoxes(PanelCreateCustomerInvoiceCost, customerInvoiceCost);
                        return;
                    }
                    await _customerInvoiceCostService.Create(customerInvoiceCost);
                    MessageBox.Show("Customer Invoice Cost Created Succesfully");
                }

                CreateDetailsCustomerInvoiceForm form = (CreateDetailsCustomerInvoiceForm)_father;
                form.UpdateDgv(InvoiceCodeCmbxUC.Cmbx.PropTxt.Text);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CostRegistryCmbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!CostRegistryCmbx.Text.Equals("All"))
                cr = list.Where(x => x.CostRegistryUniqueCode.Equals(CostRegistryCmbx.Text)).FirstOrDefault();

            if (string.IsNullOrEmpty(NameCtb.PropTxt.Text))
                NameCtb.PropTxt.Text = cr.CostRegistryName;

            if (string.IsNullOrEmpty(CostCtb.PropTxt.Text))
                CostCtb.PropTxt.Text = cr.CostRegistryPrice.ToString();

            if (string.IsNullOrEmpty(QuantityCtb.PropTxt.Text))
                QuantityCtb.PropTxt.Text = cr.CostRegistryQuantity.ToString();
        }
    }
}

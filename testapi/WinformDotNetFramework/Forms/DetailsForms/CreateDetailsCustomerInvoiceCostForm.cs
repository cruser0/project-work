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

        public CreateDetailsCustomerInvoiceCostForm()
        {
            Init();
        }

        public CreateDetailsCustomerInvoiceCostForm(object data)
        {
            Init();
            InvoiceCode = data as string;
            InvoiceCodeCmbxUC.Cmbx.Text = InvoiceCode;

        }
        Form _father;
        public CreateDetailsCustomerInvoiceCostForm(Form father, CustomerInvoiceCostDTOGet data)
        {
            Init();
            _father = father;
            _updateCost = data;
            UtilityFunctions.SetDropdownText(InvoiceCodeCmbxUC, _updateCost.CustomerInvoiceCode);
            CostRegistryCmbx.Text = _updateCost.CostRegistryCode;
            NameTxt.Text = _updateCost.Name;
            CostTxt.SetText(_updateCost.Cost.ToString());
            QuantityTxt.SetText(_updateCost.Quantity.ToString());
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
            timer.Interval = 500;
        }



        private void OpenSale_Click(object sender, EventArgs e)
        {
            UtilityFunctions.OpenFormDetails<CustomerInvoiceGridForm>(sender, e, this);
        }

        public void SetCustomerInvoiceCode(string code)
        {
            InvoiceCodeCmbxUC.Cmbx.Text = code;
        }
        public void SetCustomerInvoiceID(string idFromForm)
        {
            id = int.Parse(idFromForm);
        }

        private async void CreateCustomerInvoiceCostForm_Load(object sender, EventArgs e)
        {
            list = await UtilityFunctions.GetCostRegistry();
            CostRegistryCmbx.DataSource = list.Select(x => x.CostRegistryUniqueCode).ToList();
        }

        public async Task SetList(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                InvoiceCodeCmbxUC.Cmbx.DroppedDown = false;
                return;
            }
            var listFiltered = await _customerInvoiceService.GetAll(new CustomerInvoiceFilter()
            {
                CustomerInvoiceCode = text
            });

            var listItems = listFiltered.Select(x => x.CustomerInvoiceCode).ToList();
            InvoiceCodeCmbxUC.listItemsDropCmbx = listItems;
        }
        private async void SaveQuit_Click(object sender, EventArgs e)
        {
            CostRegistryDTO cr;
            CustomerInvoiceDTOGet listItems1;
            if (!string.IsNullOrEmpty(InvoiceCodeCmbxUC.Cmbx.Text))
            {
                listItems1 = (await _customerInvoiceService.GetAll(new CustomerInvoiceFilter() { CustomerInvoiceCode = InvoiceCodeCmbxUC.Cmbx.Text })).FirstOrDefault();
                id = (int)listItems1.CustomerInvoiceId;
            }
            else
            {
                MessageBox.Show("You need to select an Invoice Code");
                return;
            }
            if (!CostRegistryCmbx.Text.Equals("All"))
                cr = list.Where(x => x.CostRegistryUniqueCode.Equals(CostRegistryCmbx.Text)).FirstOrDefault();
            else
            {
                MessageBox.Show("You need to select a Cost Registry");
                return;
            }
            CustomerInvoiceCostDTOGet customerInvoiceCost = new CustomerInvoiceCostDTOGet()
            {
                CustomerInvoiceId = id,
                CostRegistryCode = CostRegistryCmbx.Text,
                CustomerInvoiceCode = InvoiceCodeCmbxUC.Cmbx.Text,
                Cost = string.IsNullOrEmpty(CostTxt.GetText()) ? cr.CostRegistryPrice : decimal.Parse(CostTxt.GetText()),
                Quantity = string.IsNullOrEmpty(QuantityTxt.GetText()) ? cr.CostRegistryQuantity : int.Parse(QuantityTxt.GetText()),
                Name = string.IsNullOrEmpty(NameTxt.Text) ? cr.CostRegistryName : NameTxt.Text,
            };
            if (!string.IsNullOrEmpty(InvoiceCodeCmbxUC.Cmbx.Text))
                customerInvoiceCost.CustomerInvoiceCode = InvoiceCodeCmbxUC.Cmbx.Text;
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
                        string err = "";
                        foreach (var item in result)
                        {
                            err += item.ErrorMessage + "\n";
                        }
                        MessageBox.Show(err);
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
                        string err = "";
                        foreach (var item in result)
                        {
                            err += item.ErrorMessage + "\n";
                        }
                        MessageBox.Show(err);
                        return;
                    }
                    await _customerInvoiceCostService.Create(customerInvoiceCost);
                    MessageBox.Show("Customer Invoice Cost Created Succesfully");
                }

                CreateDetailsCustomerInvoiceForm form = (CreateDetailsCustomerInvoiceForm)_father;
                form.UpdateDgv(InvoiceCodeCmbxUC.Cmbx.Text);

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void SaveBtn_Click(object sender, EventArgs e)
        {
            CostRegistryDTO cr;
            CustomerInvoiceDTOGet listItems1;
            if (!string.IsNullOrEmpty(InvoiceCodeCmbxUC.Cmbx.Text))
            {
                listItems1 = (await _customerInvoiceService.GetAll(new CustomerInvoiceFilter() { CustomerInvoiceCode = InvoiceCodeCmbxUC.Cmbx.Text })).FirstOrDefault();
                id = (int)listItems1.CustomerInvoiceId;
            }
            else
            {
                MessageBox.Show("You need to select an Invoice Code");
                return;
            }
            if (!CostRegistryCmbx.Text.Equals("All"))
                cr = list.Where(x => x.CostRegistryUniqueCode.Equals(CostRegistryCmbx.Text)).FirstOrDefault();
            else
            {
                MessageBox.Show("You need to select a Cost Registry");
                return;
            }
            CustomerInvoiceCostDTOGet customerInvoiceCost = new CustomerInvoiceCostDTOGet()
            {
                CustomerInvoiceId = id,
                CostRegistryCode = CostRegistryCmbx.Text,
                CustomerInvoiceCode = InvoiceCodeCmbxUC.Cmbx.Text,
                Cost = string.IsNullOrEmpty(CostTxt.GetText()) ? cr.CostRegistryPrice : decimal.Parse(CostTxt.GetText()),
                Quantity = string.IsNullOrEmpty(QuantityTxt.GetText()) ? cr.CostRegistryQuantity : int.Parse(QuantityTxt.GetText()),
                Name = string.IsNullOrEmpty(NameTxt.Text) ? cr.CostRegistryName : NameTxt.Text,
            };
            if (!string.IsNullOrEmpty(InvoiceCodeCmbxUC.Cmbx.Text))
                customerInvoiceCost.CustomerInvoiceCode = InvoiceCodeCmbxUC.Cmbx.Text;
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
                customerInvoiceCost.IsPost = true;
                var result = ValidatorEntity.Validate(customerInvoiceCost);
                if (result.Any())
                {
                    string err = "";
                    foreach (var item in result)
                    {
                        err += item.ErrorMessage + "\n";
                    }
                    MessageBox.Show(err);
                    return;
                }
                await _customerInvoiceCostService.Create(customerInvoiceCost);
                MessageBox.Show("Customer Invoice Cost Created Succesfully");

                CreateDetailsCustomerInvoiceForm form = (CreateDetailsCustomerInvoiceForm)_father;
                form.UpdateDgv(InvoiceCodeCmbxUC.Cmbx.Text);

                CostRegistryCmbx.Text = "All";
                NameTxt.Text = "";
                CostTxt.SetText("");
                QuantityTxt.SetText("");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}

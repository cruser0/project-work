using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinformDotNetFramework.Entities;
using WinformDotNetFramework.Entities.Filters;
using WinformDotNetFramework.Forms.AddForms;
using WinformDotNetFramework.Services;

namespace WinformDotNetFramework.Forms.GroupForms
{
    public partial class CustomerInvoiceGroupCreateForm : CreateCustomerInvoiceForm
    {
        List<string> costRegistries;
        SaleService _saleService;
        CustomerInvoiceService _customerInvoiceService;
        CustomerInvoiceCostService _customerInvoiceCostService;

        public CustomerInvoiceGroupCreateForm()
        {
            _customerInvoiceCostService= new CustomerInvoiceCostService();
            _customerInvoiceService = new CustomerInvoiceService();
            _saleService = new SaleService();
            InitializeComponent();
        }

        private async void CustomerInvoiceGroupCreateForm_Load(object sender, EventArgs e)
        {
            costRegistries = (await UtilityFunctions.GetCostRegistry())
                      .Select(x => x.CostRegistryUniqueCode)
                      .Skip(1)
                      .ToList();

            DataGridViewComboBoxColumn dgvcmbx = CustomerInvoicecostDgv.Columns["CostRegistryCode"] as DataGridViewComboBoxColumn;
            if (dgvcmbx != null)
            {
                dgvcmbx.DataSource = costRegistries;
            }
        }

        private void CustomerInvoicecostDgv_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (CustomerInvoicecostDgv.CurrentCell.ColumnIndex == CustomerInvoicecostDgv.Columns["CostRegistryCode"].Index)
            {
                if (e.Control is ComboBox comboBox)
                {
                    comboBox.SelectedIndexChanged -= ComboBox_SelectedIndexChanged;
                    comboBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
                }
            }
        }

        private async void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender is ComboBox comboBox && CustomerInvoicecostDgv.CurrentCell != null)
            {
                string selectedValue = comboBox.SelectedItem?.ToString();
                if (string.IsNullOrEmpty(selectedValue))
                {
                    comboBox.SelectedIndexChanged -= ComboBox_SelectedIndexChanged;
                    return;

                }


                var costRegistry = (await UtilityFunctions.GetCostRegistry())
                                   .FirstOrDefault(x => x.CostRegistryUniqueCode == selectedValue);

                if (costRegistry == null)
                {
                    MessageBox.Show("Wrong Cost Registry");
                    comboBox.SelectedIndexChanged -= ComboBox_SelectedIndexChanged;
                    return;
                }

                int rowIndex = CustomerInvoicecostDgv.CurrentCell.RowIndex;
                DataGridViewRow row = CustomerInvoicecostDgv.Rows[rowIndex];

                row.Cells["Quantity"].Value =row.Cells["Quantity"].Value??costRegistry.CostRegistryQuantity;
                row.Cells["Cost"].Value = row.Cells["Cost"].Value?? costRegistry.CostRegistryPrice;
                row.Cells["Name"].Value = row.Cells["Name"].Value?? costRegistry.CostRegistryName;
                comboBox.SelectedIndexChanged -= ComboBox_SelectedIndexChanged;

            }
        }
        public override async void SaveBtn_Click(object sender, EventArgs e)
        {
            CustomerInvoice ci=new CustomerInvoice();

            try
            {
                ci=await Save();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            CustomerInvoicecostDgv.EndEdit();
            CustomerInvoicecostDgv.CommitEdit(DataGridViewDataErrorContexts.Commit); 
            MessageBox.Show($"Row count: {CustomerInvoicecostDgv.Rows.Count}");
            int count = 0;
            List<CustomerInvoiceCostDTO> listCostsDto = new List<CustomerInvoiceCostDTO>();
            ci=(await _customerInvoiceService.GetAll(new CustomerInvoiceFilter() { CustomerInvoiceCode = ci.CustomerInvoiceCode })).FirstOrDefault();
            foreach(DataGridViewRow row in CustomerInvoicecostDgv.Rows)
            {
                count++;
                if (count >= CustomerInvoicecostDgv.Rows.Count)
                    break;
                CustomerInvoiceCostDTO cicdto = new CustomerInvoiceCostDTO()
                {
                    Cost = decimal.Parse(row.Cells["Cost"].Value.ToString()),
                    CostRegistryCode = row.Cells["CostRegistryCode"].Value.ToString(),
                    CustomerInvoiceCode = ci.CustomerInvoiceCode,
                    CustomerInvoiceId = ci.CustomerInvoiceId,
                    Name = row.Cells["Name"].Value.ToString(),
                    Quantity = int.Parse(row.Cells["Quantity"].Value.ToString())
                };
                listCostsDto.Add(cicdto);

            }
            try
            {
            string message=await _customerInvoiceCostService.MassSave(listCostsDto);
            MessageBox.Show(message);

            }catch (Exception ex) { MessageBox.Show(ex.Message); }

        }
    }

}



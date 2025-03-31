using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using WinformDotNetFramework.Entities;
using WinformDotNetFramework.Entities.DTO;
using WinformDotNetFramework.Entities.Filters;
using WinformDotNetFramework.Services;

namespace WinformDotNetFramework.Forms.GroupForms
{
    public partial class CustomerGroupForm : Form
    {
        CustomerFilter usedCustomerFilter = null;
        CustomerInvoiceFilter userCustomerInvoiceFilter = null;
        CustomerInvoiceCostFilter usedCustomerInvoiceCostFilter = null;
        SaleFilter usedSaleFilter = null;

        private ValueService _valueService;
        int customerPage = 1;
        int salePage = 1;
        int customerInvoicePage = 1;
        int CustomerInvoiceCostPage = 1;
        int maxPageCustomer = 0;
        int maxPageSale = 0;
        int maxPageCustomerInvoice = 0;
        int maxPageCustomerInvoiceCost = 0;
        double itemsPage = 10.0;
        bool flag;

        CustomerGroupDTO valueGroupDTOList = new CustomerGroupDTO();
        public CustomerGroupForm()
        {
            _valueService = new ValueService();
            InitializeComponent();
            Load += SupplierFinalForm_ResizeEnd;
            int minSize = searchCustomer1.Width + 30;
            MainSplitContainer.Panel2MinSize = minSize;
            MainSplitContainer.SplitterDistance = MainSplitContainer.Width - minSize;
            panel1.Width = flowLayoutPanel1.Width;
            DockButton.Text = ">";
            flag = false;
            CustomerIDTsmi.Visible = false;
            CustomerOriginalIDTsmi.Visible = false;
            SaleIDTsmi.Visible = false;
            SaleCustomerIDTsmi.Visible = false;
            CustomerInvoiceIDTsmi.Visible = false;
            CustomerInvoiceSaleIDTsmi.Visible = false;
            CustomerInvoiceCostIDTsmi.Visible = false;
            CustomerInvoiceCostCustomerInvoiceIDTsmi.Visible = false;
            if (UtilityFunctions.IsAuthorized(new HashSet<string>() { "CustomerAdmin", "CustomerInvoiceAdmin", "CustomerInvoiceCostAdmin", "SaleAdmin" }, true)
                || UtilityFunctions.IsAuthorized(new HashSet<string>() { "Admin" }))
            {
                CustomerIDTsmi.Visible = true;
                CustomerOriginalIDTsmi.Visible = true;
                SaleIDTsmi.Visible = true;
                SaleCustomerIDTsmi.Visible = true;
                CustomerInvoiceIDTsmi.Visible = true;
                CustomerInvoiceSaleIDTsmi.Visible = true;
                CustomerInvoiceCostIDTsmi.Visible = true;
                CustomerInvoiceCostCustomerInvoiceIDTsmi.Visible = true;
            }

        }

        private async void SearchBtn_Click(object sender, EventArgs e)
        {

            CustomerFilter customerfilter = searchCustomer1.GetFilter();
            SaleFilter saleFilter = searchSale1.GetFilter();
            CustomerInvoiceFilter customerInvoiceFilter = searchCustomerInvoice1.GetFilter();
            CustomerInvoiceCostFilter customerInvoiceCostfilter = searchCustomerInvoiceCost1.GetFilter();

            CustomerGroupDTO result = new CustomerGroupDTO();
            try
            {
                result = await _valueService.GetTables(customerfilter, saleFilter, customerInvoiceFilter, customerInvoiceCostfilter);
            }
            catch (Exception ex) { MessageBox.Show(Text, ex.Message); }

            if (usedCustomerFilter != customerfilter ||
                usedCustomerInvoiceCostFilter != customerInvoiceCostfilter ||
                usedSaleFilter != saleFilter ||
                userCustomerInvoiceFilter != customerInvoiceFilter)
            {
                customerPage = 1;
                salePage = 1;
                customerInvoicePage = 1;
                CustomerInvoiceCostPage = 1;
            }
            usedCustomerFilter = customerfilter;
            usedCustomerInvoiceCostFilter = customerInvoiceCostfilter;
            usedSaleFilter = saleFilter;
            userCustomerInvoiceFilter = customerInvoiceFilter;
            valueGroupDTOList = result;

            LoadCustomers();

            if (!flag)
            {
                dataGridView1.Columns["CustomerID"].Visible = false;
                dataGridView1.Columns["OriginalID"].Visible = false;
                dataGridView2.Columns["SaleId"].Visible = false;
                dataGridView2.Columns["CustomerId"].Visible = false;
                dataGridView3.Columns["SaleID"].Visible = false;
                dataGridView3.Columns["CustomerInvoiceID"].Visible = false;
                dataGridView4.Columns["CustomerInvoiceCostsID"].Visible = false;
                dataGridView4.Columns["CustomerInvoiceID"].Visible = false;
                flag = !flag;
            }
        }
        private void LoadCustomers()
        {
            dataGridView1.DataSource = valueGroupDTOList.customers.Skip((customerPage - 1) * (int)itemsPage).Take((int)itemsPage).ToList();

            if (dataGridView1.RowCount > 0)
            {
                salePage = 1;
                LoadSales();
                maxPageCustomer = (int)Math.Ceiling(valueGroupDTOList.customers.Count() / itemsPage);
                TSLbl1.Text = customerPage.ToString() + "/" + maxPageCustomer.ToString();
            }
            else
            {
                TSLbl3.Text = "N/A";
                TSLbl4.Text = "N/A";
                TSLbl2.Text = "N/A";
                TSLbl1.Text = "N/A";
            }


        }

        private void LoadSales()
        {
            var customerId = dataGridView1.CurrentRow.Cells["CustomerId"].Value;
            if (customerId != null)
            {
                dataGridView2.DataSource = valueGroupDTOList.sales.Where(x => x.CustomerId.ToString() == customerId.ToString()).Skip((salePage - 1) * (int)itemsPage).Take((int)itemsPage).ToList();
                if (dataGridView2.RowCount > 0)
                {
                    customerInvoicePage = 1;
                    LoadCustomerInvoices();
                    maxPageSale = (int)Math.Ceiling(valueGroupDTOList.sales.Where(x => x.CustomerId.ToString() == customerId.ToString()).Count() / itemsPage);
                    TSLbl2.Text = salePage.ToString() + "/" + maxPageSale.ToString();
                }
                else
                {
                    dataGridView2.DataSource = new List<SaleDTOGet>();
                    dataGridView3.DataSource = new List<CustomerInvoiceDTOGet>();
                    dataGridView4.DataSource = new List<CustomerInvoiceCostDTOGet>();
                    TSLbl3.Text = "N/A";
                    TSLbl4.Text = "N/A";
                    TSLbl2.Text = "N/A";
                }
            }
            else
            {
                dataGridView2.DataSource = new List<SaleDTOGet>();
                dataGridView3.DataSource = new List<CustomerInvoiceDTOGet>();
                dataGridView4.DataSource = new List<CustomerInvoiceCostDTOGet>();
                TSLbl3.Text = "N/A";
                TSLbl4.Text = "N/A";
                TSLbl2.Text = "N/A";

            }
        }
        private void LoadCustomerInvoices()
        {
            var saleId = dataGridView2.CurrentRow.Cells["SaleId"].Value;
            if (saleId != null)
            {
                dataGridView3.DataSource = valueGroupDTOList.invoices.Where(x => x.SaleId.ToString() == saleId.ToString()).Skip((customerInvoicePage - 1) * (int)itemsPage).Take((int)itemsPage).ToList();

                if (dataGridView3.RowCount > 0)
                {

                    CustomerInvoiceCostPage = 1;
                    LoadCustomerInvoicesCost();
                    maxPageCustomerInvoice = (int)Math.Ceiling(valueGroupDTOList.invoices.Where(x => x.SaleId.ToString() == saleId.ToString()).Count() / itemsPage);
                    TSLbl3.Text = customerInvoicePage.ToString() + "/" + maxPageCustomerInvoice.ToString();
                }
                else
                {
                    dataGridView3.DataSource = new List<CustomerInvoiceDTOGet>();
                    dataGridView4.DataSource = new List<CustomerInvoiceCostDTOGet>();
                    TSLbl3.Text = "N/A";
                    TSLbl4.Text = "N/A";
                }
            }
            else
            {
                dataGridView3.DataSource = new List<CustomerInvoiceDTOGet>();
                dataGridView4.DataSource = new List<CustomerInvoiceCostDTOGet>();
                TSLbl4.Text = "N/A";
                TSLbl3.Text = "N/A";
            }
        }
        private void LoadCustomerInvoicesCost()
        {
            var customerInvoiceId = dataGridView3.CurrentRow.Cells["CustomerInvoiceId"].Value;
            if (customerInvoiceId != null)
            {
                if (customerInvoiceId != null)
                {
                    dataGridView4.DataSource = valueGroupDTOList.invoiceCosts.Where(x => x.CustomerInvoiceId.ToString() == customerInvoiceId.ToString()).Skip((CustomerInvoiceCostPage - 1) * (int)itemsPage).Take((int)itemsPage).ToList();
                    maxPageCustomerInvoiceCost = ((int)Math.Ceiling(valueGroupDTOList.invoiceCosts.Where(x => x.CustomerInvoiceId.ToString() == customerInvoiceId.ToString()).Count() / itemsPage));
                    TSLbl4.Text = CustomerInvoiceCostPage.ToString() + "/" + maxPageCustomerInvoiceCost.ToString();
                }
            }
            else
            {
                dataGridView4.DataSource = new List<CustomerInvoiceCostDTOGet>();
                TSLbl4.Text = "N/A";
            }
        }

        private void CustomerDbClickLoadSale(object sender, DataGridViewCellEventArgs e)
        {
            LoadSales();
        }

        private void SaleDBClickLoadCustomerInvoice(object sender, DataGridViewCellEventArgs e)
        {
            LoadCustomerInvoices();
        }

        private void CustomerInvoiceDBClickLoadCustomerInvoiceCost(object sender, DataGridViewCellEventArgs e)
        {
            LoadCustomerInvoicesCost();
        }

        private void DoubleLeft_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripButton tsb)
            {
                string parentName = tsb.GetCurrentParent().Name;
                switch (parentName)
                {

                    case "toolStrip":
                        customerPage = 1;
                        LoadCustomers();
                        break;
                    case "toolStrip2":
                        salePage = 1;
                        LoadSales();
                        break;
                    case "toolStrip3":
                        customerInvoicePage = 1;
                        LoadCustomerInvoices();
                        break;
                    case "toolStrip4":
                        CustomerInvoiceCostPage = 1;
                        LoadCustomerInvoicesCost();
                        break;
                    default:
                        break;
                }
            }
        }

        private void Left_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripButton tsb)
            {
                string parentName = tsb.GetCurrentParent().Name;
                switch (parentName)
                {

                    case "toolStrip":
                        if (customerPage > 1)
                        {
                            customerPage -= 1;
                            LoadCustomers();
                        }
                        break;
                    case "toolStrip2":
                        if (salePage > 1)
                        {
                            salePage -= 1;
                            LoadSales();
                        }
                        break;
                    case "toolStrip3":
                        if (customerInvoicePage > 1)
                        {
                            customerInvoicePage -= 1;
                            LoadCustomerInvoices();
                        }
                        break;
                    case "toolStrip4":
                        if (CustomerInvoiceCostPage > 1)
                        {
                            customerInvoicePage -= 1;
                            LoadCustomerInvoicesCost();
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private void Right_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripButton tsb)
            {
                string parentName = tsb.GetCurrentParent().Name;
                switch (parentName)
                {

                    case "toolStrip":
                        if (customerPage < maxPageCustomer)
                        {
                            customerPage += 1;
                            LoadCustomers();
                        }
                        break;
                    case "toolStrip2":
                        if (salePage < maxPageSale)
                        {
                            salePage += 1;
                            LoadSales();
                        }
                        break;
                    case "toolStrip3":
                        if (customerInvoicePage < maxPageCustomerInvoice)
                        {
                            customerInvoicePage += 1;
                            LoadCustomerInvoices();
                        }
                        break;
                    case "toolStrip4":
                        if (CustomerInvoiceCostPage < maxPageCustomerInvoiceCost)
                        {
                            customerInvoicePage += 1;
                            LoadCustomerInvoicesCost();
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private void DoubleRight_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripButton tsb)
            {
                string parentName = tsb.GetCurrentParent().Name;
                switch (parentName)
                {

                    case "toolStrip":
                        customerPage = maxPageCustomer;
                        LoadCustomers();
                        break;
                    case "toolStrip2":
                        salePage = maxPageSale;
                        LoadSales();
                        break;
                    case "toolStrip3":
                        customerInvoicePage = maxPageCustomerInvoice;
                        LoadCustomerInvoices();
                        break;
                    case "toolStrip4":
                        CustomerInvoiceCostPage = maxPageCustomerInvoiceCost;
                        LoadCustomerInvoicesCost();
                        break;
                    default:
                        break;
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (btn.Text == ">")
            {
                MainSplitContainer.Panel2MinSize = btn.Width;
                MainSplitContainer.SplitterDistance = MainSplitContainer.Width - btn.Width;

                SearchPanel.Visible = false;
                searchCustomer1.Visible = false;
                searchCustomerInvoice1.Visible = false;
                searchCustomerInvoiceCost1.Visible = false;
                searchSale1.Visible = false;
                panel1.Width = flowLayoutPanel1.Width;
                btn.Text = "<";
            }
            else
            {
                searchCustomer1.Visible = true;
                searchCustomerInvoice1.Visible = true;
                searchCustomerInvoiceCost1.Visible = true;
                searchSale1.Visible = true;
                SearchPanel.Visible = true;

                int minSize = searchCustomer1.Width + 30;
                MainSplitContainer.Panel2MinSize = minSize;
                MainSplitContainer.SplitterDistance = MainSplitContainer.Width - minSize;
                panel1.Width = flowLayoutPanel1.Width;
                btn.Text = ">";
            }
        }

        private void SupplierFinalForm_ResizeEnd(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
                return;

            if (DockButton.Text == ">")
            {
                int minSize = searchCustomer1.Width + 30;
                MainSplitContainer.Panel2MinSize = minSize;
                MainSplitContainer.SplitterDistance = MainSplitContainer.Width - minSize;
                panel1.Width = flowLayoutPanel1.Width;
            }
            else
            {
                MainSplitContainer.Panel2MinSize = DockButton.Width;
                MainSplitContainer.SplitterDistance = MainSplitContainer.Width - DockButton.Width;
                panel1.Width = flowLayoutPanel1.Width;
            }





        }

        private void CustomerRightClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                if (sender is DataGridView dgv)
                {
                    switch (dgv.Name)
                    {
                        case "dataGridView1":
                            RightClickDgvCustomer.Show(dataGridView1, dataGridView1.PointToClient(Cursor.Position));
                            break;
                        case "dataGridView2":
                            RightClickDgvSale.Show(dataGridView2, dataGridView2.PointToClient(Cursor.Position));
                            break;
                        case "dataGridView3":
                            RightClickDgvCustomerInvoice.Show(dataGridView3, dataGridView3.PointToClient(Cursor.Position));
                            break;
                        case "dataGridView4":
                            RightClickDgvCustomerInvoiceCost.Show(dataGridView4, dataGridView4.PointToClient(Cursor.Position));
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        private void CustomerContextMenuStripCheckEvent(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem tsmi)
            {
                string name = tsmi.Name;
                switch (name)
                {
                    case "CustomerIDTsmi":
                        dataGridView1.Columns["CustomerID"].Visible = tsmi.Checked;
                        break;
                    case "CustomerNameTsmi":
                        dataGridView1.Columns["CustomerName"].Visible = tsmi.Checked;
                        break;
                    case "CustomerCountryTsmi":
                        dataGridView1.Columns["Country"].Visible = tsmi.Checked;
                        break;
                    case "CustomerDateTsmi":
                        dataGridView1.Columns["CreatedAt"].Visible = tsmi.Checked;
                        break;
                    case "CustomerOriginalIDTsmi":
                        dataGridView1.Columns["OriginalID"].Visible = tsmi.Checked;
                        break;
                    case "CustomerStatusTsmi":
                        dataGridView1.Columns["Deprecated"].Visible = tsmi.Checked;
                        break;
                    default:
                        break;
                }

            }
        }
        private void SaleContextMenuStripCheckEvent(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem tsmi)
            {
                string name = tsmi.Name;
                switch (name)
                {
                    case "SaleIDTsmi":
                        dataGridView2.Columns["SaleId"].Visible = tsmi.Checked;
                        break;
                    case "SaleBkNumberTsmi":
                        dataGridView2.Columns["BookingNumber"].Visible = tsmi.Checked;
                        break;
                    case "SaleBoLNumberTsmi":
                        dataGridView2.Columns["BoLnumber"].Visible = tsmi.Checked;
                        break;
                    case "SaleCustomerIDTsmi":
                        dataGridView2.Columns["CustomerId"].Visible = tsmi.Checked;
                        break;
                    case "SaleTotalRevenueTsmi":
                        dataGridView2.Columns["TotalRevenue"].Visible = tsmi.Checked;
                        break;
                    case "SaleStatusTsmi":
                        dataGridView2.Columns["Status"].Visible = tsmi.Checked;
                        break;
                    case "SaleDateTsmi":
                        dataGridView2.Columns["SaleDate"].Visible = tsmi.Checked;
                        break;
                    default:
                        break;
                }

            }
        }
        private void CustomerInvoiceContextMenuStripCheckEvent(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem tsmi)
            {
                string name = tsmi.Name;
                switch (name)
                {
                    case "CustomerInvoiceIDTsmi":
                        dataGridView3.Columns["CustomerInvoiceID"].Visible = tsmi.Checked;
                        break;
                    case "CustomerInvoiceSaleIDTsmi":
                        dataGridView3.Columns["SaleID"].Visible = tsmi.Checked;
                        break;
                    case "CustomerInvoiceInvoiceAmountTsmi":
                        dataGridView3.Columns["InvoiceAmount"].Visible = tsmi.Checked;
                        break;
                    case "CustomerInvoiceDateTsmi":
                        dataGridView3.Columns["InvoiceDate"].Visible = tsmi.Checked;
                        break;
                    case "CustomerInvoiceStatusTsmi":
                        dataGridView3.Columns["Status"].Visible = tsmi.Checked;
                        break;
                    default:
                        break;
                }

            }
        }
        private void CustomerInvoiceCostContextMenuStripCheckEvent(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem tsmi)
            {
                string name = tsmi.Name;
                switch (name)
                {
                    case "CustomerInvoiceCostIDTsmi":
                        dataGridView4.Columns["CustomerInvoiceCostsID"].Visible = tsmi.Checked;
                        break;
                    case "CustomerInvoiceCostCustomerInvoiceIDTsmi":
                        dataGridView4.Columns["CustomerInvoiceID"].Visible = tsmi.Checked;
                        break;
                    case "CustomerInvoiceCostCostTsmi":
                        dataGridView4.Columns["Cost"].Visible = tsmi.Checked;
                        break;
                    case "CustomerInvoiceCostQuantityTsmi":
                        dataGridView4.Columns["Quantity"].Visible = tsmi.Checked;
                        break;
                    case "CustomerInvoiceCostNameTsmi":
                        dataGridView4.Columns["Name"].Visible = tsmi.Checked;
                        break;
                    default:
                        break;
                }

            }
        }


    }
}

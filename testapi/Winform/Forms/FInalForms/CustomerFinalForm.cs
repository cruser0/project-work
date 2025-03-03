using API.Models.Filters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Winform.Entities;
using Winform.Entities.DTO;
using Winform.Services;

namespace Winform.Forms.FInalForms
{
    public partial class CustomerFinalForm : Form
    {
        CustomerFilter usedCustomerFilter=null;
        CustomerInvoiceFilter userCustomerInvoiceFilter = null;
        CustomerInvoiceCostFilter usedCustomerInvoiceCostFilter=null;
        SaleFilter usedSaleFilter=null;
        CustomerService _customerService;

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
        List<string> authRoles = new List<string>
            {
                "CustomerAdmin",
                "Admin"
            };
        CustomerGroupDTO valueGroupDTOList = new CustomerGroupDTO();
        public CustomerFinalForm()
        {
            _valueService = new ValueService();
            _customerService=new CustomerService();
            InitializeComponent();
            Load += CustomerFinalForm_ResizeEnd;
        }

        private bool Authorize(List<string> allowedRoles)
        {
            return allowedRoles.Any(role => UserAccessInfo.Role.Contains(role));
        }

        private void RightSideBar_closeBtnEvent(object? sender, EventArgs e)
        {
            this.Close();
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {

            CustomerFilter customerfilter = new CustomerFilter
            {
                CustomerName = searchCustomer1.NameTxt.Text,
                CustomerCountry = searchCustomer1.CountryTxt.Text,
                CustomerDeprecated = searchCustomer1.comboBox1.SelectedIndex switch
                {
                    1 => false,
                    2 => true,
                    _ => null
                },
                CustomerCreatedDateFrom = searchCustomer1.DateFromClnd.Checked ? searchCustomer1.DateFromClnd.Value : null,
                CustomerCreatedDateTo = searchCustomer1.DateToClnd.Checked ? searchCustomer1.DateToClnd.Value : null
            };
            SaleFilter saleFilter = new SaleFilter
            {
                SaleBookingNumber = searchSale1.BNTextBox.Text,
                SaleBoLnumber = searchSale1.BoLTextBox.Text,
                SaleDateFrom = searchSale1.DateFromDTP.Checked ? searchSale1.DateFromDTP.Value : null,
                SaleDateTo = searchSale1.DateToDTP.Checked ? searchSale1.DateToDTP.Value : null,
                SaleRevenueFrom = string.IsNullOrEmpty(searchSale1.RevenueFromTxt.GetText()) ? null : int.Parse(searchSale1.RevenueFromTxt.GetText()),
                SaleRevenueTo = string.IsNullOrEmpty(searchSale1.RevenueToTxt.GetText()) ? null : int.Parse(searchSale1.RevenueToTxt.GetText()),
                SaleCustomerId =null,
                SaleStatus = searchSale1.StatusCB.Text == "All" ? null : searchSale1.StatusCB.Text,
            };
            CustomerInvoiceFilter customerInvoiceFilter = new CustomerInvoiceFilter
            {
                CustomerInvoiceSaleId = null,
                CustomerInvoiceInvoiceDateFrom = searchCustomerInvoice1.DateFromClnd.Checked ? searchCustomerInvoice1.DateFromClnd.Value : null,
                CustomerInvoiceInvoiceDateTo = searchCustomerInvoice1.DateToClnd.Checked ? searchCustomerInvoice1.DateToClnd.Value : null,
                CustomerInvoiceStatus = searchCustomerInvoice1.StatusCmb.Text,
                CustomerInvoiceInvoiceAmountFrom = !string.IsNullOrEmpty(searchCustomerInvoice1.AmountFromTxt.GetText()) ? int.Parse(searchCustomerInvoice1.AmountFromTxt.GetText()) : null,
                CustomerInvoiceInvoiceAmountTo = !string.IsNullOrEmpty(searchCustomerInvoice1.AmountToTxt.GetText()) ? int.Parse(searchCustomerInvoice1.AmountToTxt.GetText()) : null
            };
            CustomerInvoiceCostFilter customerInvoiceCostfilter = new CustomerInvoiceCostFilter
            {
                CustomerInvoiceCostCustomerInvoiceId = null,
                CustomerInvoiceCostCostFrom = string.IsNullOrEmpty(searchCustomerInvoiceCost1.CostFromTxt.GetText()) ? null : int.Parse(searchCustomerInvoiceCost1.CostFromTxt.GetText()),
                CustomerInvoiceCostCostTo = string.IsNullOrEmpty(searchCustomerInvoiceCost1.CostToTxt.GetText()) ? null : int.Parse(searchCustomerInvoiceCost1.CostToTxt.GetText()),
                CustomerInvoiceCostName = searchCustomerInvoiceCost1.NameTxt.Text,
            };
            CustomerGroupDTO result=new CustomerGroupDTO();
            try
            {
                 result=_valueService.GetTables(customerfilter, saleFilter, customerInvoiceFilter, customerInvoiceCostfilter);
            }catch (Exception ex) { MessageBox.Show(Text, ex.Message); }

            if(usedCustomerFilter!=customerfilter ||
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
            usedSaleFilter=saleFilter;
            userCustomerInvoiceFilter = customerInvoiceFilter;
            valueGroupDTOList = result;

            
            
            
            LoadCustomers();
        }
        private void LoadCustomers()
        {
            dataGridView1.DataSource = valueGroupDTOList.customers.Skip((customerPage-1)*(int)itemsPage).Take((int)itemsPage).ToList();
            if (dataGridView1.RowCount > 0)
            {
                salePage=1;
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
                    dataGridView2.DataSource = new SaleFilter();
                    dataGridView3.DataSource = new CustomerInvoiceFilter();
                    dataGridView4.DataSource = new CustomerInvoiceCostFilter();
                    TSLbl3.Text = "N/A";
                    TSLbl4.Text = "N/A";
                    TSLbl2.Text = "N/A";
                }
            }
            else
            {
                dataGridView2.DataSource = new SaleFilter();
                dataGridView3.DataSource = new CustomerInvoiceFilter();
                dataGridView4.DataSource = new CustomerInvoiceCostFilter();
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
                if(dataGridView3.RowCount > 0)
                {
                CustomerInvoiceCostPage = 1;
                LoadCustomerInvoicesCost();
                    maxPageCustomerInvoice = (int)Math.Ceiling(valueGroupDTOList.invoices.Where(x => x.SaleId.ToString() == saleId.ToString()).Count() / itemsPage);
                TSLbl3.Text = customerInvoicePage.ToString() + "/" + maxPageCustomerInvoice.ToString();
                }
                else
                {
                    dataGridView3.DataSource = new CustomerInvoiceFilter();
                    dataGridView4.DataSource = new CustomerInvoiceCostFilter();
                    TSLbl3.Text = "N/A";
                    TSLbl4.Text = "N/A";
                }
            }
            else
            {
                dataGridView3.DataSource = new CustomerInvoiceFilter();
                dataGridView4.DataSource = new CustomerInvoiceCostFilter();
                TSLbl4.Text = "N/A";
                TSLbl3.Text = "N/A";
            }
        }
        private void LoadCustomerInvoicesCost()
        {
            var customerInvoiceId = dataGridView3.CurrentRow.Cells["CustomerInvoiceId"].Value;
            if (customerInvoiceId!=null)
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
             dataGridView4.DataSource = new CustomerInvoiceCostFilter();
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
            if(sender is ToolStripButton tsb)
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
                        if(customerPage> 1)
                        {
                        customerPage -=1;
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
                            customerInvoicePage-= 1;
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

                int minSize = searchCustomer1.Width + 30;
                MainSplitContainer.Panel2MinSize = minSize;
                MainSplitContainer.SplitterDistance = MainSplitContainer.Width - minSize;
                panel1.Width = flowLayoutPanel1.Width;
                btn.Text = ">";
            }
        }

        private void CustomerFinalForm_ResizeEnd(object sender, EventArgs e)
        {
            if (button2.Text == ">")
            {

                int minSize = searchCustomer1.Width + 30;
                MainSplitContainer.Panel2MinSize = minSize;
                MainSplitContainer.SplitterDistance = MainSplitContainer.Width - minSize;
                panel1.Width = flowLayoutPanel1.Width;

            }
            else
            {
                MainSplitContainer.Panel2MinSize = button2.Width;
                MainSplitContainer.SplitterDistance = MainSplitContainer.Width - button2.Width;
                panel1.Width = flowLayoutPanel1.Width;
            }
        }





    }



}

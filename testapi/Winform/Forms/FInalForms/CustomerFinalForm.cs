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
        int page1 = 1;
        int page2 = 1;
        int page3 = 1;
        int page4 = 1;
        int maxPage1;
        int maxPage2;
        int maxPage3;
        int maxPage4;
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


        }

        private bool Authorize(List<string> allowedRoles)
        {
            return allowedRoles.Any(role => UserAccessInfo.Role.Contains(role));
        }

        //private void PaginationUserControl_SingleLeftArrowEvent(object? sender, EventArgs e)
        //{
        //    if (PaginationUserControl.CurrentPage <= 1)
        //        return;
        //    PaginationUserControl.CurrentPage = PaginationUserControl.CurrentPage - 1;
        //    PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());
        //    MyControl_ButtonClicked_Pagination(sender, e);
        //}

        //private void PaginationUserControl_DoubleLeftArrowEvent(object? sender, EventArgs e)
        //{

        //    PaginationUserControl.CurrentPage = 1;
        //    PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());
        //    MyControl_ButtonClicked_Pagination(sender, e);
        //}

        //private void PaginationUserControl_DoubleRightArrowEvent(object? sender, EventArgs e)
        //{
        //    PaginationUserControl.CurrentPage = int.Parse(PaginationUserControl.GetmaxPage());
        //    PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());
        //    MyControl_ButtonClicked_Pagination(sender, e);
        //}

        //private void PaginationUserControl_SingleRightArrowEvent(object? sender, EventArgs e)
        //{
        //    if (PaginationUserControl.CurrentPage >= int.Parse(PaginationUserControl.GetmaxPage()))
        //        return;
        //    PaginationUserControl.CurrentPage++;
        //    PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());
        //    MyControl_ButtonClicked_Pagination(sender, e);

        //}


        private void RightSideBar_closeBtnEvent(object? sender, EventArgs e)
        {
            this.Close();
        }

        //public virtual void MyControl_OpenDetails_Clicked(object sender, DataGridViewCellEventArgs e)
        //{

        //    if (sender is DataGridView dgv)
        //    {
        //        if (_father is CreateSaleForm csf)
        //        {
        //            csf.SetCustomerID(dgv.CurrentRow.Cells["CustomerID"].Value.ToString());
        //        }
        //    }
        //}

        //public void CustomerGridForm_Resize(object sender, EventArgs e)
        //{

        //    panel5.Location = new Point((Width - panel5.Width) / 2, 0);
        //    PaginationUserControl.Location = new Point((panel5.Width - PaginationUserControl.Width) / 2, (panel5.Height - PaginationUserControl.Height) / 2);
        //    int newHeight = (int)((Height - TextBoxesRightPanel.Top) * 0.9);
        //    if (TextBoxesRightPanel.Height != newHeight)
        //    {
        //        TextBoxesRightPanel.Height = newHeight;
        //    }

        //}

        //private void CustomerDgv_RightClick(object sender, DataGridViewCellMouseEventArgs e)
        //{
        //    if (e.Button == MouseButtons.Right)
        //    {
        //        var hitTest = CustomerDgv.HitTest(e.X, e.Y);
        //        if (hitTest.RowIndex >= 0)
        //        {
        //            RightClickDgv.Show(CustomerDgv, e.Location);
        //        }
        //    }
        //}

        //private void ContextMenuStripCheckEvent(object sender, EventArgs e)
        //{
        //    if (sender is ToolStripMenuItem tsmi)
        //    {
        //        string name = tsmi.Name;
        //        switch (name)
        //        {
        //            case "CustomerIDTsmi":
        //                CustomerDgv.Columns["CustomerID"].Visible = tsmi.Checked;
        //                break;
        //            case "CustomerNameTsmi":
        //                CustomerDgv.Columns["CustomerName"].Visible = tsmi.Checked;
        //                break;
        //            case "CustomerCountryTsmi":
        //                CustomerDgv.Columns["Country"].Visible = tsmi.Checked;
        //                break;
        //            case "CustomerDateTsmi":
        //                CustomerDgv.Columns["CreatedAt"].Visible = tsmi.Checked;
        //                break;
        //            case "CustomerOriginalIDTsmi":
        //                CustomerDgv.Columns["OriginalID"].Visible = tsmi.Checked;
        //                break;
        //            case "CustomerStatusTsmi":
        //                CustomerDgv.Columns["Deprecated"].Visible = tsmi.Checked;
        //                break;
        //            default:
        //                break;
        //        }

        //    }
        //}

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
            usedCustomerFilter = customerfilter;
            usedCustomerInvoiceCostFilter = customerInvoiceCostfilter;
            usedSaleFilter=saleFilter;
            userCustomerInvoiceFilter = customerInvoiceFilter;
            valueGroupDTOList = result;
            page1 = 1;
            page2 = 1;
            page3 = 1;
            page4 = 1;
            dataGridView1.DataSource = result.customers;
            dataGridView2.DataSource = result.sales.Where(x=>x.CustomerId== int.Parse(dataGridView1.CurrentRow.Cells["CustomerId"].Value.ToString()));
            dataGridView3.DataSource = result.invoices.Where(x=>x.SaleId== int.Parse(dataGridView2.CurrentRow.Cells["SaleId"].Value.ToString()));
            dataGridView4.DataSource = result.invoiceCosts.Where(x=>x.CustomerInvoiceId== int.Parse(dataGridView3.CurrentRow.Cells["CustomerInvoiceId"].Value.ToString()));

        }

        private void CustomerFinalForm_Load(object sender, EventArgs e)
        {
        }
    }
}

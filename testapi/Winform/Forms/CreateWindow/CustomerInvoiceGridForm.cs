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
using Winform.Services;

namespace Winform.Forms.CreateWindow
{
    public partial class CustomerInvoiceGridForm : Form
    {
        string? saleID;
        DateTime? invoiceDateFrom;
        DateTime? invoiceDateTo;
        string status;
        double itemsPage = 10.0;
        int pages;
        CustomerInvoiceService _customerService;
        public CustomerInvoiceGridForm()
        {
            _customerService = new CustomerInvoiceService();
            pages = (int)Math.Ceiling(_customerService.Count(new CustomerInvoiceFilter()) / itemsPage);
            InitializeComponent();
            PaginationUserControl.CurrentPage = 1;
            StatusCmb.SelectedIndex = 0;
            RightSideBar.searchBtnEvent += RightSideBar_searchBtnEvent;
            RightSideBar.closeBtnEvent += RightSideBar_closeBtnEvent;

            PaginationUserControl.SingleRightArrowEvent += PaginationUserControl_SingleRightArrowEvent;
            PaginationUserControl.DoubleRightArrowEvent += PaginationUserControl_DoubleRightArrowEvent;
            PaginationUserControl.DoubleLeftArrowEvent += PaginationUserControl_DoubleLeftArrowEvent;
            PaginationUserControl.SingleLeftArrowEvent += PaginationUserControl_SingleLeftArrowEvent;
            PaginationUserControl.Visible = false;
            PaginationUserControl.SetMaxPage(pages.ToString());
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());
        }

        private void RightSideBar_closeBtnEvent(object? sender, EventArgs e)
        {
            this.Close();
        }

        private void RightSideBar_searchBtnEvent(object? sender, EventArgs e)
        {
            PaginationUserControl.CurrentPage = 1;
            bool flagfrom = false;
            bool flagto = false;
            if (DateFromClnd.Checked)
            {
                if (!(DateFromClnd.Value <= DateTime.Now) || !(DateFromClnd.Value > new DateTime(1975, 1, 1)))
                    flagfrom = true;
            }
            if (DateToClnd.Checked)
            {
                if (!(DateToClnd.Value <= DateTime.Now) || !(DateToClnd.Value >= DateFromClnd.Value))
                    flagto = true;
            }
            if (flagfrom && flagto)
                MessageBox.Show("Incorrect Input Date From and Date To");
            else
            {
                if (flagfrom)
                    MessageBox.Show("Incorrect Input Date From");
                if (flagto)
                    MessageBox.Show("Incorrect Input Date To");
            }

            CustomerInvoiceFilter filter = new CustomerInvoiceFilter
            {
                SaleId = !string.IsNullOrEmpty(SaleIDTxt.GetText()) ? int.Parse(SaleIDTxt.GetText()) : null,
                InvoiceDateFrom = DateFromClnd.Checked ? DateFromClnd.Value : null,
                InvoiceDateTo = DateToClnd.Checked ? DateToClnd.Value : null,
                Status = StatusCmb.Text,
                page=PaginationUserControl.CurrentPage,
                //InvoiceAmount
            };
            CustomerInvoiceFilter filterPage = new CustomerInvoiceFilter
            {
                SaleId = !string.IsNullOrEmpty(SaleIDTxt.GetText()) ? int.Parse(SaleIDTxt.GetText()) : null,
                InvoiceDateFrom = DateFromClnd.Checked ? DateFromClnd.Value : null,
                InvoiceDateTo = DateToClnd.Checked ? DateToClnd.Value : null,
                Status = StatusCmb.Text,
                //InvoiceAmount = 0,
            };
            saleID=SaleIDTxt.GetText();
            invoiceDateFrom=DateFromClnd.Checked ? DateFromClnd.Value : null;
            invoiceDateTo=DateToClnd.Checked ? DateToClnd.Value : null;
            status=StatusCmb.Text;

            IEnumerable<CustomerInvoice> query = _customerService.GetAll(filter);
            PaginationUserControl.maxPage = ((int)Math.Ceiling(_customerService.Count(filterPage) / itemsPage)).ToString();
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());

            CenterDgv.DataSource = query.ToList();

            if (!PaginationUserControl.Visible)
            {
                PaginationUserControl.Visible = true;
            }
        }
        private void MyControl_ButtonClicked_Pagination(object sender, EventArgs e)
        {
            int idNum;
            CustomerInvoiceFilter filter = new CustomerInvoiceFilter
            {
                SaleId =int.TryParse(saleID,out idNum)?idNum:null,
                InvoiceDateFrom = invoiceDateFrom,
                InvoiceDateTo = invoiceDateTo,
                Status = status,
                page = PaginationUserControl.CurrentPage,
                //InvoiceAmount
            };

            IEnumerable<CustomerInvoice> query = _customerService.GetAll(filter);
            CenterDgv.DataSource = query.ToList();
        }

        private void CenterDgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (sender is DataGridView dgv)
            {
                SupplierInvoiceDetailsForm sid = new SupplierInvoiceDetailsForm(int.Parse(dgv.CurrentRow.Cells[0].Value.ToString()));
                sid.Show();
            }
            else
            {
                MessageBox.Show(sender.ToString());

            }
        }
        private void PaginationUserControl_SingleLeftArrowEvent(object? sender, EventArgs e)
        {
            if (PaginationUserControl.CurrentPage <= 1)
                return;
            PaginationUserControl.CurrentPage = PaginationUserControl.CurrentPage - 1;
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());
            MyControl_ButtonClicked_Pagination(sender, e);
        }

        private void PaginationUserControl_DoubleLeftArrowEvent(object? sender, EventArgs e)
        {

            PaginationUserControl.CurrentPage = 1;
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());
            MyControl_ButtonClicked_Pagination(sender, e);
        }

        private void PaginationUserControl_DoubleRightArrowEvent(object? sender, EventArgs e)
        {
            PaginationUserControl.CurrentPage = int.Parse(PaginationUserControl.GetmaxPage());
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());
            MyControl_ButtonClicked_Pagination(sender, e);
        }

        private void PaginationUserControl_SingleRightArrowEvent(object? sender, EventArgs e)
        {
            if (PaginationUserControl.CurrentPage >= int.Parse(PaginationUserControl.GetmaxPage()))
                return;
            PaginationUserControl.CurrentPage++;
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());
            MyControl_ButtonClicked_Pagination(sender, e);
        }
    }
}

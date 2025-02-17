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

namespace Winform.Forms
{
    public partial class SupplierInvoiceForm : Form
    {
        SupplierInvoiceService _supplierInvoiceService;
        private DateTime selectedDate;
        public SupplierInvoiceForm()
        {
            _supplierInvoiceService = new SupplierInvoiceService();
            InitializeComponent();
            StatusCmb.SelectedIndex = 0;
            SupplierInvoiceGridUserControl.buttonGet += MyControl_ButtonClicked;
            SupplierInvoiceGridUserControl.dgvDoubleClick += MyControl_OpenDetails_Clicked;
            DateClnd.MaxSelectionCount = 1;
        }

        private void MyControl_OpenDetails_Clicked(object? sender, DataGridViewCellEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void MyControl_ButtonClicked(object? sender, EventArgs e)
        {
            
            IEnumerable<SupplierInvoice> query = _supplierInvoiceService.GetAll(SaleIDTxt.Text,SupplierIDTxt.Text,selectedDate, StatusCmb.Text);

            SupplierInvoiceGridUserControl.setDataGrid(query.ToList());
        }

        private void DateClnd_DateChanged(object sender, DateRangeEventArgs e)
        {
            selectedDate = DateClnd.SelectionStart;
        }
    }
}

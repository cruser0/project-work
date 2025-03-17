using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinformDotNetFramework.Entities.Filters;

namespace WinformDotNetFramework.Forms.control
{
    public partial class SearchSupplierInvoiceReport : UserControl
    {
        public SearchSupplierInvoiceReport()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }
        public TotalAmountSpentPerSupplierInvoiceFilter GetFilter()
        {
            TotalAmountSpentPerSupplierInvoiceFilter filter = new TotalAmountSpentPerSupplierInvoiceFilter()
            {
                SupplierCountry = string.IsNullOrEmpty(CountryTxt.Text) ? null : CountryTxt.Text,
                SupplierName = string.IsNullOrEmpty(NameTxt.Text) ? null : NameTxt.Text,
                Status = comboBox1.Text.Equals("All") ? null : comboBox1.Text,

            };
            if (DateFromClnd.Checked)
                filter.DateFrom = DateFromClnd.Value;
            else
                filter.DateFrom = null;
            if (DateToClnd.Checked)
                filter.DateTo = DateToClnd.Value;
            else
                filter.DateTo = null;
            if (!string.IsNullOrEmpty(SpentFromIntegerTxt.GetText()))
                filter.TotalSpentFrom = int.Parse(SpentFromIntegerTxt.GetText());
            else
                filter.TotalSpentFrom = null;
            if (!string.IsNullOrEmpty(SpentToIntegerTxt.GetText()))
                filter.TotalSpentTo = int.Parse(SpentToIntegerTxt.GetText());
            else
                filter.TotalSpentTo = null;
            return filter;
        }
        public bool IsFilterEmpty(TotalAmountSpentPerSupplierInvoiceFilter filter)
        {
            if (filter.SupplierCountry != null || filter.SupplierName != null || filter.Status != null || filter.DateFrom.HasValue || filter.DateTo.HasValue || filter.TotalSpentFrom != null || filter.TotalSpentTo != null)
                return false;
            else
                return true;
        }
    }
}

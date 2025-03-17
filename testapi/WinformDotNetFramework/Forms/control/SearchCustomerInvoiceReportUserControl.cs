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
    public partial class SearchCustomerInvoiceReportUserControl : UserControl
    {
        public SearchCustomerInvoiceReportUserControl()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }
        public TotalAmountGainedPerCustomerInvoiceFilter GetFilter()
        {
            TotalAmountGainedPerCustomerInvoiceFilter filter = new TotalAmountGainedPerCustomerInvoiceFilter()
            {
                CustomerCountry = string.IsNullOrEmpty(CountryTxt.Text)?null: CountryTxt.Text,
                CustomerName = string.IsNullOrEmpty(NameTxt.Text)?null: NameTxt.Text,
                Status=comboBox1.Text.Equals("All")?null:comboBox1.Text,
            };
            if (DateFromClnd.Checked)
                filter.DateFrom = DateFromClnd.Value;
            else
                filter.DateFrom = null;
            if (DateToClnd.Checked)
                filter.DateTo = DateToClnd.Value;
            else
                filter.DateTo = null;
            if (GainedFromIntegerTxt.GetText() != null)
                filter.TotalGainedFrom = int.Parse(GainedFromIntegerTxt.GetText());
            else
                filter.TotalGainedFrom = null;
            if (GainedToIntegerTxt.GetText() != null)
                filter.TotalGainedTo = int.Parse(GainedToIntegerTxt.GetText());
            else
                filter.TotalGainedTo = null;
            return filter;
        } 
        public bool IsFilterEmpty(TotalAmountGainedPerCustomerInvoiceFilter filter)
        {
            if (filter.CustomerCountry != null || filter.CustomerName != null || filter.Status != null || filter.DateFrom.HasValue || filter.DateTo.HasValue || filter.TotalGainedFrom != null || filter.TotalGainedTo != null)
                return false;
            else
                return true;
        }
    }
}

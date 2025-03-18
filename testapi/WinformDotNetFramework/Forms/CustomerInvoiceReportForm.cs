using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinformDotNetFramework.Forms.GridForms;

namespace WinformDotNetFramework.Forms
{
    public partial class CustomerInvoiceReportForm : ReportGridForm
    {
        public CustomerInvoiceReportForm()
        {
            InitializeComponent();
            DialogReport = "CustomerInvoice";
            CallDialogReport();
        }
    }
}

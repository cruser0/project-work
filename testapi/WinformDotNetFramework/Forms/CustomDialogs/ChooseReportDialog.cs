using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace WinformDotNetFramework.Forms.CustomDialog
{

    public enum ReportEnum
    {
        Sale,
        CustomerInvoice,
        SupplierInvoice,
    }
    public partial class ChooseReportDialog : Form
    {
        public ReportEnum ChoosenReport { get; set; }
        public ChooseReportDialog()
        {
            InitializeComponent();
        }

        private void OpenBtn_Click(object sender, EventArgs e)
        {
            if (CustomerInvoiceReportRadio.Checked)
            {
                ChoosenReport = ReportEnum.CustomerInvoice;
                DialogResult = DialogResult.OK;
                Close();
            }
            else if (SupplierInvoiceReportRadio.Checked)
            {
                ChoosenReport = ReportEnum.SupplierInvoice;
                DialogResult = DialogResult.OK;
                Close();
            }
            else if (SaleReportRadio.Checked)
            {
                ChoosenReport = ReportEnum.Sale;
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Select the report you want to open");
            }
        }
    }
}

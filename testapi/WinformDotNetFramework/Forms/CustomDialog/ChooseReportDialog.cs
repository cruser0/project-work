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

        private void button1_Click(object sender, EventArgs e)
        {
            if(sender is Button btn)
                switch (btn.Name)
                {
                    case "CustomerInvoiceBtn":
                        ChoosenReport = ReportEnum.CustomerInvoice;
                        DialogResult = DialogResult.OK;
                        Close();
                        break;
                    case "SupplierInvoiceBtn":
                        ChoosenReport = ReportEnum.SupplierInvoice;
                        DialogResult = DialogResult.OK;
                        Close();
                        break;
                    case "SaleBtn":
                        ChoosenReport = ReportEnum.Sale;
                        DialogResult = DialogResult.OK;
                        Close();
                        break;
                    default:
                        Close(); break;
                }
        }
    }
}

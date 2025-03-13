using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformDotNetFramework.Forms
{
    public partial class SaleReportForm : Form
    {
        public SaleReportForm()
        {
            InitializeComponent();

        }

        private void SaleReportForm_Load(object sender, EventArgs e)
        {

            this.ReportViewer.RefreshReport();
        }

        private void DockButton_Click(object sender, EventArgs e)
        {
            if (splitContainer1.Panel2.Width == 200)
                splitContainer1.SplitterDistance = this.Width - 25;
            else if(splitContainer1.Panel2.Width == 25)
                splitContainer1.SplitterDistance = splitContainer1.Width - 204;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            byte[] bytes = ReportViewer.LocalReport.Render(
           "PDF", null, out string mimeType, out string encoding,
           out string filenameExtension, out string[] streamIds,
           out Warning[] warnings);

            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Report.pdf");
            File.WriteAllBytes(filePath, bytes);

            MessageBox.Show("PDF generated successfully!");
        }
    }
}

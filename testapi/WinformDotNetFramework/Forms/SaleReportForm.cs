using Microsoft.Reporting.WinForms;
using System;
using System.IO;
using System.Windows.Forms;
using WinformDotNetFramework.Entities.Filters;
using WinformDotNetFramework.Services;

namespace WinformDotNetFramework.Forms
{
    public partial class SaleReportForm : Form
    {
        ProceduresService _procedureService;
        public SaleReportForm()
        {
            _procedureService = new ProceduresService();
            InitializeComponent();
        }

        private async void SaleReportForm_Load(object sender, EventArgs e)
        {
            
        }

        private void DockButton_Click(object sender, EventArgs e)
        {
            if (splitContainer1.Panel2.Width == 200)
                splitContainer1.SplitterDistance = this.Width - 25;
            else if (splitContainer1.Panel2.Width == 25)
                splitContainer1.SplitterDistance = splitContainer1.Width - 204;

        }

        private void PrfButton_click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "PDF Files|*.pdf",
                Title = "Save PDF File",
                FileName = "Report.pdf"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Cursor = Cursors.WaitCursor;
                    Application.DoEvents();

                    byte[] bytes = ReportViewer.LocalReport.Render(
                        "PDF", null, out string mimeType, out string encoding,
                        out string filenameExtension, out string[] streamIds,
                        out Warning[] warnings);

                    File.WriteAllBytes(saveFileDialog.FileName, bytes);

                    MessageBox.Show("PDF saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            }
        }

        private void PageTSTxt_Enter(object sender, EventArgs e)
        {

        }

        private async void SearchButton_Click(object sender, EventArgs e)
        {
            var list = await _procedureService.GetClassifySalesByProfit(new ClassifySalesByProfitFilter());
            ReportDataSource reportDataSource = new ReportDataSource { Name = "SaleByProfit", Value = list };


            ReportViewer.LocalReport.DataSources.Add(reportDataSource);
            ReportViewer.RefreshReport();
            ReportViewer.ZoomMode = ZoomMode.Percent;
            ZoomTSLbl.Text=ReportViewer.ZoomPercent.ToString()+"%";
        }

        private void EmptyReportTSB_Click(object sender, EventArgs e)
        {
            ReportViewer.Clear();
        }

        private void PrintPagePreviewBTS_Click(object sender, EventArgs e)
        {
            ReportViewer.SetDisplayMode(DisplayMode.PrintLayout);
        }

        private void ExcelTSB_Click(object sender, EventArgs e)
        {

        }

        private void DezoomTSB_Click(object sender, EventArgs e)
        {
            if(ReportViewer.ZoomPercent<400)
                ReportViewer.ZoomPercent += 5;
        }

        private void ZoomTSB_Click(object sender, EventArgs e)
        {
            if (ReportViewer.ZoomPercent > 0)
                ReportViewer.ZoomPercent -= 5;
        }
    }
}

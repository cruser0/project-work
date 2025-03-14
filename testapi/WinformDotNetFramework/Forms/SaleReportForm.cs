using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinformDotNetFramework.Entities;
using WinformDotNetFramework.Entities.Filters;
using WinformDotNetFramework.Forms.CustomDialog;
using WinformDotNetFramework.Procedures;
using WinformDotNetFramework.Services;

namespace WinformDotNetFramework.Forms
{
    public partial class SaleReportForm : Form
    {
        public string DialogReport { get; set; }
        ProceduresService _procedureService;
        private CustomerService _customerService;

        // Data collections for the report and subreports
        private List<ClassifySalesByProfit> _profitData = new List<ClassifySalesByProfit>();
        private List<Customer> _customerData = new List<Customer>();
        public SaleReportForm()
        {
            InitializeComponent();
            Init();
        }
        private void Init()
        {
            _procedureService = new ProceduresService();
            _customerService = new CustomerService();
            DisableTSItems();
            SetSearchVisibilityFalse();
        }

        private async void SaleReportForm_Load(object sender, EventArgs e)
        {
            ReportViewer.ProcessingMode = ProcessingMode.Local;
            ReportViewer.LocalReport.SubreportProcessing +=
                        new SubreportProcessingEventHandler(SubreportProcessingEventHandler);
            CallDialogReport();
        }
        

        private void DockButton_Click(object sender, EventArgs e)
        {
            if (splitContainer1.Panel2.Width != 25)
                splitContainer1.SplitterDistance = this.Width - 25;
            else
                splitContainer1.SplitterDistance = splitContainer1.Width - 236;

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

        private async void SearchButton_Click(object sender, EventArgs e)
        {
            ReportViewer.LocalReport.DataSources.Clear();
            _profitData = new List<ClassifySalesByProfit>();
            _customerData = new List<Customer>();

            await LoadReportData();
            ReportDataSource mainDataSource = new ReportDataSource()
            {
                Name = "SaleByProfit",
                Value = _profitData
            };
            ReportViewer.LocalReport.DataSources.Add(mainDataSource);
            ReportViewer.RefreshReport();
            ReportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            ReportViewer.ZoomMode = ZoomMode.Percent;
            ReportViewer.ZoomPercent = 130;
            ZoomTSLbl.Text=ReportViewer.ZoomPercent.ToString()+"%";
            if (!PdfTSB.Enabled)
                EnableTSItems();
        }
      

        private void EmptyReportTSB_Click(object sender, EventArgs e)
        {
            ReportViewer.Clear();
            toolStrip2.Enabled=false;
        }

        private void PrintPagePreviewBTS_Click(object sender, EventArgs e)
        {
            if (ReportViewer.DisplayMode!= DisplayMode.PrintLayout)
                ReportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            else
                ReportViewer.SetDisplayMode(DisplayMode.Normal);
            ReportViewer.ZoomMode = ZoomMode.Percent;
            ReportViewer.ZoomPercent = 130;
        }

        private void ExcelTSB_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "EXCEL Files|*.xlsx",
                Title = "Save EXCEL File",
                FileName = "Report.xlsx"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Cursor = Cursors.WaitCursor;
                    Application.DoEvents();

                    byte[] bytes = ReportViewer.LocalReport.Render(
                        "EXCELOPENXML", null, out string mimeType, out string encoding,
                        out string filenameExtension, out string[] streamIds,
                        out Warning[] warnings);

                    File.WriteAllBytes(saveFileDialog.FileName, bytes);

                    MessageBox.Show("Excel saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void DezoomTSB_Click(object sender, EventArgs e)
        {
            if (ReportViewer.ZoomPercent > 30)
            {
                ReportViewer.ZoomPercent -= 5;
                ZoomTSLbl.Text = ReportViewer.ZoomPercent.ToString() + "%";

            }
        }

        private void ZoomTSB_Click(object sender, EventArgs e)
        {
            if (ReportViewer.ZoomPercent < 400)
            {
                ReportViewer.ZoomPercent += 5;
                ZoomTSLbl.Text = ReportViewer.ZoomPercent.ToString()+"%";
            }
        }
        void SubreportProcessingEventHandler(object sender, SubreportProcessingEventArgs e)
        {

            //if (searchSaleReport1.checkBox1.Checked)
            //    e.DataSources.Add(new ReportDataSource("SaleByProfit", _profitData));
            //else
            //    e.DataSources.Add(new ReportDataSource("SaleByProfit", new List<ClassifySalesByProfit>()));

            //if (searchSaleReport1.checkBox2.Checked)
            //    e.DataSources.Add(new ReportDataSource("Customers", _customerData));
            //else
            //    e.DataSources.Add(new ReportDataSource("Customers", new List<Customer>()));

            //if (searchSaleReport1.checkBox3.Checked)
            //    e.DataSources.Add(new ReportDataSource("SaleTemporal", _profitData));
            //else
            //    e.DataSources.Add(new ReportDataSource("SaleTemporal", new List<ClassifySalesByProfit>()));

        }

        private void ChooseReportTSB_Click(object sender, EventArgs e)
        {
            CallDialogReport();
            ReportViewer.Clear();
            DisableTSItems();
        }
        private void DisableTSItems()
        {
            DezoomTSB.Enabled = false;
            ZoomTSB.Enabled = false;
            ExcelTSB.Enabled = false;
            PdfTSB.Enabled = false;
            EmptyReportTSB.Enabled = false;
            PrintPagePreviewBTS.Enabled = false;
        }
        private void EnableTSItems()
        {
            DezoomTSB.Enabled = true;
            ZoomTSB.Enabled = true;
            ExcelTSB.Enabled = true;
            PdfTSB.Enabled = true;
            EmptyReportTSB.Enabled = true;
            PrintPagePreviewBTS.Enabled = true;
        }
        private void SetSearchVisibilityFalse()
        {
            searchSupplierInvoiceReport1.Visible = false;
            searchSaleReport1.Visible = false;
            searchCustomerInvoiceReportUserControl1.Visible = false;
        }
        private async Task LoadReportData()
        {
            var tasks = new List<Task>();

            //if (true || searchSaleReport1.checkBox1.Checked || searchSaleReport1.checkBox3.Checked)  // Main report always needs this data
            //{
            //    var profitTask = LoadProfitData();
            //    tasks.Add(profitTask);
            //}

            //if (searchSaleReport1.checkBox2.Checked)
            //{
            //    var customerTask = LoadCustomerData();
            //    tasks.Add(customerTask);
            //}

            await Task.WhenAll(tasks);
        }

        private async Task LoadProfitData()
        {
            var filter = new ClassifySalesByProfitFilter();
            _profitData = await _procedureService.GetClassifySalesByProfit(filter);
        }

        private async Task LoadCustomerData()
        {
            var filter = new CustomerFilter();
            var customers = await _customerService.GetAll(filter);
            _customerData = customers as List<Customer> ?? new List<Customer>(customers);
        }
        private void CallDialogReport()
        {
            ChooseReportDialog dialog = new ChooseReportDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                DialogReport = dialog.ChoosenReport.ToString();
            }
            dialog.Close();
            ReportViewer.Clear();
            searchSupplierInvoiceReport1.Visible = false;
            searchSaleReport1.Visible = false;
            searchCustomerInvoiceReportUserControl1.Visible = false;
            switch (DialogReport)
            {
                case "Sale":
                    ReportViewer.LocalReport.ReportEmbeddedResource = "WinformDotNetFramework.Reports.ReportSales.rdlc";
                    SetSearchVisibilityFalse();
                    searchSaleReport1.Visible = true;
                    break;
                case "CustomerInvoice":
                    ReportViewer.LocalReport.ReportEmbeddedResource = "WinformDotNetFramework.Reports.SaleProfitReport.rdlc";
                    SetSearchVisibilityFalse();
                    searchCustomerInvoiceReportUserControl1.Visible = true;
                    break;
                case "SupplierInvoice":
                    ReportViewer.LocalReport.ReportEmbeddedResource = "";
                    SetSearchVisibilityFalse();
                    searchSupplierInvoiceReport1.Visible = true;
                    break;
                default:
                    if (string.IsNullOrEmpty(DialogReport))
                    {
                        MessageBox.Show("No report was choosen");
                    }
                    break;
            }
        }
    }
}

using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinformDotNetFramework.Entities.Filters;
using WinformDotNetFramework.Procedures;
using WinformDotNetFramework.Services;

namespace WinformDotNetFramework.Forms.GridForms
{
    public partial class ReportGridForm : Form
    {
        public string DialogReport { get; set; }
        ProceduresService _procedureService;
        private bool saleFiltersVisible;
        private bool customerInvoiceFiltersVisible;
        private bool supplierInvoiceFiltersVisible;
        List<Task> tasks = new List<Task>();

        // Data collections for the report and subreports
        private List<ClassifySalesByProfit> _saleData = new List<ClassifySalesByProfit>();
        private List<TotalAmountGainedPerCustomerInvoice> _customerInvoiceData = new List<TotalAmountGainedPerCustomerInvoice>();
        private List<TotalAmountSpentPerSupplierInvoice> _supplierInvoiceData = new List<TotalAmountSpentPerSupplierInvoice>();
        public ReportGridForm()
        {
            InitializeComponent();
            Init();
        }
        private void Init()
        {
            _procedureService = new ProceduresService();
            DisableTSItems();
            SetSearchVisibilityFalse();
        }

        private async void SaleReportForm_Load(object sender, EventArgs e)
        {
            ReportViewer.ProcessingMode = ProcessingMode.Local;
            ReportViewer.LocalReport.SubreportProcessing +=
                        new SubreportProcessingEventHandler(SubreportProcessingEventHandler);
            tasks.Add(_procedureService.GetClassifySalesByProfit(new ClassifySalesByProfitFilter()));
            tasks.Add(_procedureService.GetTotalAmountGainedPerCustomerInvoice(new TotalAmountGainedPerCustomerInvoiceFilter()));
            tasks.Add(_procedureService.GetTotalAmountSpentPerSupplierInvoice(new TotalAmountSpentPerSupplierInvoiceFilter()));

        }


        private void DockButton_Click(object sender, EventArgs e)
        {
            if (splitContainer1.Panel2.Width != 25)
            {
                splitContainer1.SplitterDistance = this.Width - 25;
                DockButton.Text = "<";
                saleFiltersVisible = searchSaleReport1.Visible;
                customerInvoiceFiltersVisible = searchCustomerInvoiceReportUserControl1.Visible;
                supplierInvoiceFiltersVisible = searchSupplierInvoiceReport1.Visible;
                SetSearchVisibilityFalse();
            }
            else
            {
                splitContainer1.SplitterDistance = splitContainer1.Width - 236;
                DockButton.Text = ">";
                searchSaleReport1.Visible = saleFiltersVisible;
                searchCustomerInvoiceReportUserControl1.Visible = customerInvoiceFiltersVisible;
                searchSupplierInvoiceReport1.Visible = supplierInvoiceFiltersVisible;
            }

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
            _saleData = new List<ClassifySalesByProfit>();
            _customerInvoiceData = new List<TotalAmountGainedPerCustomerInvoice>();
            _supplierInvoiceData = new List<TotalAmountSpentPerSupplierInvoice>();
            await LoadReportData();
            ReportViewer.RefreshReport();
            ReportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            ReportViewer.ZoomMode = ZoomMode.Percent;
            ReportViewer.ZoomPercent = 130;
            ZoomTSLbl.Text = ReportViewer.ZoomPercent.ToString() + "%";
            if (!PdfTSB.Enabled)
                EnableTSItems();
        }


        private void EmptyReportTSB_Click(object sender, EventArgs e)
        {
            ReportViewer.Clear();
            toolStrip2.Enabled = false;
        }

        private void PrintPagePreviewBTS_Click(object sender, EventArgs e)
        {
            if (ReportViewer.DisplayMode != DisplayMode.PrintLayout)
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
                ZoomTSLbl.Text = ReportViewer.ZoomPercent.ToString() + "%";
            }
        }
        void SubreportProcessingEventHandler(object sender, SubreportProcessingEventArgs e)
        {

            //if (searchSaleReport1.checkBox1.Checked)
            //    e.DataSources.Add(new ReportDataSource("SaleByProfit", _profitData));
            //else
            //    e.DataSources.Add(new ReportDataSource("SaleByProfit", new List<ClassifySalesByProfit>()));
            if (IsIndexSelected(searchSaleReport1.GrapCBL, 0))
                e.DataSources.Add(new ReportDataSource("SaleCountByStatus", _saleData));
            else
                e.DataSources.Add(new ReportDataSource("SaleCountByStatus", new List<ClassifySalesByProfit>()));
            if (IsIndexSelected(searchSaleReport1.GrapCBL, 1))
                e.DataSources.Add(new ReportDataSource("SaleCountByCountry", _saleData));
            else
                e.DataSources.Add(new ReportDataSource("SaleCountByCountry", new List<ClassifySalesByProfit>()));
            if (IsIndexSelected(searchSaleReport1.GrapCBL, 2))
                e.DataSources.Add(new ReportDataSource("SaleCountByMargin", _saleData));
            else
                e.DataSources.Add(new ReportDataSource("SaleCountByMargin", new List<ClassifySalesByProfit>()));
            if (IsIndexSelected(searchSaleReport1.GrapCBL, 3))
                e.DataSources.Add(new ReportDataSource("SaleCountByDate", _saleData));
            else
                e.DataSources.Add(new ReportDataSource("SaleCountByDate", new List<ClassifySalesByProfit>()));
            if (IsIndexSelected(searchSaleReport1.GrapCBL, 4))
                e.DataSources.Add(new ReportDataSource("SaleProfitSumByDate", _saleData));
            else
                e.DataSources.Add(new ReportDataSource("SaleProfitSumByDate", new List<ClassifySalesByProfit>()));
            if (IsIndexSelected(searchSaleReport1.GrapCBL, 5))
                e.DataSources.Add(new ReportDataSource("SaleTotalRevenueSpentSumByDate", _saleData));
            else
                e.DataSources.Add(new ReportDataSource("SaleTotalRevenueSpentSumByDate", new List<ClassifySalesByProfit>()));
            if (IsIndexSelected(searchSaleReport1.GrapCBL, 6))
                e.DataSources.Add(new ReportDataSource("SaleProfitSumByCountry", _saleData));
            else
                e.DataSources.Add(new ReportDataSource("SaleProfitSumByCountry", new List<ClassifySalesByProfit>()));

            if (IsIndexSelected(searchSaleReport1.GrapCBL, 7))
                e.DataSources.Add(new ReportDataSource("SaleTotalRevenueSpentSumByCountry", _saleData));
            else
                e.DataSources.Add(new ReportDataSource("SaleTotalRevenueSpentSumByCountry", new List<ClassifySalesByProfit>()));



            if (IsIndexSelected(searchCustomerInvoiceReportUserControl1.GrapCBL, 0))
                e.DataSources.Add(new ReportDataSource("CustomerInvoiceCountByStatus", _customerInvoiceData));
            else
                e.DataSources.Add(new ReportDataSource("CustomerInvoiceCountByStatus", new List<TotalAmountGainedPerCustomerInvoice>()));
            if (IsIndexSelected(searchCustomerInvoiceReportUserControl1.GrapCBL, 1))
                e.DataSources.Add(new ReportDataSource("CustomerInvoiceCountByCountry", _customerInvoiceData));
            else
                e.DataSources.Add(new ReportDataSource("CustomerInvoiceCountByCountry", new List<TotalAmountGainedPerCustomerInvoice>()));
            if (IsIndexSelected(searchCustomerInvoiceReportUserControl1.GrapCBL, 2))
                e.DataSources.Add(new ReportDataSource("CustomerInvoiceCountByDate", _customerInvoiceData));
            else
                e.DataSources.Add(new ReportDataSource("CustomerInvoiceCountByDate", new List<TotalAmountGainedPerCustomerInvoice>()));
            if (IsIndexSelected(searchCustomerInvoiceReportUserControl1.GrapCBL, 3))
                e.DataSources.Add(new ReportDataSource("CustomerInvoiceTotalGainedSumByDate", _customerInvoiceData));
            else
                e.DataSources.Add(new ReportDataSource("CustomerInvoiceTotalGainedSumByDate", new List<TotalAmountGainedPerCustomerInvoice>()));
            if (IsIndexSelected(searchCustomerInvoiceReportUserControl1.GrapCBL, 4))
                e.DataSources.Add(new ReportDataSource("CustomerInvoiceTotalGainedSumByCountry", _customerInvoiceData));
            else
                e.DataSources.Add(new ReportDataSource("CustomerInvoiceTotalGainedSumByCountry", new List<TotalAmountGainedPerCustomerInvoice>()));


            if (IsIndexSelected(searchSupplierInvoiceReport1.GrapCBL, 0))
                e.DataSources.Add(new ReportDataSource("SupplierInvoiceCountByCountry", _supplierInvoiceData));
            else
                e.DataSources.Add(new ReportDataSource("SupplierInvoiceCountByCountry", new List<TotalAmountSpentPerSupplierInvoice>()));
            if (IsIndexSelected(searchSupplierInvoiceReport1.GrapCBL, 1))
                e.DataSources.Add(new ReportDataSource("SupplierInvoiceCountByStatus", _supplierInvoiceData));
            else
                e.DataSources.Add(new ReportDataSource("SupplierInvoiceCountByStatus", new List<TotalAmountSpentPerSupplierInvoice>()));
            if (IsIndexSelected(searchSupplierInvoiceReport1.GrapCBL, 2))
                e.DataSources.Add(new ReportDataSource("SupplierInvoiceCountByDate", _supplierInvoiceData));
            else
                e.DataSources.Add(new ReportDataSource("SupplierInvoiceCountByDate", new List<TotalAmountSpentPerSupplierInvoice>()));
            if (IsIndexSelected(searchSupplierInvoiceReport1.GrapCBL, 3))
                e.DataSources.Add(new ReportDataSource("SupplierInvoiceTotalSpentSumByDate", _supplierInvoiceData));
            else
                e.DataSources.Add(new ReportDataSource("SupplierInvoiceTotalSpentSumByDate", new List<TotalAmountSpentPerSupplierInvoice>()));
            if (IsIndexSelected(searchSupplierInvoiceReport1.GrapCBL, 4))
                e.DataSources.Add(new ReportDataSource("SupplierInvoiceTotalSpentSumByCountry", _supplierInvoiceData));
            else
                e.DataSources.Add(new ReportDataSource("SupplierInvoiceTotalSpentSumByCountry", new List<TotalAmountSpentPerSupplierInvoice>()));

        }
        private bool IsIndexSelected(CheckedListBox listBox, int index)
        {
            if (listBox.InvokeRequired)
            {
                return (bool)listBox.Invoke(new Func<bool>(() => listBox.CheckedIndices.Contains(index)));
            }
            else
            {
                return listBox.CheckedIndices.Contains(index);
            }
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
            ZoomTSLbl.Enabled = false;
        }
        private void EnableTSItems()
        {
            DezoomTSB.Enabled = true;
            ZoomTSB.Enabled = true;
            ExcelTSB.Enabled = true;
            PdfTSB.Enabled = true;
            EmptyReportTSB.Enabled = true;
            PrintPagePreviewBTS.Enabled = true;
            ZoomTSLbl.Enabled=true;
        }
        private void SetSearchVisibilityFalse()
        {
            searchSupplierInvoiceReport1.Visible = false;
            searchSaleReport1.Visible = false;
            searchCustomerInvoiceReportUserControl1.Visible = false;
        }
        private async Task LoadReportData()
        {

            if (DialogReport.Equals("Sale"))  // Main report always needs this data
            {
                await LoadSaleData();
                ReportDataSource mainDataSource = new ReportDataSource()
                {
                    Name = "SaleByProfit",
                    Value = _saleData
                };
                ReportViewer.LocalReport.DataSources.Add(mainDataSource);
            }

            if (DialogReport.Equals("CustomerInvoice"))
            {
                await LoadCustomerInvoiceData();
                ReportDataSource mainDataSource = new ReportDataSource()
                {
                    Name = "CustomerInvoiceData",
                    Value = _customerInvoiceData
                };
                ReportViewer.LocalReport.DataSources.Add(mainDataSource);
            }

            if (DialogReport.Equals("SupplierInvoice"))
            {
                await LoadSupplierInvoiceData();
                ReportDataSource mainDataSource = new ReportDataSource()
                {
                    Name = "SupplierInvoiceData",
                    Value = _supplierInvoiceData
                };
                ReportViewer.LocalReport.DataSources.Add(mainDataSource);
            }

        }


        private async Task LoadSaleData()
        {
            var filter = searchSaleReport1.GetFilter();
            if (searchSaleReport1.IsFilterEmpty(filter))
                _saleData = await (Task<List<ClassifySalesByProfit>>)tasks[0];
            else
                _saleData = await _procedureService.GetClassifySalesByProfit(filter);
        }

        private async Task LoadCustomerInvoiceData()
        {
            var filter = searchCustomerInvoiceReportUserControl1.GetFilter();
            if (searchCustomerInvoiceReportUserControl1.IsFilterEmpty(filter))
                _customerInvoiceData = await (Task<List<TotalAmountGainedPerCustomerInvoice>>)tasks[1];
            else
                _customerInvoiceData = await _procedureService.GetTotalAmountGainedPerCustomerInvoice(filter);
        }

        private async Task LoadSupplierInvoiceData()
        {
            var filter = searchSupplierInvoiceReport1.GetFilter();
            if (searchSupplierInvoiceReport1.IsFilterEmpty(filter))
                _supplierInvoiceData = await (Task<List<TotalAmountSpentPerSupplierInvoice>>)tasks[2];
            _supplierInvoiceData = await _procedureService.GetTotalAmountSpentPerSupplierInvoice(filter);
        }
        public void CallDialogReport()
        {
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
                    ReportViewer.LocalReport.ReportEmbeddedResource = "WinformDotNetFramework.Reports.ReportCustomerInvoices.rdlc";
                    SetSearchVisibilityFalse();
                    searchCustomerInvoiceReportUserControl1.Visible = true;
                    break;
                case "SupplierInvoice":
                    ReportViewer.LocalReport.ReportEmbeddedResource = "WinformDotNetFramework.Reports.ReportSupplierInvoices.rdlc";
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

        private void SaleReportForm_Shown(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(DialogReport))
            {
                this.Close();
            }
        }
    }
}

using Entity_Validator.Entity.DTO;
using Entity_Validator.Entity.Filters;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using WinformDotNetFramework.Services;

namespace WinformDotNetFramework
{
    public partial class PdfInvoiceForm : Form
    {
        CustomerInvoiceService _customerInvoiceService = new CustomerInvoiceService();
        CustomerInvoiceCostService _customerInvoiceCostService = new CustomerInvoiceCostService();
        SaleService _saleService = new SaleService();
        LocalReport report = new LocalReport()
        {
            ReportEmbeddedResource = "WinformDotNetFramework.Reports.ReportPaidInvoice.rdlc",
            EnableHyperlinks = true,
        };

        SaleCustomerDTO saleCustomerDTO;
        CustomerInvoiceDTOGet invoice;
        public PdfInvoiceForm(int saleId, CustomerInvoiceDTOGet customerInvoice)
        {
            invoice = customerInvoice;
            report.Refresh();
            InitializeComponent();
            Init(saleId);
        }

        private async void Init(int saleId)
        {
            saleCustomerDTO = await _saleService.GetById(saleId);

            CustomerInvoiceCostFilter cic_filter = new CustomerInvoiceCostFilter()
            {
                CustomerInvoiceCostCustomerInvoiceCode = invoice.CustomerInvoiceCode
            };
            var costs = await _customerInvoiceCostService.GetAll(cic_filter);

            // Convert single objects to lists/collections that implement IEnumerable
            var invoiceList = new List<CustomerInvoiceDTOGet> { invoice };
            var saleCustomerList = new List<SaleCustomerDTO> { saleCustomerDTO };

            ReportDataSource CustomerInvoice = new ReportDataSource()
            {
                Name = "CustomerInvoice",
                Value = invoiceList  // Using list instead of single object
            };
            ReportDataSource SaleCustomer = new ReportDataSource()
            {
                Name = "SaleCustomer",
                Value = saleCustomerList  // Using list instead of single object
            };
            ReportDataSource CustomerInvoiceCost = new ReportDataSource()
            {
                Name = "CustomerInvoiceCost",
                Value = costs  // This should already be a collection
            };

            ReportParameter param = new ReportParameter("UrlPay",
    "http://localhost:5069/paypage.html?name=" + saleCustomerDTO.CustomerName + "&country=" + saleCustomerDTO.Country);

            report.SetParameters(new ReportParameter[] { param });

            report.DataSources.Add(CustomerInvoice);
            report.DataSources.Add(SaleCustomer);
            report.DataSources.Add(CustomerInvoiceCost);
        }

        private void PrfButton_click(object sender, EventArgs e)
        {

            try
            {
                Cursor = Cursors.WaitCursor;
                Application.DoEvents();

                string FileName = $"{invoice.CustomerInvoiceCode}.pdf";

                byte[] bytes = report.Render(
                    "PDF", null, out string mimeType, out string encoding,
                    out string filenameExtension, out string[] streamIds,
                    out Warning[] warnings);

                string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FileName);

                File.WriteAllBytes(filePath, bytes);

                MessageBox.Show($"{FileName} saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
}


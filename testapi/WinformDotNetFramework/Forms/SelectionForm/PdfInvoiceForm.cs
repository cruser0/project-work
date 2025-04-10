using Entity_Validator.Entity.DTO;
using Entity_Validator.Entity.Filters;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinformDotNetFramework.Services;

namespace WinformDotNetFramework
{
    public partial class PdfInvoiceForm : Form
    {
        CustomerInvoiceCostService _customerInvoiceCostService = new CustomerInvoiceCostService();
        SaleService _saleService = new SaleService();
        EmailService _emailService = new EmailService();
        CustomerUserService _customerUserService = new CustomerUserService();
        LocalReport report = new LocalReport()
        {
            ReportEmbeddedResource = "WinformDotNetFramework.Reports.ReportPaidInvoice.rdlc",
            EnableHyperlinks = true,
        };
        SaleCustomerDTO saleCustomerDTO;
        CustomerInvoiceDTOGet invoice;
        string link;

        public PdfInvoiceForm(int saleId, CustomerInvoiceDTOGet customerInvoice)
        {
            invoice = customerInvoice;
            report.Refresh();
            InitializeComponent();
            Init(saleId);
            label2.Text = "admin@localhost.com";
            ToCCMB.Cmbx.SetTiltes("To");
            customTextBoxUserControl1.SetPropName("Subject");
        }

        private async void Init(int saleId)
        {
            saleCustomerDTO = await _saleService.GetById(saleId);
            CustomerInvoiceCostFilter cic_filter = new CustomerInvoiceCostFilter()
            {
                CustomerInvoiceCostCustomerInvoiceCode = invoice.CustomerInvoiceCode
            };
            var costs = await _customerInvoiceCostService.GetAll(cic_filter);

            var invoiceList = new List<CustomerInvoiceDTOGet> { invoice };
            var saleCustomerList = new List<SaleCustomerDTO> { saleCustomerDTO };

            ReportDataSource CustomerInvoice = new ReportDataSource()
            {
                Name = "CustomerInvoice",
                Value = invoiceList
            };

            ReportDataSource SaleCustomer = new ReportDataSource()
            {
                Name = "SaleCustomer",
                Value = saleCustomerList
            };

            ReportDataSource CustomerInvoiceCost = new ReportDataSource()
            {
                Name = "CustomerInvoiceCost",
                Value = costs
            };

            link = "http://localhost:5069/paypage.html?bol=" + saleCustomerDTO.BoLnumber + "&bk=" + saleCustomerDTO.BookingNumber;
            ReportParameter param = new ReportParameter("UrlPay", link);

            report.SetParameters(new ReportParameter[] { param });
            report.DataSources.Add(CustomerInvoice);
            report.DataSources.Add(SaleCustomer);
            report.DataSources.Add(CustomerInvoiceCost);
        }

        private async void PrfButton_click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                Application.DoEvents();
                string fileName = $"{invoice.CustomerInvoiceCode}.pdf";
                byte[] pdfBytes = report.Render(
                    "PDF", null, out string mimeType, out string encoding,
                    out string filenameExtension, out string[] streamIds,
                    out Warning[] warnings);

                // Converti PDF in base64
                string base64Pdf = Convert.ToBase64String(pdfBytes);

                EmailDTO email = new EmailDTO()
                {
                    Body = BodyTxt.Text,
                    FileName = fileName,
                    PdfContent = base64Pdf,
                    To = ToCCMB.Cmbx.PropTxt.Text,
                    Subject = customTextBoxUserControl1.PropTxt.Text,
                    Link = link
                };

                try
                {
                    var ret = await _emailService.Create(email);
                    MessageBox.Show(ret.Body);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(Text, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

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

        public async Task SetList()
        {

            var listFiltered = await _customerUserService.GetAll(new CustomerUserFilter()
            {
                CustomerUserEmail = ToCCMB.Cmbx.PropTxt.Text,
                CustomerName = saleCustomerDTO.CustomerName,
                CustomerCountry = saleCustomerDTO.Country
            });

            var listItems = listFiltered.Select(x => x.Email).ToList();
            ToCCMB.listItemsDropCmbx = listItems;
        }
    }
}
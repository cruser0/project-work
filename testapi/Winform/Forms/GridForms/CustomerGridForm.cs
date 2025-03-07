using API.Models.Filters;
using Winform.Entities;
using Winform.Entities.Preference;
using Winform.Forms.AddForms;
using Winform.Services;
using ClosedXML.Excel;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System.Data;

namespace Winform.Forms
{
    public partial class CustomerGridForm : Form
    {
        string name;
        string country;
        int status;
        DateTime? dateFrom;
        DateTime? dateTo;

        private CustomerService _customerService;
        int pages;
        double itemsPage = 10.0;
        Form _father;
        Task<ICollection<Customer>> getAllNotFiltered;
        Task<int> countNotFiltered;
        Task<CustomerDGV> getFav;
        private UserService _userService;
        public CustomerGridForm()
        {
            Init();
        }

        public CustomerGridForm(CreateSaleForm father)
        {
            _father = father;
            Init();
        }

        private async void Init()
        {
            _customerService = new CustomerService();
            _userService = new UserService();


            InitializeComponent();
            pages = (int)Math.Ceiling(await _customerService.Count(new CustomerFilter()) / itemsPage);
            RightSideBar.searchBtnEvent += MyControl_ButtonClicked;

            PaginationUserControl.SingleRightArrowEvent += PaginationUserControl_SingleRightArrowEvent;
            PaginationUserControl.DoubleRightArrowEvent += PaginationUserControl_DoubleRightArrowEvent;
            PaginationUserControl.DoubleLeftArrowEvent += PaginationUserControl_DoubleLeftArrowEvent;
            PaginationUserControl.SingleLeftArrowEvent += PaginationUserControl_SingleLeftArrowEvent;

            comboBox1.SelectedIndex = 1;
            PaginationUserControl.Visible = false;
            PaginationUserControl.SetMaxPage(pages.ToString());
            PaginationUserControl.CurrentPage = 1;
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());
            CustomerDgv.ContextMenuStrip = RightClickDgv;
            if (!UtilityFunctions.IsAuthorized(new[] { "CustomerAdmin", "Admin" }))
            {
                CustomerIDTsmi.Visible = false;
                CustomerOriginalIDTsmi.Visible = false;
            }
        }

        private async void MyControl_ButtonClicked(object sender, EventArgs e)
        {
            PaginationUserControl.CurrentPage = 1;
            name = NameTxt.Text;
            country = CountryTxt.Text;
            status = comboBox1.SelectedIndex;
            dateFrom = DateFromClnd.Checked ? DateFromClnd.Value : null;
            dateTo = DateToClnd.Checked ? DateToClnd.Value : null;

            CustomerFilter filter = new CustomerFilter
            {
                CustomerName = name,
                CustomerCountry = country,
                CustomerDeprecated = status switch
                {
                    1 => false,
                    2 => true,
                    _ => null
                },
                CustomerCreatedDateFrom = dateFrom,
                CustomerCreatedDateTo = dateTo,
                CustomerPage = PaginationUserControl.CurrentPage

            };
            CustomerFilter filterPage = new CustomerFilter
            {
                CustomerName = name,
                CustomerCountry = country,
                CustomerDeprecated = status switch
                {
                    1 => false,
                    2 => true,
                    _ => null
                },
                CustomerCreatedDateFrom = dateFrom,
                CustomerCreatedDateTo = dateTo
            };


            var query = _customerService.GetAll(filter);
            var totalCount = _customerService.Count(filterPage);
            await Task.WhenAll(query, totalCount);
            IEnumerable<Customer> query1 = await query;
            CustomerDgv.DataSource = query1.ToList();
            PaginationUserControl.maxPage = ((int)Math.Ceiling((double)await totalCount / itemsPage)).ToString();
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());

        }

        private async Task SetCheckBoxes()
        {
            await Task.WhenAll(getFav, countNotFiltered, getAllNotFiltered);
            IEnumerable<Customer> query = await getAllNotFiltered;
            PaginationUserControl.maxPage = ((int)Math.Ceiling((double)await countNotFiltered / itemsPage)).ToString();
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());
            CustomerDgv.DataSource = query.ToList();
            CustomerDGV cdgv = await getFav;
            CustomerCountryTsmi.Checked = cdgv.ShowCountry;
            CustomerDateTsmi.Checked = cdgv.ShowDate;
            CustomerIDTsmi.Checked = cdgv.ShowID;
            CustomerStatusTsmi.Checked = cdgv.ShowStatus;
            CustomerOriginalIDTsmi.Checked = cdgv.ShowOriginalID;
            CustomerNameTsmi.Checked = cdgv.ShowName;
            PaginationUserControl.Visible = true;
            CustomerDgv.Columns["CustomerName"].Visible = cdgv.ShowName;
            CustomerDgv.Columns["Country"].Visible = cdgv.ShowCountry;
            CustomerDgv.Columns["CreatedAt"].Visible = cdgv.ShowDate;
            CustomerDgv.Columns["OriginalID"].Visible = cdgv.ShowOriginalID;
            CustomerDgv.Columns["Deprecated"].Visible = cdgv.ShowStatus;
            CustomerDgv.Columns["CustomerID"].Visible = CustomerIDTsmi.Checked;
        }
        private async void MyControl_ButtonClicked_Pagination(object sender, EventArgs e)
        {
            if (dateFrom != null)
                DateFromClnd.Checked = true;
            if (dateTo != null)
                DateToClnd.Checked = true;


            CustomerFilter filter = new CustomerFilter
            {
                CustomerName = name,
                CustomerCountry = country,
                CustomerDeprecated = status switch
                {
                    1 => false,
                    2 => true,
                    _ => null
                },
                CustomerCreatedDateFrom = dateFrom,
                CustomerCreatedDateTo = dateTo,
                CustomerPage = PaginationUserControl.CurrentPage
            };

            IEnumerable<Customer> query = await _customerService.GetAll(filter);
            CustomerDgv.DataSource = query.ToList();
        }

        private void PaginationUserControl_SingleLeftArrowEvent(object? sender, EventArgs e)
        {
            if (PaginationUserControl.CurrentPage <= 1)
                return;
            PaginationUserControl.CurrentPage = PaginationUserControl.CurrentPage - 1;
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());
            MyControl_ButtonClicked_Pagination(sender, e);
        }

        private void PaginationUserControl_DoubleLeftArrowEvent(object? sender, EventArgs e)
        {

            PaginationUserControl.CurrentPage = 1;
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());
            MyControl_ButtonClicked_Pagination(sender, e);
        }

        private void PaginationUserControl_DoubleRightArrowEvent(object? sender, EventArgs e)
        {
            PaginationUserControl.CurrentPage = int.Parse(PaginationUserControl.GetmaxPage());
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());
            MyControl_ButtonClicked_Pagination(sender, e);
        }

        private void PaginationUserControl_SingleRightArrowEvent(object? sender, EventArgs e)
        {
            if (PaginationUserControl.CurrentPage >= int.Parse(PaginationUserControl.GetmaxPage()))
                return;
            PaginationUserControl.CurrentPage++;
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());
            MyControl_ButtonClicked_Pagination(sender, e);

        }



        public virtual void MyControl_OpenDetails_Clicked(object sender, DataGridViewCellEventArgs e)
        {

            if (sender is DataGridView dgv)
            {
                if (_father is CreateSaleForm csf)
                {
                    csf.SetCustomerID(dgv.CurrentRow.Cells["CustomerID"].Value.ToString());
                }
            }
        }

        public void CustomerGridForm_Resize(object sender, EventArgs e)
        {

            panel5.Location = new System.Drawing.Point((Width - panel5.Width) / 2, 0);
            PaginationUserControl.Location = new System.Drawing.Point((panel5.Width - PaginationUserControl.Width) / 2, (panel5.Height - PaginationUserControl.Height) / 2);
            int newHeight = (int)((Height - TextBoxesRightPanel.Top) * 0.9);
            if (TextBoxesRightPanel.Height != newHeight)
            {
                TextBoxesRightPanel.Height = newHeight;
            }

        }

        private void CustomerDgv_RightClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hitTest = CustomerDgv.HitTest(e.X, e.Y);
                if (hitTest.RowIndex >= 0)
                {
                    RightClickDgv.Show(CustomerDgv, e.Location);
                }
            }
        }

        private async void ContextMenuStripCheckEvent(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem tsmi)
            {
                string name = tsmi.Name;
                switch (name)
                {
                    case "CustomerIDTsmi":
                        CustomerDgv.Columns["CustomerID"].Visible = tsmi.Checked;
                        break;
                    case "CustomerNameTsmi":
                        CustomerDgv.Columns["CustomerName"].Visible = tsmi.Checked;
                        break;
                    case "CustomerCountryTsmi":
                        CustomerDgv.Columns["Country"].Visible = tsmi.Checked;
                        break;
                    case "CustomerDateTsmi":
                        CustomerDgv.Columns["CreatedAt"].Visible = tsmi.Checked;
                        break;
                    case "CustomerOriginalIDTsmi":
                        CustomerDgv.Columns["OriginalID"].Visible = tsmi.Checked;
                        break;
                    case "CustomerStatusTsmi":
                        CustomerDgv.Columns["Deprecated"].Visible = tsmi.Checked;
                        break;
                    default:
                        break;
                }
                CustomerDGV cdgv = new CustomerDGV
                {
                    ShowDate = CustomerDateTsmi.Checked,
                    ShowID = CustomerIDTsmi.Checked,
                    ShowStatus = CustomerStatusTsmi.Checked,
                    ShowOriginalID = CustomerOriginalIDTsmi.Checked,
                    ShowCountry = CustomerCountryTsmi.Checked,
                    ShowName = CustomerNameTsmi.Checked,
                    UserID = UserAccessInfo.RefreshUserID
                };
                await _userService.PostCustomerDGV(cdgv);

            }
        }

        private async void CustomerGridForm_Load(object sender, EventArgs e)
        {
            getAllNotFiltered = _customerService.GetAll(new CustomerFilter() { CustomerPage = 1 });
            countNotFiltered = _customerService.Count(new CustomerFilter());
            getFav = _userService.GetCustomerDGV();
            await SetCheckBoxes();
        }

        private void Pdf_ClickBtn(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "PDF Files|*.pdf",
                Title = "Save PDF File"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Cursor = Cursors.WaitCursor;
                    Application.DoEvents(); // Forza l'aggiornamento dell'interfaccia utente

                    using (FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        using (PdfWriter writer = new PdfWriter(fs))
                        {
                            using (PdfDocument pdf = new PdfDocument(writer))
                            {
                                Document doc = new Document(pdf, PageSize.A4);

                                string title = Text[5..] + " Data Report";  // Customize your title here
                                Paragraph titleParagraph = new Paragraph(title)
                                    .SetFontSize(18)
                                    .SimulateBold()
                                    .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                                    .SetMarginBottom(20);
                                doc.Add(titleParagraph);

                                int visibleColumnCount = CustomerDgv.Columns.Cast<DataGridViewColumn>().Count(c => c.Visible);
                                Table table = new Table(visibleColumnCount);

                                // Aggiungi le intestazioni delle colonne visibili
                                foreach (DataGridViewColumn column in CustomerDgv.Columns)
                                {
                                    if (column.Visible)
                                    {
                                        table.AddCell(column.HeaderText);
                                    }
                                }

                                // Aggiungi le righe della DataGridView
                                foreach (DataGridViewRow row in CustomerDgv.Rows)
                                {
                                    if (!row.IsNewRow)
                                    {
                                        foreach (DataGridViewColumn column in CustomerDgv.Columns)
                                        {
                                            if (column.Visible)
                                            {
                                                DataGridViewCell cell = row.Cells[column.Index];
                                                table.AddCell(cell.Value?.ToString() ?? "");
                                            }
                                        }
                                    }
                                }

                                doc.Add(table);
                                doc.Close();
                            }
                        }
                    }

                    MessageBox.Show("PDF salvato con successo!", "Successo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Errore: " + ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            }
        }


        private void Excel_ClickBtn(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel Files|*.xlsx",
                Title = "Save Excel File"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Cursor = Cursors.WaitCursor;
                    Application.DoEvents(); // Forza l'aggiornamento dell'interfaccia utente

                    using (XLWorkbook xLWorkbook = new XLWorkbook())
                    {
                        DataTable dt = new DataTable() { TableName = Text[5..] + " Data Report" };

                        // Create columns from DataGridView

                        foreach (DataGridViewColumn col in CustomerDgv.Columns)
                        {
                            if (col.Visible)
                            {
                                dt.Columns.Add(col.HeaderText);
                            }
                        }

                        // Add rows from DataGridView
                        foreach (DataGridViewRow row in CustomerDgv.Rows)
                        {
                            if (!row.IsNewRow) // Skip the empty new row
                            {
                                DataRow dRow = dt.NewRow();
                                int index = 0;
                                foreach (DataGridViewColumn column in CustomerDgv.Columns)
                                {
                                    if (column.Visible)
                                    {
                                        dRow[index] = row.Cells[column.Name].Value ?? "";
                                        index++;
                                    }
                                }
                                dt.Rows.Add(dRow);
                            }
                        }

                        // Add DataTable to the Excel file
                        xLWorkbook.Worksheets.Add(dt, "Sheet1");

                        // Save the file
                        xLWorkbook.SaveAs(saveFileDialog.FileName);

                        MessageBox.Show("Excel file saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        }
    }
}

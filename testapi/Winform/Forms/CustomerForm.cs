using ClosedXML.Excel;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System.Data;


namespace Winform.Forms
{
    public partial class CustomerForm : CustomerGridForm
    {

        public CustomerForm()
        {
            InitializeComponent();
        }


        public override void MyControl_OpenDetails_Clicked(object sender, DataGridViewCellEventArgs e)
        {

            if (sender is DataGridView dgv)
            {
                if (e.RowIndex == -1)
                    return;

                UtilityFunctions.OpenFormDetails<CustomerDetailsForm>(sender, e, int.Parse(dgv.CurrentRow.Cells["CustomerId"].Value.ToString()));

            }
        }

        private void button1_Click(object sender, EventArgs e)
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


        private void button2_Click(object sender, EventArgs e)
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

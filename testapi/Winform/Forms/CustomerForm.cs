using ClosedXML.Excel;
using System.Data;

namespace Winform.Forms
{
    public partial class CustomerForm : CustomerGridForm
    {
        public CustomerForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
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
                    using (XLWorkbook xLWorkbook = new XLWorkbook())
                    {
                        DataTable dt = new DataTable();

                        // Create columns from DataGridView
                        foreach (DataGridViewColumn col in CustomerDgv.Columns)
                        {
                            dt.Columns.Add(col.HeaderText);
                        }

                        // Add rows from DataGridView
                        foreach (DataGridViewRow row in CustomerDgv.Rows)
                        {
                            if (!row.IsNewRow) // Skip the empty new row
                            {
                                DataRow dRow = dt.NewRow();
                                for (int i = 0; i < CustomerDgv.Columns.Count; i++)
                                {
                                    dRow[i] = row.Cells[i].Value ?? "";
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
            }
        }
    }
}

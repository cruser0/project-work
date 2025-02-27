using ClosedXML.Excel;
using System.Data;
using Winform.Forms.control;

namespace Winform.Forms
{
    public partial class CustomerForm : CustomerGridForm
    {
        MainForm mainForm = Application.OpenForms.OfType<MainForm>().First();
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

                foreach (Form form in Application.OpenForms.Cast<Form>().ToList())
                {
                    if (form is CustomerDetailsForm)
                    {
                        form.Close();
                    }
                }

                TableLayoutPanel minimizedPanel = (TableLayoutPanel)mainForm.Controls.Find("minimizedPanel", true)[0];

                foreach (var button in minimizedPanel.Controls)
                {
                    if (button is formDockButton btn)
                    {
                        if (btn.getForm() is CustomerDetailsForm form)
                        {
                            form.Close();
                            minimizedPanel.Controls.Remove(btn);
                        }
                    }

                }

                CustomerDetailsForm cdf = new CustomerDetailsForm(int.Parse(dgv.CurrentRow.Cells[0].Value.ToString()));
                cdf.MdiParent = mainForm;
                cdf.Size = new Size((int)Math.Floor(mainForm.Width * 0.48),
                (int)Math.Floor(mainForm.Height * 0.40));
                cdf.Text = "Customer Details";
                cdf.Resize += ChildForm_Resize;
                cdf.FormClosing += ChildForm_Close;

                cdf.Show();

            }
        }

        public void ChildForm_Close(object sender, FormClosingEventArgs e)
        {
            mainForm.BeginInvoke(new Action(UpdateMdiLayout));
        }

        private void UpdateMdiLayout()
        {
            int countOpenForms = mainForm.MdiChildren.Count(x => x.WindowState != FormWindowState.Minimized);
            mainForm.LayoutMdi(MdiLayout.ArrangeIcons);
        }

        public void ChildForm_Resize(object sender, EventArgs e)
        {
            var childForm = sender as Form;
            TableLayoutPanel minimizedPanel = (TableLayoutPanel)mainForm.Controls.Find("minimizedPanel", true)[0];

            if (childForm == null ||
                childForm.WindowState != FormWindowState.Minimized ||
                minimizedPanel.Controls.OfType<formDockButton>().Any(btn => btn.Name == childForm.Text))
            {
                return;
            }
            // Increase the column count for each new button
            minimizedPanel.ColumnCount += 1;

            // Create a new button for the minimized form
            var minimizedButton = new formDockButton(childForm.Text, childForm, minimizedPanel, mainForm)
            {
                Name = childForm.Text,
                Dock = DockStyle.Top
            };

            // Add the button to the table layout panel in the next available column
            minimizedPanel.Controls.Add(minimizedButton, minimizedPanel.ColumnCount - 1, 0);

            // Set the column style to make buttons stretch horizontally
            minimizedPanel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));

            // Hide the minimized form in the MDI parent
            childForm.Hide();



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

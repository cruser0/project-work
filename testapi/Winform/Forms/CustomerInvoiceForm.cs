using Winform.Forms.control;
using Winform.Forms.CreateWindow;

namespace Winform.Forms
{
    public partial class CustomerInvoiceForm : CustomerInvoiceGridForm
    {
        MainForm mainForm = Application.OpenForms.OfType<MainForm>().First();
        public CustomerInvoiceForm()
        {

            InitializeComponent();
        }
        public override void CenterDgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (sender is DataGridView dgv)
            {
                if (e.RowIndex == -1)
                    return;

                foreach (Form form in Application.OpenForms.Cast<Form>().ToList())
                {
                    if (form is CustomerInvoiceDetailsForm)
                    {
                        form.Close();
                    }
                }

                TableLayoutPanel minimizedPanel = (TableLayoutPanel)mainForm.Controls.Find("minimizedPanel", true)[0];

                foreach (var button in minimizedPanel.Controls)
                {
                    if (button is formDockButton btn)
                    {
                        if (btn.getForm() is CustomerInvoiceDetailsForm form)
                        {
                            form.Close();
                            minimizedPanel.Controls.Remove(btn);
                        }
                    }

                }

                CustomerInvoiceDetailsForm cdf = new CustomerInvoiceDetailsForm(int.Parse(dgv.CurrentRow.Cells[0].Value.ToString()));
                cdf.MdiParent = mainForm;
                cdf.Size = new Size((int)Math.Floor(mainForm.Width * 0.48),
                (int)Math.Floor(mainForm.Height * 0.40));
                cdf.Text = "Customer Invoice Details";
                cdf.Resize += ChildForm_Resize;
                cdf.FormClosing += ChildForm_Close;
                Panel mainPanel = (Panel)mainForm.Controls.Find("MainPanel", true)[0];
                mainPanel.Controls.Add(cdf);
                cdf.Show();
                cdf.BringToFront();
                cdf.Activate();

            }
        }

        public void ChildForm_Close(object sender, FormClosingEventArgs e)
        {

            mainForm.BeginInvoke(new Action(UpdateMdiLayout));
        }

        private void UpdateMdiLayout()
        {
            Panel mainPanel = (Panel)mainForm.Controls.Find("MainPanel", true)[0];
            int countOpenForms = mainPanel.Controls.OfType<Form>().Count(x => x.WindowState != FormWindowState.Minimized);
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
    }
}

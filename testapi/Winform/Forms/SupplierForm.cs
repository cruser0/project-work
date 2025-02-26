using Winform.Forms.control;

namespace Winform.Forms
{
    public partial class SupplierForm : SupplierGridForm
    {
        public SupplierForm()
        {
            InitializeComponent();
        }

        public override void SupplierDgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (sender is DataGridView dgv)
            {
                if (e.RowIndex == -1)
                    return;
                SupplierDetailsForm cdf = new SupplierDetailsForm(int.Parse(dgv.CurrentRow.Cells[0].Value.ToString()));
                cdf.MdiParent = MdiParent;
                cdf.Size = new Size((int)Math.Floor(MdiParent.Width * 0.48),
                (int)Math.Floor(MdiParent.Height * 0.40));

                cdf.Resize += ChildForm_Resize;
                cdf.FormClosing += ChildForm_Close;

                cdf.Show();

            }
        }

        public void ChildForm_Close(object sender, FormClosingEventArgs e)
        {
            this.BeginInvoke(new Action(UpdateMdiLayout));
        }

        private void UpdateMdiLayout()
        {
            int countOpenForms = MdiParent.MdiChildren.Count(x => x.WindowState != FormWindowState.Minimized);
            MdiParent.LayoutMdi(MdiLayout.ArrangeIcons);
        }


        public void ChildForm_Resize(object sender, EventArgs e)
        {
            var childForm = sender as Form;
            TableLayoutPanel minimizedPanel = (TableLayoutPanel)MdiParent.Controls.Find("minimizedPanel", true)[0];

            if (childForm == null ||
                childForm.WindowState != FormWindowState.Minimized ||
                minimizedPanel.Controls.OfType<formDockButton>().Any(btn => btn.Name == childForm.Text))
            {
                return;
            }
            // Increase the column count for each new button
            minimizedPanel.ColumnCount += 1;

            // Create a new button for the minimized form
            var minimizedButton = new formDockButton(childForm.Text, childForm, minimizedPanel, (MainForm)MdiParent)
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

            int? countOpenForms = MdiChildren.Where(x => x.WindowState != FormWindowState.Minimized).Count();
            List<Form?> childrenOpen = MdiChildren.Where(x => x.WindowState != FormWindowState.Minimized).ToList();
            LayoutMdi(MdiLayout.ArrangeIcons);

        }


    }
}

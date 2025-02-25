using Winform.Forms;
using Winform.Forms.AddForms;
using Winform.Forms.control;

namespace Winform
{

    public partial class MainForm : Form
    {
        private TableLayoutPanel minimizedPanel; // Panel to hold minimized child forms

        public MainForm()
        {
            InitializeComponent();
            toolStripTextBox1.Text = "Role: " + UserAccessInfo.Role;
            IsMdiContainer = true; // Set the MDI container
            this.WindowState = FormWindowState.Maximized;

            // Create a panel to hold minimized forms at the bottom
            minimizedPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Bottom,
                Height = 60, // Adjust the height of the panel as needed
                RowCount = 1,
                AutoScroll = true
            };
            this.Controls.Add(minimizedPanel);
        }

        private void buttonOpenChild_Click(object sender, EventArgs e)
        {
            var menuItem = sender as ToolStripMenuItem;

            Cursor.Current = Cursors.WaitCursor;
            string formName = menuItem.Text;
            int? countOpenForms = MdiChildren.Where(x => x.WindowState != FormWindowState.Minimized).Count();
            List<Form?> childrenOpen = MdiChildren.Where(x => x.WindowState != FormWindowState.Minimized).ToList();



            // Check if the form is already open
            Form? existingForm = MdiChildren.FirstOrDefault(f => f.Text == formName);
            if (existingForm != null)
            {
                // Check if the form is already minimized and exists in the minimized panel
                var minimizedButton = minimizedPanel.Controls.OfType<formDockButton>()
                    .FirstOrDefault(btn => btn.Name == formName);

                if (minimizedButton != null)
                {
                    // Trigger the button click event to show the form from the minimized state
                    minimizedButton.ButtonShowForm?.PerformClick();
                    Cursor.Current = Cursors.Default;
                    return;
                }

                if (countOpenForms >= 4)
                    LayoutMdi(MdiLayout.ArrangeIcons);
                else
                    LayoutMdi(MdiLayout.TileVertical);

                existingForm.WindowState = FormWindowState.Normal;
                existingForm.Activate();
                Cursor.Current = Cursors.Default;
                return;
            }



            // Create a new form if it doesn't exist already
            Form child = formName switch
            {
                "Show Customers" => new CustomerForm(),
                "Show Customer Invoices" => new CustomerInvoiceForm(),
                "Show Suppliers" => new SupplierForm(),
                "Show Supplier Invoices" => new SupplierInvoiceForm(),
                "Show Supplier Invoices Costs" => new SupplierInvoiceCostsForm(),
                "Add Supplier Invoices Cost" => new CreateSupplierInvoiceCostForm(),
                "Show Sales" => new SaleForm(),
                "Add Customer" => new CreateCustomerForm(),
                "Add Supplier" => new CreateSupplierForm(),
                "Add Supplier Invoice" => new CreateSupplierInvoicesForm(),
                "Show Customer Invoices Costs" => new CustomerInvoiceCostForm(),
                _ => new Form()
            };

            child.Text = formName; // Set the title for future control
            child.MdiParent = this;
            child.Size = new Size(1000, 600);

            child.Resize += ChildForm_Resize; // Handle resize event for child forms

            child.Show();
            if (countOpenForms >= 4)
                LayoutMdi(MdiLayout.ArrangeIcons);
            else
                LayoutMdi(MdiLayout.TileVertical);


            Cursor.Current = Cursors.Default;

        }



        private void ChildForm_Resize(object sender, EventArgs e)
        {
            var childForm = sender as Form;

            if (childForm == null ||
                childForm.WindowState != FormWindowState.Minimized ||
                minimizedPanel.Controls.OfType<formDockButton>().Any(btn => btn.Name == childForm.Text))
            {
                return;
            }
            // Increase the column count for each new button
            minimizedPanel.ColumnCount += 1;

            // Create a new button for the minimized form
            var minimizedButton = new formDockButton(childForm.Text, childForm, minimizedPanel, this)
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

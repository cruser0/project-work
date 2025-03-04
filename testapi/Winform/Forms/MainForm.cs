using Winform.Forms;
using Winform.Forms.AddForms;
using Winform.Forms.control;
using Winform.Forms.FInalForms;
using Winform.Services;

namespace Winform
{

    public partial class MainForm : Form
    {
        private TableLayoutPanel minimizedPanel; // Panel to hold minimized child forms
        public MainForm()
        {
            InitializeComponent();
            IsMdiContainer = true; // Set the MDI container
            WindowState = FormWindowState.Maximized;

            CreateDockPanel();
            SetAuthorizations();
            tabControl.TabPages.Remove(ShowTP);
            tabControl.TabPages.Remove(EditTP);
            tabControl.TabPages.Remove(AddTP);
            tabControl.TabPages.Remove(GroupTP);
        }

        private void CreateDockPanel()
        {
            minimizedPanel = new TableLayoutPanel
            {
                Name = "minimizedPanel",
                Dock = DockStyle.Bottom,
                Height = 60,
                RowCount = 1,
                AutoScroll = true
            };
            this.Controls.Add(minimizedPanel);
        }

        private void SetAuthorizations()
        {
            if(Authorize(new List<string> {"Admin", "CustomerRead", "CustomerInvoiceRead", "CustomerInvoiceCostRead", "SaleRead", "SupplierRead", "SupplierInvoiceRead", "SupplierInvoiceCostRead","UserRead",
            "CustomerWrite", "CustomerInvoiceWrite", "CustomerInvoiceCostWrite", "SaleWrite", "SupplierWrite", "SupplierInvoiceWrite", "SupplierInvoiceCostWrite","UserWrite",
            "CustomerAdmin", "CustomerInvoiceAdmin", "CustomerInvoiceCostAdmin", "SaleAdmin", "SupplierAdmin", "SupplierInvoiceAdmin", "SupplierInvoiceCostAdmin","UserAdmin"}))
            {
                tabControl.TabPages.Add(ShowTP);
            }
            if (Authorize(new List<string> {"Admin","CustomerWrite", "CustomerInvoiceWrite", "CustomerInvoiceCostWrite", "SaleWrite", "SupplierWrite", "SupplierInvoiceWrite", "SupplierInvoiceCostWrite","UserWrite",
            "CustomerAdmin", "CustomerInvoiceAdmin", "CustomerInvoiceCostAdmin", "SaleAdmin", "SupplierAdmin", "SupplierInvoiceAdmin", "SupplierInvoiceCostAdmin","UserAdmin"}))
            {
                tabControl.TabPages.Add(AddTP);
                tabControl.TabPages.Add(EditTP);
            }
            if (AuthorizeGroup(new List<string> { "CustomerRead", "CustomerInvoiceRead", "CustomerInvoiceCostRead", "SaleRead" }) ||
                AuthorizeGroup(new List<string> { "CustomerWrite", "CustomerInvoiceWrite", "CustomerInvoiceCostWrite", "SaleWrite" }) ||
                 AuthorizeGroup(new List<string> { "CustomerAdmin", "CustomerInvoiceAdmin", "CustomerInvoiceCostAdmin", "SaleAdmin" }) ||
                 Authorize(new List<string> { "Admin" }) ||
                 AuthorizeGroup(new List<string> { "SupplierRead", "SupplierInvoiceRead", "SupplierInvoiceCostRead" }) ||
                AuthorizeGroup(new List<string> { "SupplierWrite", "SupplierInvoiceWrite", "SupplierInvoiceCostWrite" }) ||
                 AuthorizeGroup(new List<string> { "SupplierAdmin", "SupplierInvoiceAdmin", "SupplierInvoiceCostAdmin" }))
            {
            tabControl.TabPages.Add(GroupTP);
            }
            
            
            CustomerShowTS.Visible = Authorize(new List<string>
                { "Admin", "CustomerRead", "CustomerWrite", "CustomerAdmin" });
            CustomerCreateTS.Visible = Authorize(new List<string>
                { "Admin", "CustomerWrite","CustomerAdmin" });

            CustomerInvoiceShowTS.Visible = Authorize(new List<string>
                { "Admin", "CustomerInvoiceRead", "CustomerInvoiceWrite", "CustomerInvoiceAdmin" });
            CustomerInvoiceCreateTS.Visible = Authorize(new List<string>
                { "Admin", "CustomerInvoiceWrite", "CustomerInvoiceAdmin"});

            CustomerInvoiceCostShowTS.Visible = Authorize(new List<string>
                { "Admin", "CustomerInvoiceCostRead", "CustomerInvoiceCostWrite", "CustomerInvoiceCostAdmin" });
            CustomerInvoiceCostCreateTS.Visible = Authorize(new List<string>
                { "Admin", "CustomerInvoiceCostWrite", "CustomerInvoiceCostAdmin"});

            SupplierShowTS.Visible = Authorize(new List<string>
                { "Admin", "SupplierRead", "SupplierWrite", "SupplierAdmin" });
            SupplierCreateTS.Visible = Authorize(new List<string>
                { "Admin", "SupplierWrite", "SupplierAdmin"});

            SupplierInvoiceShowTS.Visible = Authorize(new List<string>
                { "Admin", "SupplierInvoiceRead", "SupplierInvoiceWrite", "SupplierInvoiceAdmin" });
            SupplierInvoiceCreateTS.Visible = Authorize(new List<string>
                { "Admin", "SupplierInvoiceWrite", "SupplierInvoiceAdmin"});

            SupplierInvoiceCostShowTS.Visible = Authorize(new List<string>
                { "Admin", "SupplierInvoiceCostRead", "SupplierInvoicesCostWrite", "SupplierInvoicesCostAdmin" });
            SupplierInvoiceCostCreateTS.Visible = Authorize(new List<string>
                { "Admin", "SupplierInvoicesCostWrite", "SupplierInvoicesCostAdmin"});
            SaleShowTS.Visible = Authorize(new List<string>
                { "Admin", "SaleRead", "SaleWrite", "SaleAdmin" });
            SaleCreateTS.Visible = Authorize(new List<string>
                { "Admin", "SaleWrite", "SaleAdmin"});
            if (AuthorizeGroup(new List<string> { "CustomerRead", "CustomerInvoiceRead", "CustomerInvoiceCostRead", "SaleRead" }) ||
                AuthorizeGroup(new List<string> { "CustomerWrite", "CustomerInvoiceWrite", "CustomerInvoiceCostWrite", "SaleWrite" }) ||
                 AuthorizeGroup(new List<string> { "CustomerAdmin", "CustomerInvoiceAdmin", "CustomerInvoiceCostAdmin", "SaleAdmin" }) ||
                 Authorize(new List<string> { "Admin" }))
            {
                CustomerGroupTS.Visible = true;
            }
            if(Authorize(new List<string> { "Admin" }) ||
                 AuthorizeGroup(new List<string> { "SupplierRead", "SupplierInvoiceRead", "SupplierInvoiceCostRead" }) ||
                AuthorizeGroup(new List<string> { "SupplierWrite", "SupplierInvoiceWrite", "SupplierInvoiceCostWrite" }) ||
                 AuthorizeGroup(new List<string> { "SupplierAdmin", "SupplierInvoiceAdmin", "SupplierInvoiceCostAdmin" }))
            {
                SupplierGroupTS.Visible = true;
            }
        }

        private bool Authorize(List<string> allowedRoles)
        {
            return allowedRoles.Any(role => UserAccessInfo.Role.Contains(role));
        }
        private bool AuthorizeGroup(List<string> allowedRoles)
        {
            foreach(string a in allowedRoles)
            {
                if (!UserAccessInfo.Role.Contains(a))
                    return false;
            }
            return true;
        }

        private void buttonOpenChild_Click(object sender, EventArgs e)
        {
            var menuItem = sender as ToolStripButton;

            Cursor.Current = Cursors.WaitCursor;
            string tabName = menuItem.GetCurrentParent().Name;
            string formName = tabName + " " + menuItem.Text;
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

                LayoutMdi(MdiLayout.ArrangeIcons);


                existingForm.WindowState = FormWindowState.Normal;
                existingForm.Activate();
                Cursor.Current = Cursors.Default;
                return;
            }



            // Create a new form if it doesn't exist already
            Form child = formName switch
            {
                "Show Customer" => new CustomerForm(),
                "Show Customer Invoice" => new CustomerInvoiceForm(),
                "Show Supplier" => new SupplierForm(),
                "Show Supplier Invoice" => new SupplierInvoiceForm(),
                "Show Supplier Invoice Cost" => new SupplierInvoiceCostsForm(),
                "Show Sale" => new SaleForm(),
                "Add Supplier Invoice Cost" => new CreateSupplierInvoiceCostForm(),
                "Add Sale" => new CreateSaleForm(),
                "Add Customer" => new CreateCustomerForm(),
                "Add Customer Invoice" => new CreateCustomerInvoiceForm(),
                "Add Customer Invoice Cost" => new CreateCustomerInvoiceCostForm(),
                "Add Supplier" => new CreateSupplierForm(),
                "Add Supplier Invoice" => new CreateSupplierInvoicesForm(),
                "Show Customer Invoice Cost" => new CustomerInvoiceCostForm(),
                "Show User" => new UserForm(),
                "Add User" => new CreateUserForm(),

                "Group Supplier" => new SupplierFinalForm(),

                "Group Customer"=> new CustomerFinalForm(),



                _ => new Form()
            };

            child.Text = formName; // Set the title for future control
            child.MdiParent = this;
            child.Size = new Size((int)Math.Floor(Width * 0.48),
                (int)Math.Floor(Height * 0.40));

            child.Resize += ChildForm_Resize; // Handle resize event for child forms
            child.FormClosing += ChildForm_Close;

            child.Show();
            LayoutMdi(MdiLayout.ArrangeIcons);



            Cursor.Current = Cursors.Default;

        }

        public void ChildForm_Close(object sender, FormClosingEventArgs e)
        {
            this.BeginInvoke(new Action(UpdateMdiLayout));
        }

        private void UpdateMdiLayout()
        {
            int countOpenForms = MdiChildren.Count(x => x.WindowState != FormWindowState.Minimized);
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        public void ChildForm_Resize(object sender, EventArgs e)
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

            int? countOpenForms = MdiChildren.Where(x => x.WindowState != FormWindowState.Minimized).Count();
            List<Form?> childrenOpen = MdiChildren.Where(x => x.WindowState != FormWindowState.Minimized).ToList();
            LayoutMdi(MdiLayout.ArrangeIcons);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MdiChildren.ToList().ForEach(form => form.WindowState = FormWindowState.Minimized);
        }
    }
}

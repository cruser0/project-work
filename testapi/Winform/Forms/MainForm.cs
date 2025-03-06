using Winform.Forms;
using Winform.Forms.AddForms;
using Winform.Forms.control;
using Winform.Forms.FInalForms;

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
            tabControl.TabPages.Remove(ShowTP);
            tabControl.TabPages.Remove(EditTP);
            tabControl.TabPages.Remove(AddTP);
            tabControl.TabPages.Remove(GroupTP);
            SetAuthorizations();
            UserProfile.Text = "Hello " + UserAccessInfo.Name;
        }

        private void CreateDockPanel()
        {
            minimizedPanel = new TableLayoutPanel
            {
                Name = "minimizedPanel",
                Dock = DockStyle.Bottom,
                Height = 60,
                RowCount = 1,
                AutoScroll = true,
                BackColor = Color.FromArgb(174, 180, 194)
            };
            this.Controls.Add(minimizedPanel);
        }

        private static readonly string[] AdminRoles = { "Admin" };
        private static readonly string[] WriteRoles = { "Admin", "CustomerWrite", "CustomerInvoiceWrite", "CustomerInvoiceCostWrite", "SaleWrite", "SupplierWrite", "SupplierInvoiceWrite", "SupplierInvoiceCostWrite", "UserWrite" };
        private static readonly string[] ReadRoles = { "Admin", "CustomerRead", "CustomerInvoiceRead", "CustomerInvoiceCostRead", "SaleRead", "SupplierRead", "SupplierInvoiceRead", "SupplierInvoiceCostRead", "UserRead" };
        private static readonly string[] AdminGroupRoles = { "CustomerAdmin", "CustomerInvoiceAdmin", "CustomerInvoiceCostAdmin", "SaleAdmin", "SupplierAdmin", "SupplierInvoiceAdmin", "SupplierInvoiceCostAdmin", "UserAdmin" };

        private void SetAuthorizations()
        {
            // Convertiamo UserAccessInfo.Role in un HashSet per ottimizzare Contains()

            if (UtilityFunctions.IsAuthorized(ReadRoles) || UtilityFunctions.IsAuthorized(WriteRoles) || UtilityFunctions.IsAuthorized(AdminGroupRoles) || UtilityFunctions.IsAuthorized(AdminRoles))
            {
                tabControl.TabPages.Add(ShowTP);
            }

            if (UtilityFunctions.IsAuthorized(WriteRoles) || UtilityFunctions.IsAuthorized(AdminGroupRoles))
            {
                tabControl.TabPages.Add(AddTP);
                tabControl.TabPages.Add(EditTP);
            }

            if (UtilityFunctions.IsAuthorized(new[] { "CustomerRead", "CustomerInvoiceRead", "CustomerInvoiceCostRead", "SaleRead" }, requireAll: true) ||
                UtilityFunctions.IsAuthorized(new[] { "SupplierRead", "SupplierInvoiceRead", "SupplierInvoiceCostRead" }, requireAll: true) ||
                UtilityFunctions.IsAuthorized(AdminRoles))
            {
                tabControl.TabPages.Add(GroupTP);
            }

            // Impostazione visibilità ToolStripMenuItems
            CustomerShowTS.Visible = UtilityFunctions.IsAuthorized(new[] { "Admin", "CustomerRead", "CustomerWrite", "CustomerAdmin" });
            CustomerCreateTS.Visible = UtilityFunctions.IsAuthorized(new[] { "Admin", "CustomerWrite", "CustomerAdmin" });

            CustomerInvoiceShowTS.Visible = UtilityFunctions.IsAuthorized(new[] { "Admin", "CustomerInvoiceRead", "CustomerInvoiceWrite", "CustomerInvoiceAdmin" });
            CustomerInvoiceCreateTS.Visible = UtilityFunctions.IsAuthorized(new[] { "Admin", "CustomerInvoiceWrite", "CustomerInvoiceAdmin" });

            CustomerInvoiceCostShowTS.Visible = UtilityFunctions.IsAuthorized(new[] { "Admin", "CustomerInvoiceCostRead", "CustomerInvoiceCostWrite", "CustomerInvoiceCostAdmin" });
            CustomerInvoiceCostCreateTS.Visible = UtilityFunctions.IsAuthorized(new[] { "Admin", "CustomerInvoiceCostWrite", "CustomerInvoiceCostAdmin" });

            SupplierShowTS.Visible = UtilityFunctions.IsAuthorized(new[] { "Admin", "SupplierRead", "SupplierWrite", "SupplierAdmin" });
            SupplierCreateTS.Visible = UtilityFunctions.IsAuthorized(new[] { "Admin", "SupplierWrite", "SupplierAdmin" });

            SupplierInvoiceShowTS.Visible = UtilityFunctions.IsAuthorized(new[] { "Admin", "SupplierInvoiceRead", "SupplierInvoiceWrite", "SupplierInvoiceAdmin" });
            SupplierInvoiceCreateTS.Visible = UtilityFunctions.IsAuthorized(new[] { "Admin", "SupplierInvoiceWrite", "SupplierInvoiceAdmin" });

            SupplierInvoiceCostShowTS.Visible = UtilityFunctions.IsAuthorized(new[] { "Admin", "SupplierInvoiceCostRead", "SupplierInvoiceCostWrite", "SupplierInvoiceCostAdmin" });
            SupplierInvoiceCostCreateTS.Visible = UtilityFunctions.IsAuthorized(new[] { "Admin", "SupplierInvoiceCostWrite", "SupplierInvoiceCostAdmin" });

            SaleShowTS.Visible = UtilityFunctions.IsAuthorized(new[] { "Admin", "SaleRead", "SaleWrite", "SaleAdmin" });
            SaleCreateTS.Visible = UtilityFunctions.IsAuthorized(new[] { "Admin", "SaleWrite", "SaleAdmin" });

            UserShowTS.Visible = UtilityFunctions.IsAuthorized(new[] { "Admin" });
            UserCreateTS.Visible = UtilityFunctions.IsAuthorized(new[] { "Admin" });

            CustomerGroupTS.Visible = UtilityFunctions.IsAuthorized(ReadRoles, requireAll: true) ||
                                      UtilityFunctions.IsAuthorized(WriteRoles, requireAll: true) ||
                                      UtilityFunctions.IsAuthorized(AdminGroupRoles, requireAll: true) ||
                                      UtilityFunctions.IsAuthorized(AdminRoles);

            SupplierGroupTS.Visible = UtilityFunctions.IsAuthorized(AdminRoles) ||
                                      UtilityFunctions.IsAuthorized(new[] { "SupplierRead", "SupplierInvoiceRead", "SupplierInvoiceCostRead" }, requireAll: true) ||
                                      UtilityFunctions.IsAuthorized(new[] { "SupplierWrite", "SupplierInvoiceWrite", "SupplierInvoiceCostWrite" }, requireAll: true) ||
                                      UtilityFunctions.IsAuthorized(new[] { "SupplierAdmin", "SupplierInvoiceAdmin", "SupplierInvoiceCostAdmin" }, requireAll: true);
        }



        private void buttonOpenChild_Click(object sender, EventArgs e)
        {
            var menuItem = sender as ToolStripButton;

            Cursor.Current = Cursors.WaitCursor;

            string tabName = menuItem.GetCurrentParent().Name;
            string formName;
            if (tabName.Equals("ToolStripTopMenu"))
                formName = tabName + " " + menuItem.Name;
            else
                formName = tabName + " " + menuItem.Text;
            int? countOpenForms = MainPanel.Controls.OfType<Form>().Count(x => x.WindowState != FormWindowState.Minimized);
            List<Form?> childrenOpen = MainPanel.Controls.OfType<Form>().Where(x => x.WindowState != FormWindowState.Minimized).ToList();




            // Check if the form is already open
            Form? existingForm = MainPanel.Controls.OfType<Form>().FirstOrDefault(f => f.Text == formName);
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
                "TS UserProfile" => new UserProfileForm(),

                "Show Customer" => new CustomerForm(),
                "Show Customer Invoice" => new CustomerInvoiceForm(),
                "Show Customer Invoice Cost" => new CustomerInvoiceCostForm(),

                "Show Supplier" => new SupplierForm(),
                "Show Supplier Invoice" => new SupplierInvoiceForm(),
                "Show Supplier Invoice Cost" => new SupplierInvoiceCostsForm(),

                "Show Sale" => new SaleForm(),
                "Show User" => new UserForm(),

                "Create Customer" => new CreateCustomerForm(),
                "Create Customer Invoice" => new CreateCustomerInvoiceForm(),
                "Create Customer Invoice Cost" => new CreateCustomerInvoiceCostForm(),

                "Create Supplier" => new CreateSupplierForm(),
                "Create Supplier Invoice" => new CreateSupplierInvoicesForm(),
                "Create Supplier Invoice Cost" => new CreateSupplierInvoiceCostForm(),

                "Create Sale" => new CreateSaleForm(),
                "Create User" => new CreateUserForm(),

                "Group Supplier" => new SupplierFinalForm(),
                "Group Customer" => new CustomerFinalForm(),



                _ => new Form()
            };

            child.Text = formName.Equals("ToolStripTopMenu UserBtnTS") ? "User Area" : formName;
            child.MdiParent = this;
            child.Size = new Size(800, 500);

            child.Resize += ChildForm_Resize;
            child.FormClosing += ChildForm_Close;
            MainPanel.Controls.Add(child);
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
            int countOpenForms = MainPanel.Controls.OfType<Form>().Count(x => x.WindowState != FormWindowState.Minimized);
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

            int? countOpenForms = MainPanel.Controls.OfType<Form>().Count(x => x.WindowState != FormWindowState.Minimized);
            List<Form?> childrenOpen = MainPanel.Controls.OfType<Form>().Where(x => x.WindowState != FormWindowState.Minimized).ToList();
            LayoutMdi(MdiLayout.ArrangeIcons);

        }


        private void Logout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to log out?", "Logout Confirmation",
                                                  MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Abort;  // Signal logout
                this.Close();
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            foreach (var form in MdiChildren)
            {
                if (form.WindowState != FormWindowState.Minimized)
                {
                    form.WindowState = FormWindowState.Minimized;
                }
            }
        }
    }
}

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
        UserService _userService;
        public ICollection<string> favoriteList;

        Form activeForm;

        private static readonly string[] AdminRoles = { "Admin" };
        private static readonly string[] WriteRoles = { "Admin", "CustomerWrite", "CustomerInvoiceWrite", "CustomerInvoiceCostWrite", "SaleWrite", "SupplierWrite", "SupplierInvoiceWrite", "SupplierInvoiceCostWrite", "UserWrite" };
        private static readonly string[] ReadRoles = { "Admin", "CustomerRead", "CustomerInvoiceRead", "CustomerInvoiceCostRead", "SaleRead", "SupplierRead", "SupplierInvoiceRead", "SupplierInvoiceCostRead", "UserRead" };
        private static readonly string[] AdminGroupRoles = { "CustomerAdmin", "CustomerInvoiceAdmin", "CustomerInvoiceCostAdmin", "SaleAdmin", "SupplierAdmin", "SupplierInvoiceAdmin", "SupplierInvoiceCostAdmin", "UserAdmin" };

        public MainForm()
        {
            _userService = new UserService();

            InitializeComponent();
            AddFavoriteButton.Visible = false;
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

        public void buttonOpenChild_Click(object sender, EventArgs e)
        {
            var menuItem = sender as ToolStripButton;

            Cursor.Current = Cursors.WaitCursor;

            string tabName = menuItem.GetCurrentParent().Name;
            string formName;
            if (tabName.Equals("TS"))
                formName = tabName + " " + menuItem.Name;
            else
                formName = tabName + " " + menuItem.Text;

            if (tabControl.SelectedTab.Text.Equals("Favorite"))
            {
                formName = (string)menuItem.Tag;
            }

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
                existingForm.BringToFront();
                existingForm.Activate();
                existingForm.Focus(); // Aggiunto per assicurare il focus
                existingForm.TopMost = true;
                existingForm.TopMost = false; // Reset per evitare problemi di persistenza
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

            child.Text = formName.Equals("TS UserProfile") ? "User Area" : formName;
            child.MdiParent = this;
            child.Size = new Size(800, 500);

            child.Resize += ChildForm_Resize;
            child.FormClosing += ChildForm_Close;
            MainPanel.Controls.Add(child);
            child.Show();
            child.BringToFront();
            child.Activate();
            child.Focus(); // Aggiunto per garantire il focus
            child.TopMost = true;
            child.TopMost = false; // Reset per evitare problemi di persistenza

            LayoutMdi(MdiLayout.ArrangeIcons);
            Cursor.Current = Cursors.Default;
        }

        public void ChildForm_Close(object sender, FormClosingEventArgs e)
        {
            BeginInvoke(new Action(UpdateMdiLayout));
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
            MainPanel.Controls
                .OfType<Form>()
                .Where(form => form.WindowState != FormWindowState.Minimized)
                .ToList()
                .ForEach(form => form.WindowState = FormWindowState.Minimized);
        }

        public async Task GetPreferred()
        {
            favoriteList = await _userService.GetAllPreferredPagesUser();
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            var preferredTask = GetPreferred();
            var updateTask = UpdateFavoriteTab();
            await Task.WhenAll(preferredTask, updateTask);
        }

        private async void AddFavoriteButton_Click(object sender, EventArgs e)
        {
            var latestForm = MainPanel.Controls
                .OfType<Form>()
                .Where(form => form.WindowState != FormWindowState.Minimized)
                .OrderByDescending(form => MainPanel.Controls.GetChildIndex(form))
                .LastOrDefault();

            if (latestForm != null)
            {

                string response;

                if (favoriteList.Contains(latestForm.Text))
                {
                    DialogResult result = MessageBox.Show($"Remove \"{latestForm.Text}\" from favorites?", "Favorite Confirmation",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        response = await _userService.RemoveUserFavouritePage(new List<string>() { latestForm.Text });
                        MessageBox.Show(response, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await UpdateFavoriteTab();  // Rimuovi o aggiorna la tab dopo la rimozione
                    }
                }
                else
                {
                    DialogResult result = MessageBox.Show($"Add \"{latestForm.Text}\" to favorites?", "Favorite Confirmation",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        response = await _userService.AddUserFavouritePage(new List<string>() { latestForm.Text });
                        MessageBox.Show(response, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await UpdateFavoriteTab();  // Aggiungi o aggiorna la tab dopo l'aggiunta
                    }
                }

            }
            else
            {
                MessageBox.Show("No open form");
            }
        }

        private async Task UpdateFavoriteTab()
        {
            // Recupera la lista di preferiti
            await GetPreferred();

            // Se ci sono preferiti, aggiungi o aggiorna la TabPage
            if (favoriteList.Count > 0)
            {
                ToolStrip toolstrip4;

                // Aggiungi la TabPage se non esiste
                if (!tabControl.TabPages.ContainsKey("Favorite"))
                {
                    TabPage FavoriteTB = new TabPage()
                    {
                        Name = "Favorite",
                        BackColor = Color.FromArgb(232, 234, 237),
                        Size = new Size(1151, 36),
                        Text = "Favorite"
                    };
                    toolstrip4 = new ToolStrip()
                    {
                        GripStyle = ToolStripGripStyle.Hidden,
                        BackColor = Color.Transparent,
                        Location = Show.Location,
                        Padding = Show.Padding,
                        AutoSize = false
                    };

                    FavoriteTB.Controls.Add(toolstrip4);
                    toolstrip4.Dock = DockStyle.Fill;

                    tabControl.TabPages.Insert(0, FavoriteTB);
                }

                // Ottieni il ToolStrip associato alla tab dei preferiti
                toolstrip4 = tabControl.TabPages["Favorite"].Controls.OfType<ToolStrip>().FirstOrDefault();

                // Rimuovi tutti i bottoni esistenti
                toolstrip4.Items.Clear();

                Dictionary<string, ToolStripButton> buttonMap = new Dictionary<string, ToolStripButton>
                {
                    { "User Area", UserProfile },
                    { "Show Customer", CustomerShowTS },
                    { "Show Customer Invoice", CustomerInvoiceShowTS },
                    { "Show Customer Invoice Cost", CustomerInvoiceCostShowTS },
                    { "Show Supplier", SupplierShowTS },
                    { "Show Supplier Invoice", SupplierInvoiceShowTS },
                    { "Show Supplier Invoice Cost", SupplierInvoiceCostShowTS },
                    { "Show Sale", SaleShowTS },
                    { "Show User", UserShowTS },
                    { "Create Customer", CustomerCreateTS },
                    { "Create Customer Invoice", CustomerInvoiceCreateTS },
                    { "Create Customer Invoice Cost", CustomerInvoiceCostCreateTS },
                    { "Create Supplier", SupplierCreateTS },
                    { "Create Supplier Invoice", SupplierInvoiceCreateTS },
                    { "Create Supplier Invoice Cost", SupplierInvoiceCostCreateTS },
                    { "Create Sale", SaleCreateTS },
                    { "Create User", UserCreateTS },
                    { "Group Supplier", SupplierGroupTS },
                    { "Group Customer", CustomerGroupTS }
                };

                foreach (string favorite in favoriteList)
                {
                    if (buttonMap.ContainsKey(favorite))
                    {
                        ToolStripButton btn = buttonMap[favorite];

                        // Crea una nuova istanza del bottone
                        ToolStripButton clonedButton = new ToolStripButton
                        {
                            AutoSize = false,
                            Margin = btn.Margin,
                            BackColor = Color.Transparent,
                            Text = $"{btn.GetCurrentParent().Parent.Text} {btn.Text}",
                            Image = btn.Image,
                            ToolTipText = btn.ToolTipText,
                            Tag = favorite,
                            DisplayStyle = btn.DisplayStyle,
                            Size = btn.Size
                        };

                        clonedButton.Click += buttonOpenChild_Click;

                        // Aggiungi il nuovo bottone alla ToolStrip
                        toolstrip4.Items.Add(clonedButton);
                    }
                }
            }
            else
            {
                // Se non ci sono preferiti, rimuovi la TabPage
                if (tabControl.TabPages.ContainsKey("Favorite"))
                {
                    tabControl.TabPages.RemoveByKey("Favorite");
                }
            }
        }


        private void MainPanel_ControlAdded(object sender, ControlEventArgs e)
        {
            Form form = (Form)e.Control;

            // Recursively add the MouseDown event to all controls within the form, including nested containers
            AttachMouseDownToControls(form);

            if (favoriteList.Contains(form.Text))
                AddFavoriteButton.Image = Properties.Resources.star_yellow_removebg;
            else
                AddFavoriteButton.Image = Properties.Resources.star;

            if (!AddFavoriteButton.Visible)
                AddFavoriteButton.Visible = true;

            form.ShowIcon = false;

            if (form.Text.Contains("Show") || form.Text.Contains("Group"))
            {
                toolStripButton3.PerformClick();
                form.WindowState = FormWindowState.Maximized;
            }
            else if (form.Text.Contains("Create") || form.Text.Contains("Details"))
            {
                form.MaximizeBox = false;
                form.FormBorderStyle = FormBorderStyle.FixedSingle;
            }
        }

        private void AttachMouseDownToControls(Control parent)
        {
            HashSet<Control> controlsWithEvent = new HashSet<Control>();
            // Only attach the event if it hasn't already been attached to this control
            if (!controlsWithEvent.Contains(parent))
            {
                parent.MouseDown += FormControl_MouseDown;
                controlsWithEvent.Add(parent);  // Track that the event is attached
            }

            // Recursively attach the event to all child controls
            foreach (Control child in parent.Controls)
            {
                AttachMouseDownToControls(child); // Recursive call for nested controls
            }
        }

        private void FormControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender is Control control)
            {
                // Traverse up the control tree to find the parent Form
                Form form = control.FindForm();

                // Now you have the correct Form object, regardless of the control's nesting
                if (form != null)
                {
                    form.BringToFront();
                    form.Focus();

                    if (favoriteList.Contains(form.Text))
                        AddFavoriteButton.Image = Properties.Resources.star_yellow_removebg;
                    else
                        AddFavoriteButton.Image = Properties.Resources.star;
                }
            }
        }



    }
}


using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinformDotNetFramework.Entities;
using WinformDotNetFramework.Forms.AddForms;
using WinformDotNetFramework.Forms.control;
using WinformDotNetFramework.Forms.DetailsForms;
using WinformDotNetFramework.Forms.GroupForms;
using WinformDotNetFramework.Services;

namespace WinformDotNetFramework.Forms
{

    public partial class MainForm : Form
    {
        private TableLayoutPanel minimizedPanel; // Panel to hold minimized child forms
        UserService _userService;
        public ICollection<string> favoriteList;
        private UtilityService _utilityService;
        private static readonly HashSet<string> AdminRoles = new HashSet<string>() { "Admin" };
        private static readonly HashSet<string> WriteRoles = new HashSet<string>() { "Admin", "CustomerWrite", "CustomerInvoiceWrite", "CustomerInvoiceCostWrite", "SaleWrite", "SupplierWrite", "SupplierInvoiceWrite", "SupplierInvoiceCostWrite", "UserWrite" };
        private static readonly HashSet<string> ReadRoles = new HashSet<string>() { "Admin", "CustomerRead", "CustomerInvoiceRead", "CustomerInvoiceCostRead", "SaleRead", "SupplierRead", "SupplierInvoiceRead", "SupplierInvoiceCostRead", "UserRead" };
        private static readonly HashSet<string> AdminGroupRoles = new HashSet<string>() { "CustomerAdmin", "CustomerInvoiceAdmin", "CustomerInvoiceCostAdmin", "SaleAdmin", "SupplierAdmin", "SupplierInvoiceAdmin", "SupplierInvoiceCostAdmin", "UserAdmin" };
        public Task<ICollection<Country>> CountriesList { get; set; }
        public Task<ICollection<CostRegistry>> CostRegistryList { get; set; }

        public MainForm()
        {
            _utilityService = new UtilityService();
            _userService = new UserService();

            InitializeComponent();
            AddFavoriteButton.Visible = false;
            IsMdiContainer = true; // Set the MDI container
            WindowState = FormWindowState.Maximized;

            CreateDockPanel();
            tabControl.TabPages.Remove(ShowTP);
            tabControl.TabPages.Remove(AddTP);
            tabControl.TabPages.Remove(GroupTP);
            tabControl.TabPages.Remove(ReportTP);
            UserProfile.Text = "Hello " + UserAccessInfo.Name;

        }
        private async void MainForm_Load(object sender, EventArgs e)
        {
            SetAuthorizations();
            CountriesList = _utilityService.GetAllCountry();
            CostRegistryList = _utilityService.GetAllCostRegistry();
            var preferredTask = GetPreferred();
            var updateTask = UpdateFavoriteTab();
            await Task.WhenAll(preferredTask, updateTask);
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
                BackColor = Color.FromArgb(174, 180, 194),
            };
            minimizedPanel.ColumnStyles.Clear();
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
            }

            if (UtilityFunctions.IsAuthorized(new HashSet<string>() { "CustomerRead", "CustomerInvoiceRead", "CustomerInvoiceCostRead", "SaleRead" }, requireAll: true) ||
                UtilityFunctions.IsAuthorized(new HashSet<string>() { "SupplierRead", "SupplierInvoiceRead", "SupplierInvoiceCostRead" }, requireAll: true) ||
                UtilityFunctions.IsAuthorized(AdminRoles))
            {
                tabControl.TabPages.Add(GroupTP);
            }
            if (UtilityFunctions.IsAuthorized(new HashSet<string>() { "CustomerRead", "CustomerInvoiceRead", "CustomerInvoiceCostRead", "SaleRead" }, requireAll: true) ||
                UtilityFunctions.IsAuthorized(new HashSet<string>() { "SupplierRead", "SupplierInvoiceRead", "SupplierInvoiceCostRead" }, requireAll: true) ||
                UtilityFunctions.IsAuthorized(AdminRoles))
            {
                tabControl.TabPages.Add(ReportTP);
            }

            // Impostazione visibilità ToolStripMenuItems
            CustomerShowTS.Visible = UtilityFunctions.IsAuthorized(new HashSet<string>() { "Admin", "CustomerRead", "CustomerWrite", "CustomerAdmin" });
            CustomerCreateTS.Visible = UtilityFunctions.IsAuthorized(new HashSet<string>() { "Admin", "CustomerWrite", "CustomerAdmin" });

            CustomerInvoiceShowTS.Visible = UtilityFunctions.IsAuthorized(new HashSet<string>() { "Admin", "CustomerInvoiceRead", "CustomerInvoiceWrite", "CustomerInvoiceAdmin" });
            CustomerInvoiceCreateTS.Visible = UtilityFunctions.IsAuthorized(new HashSet<string>() { "Admin", "CustomerInvoiceWrite", "CustomerInvoiceAdmin" });

            SupplierShowTS.Visible = UtilityFunctions.IsAuthorized(new HashSet<string>() { "Admin", "SupplierRead", "SupplierWrite", "SupplierAdmin" });
            SupplierCreateTS.Visible = UtilityFunctions.IsAuthorized(new HashSet<string>() { "Admin", "SupplierWrite", "SupplierAdmin" });

            SupplierInvoiceShowTS.Visible = UtilityFunctions.IsAuthorized(new HashSet<string>() { "Admin", "SupplierInvoiceRead", "SupplierInvoiceWrite", "SupplierInvoiceAdmin" });
            SupplierInvoiceCreateTS.Visible = UtilityFunctions.IsAuthorized(new HashSet<string>() { "Admin", "SupplierInvoiceWrite", "SupplierInvoiceAdmin" });

            SaleShowTS.Visible = UtilityFunctions.IsAuthorized(new HashSet<string>() { "Admin", "SaleRead", "SaleWrite", "SaleAdmin" });
            SaleCreateTS.Visible = UtilityFunctions.IsAuthorized(new HashSet<string>() { "Admin", "SaleWrite", "SaleAdmin" });

            UserShowTS.Visible = UtilityFunctions.IsAuthorized(new HashSet<string>() { "Admin" });
            UserCreateTS.Visible = UtilityFunctions.IsAuthorized(new HashSet<string>() { "Admin" });

            CustomerGroupTS.Visible = UtilityFunctions.IsAuthorized(ReadRoles, requireAll: true) ||
                                      UtilityFunctions.IsAuthorized(WriteRoles, requireAll: true) ||
                                      UtilityFunctions.IsAuthorized(AdminGroupRoles, requireAll: true) ||
                                      UtilityFunctions.IsAuthorized(AdminRoles);

            SupplierGroupTS.Visible = UtilityFunctions.IsAuthorized(AdminRoles) ||
                                      UtilityFunctions.IsAuthorized(new HashSet<string>() { "SupplierRead", "SupplierInvoiceRead", "SupplierInvoiceCostRead" }, requireAll: true) ||
                                      UtilityFunctions.IsAuthorized(new HashSet<string>() { "SupplierWrite", "SupplierInvoiceWrite", "SupplierInvoiceCostWrite" }, requireAll: true) ||
                                      UtilityFunctions.IsAuthorized(new HashSet<string>() { "SupplierAdmin", "SupplierInvoiceAdmin", "SupplierInvoiceCostAdmin" }, requireAll: true);

            SupplierInvoiceReportTS.Visible = UtilityFunctions.IsAuthorized(AdminRoles) ||
                                      UtilityFunctions.IsAuthorized(new HashSet<string>() { "SupplierRead", "SupplierInvoiceRead", "SupplierInvoiceCostRead", "SaleRead" }, requireAll: true) ||
                                      UtilityFunctions.IsAuthorized(new HashSet<string>() { "SupplierAdmin", "SupplierInvoiceAdmin", "SupplierInvoiceCostAdmin", "SaleAdmin" }, requireAll: true);
            CustomerInvoiceReportTS.Visible = SaleReportTS.Visible = UtilityFunctions.IsAuthorized(AdminRoles) ||
                                      UtilityFunctions.IsAuthorized(new HashSet<string>() { "CustomerRead", "CustomerInvoiceRead", "CustomerInvoiceCostRead", "SaleRead" }, requireAll: true) ||
                                      UtilityFunctions.IsAuthorized(new HashSet<string>() { "CustomerAdmin", "CustomerInvoiceAdmin", "CustomerInvoiceCostAdmin", "SaleAdmin" }, requireAll: true);
        }

        public async void buttonOpenChild_Click(object sender, EventArgs e)
        {
            var menuItem = sender as ToolStripButton;

            Cursor.Current = Cursors.WaitCursor;

            string tabName = menuItem.GetCurrentParent().Name;
            string formName;
            if (tabName.Equals("TS"))
                formName = tabName + " " + menuItem.Name;
            else
            {
                formName = tabName + " " + menuItem.Text;

                if (tabControl.SelectedTab.Text.Equals("Favorite"))
                {
                    formName = (string)menuItem.Tag;
                }
            }

            int? countOpenForms = MdiChildren.Count(x => x.WindowState != FormWindowState.Minimized);
            List<Form> childrenOpen = MdiChildren.Where(x => x.WindowState != FormWindowState.Minimized).ToList();

            // Check if the form is already open
            Form existingForm = MdiChildren.FirstOrDefault(f => f.Text == formName || f.Text == "User Area");
            if (existingForm != null)
            {
                formDockButton minimizedButton;
                if (formName == "TS UserProfile")
                    minimizedButton = minimizedPanel.Controls.OfType<formDockButton>()
                   .FirstOrDefault(btn => btn.Name == "User Area");
                else
                    // Check if the form is already minimized and exists in the minimized panel
                    minimizedButton = minimizedPanel.Controls.OfType<formDockButton>()
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
            Form child;

            switch (formName)
            {
                case "TS UserProfile":
                    child = new UserProfileForm();
                    break;

                case "Report Customer Invoice":
                    //child = new AllChartTest();
                    //child = new testChart();
                    child = new CustomerInvoiceReportForm();
                    break;
                case "Report Supplier Invoice":
                    child = new SupplierInvoiceReportForm();
                    break;
                case "Report Sale":
                    child = new SaleReportForm();
                    break;

                case "Show Customer":
                    child = new CustomerForm();
                    break;

                case "Show Customer Invoice":
                    child = new CustomerInvoiceForm();
                    break;

                case "Show Customer Invoice Cost":
                    child = new CustomerInvoiceCostForm();
                    break;

                case "Show Supplier":
                    child = new SupplierForm();
                    break;

                case "Show Supplier Invoice":
                    child = new SupplierInvoiceForm();
                    break;

                case "Show Supplier Invoice Cost":
                    child = new SupplierInvoiceCostsForm();
                    break;

                case "Show Sale":
                    child = new SaleForm();
                    break;

                case "Show User":
                    child = new UserForm();
                    break;

                case "Create Customer":
                    child = new CustomerDetailsForm();
                    break;

                case "Create Customer Invoice":
                    child = new CustomerInvoiceDetailsForm();
                    break;

                case "Create Customer Invoice Cost":
                    child = new CreateCustomerInvoiceCostForm();
                    break;

                case "Create Supplier":
                    child = new SupplierDetailsForm();
                    break;

                case "Create Supplier Invoice":
                    child = new SupplierInvoiceDetailsForm();
                    break;

                case "Create Supplier Invoice Cost":
                    child = new CreateSupplierInvoiceCostForm();
                    break;

                case "Create Sale":
                    child = new CreateSaleForm();
                    break;

                case "Create User":
                    child = new CreateUserForm();
                    break;

                case "Group Supplier":
                    child = new SupplierGroupForm();
                    break;

                case "Group Customer":
                    child = new CustomerGroupForm();
                    break;

                default:
                    child = new Form();
                    break;
            }


            child.StartPosition = FormStartPosition.CenterParent;

            child.Text = formName.Equals("TS UserProfile") ? "User Area" : formName;
            child.MdiParent = this;
            child.Size = new Size(800, 500);

            child.Resize += ChildForm_Resize;
            child.FormClosing += ChildForm_Close;

            if (favoriteList.Contains(child.Text))
                AddFavoriteButton.Image = WinformDotNetFramework.Properties.Resources.star_yellow_removebg;
            else
                AddFavoriteButton.Image = WinformDotNetFramework.Properties.Resources.star;

            if (!AddFavoriteButton.Visible)
                AddFavoriteButton.Visible = true;

            child.ShowIcon = false;
            child.Resize += Form_Resize;
            child.Activated += ChildForm_Activate;

            if (child.Text.Contains("Show") || child.Text.Contains("Group") || child.Text.Contains("Report"))
            {
                toolStripButton3.PerformClick();
                child.WindowState = FormWindowState.Maximized;
            }
            else if (child.Text.Contains("Create") || child.Text.Contains("Details"))
            {
                child.MaximizeBox = false;
                child.WindowState = FormWindowState.Normal;
            }



            child.Show();
            child.BringToFront();
            child.Activate();
            child.Focus(); // Aggiunto per garantire il focus
            child.TopMost = true;
            child.TopMost = false; // Reset per evitare problemi di persistenza

            LayoutMdi(MdiLayout.ArrangeIcons);
            Cursor.Current = Cursors.Default;
        }

        private void ChildForm_Activate(object sender, EventArgs e)
        {

            var latestForm = ActiveMdiChild;

            if (latestForm == null || latestForm.Text.Contains("Details"))
            {
                AddFavoriteButton.Visible = false;
            }
            else
            {
                if (favoriteList.Contains(latestForm.Text))
                    AddFavoriteButton.Image = Properties.Resources.star_yellow_removebg;
                else
                    AddFavoriteButton.Image = Properties.Resources.star;
            }

            if (!AddFavoriteButton.Visible)
                AddFavoriteButton.Visible = true;

        }

        public void ChildForm_Close(object sender, FormClosingEventArgs e)
        {
            BeginInvoke(new Action(UpdateMdiLayout));
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
                Location = new Point(0, 0)
            };

            // Add the button to the table layout panel in the next available column
            minimizedPanel.Controls.Add(minimizedButton, minimizedPanel.ColumnCount - 1, 0);

            // Set the column style to make buttons stretch horizontally
            minimizedPanel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, minimizedButton.Width));

            // Hide the minimized form in the MDI parent
            childForm.Hide();

            int? countOpenForms = MdiChildren.Count(x => x.WindowState != FormWindowState.Minimized);
            List<Form> childrenOpen = MdiChildren.Where(x => x.WindowState != FormWindowState.Minimized).ToList();
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

        private void MinimizeAll_Click(object sender, EventArgs e)
        {
            MdiChildren
                .Where(form => form.WindowState != FormWindowState.Minimized)
                .ToList()
                .ForEach(form => form.WindowState = FormWindowState.Minimized);
        }

        public async Task GetPreferred()
        {
            favoriteList = await _userService.GetAllPreferredPagesUser();
        }

        private async void AddFavoriteButton_Click(object sender, EventArgs e)
        {
            var latestForm = ActiveMdiChild;

            if (latestForm != null)
            {
                if (!latestForm.Name.Contains("Details"))
                {
                    string response;

                    if (favoriteList.Contains(latestForm.Text))
                    {
                        DialogResult result = MessageBox.Show($"Remove \"{latestForm.Text}\" from favorites?", "Favorite Confirmation",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            // Immediately update the button image
                            AddFavoriteButton.Image = WinformDotNetFramework.Properties.Resources.star;

                            response = await _userService.RemoveUserFavouritePage(new List<string>() { latestForm.Text });

                            // Remove the item from the local list immediately
                            favoriteList.Remove(latestForm.Text);

                            MessageBox.Show(response, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            await UpdateFavoriteTab();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show($"Add \"{latestForm.Text}\" to favorites?", "Favorite Confirmation",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            // Immediately update the button image
                            AddFavoriteButton.Image = WinformDotNetFramework.Properties.Resources.star_yellow_removebg;

                            response = await _userService.AddUserFavouritePage(new List<string>() { latestForm.Text });

                            // Add the item to the local list immediately
                            favoriteList.Add(latestForm.Text);

                            MessageBox.Show(response, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            await UpdateFavoriteTab();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Can't add details form to favorites");
                }
            }
            else
            {
                MessageBox.Show("No open form");
            }
        }

        public async Task UpdateFavoriteTab()
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
                        Padding = new Padding(0, 2, 0, 2),
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
                    { "Show Supplier", SupplierShowTS },
                    { "Show Supplier Invoice", SupplierInvoiceShowTS },
                    { "Show Sale", SaleShowTS },
                    { "Show User", UserShowTS },
                    { "Report Customer Invoice",CustomerInvoiceReportTS },
                    { "Report Supplier Invoice",SupplierInvoiceReportTS },
                    { "Report Sale",SaleReportTS },
                    { "Create Customer", CustomerCreateTS },
                    { "Create Customer Invoice", CustomerInvoiceCreateTS },
                    { "Create Supplier", SupplierCreateTS },
                    { "Create Supplier Invoice", SupplierInvoiceCreateTS },
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
                            AutoSize = true,
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

        private void Form_Resize(object sender, EventArgs e)
        {
            Form form = (Form)sender;

            if (form.WindowState == FormWindowState.Minimized)
            {
                var latestForm = ActiveMdiChild;

                if (latestForm == null)
                {
                    AddFavoriteButton.Visible = false;
                }
                else
                {
                    if (favoriteList.Contains(latestForm.Text))
                        AddFavoriteButton.Image = WinformDotNetFramework.Properties.Resources.star_yellow_removebg;
                    else
                        AddFavoriteButton.Image = WinformDotNetFramework.Properties.Resources.star;
                }

            }
            else
            {
                if (!AddFavoriteButton.Visible)
                    AddFavoriteButton.Visible = true;
            }

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            MdiChildren
                .ToList()
                .ForEach(form => form.Close());

            minimizedPanel.Controls.Clear();
        }
    }
}


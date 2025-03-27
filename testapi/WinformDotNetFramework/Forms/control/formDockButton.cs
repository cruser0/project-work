

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinformDotNetFramework.Services;

namespace WinformDotNetFramework.Forms.control
{
    public partial class formDockButton : UserControl
    {

        public formDockButton()
        {
            InitializeComponent();
        }

        public Button ButtonShowForm => buttonShowForm;
        Form form;
        TableLayoutPanel panel;
        MainForm mainForm;
        UserService _userService;
        public formDockButton(string buttonName, Form childForm, TableLayoutPanel panelFather, MainForm mainform)
        {
            _userService = new UserService();
            InitializeComponent();
            if (childForm.Text.Contains("Detail"))
            {
                AddFavoriteButton.Visible = false;
            }

            buttonShowForm.Text = buttonName;
            form = childForm;
            panel = panelFather;
            mainForm = mainform;

            Width = 2 + buttonShowForm.Width + buttonCloseForm.Width + AddFavoriteButton.Width;
            if (mainform.favoriteList.Contains(buttonName))
            {
                AddFavoriteButton.Image = Properties.Resources.star_yellow25x25;
                AddFavoriteButton.Tag = true;
            }
            else
            {
                AddFavoriteButton.Image = Properties.Resources.star25x25;
                AddFavoriteButton.Tag = false;
            }
        }

        public Form getForm()
        {
            return form;
        }

        public void buttonShowForm_Click(object sender, EventArgs e)
        {

            if (mainForm.favoriteList.Contains(buttonShowForm.Text))
                mainForm.AddFavoriteButton.Image = Properties.Resources.star_yellow_removebg;
            else
                mainForm.AddFavoriteButton.Image = Properties.Resources.star;


            form.Activate();
            form.Show();
            form.WindowState = FormWindowState.Normal;
            mainForm.LayoutMdi(MdiLayout.ArrangeIcons);
            panel.Controls.Remove(this);

        }


        private void buttonCloseForm_Click(object sender, EventArgs e)
        {

            // Cerca il ToolStripButton corrispondente al nome del form
            ToolStripItem buttonToRemove = mainForm.OpenFormDropDown.DropDownItems
                .Cast<ToolStripItem>()
                .FirstOrDefault(item => item.Text == form.Text);

            if (buttonToRemove != null)
            {
                // Rimuovi il ToolStripButton dagli items del dropdown
                mainForm.OpenFormDropDown.DropDownItems.Remove(buttonToRemove);
            }

            if (mainForm.MdiChildren.Count() == 1)
                mainForm.OpenFormDropDown.Enabled = false;


            form.Close();
            mainForm.LayoutMdi(MdiLayout.ArrangeIcons);
            panel.Controls.Remove(this);
        }

        private void UpdateFavoriteButton()
        {
            AddFavoriteButton.Tag = !(bool)AddFavoriteButton.Tag;
            if ((bool)AddFavoriteButton.Tag)
                AddFavoriteButton.Image = Properties.Resources.star_yellow25x25;
            else
                AddFavoriteButton.Image = Properties.Resources.star25x25;
        }

        private async void AddFavoriteButton_Click(object sender, EventArgs e)
        {


            string response;

            if ((bool)AddFavoriteButton.Tag)
            {
                DialogResult result = MessageBox.Show($"Remove \"{buttonShowForm.Text}\" from favorites?", "Favorite Confirmation",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    response = await _userService.RemoveUserFavouritePage(new List<string>() { buttonShowForm.Text });
                    MessageBox.Show(response, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AddFavoriteButton.Image = Properties.Resources.star25x25;
                    await UpdateFavoriteTab();  // Rimuovi o aggiorna la tab dopo la rimozione
                }
            }
            else
            {
                DialogResult result = MessageBox.Show($"Add \"{buttonShowForm.Text}\" to favorites?", "Favorite Confirmation",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    response = await _userService.AddUserFavouritePage(new List<string>() { buttonShowForm.Text });
                    MessageBox.Show(response, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AddFavoriteButton.Image = Properties.Resources.star_yellow25x25;
                    await UpdateFavoriteTab();  // Aggiungi o aggiorna la tab dopo l'aggiunta
                }
            }
        }

        private async Task UpdateFavoriteTab()
        {
            UpdateFavoriteButton();
            await mainForm.GetPreferred();

            // Se ci sono preferiti, aggiungi o aggiorna la TabPage
            if (mainForm.favoriteList.Count > 0)
            {
                ToolStrip toolstrip4;

                // Aggiungi la TabPage se non esiste
                if (!mainForm.tabControl.TabPages.ContainsKey("Favorite"))
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
                        Location = mainForm.Show.Location,
                        Padding = mainForm.Show.Padding,
                        AutoSize = false
                    };

                    FavoriteTB.Controls.Add(toolstrip4);
                    toolstrip4.Dock = DockStyle.Fill;

                    mainForm.tabControl.TabPages.Insert(0, FavoriteTB);
                }

                // Ottieni il ToolStrip associato alla tab dei preferiti
                toolstrip4 = mainForm.tabControl.TabPages["Favorite"].Controls.OfType<ToolStrip>().FirstOrDefault();

                // Rimuovi tutti i bottoni esistenti
                toolstrip4.Items.Clear();

                Dictionary<string, ToolStripButton> buttonMap = new Dictionary<string, ToolStripButton>
                    {
                        { "User Area", mainForm.UserProfile },
                        { "Show Customer", mainForm.CustomerShowTS },
                        { "Show Customer Invoice", mainForm.CustomerInvoiceShowTS },
                        { "Show Supplier", mainForm.SupplierShowTS },
                        { "Show Supplier Invoice", mainForm.SupplierInvoiceShowTS },
                        { "Show Sale", mainForm.SaleShowTS },
                        { "Show User", mainForm.UserShowTS },
                        { "Create Customer", mainForm.CustomerCreateTS },
                        { "Create Customer Invoice", mainForm.CustomerInvoiceCreateTS },
                        { "Create Supplier", mainForm.SupplierCreateTS },
                        { "Create Supplier Invoice", mainForm.SupplierInvoiceCreateTS },
                        { "Create Sale", mainForm.SaleCreateTS },
                        { "Create User", mainForm.UserCreateTS },
                        { "Group Supplier", mainForm.SupplierGroupTS },
                        { "Group Customer", mainForm.CustomerGroupTS }
                    };

                foreach (string favorite in mainForm.favoriteList)
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

                        clonedButton.Click += mainForm.buttonOpenChild_Click;

                        // Aggiungi il nuovo bottone alla ToolStrip
                        toolstrip4.Items.Add(clonedButton);
                    }
                }
            }
            else
            {
                // Se non ci sono preferiti, rimuovi la TabPage
                if (mainForm.tabControl.TabPages.ContainsKey("Favorite"))
                {
                    mainForm.tabControl.TabPages.RemoveByKey("Favorite");
                }
            }
        }
    }
}

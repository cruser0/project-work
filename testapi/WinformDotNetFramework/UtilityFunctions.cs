using System;
using System.Collections.Generic;
//using ClosedXML.Excel;
//using iText.Kernel.Geom;
//using iText.Kernel.Pdf;
//using iText.Layout;
//using iText.Layout.Element;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinformDotNetFramework.Entities;
using WinformDotNetFramework.Forms;
using WinformDotNetFramework.Forms.control;

namespace WinformDotNetFramework
{
    internal static class UtilityFunctions
    {
        private static MainForm mainForm => Application.OpenForms.OfType<MainForm>().FirstOrDefault();
        // Verifica se l'utente ha uno dei ruoli richiesti
        public static bool IsAuthorized(HashSet<string> requiredRoles, bool requireAll = false)
        {
            if (mainForm == null)
                return false;
            var userRoles = new HashSet<string>(UserAccessInfo.Role);
            return requireAll ? requiredRoles.All(userRoles.Contains) : requiredRoles.Any(userRoles.Contains);
        }

        public static void SetDropdownText(DropDownMenuAutoCompleteUserControl dropdown, string text)
        {
            dropdown.Cmbx.TextChanged -= dropdown.Cmbx_TextChanged;
            dropdown.Cmbx.Text = text;
            dropdown.Cmbx.TextChanged += dropdown.Cmbx_TextChanged;
        }

        public static void CreateFromDetails<T>(object sender, EventArgs e, object data) where T : Form
        {
            if (mainForm == null)
                return;

            // Chiude i form aperti dello stesso tipo
            CloseOpenForms<T>();

            TableLayoutPanel minimizedPanel = (TableLayoutPanel)mainForm.Controls.Find("minimizedPanel", true)[0];
            RemoveMinimizedButtons<T>(minimizedPanel);

            // Crea un'istanza del form di tipo T e lo apre
            T formInstance = (T)Activator.CreateInstance(typeof(T), data);
            formInstance.MdiParent = mainForm;
            formInstance.StartPosition = FormStartPosition.CenterScreen;
            formInstance.Size = formInstance.MinimumSize;
            formInstance.Text = FormatFormName(typeof(T).Name);
            formInstance.Resize += ChildForm_Resize;
            formInstance.FormClosing += ChildForm_Close;
            formInstance.Activated += FormInstance_Activated;

            formInstance.Show();
            formInstance.BringToFront();
            formInstance.Activate();

        }
        public static void CreateFromDetails<T>(object sender, EventArgs e, Form father, object data) where T : Form
        {
            if (mainForm == null)
                return;

            // Chiude i form aperti dello stesso tipo
            CloseOpenForms<T>();

            TableLayoutPanel minimizedPanel = (TableLayoutPanel)mainForm.Controls.Find("minimizedPanel", true)[0];
            RemoveMinimizedButtons<T>(minimizedPanel);

            // Crea un'istanza del form di tipo T e lo apre
            T formInstance = (T)Activator.CreateInstance(typeof(T), father, data);
            formInstance.MdiParent = mainForm;
            formInstance.StartPosition = FormStartPosition.CenterScreen;
            formInstance.Size = formInstance.MinimumSize;
            formInstance.Text = FormatFormName(typeof(T).Name);
            formInstance.Resize += ChildForm_Resize;
            formInstance.FormClosing += ChildForm_Close;
            formInstance.Activated += FormInstance_Activated;

            formInstance.Show();
            formInstance.BringToFront();
            formInstance.Activate();

        }

        // Apre un form dei dettagli (con ID) del tipo specificato
        public static void OpenFormDetails<T>(object sender, DataGridViewCellEventArgs e, int id) where T : Form
        {
            if (mainForm == null)
                return;
            if (sender is DataGridView dgv)
            {
                if (e.RowIndex == -1)
                    return;

                // Chiude i form aperti dello stesso tipo
                CloseOpenForms<T>();

                TableLayoutPanel minimizedPanel = (TableLayoutPanel)mainForm.Controls.Find("minimizedPanel", true)[0];
                RemoveMinimizedButtons<T>(minimizedPanel);

                // Crea un'istanza del form di tipo T e lo apre
                T formInstance = (T)Activator.CreateInstance(typeof(T), id);
                formInstance.MdiParent = mainForm;
                formInstance.StartPosition = FormStartPosition.CenterScreen;
                formInstance.Size = formInstance.MinimumSize;
                formInstance.Text = FormatFormName(typeof(T).Name);
                formInstance.Resize += ChildForm_Resize;
                formInstance.FormClosing += ChildForm_Close;
                formInstance.Activated += FormInstance_Activated;

                formInstance.Show();
                formInstance.BringToFront();
                formInstance.Activate();
            }
        }

        // Apre un form dei dettagli (con riferimento a un altro form) del tipo specificato
        public static void OpenFormDetails<T>(object sender, EventArgs e, Form father) where T : Form
        {
            if (mainForm == null)
                return;
            // Chiude i form aperti dello stesso tipo
            CloseOpenForms<T>();

            TableLayoutPanel minimizedPanel = (TableLayoutPanel)mainForm.Controls.Find("minimizedPanel", true)[0];
            RemoveMinimizedButtons<T>(minimizedPanel);

            // Crea un'istanza del form di tipo T e lo apre
            T formInstance = (T)Activator.CreateInstance(typeof(T), father);
            formInstance.MdiParent = mainForm;
            formInstance.StartPosition = FormStartPosition.CenterScreen;
            formInstance.Size = formInstance.MinimumSize;
            formInstance.Text = FormatFormName(typeof(T).Name);
            formInstance.Resize += ChildForm_Resize;
            formInstance.FormClosing += ChildForm_Close;
            formInstance.Activated += FormInstance_Activated;

            formInstance.Show();
            formInstance.BringToFront();
            formInstance.Activate();
        }

        private static void FormInstance_Activated(object sender, EventArgs e)
        {
            var latestForm = mainForm.ActiveMdiChild;

            if (latestForm == null || latestForm.Text.Contains("Details"))
            {
                mainForm.AddFavoriteButton.Visible = false;
            }
            else
            {
                if (mainForm.favoriteList.Contains(latestForm.Text))
                    mainForm.AddFavoriteButton.Image = Properties.Resources.star_yellow_removebg;
                else
                    mainForm.AddFavoriteButton.Image = Properties.Resources.star;
            }

            if (!mainForm.AddFavoriteButton.Visible)
                mainForm.AddFavoriteButton.Visible = true;
        }

        // Chiude i form aperti dello stesso tipo
        private static void CloseOpenForms<T>() where T : Form
        {
            if (mainForm == null)
                return;
            foreach (Form form in Application.OpenForms.Cast<Form>().ToList())
            {
                if (form is T)
                {
                    form.Close();
                }
            }
        }

        // Rimuove i pulsanti minimizzati dei form aperti dello stesso tipo
        private static void RemoveMinimizedButtons<T>(TableLayoutPanel minimizedPanel) where T : Form
        {
            if (mainForm == null)
                return;
            foreach (var button in minimizedPanel.Controls)
            {
                if (button is formDockButton btn)
                {
                    if (btn.getForm() is T)
                    {
                        btn.getForm().Close();

                        minimizedPanel.Controls.Remove(btn);
                    }
                }
            }
        }

        // Gestisce la chiusura di un form figlio
        public static void ChildForm_Close(object sender, FormClosingEventArgs e)
        {
            if (mainForm == null)
                return;
            mainForm.BeginInvoke(new Action(UpdateMdiLayout));
        }

        // Riorganizza i layout dei form MDI
        private static void UpdateMdiLayout()
        {
            int countOpenForms = mainForm.MdiChildren.Count(x => x.WindowState != FormWindowState.Minimized);
            mainForm.LayoutMdi(MdiLayout.ArrangeIcons);
        }

        // Gestisce il ridimensionamento di un form figlio
        public static void ChildForm_Resize(object sender, EventArgs e)
        {
            if (mainForm == null)
                return;
            var childForm = sender as Form;
            TableLayoutPanel minimizedPanel = (TableLayoutPanel)mainForm.Controls.Find("minimizedPanel", true)[0];

            if (childForm == null ||
                childForm.WindowState != FormWindowState.Minimized ||
                minimizedPanel.Controls.OfType<formDockButton>().Any(btn => btn.Name == childForm.Text))
            {
                return;
            }

            // Aggiunge un pulsante per il form minimizzato
            minimizedPanel.ColumnCount += 1;

            var minimizedButton = new formDockButton(childForm.Text, childForm, minimizedPanel, mainForm)
            {

                Name = childForm.Text,
                Dock = DockStyle.Top
            };

            minimizedPanel.Controls.Add(minimizedButton, minimizedPanel.ColumnCount - 1, 0);
            minimizedPanel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));

            childForm.Hide();
        }

        // Format the form name to be more user-friendly
        public static string FormatFormName(string formName)
        {
            if (mainForm == null)
                return "";
            if (formName.Contains("Details"))
            {
                // Capitalizes each word
                string formattedName = Regex.Replace(formName, "(?<=.)([A-Z])", " $1");
                formattedName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(formattedName.ToLower());

                return formattedName;
            }
            if (formName.Contains("Create"))
            {
                formName = formName.Substring(0, formName.Length - 4);
                // Capitalizes each word
                string formattedName = Regex.Replace(formName, "(?<=.)([A-Z])", " $1");
                formattedName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(formattedName.ToLower());

                return formattedName;
            }
            else
            {
                // Removes "Form" suffix and capitalizes each word
                if (formName.EndsWith("GridForm"))
                {
                    formName = formName.Substring(0, formName.Length - 8);
                }

                string formattedName = Regex.Replace(formName, "(?<=.)([A-Z])", " $1");
                formattedName = "Choose " + CultureInfo.CurrentCulture.TextInfo.ToTitleCase(formattedName.ToLower());

                return formattedName;
            }
        }
        public static async Task<List<Country>> GetCountries()
        {

            if (mainForm == null)
                return new List<Country>() { new Country() { CountryID = 0, CountryName = "All", ISOCountry = "All" } };

            return new List<Country>() { new Country() { CountryID = 0, CountryName = "All", ISOCountry = "All" } }
                .Concat(await mainForm.CountriesList)
                .ToList();
        }

        public static async Task<List<CostRegistry>> GetCostRegistry()
        {
            if (mainForm == null)
                return new List<CostRegistry>() { new CostRegistry() { CostRegistryID = 0, CostRegistryName = "All", CostRegistryPrice = 1, CostRegistryQuantity = 1, CostRegistryUniqueCode = "All" } };

            return new List<CostRegistry>() { new CostRegistry() { CostRegistryID = 0, CostRegistryName = "All", CostRegistryPrice = 1, CostRegistryQuantity = 1, CostRegistryUniqueCode = "All" } }
                .Concat(await mainForm.CostRegistryList)
                .ToList();
        }
    }
}

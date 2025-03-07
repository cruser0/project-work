using System.Globalization;
using System.Text.RegularExpressions;
using Winform.Forms.control;

namespace Winform
{
    internal static class UtilityFunctions
    {
        // Verifica se l'utente ha uno dei ruoli richiesti
        public static bool IsAuthorized(string[] requiredRoles, bool requireAll = false)
        {
            var userRoles = new HashSet<string>(UserAccessInfo.Role);

            return requireAll ? requiredRoles.All(userRoles.Contains) : requiredRoles.Any(userRoles.Contains);
        }

        private static MainForm mainForm = Application.OpenForms.OfType<MainForm>().First();

        // Apre un form dei dettagli (con ID) del tipo specificato
        public static void OpenFormDetails<T>(object? sender, DataGridViewCellEventArgs e, int id) where T : Form
        {
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
                formInstance.Size = formInstance.MinimumSize;
                formInstance.Text = FormatFormName(typeof(T).Name);
                formInstance.Resize += ChildForm_Resize;
                formInstance.FormClosing += ChildForm_Close;

                Panel mainPanel = (Panel)mainForm.Controls.Find("MainPanel", true)[0];
                mainPanel.Controls.Add(formInstance);
                formInstance.Show();
                formInstance.BringToFront();
                formInstance.Activate();
            }
        }

        // Apre un form dei dettagli (con riferimento a un altro form) del tipo specificato
        public static void OpenFormDetails<T>(object? sender, EventArgs e, Form father) where T : Form
        {
            // Chiude i form aperti dello stesso tipo
            CloseOpenForms<T>();

            TableLayoutPanel minimizedPanel = (TableLayoutPanel)mainForm.Controls.Find("minimizedPanel", true)[0];
            RemoveMinimizedButtons<T>(minimizedPanel);

            // Crea un'istanza del form di tipo T e lo apre
            T formInstance = (T)Activator.CreateInstance(typeof(T), father);
            formInstance.MdiParent = mainForm;
            formInstance.Size = formInstance.MinimumSize;
            formInstance.Text = FormatFormName(typeof(T).Name);
            formInstance.Resize += ChildForm_Resize;
            formInstance.FormClosing += ChildForm_Close;

            Panel mainPanel = (Panel)mainForm.Controls.Find("MainPanel", true)[0];
            mainPanel.Controls.Add(formInstance);
            formInstance.Show();
            formInstance.BringToFront();
            formInstance.Activate();
        }

        // Chiude i form aperti dello stesso tipo
        private static void CloseOpenForms<T>() where T : Form
        {
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
            mainForm.BeginInvoke(new Action(UpdateMdiLayout));
        }

        // Riorganizza i layout dei form MDI
        private static void UpdateMdiLayout()
        {
            Panel mainPanel = (Panel)mainForm.Controls.Find("MainPanel", true)[0];
            int countOpenForms = mainPanel.Controls.OfType<Form>().Count(x => x.WindowState != FormWindowState.Minimized);
            mainForm.LayoutMdi(MdiLayout.ArrangeIcons);
        }

        // Gestisce il ridimensionamento di un form figlio
        public static void ChildForm_Resize(object sender, EventArgs e)
        {
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
            if (formName.Contains("Details"))
            {
                // Capitalizes each word
                return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(formName.ToLower());
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
    }
}

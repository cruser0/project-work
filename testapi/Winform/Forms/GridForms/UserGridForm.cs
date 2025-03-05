using API.Models.Filters;
using Winform.Entities.DTO;
using Winform.Entities.Preference;
using Winform.Services;

namespace Winform.Forms.GridForms
{
    public partial class UserGridForm : Form
    {
        private UserService _userService;

        string name;
        string lastname;
        string email;
        List<string> selectedRoles;

        int pages;
        double itemsPage = 10.0;

        public UserGridForm()
        {
            _userService = new UserService();
            pages = (int)Math.Ceiling(_userService.Count(new UserFilter()) / itemsPage);


            InitializeComponent();
            RightSideBar.searchBtnEvent += MyControl_ButtonClicked;

            paginationControl.SingleRightArrowEvent += PaginationUserControl_SingleRightArrowEvent;
            paginationControl.DoubleRightArrowEvent += PaginationUserControl_DoubleRightArrowEvent;
            paginationControl.DoubleLeftArrowEvent += PaginationUserControl_DoubleLeftArrowEvent;
            paginationControl.SingleLeftArrowEvent += PaginationUserControl_SingleLeftArrowEvent;

            rolesListBox.ItemCheck -= rolesListBox_ItemCheck;
            for (int i = 0; i < rolesListBox.Items.Count; i++)
            {
                rolesListBox.SetItemChecked(i, true);
            }
            rolesListBox.ItemCheck += rolesListBox_ItemCheck;

            paginationControl.Visible = false;
            paginationControl.SetMaxPage(pages.ToString());
            paginationControl.CurrentPage = 1;
            paginationControl.SetPageLbl(paginationControl.CurrentPage + "/" + paginationControl.GetmaxPage());
            userDgv.ContextMenuStrip = RightClickDgv;
            if (!UtilityFunctions.IsAuthorized(new[] { "UserAdmin", "Admin" }))
                UserIDTsmi.Visible = false;
        }

        private void MyControl_ButtonClicked(object sender, EventArgs e)
        {
            // Reset della paginazione
            paginationControl.CurrentPage = 1;

            // Inizializza la lista dei ruoli selezionati
            selectedRoles = new List<string>();

            // Controlla se il primo elemento della lista non è selezionato
            if (!rolesListBox.GetItemChecked(0))
            {
                for (int i = 1; i < rolesListBox.Items.Count; i++) // Salta il primo elemento
                {
                    if (rolesListBox.GetItemChecked(i)) // Solo elementi selezionati
                    {
                        selectedRoles.Add(rolesListBox.Items[i].ToString());
                    }
                }
            }

            // Recupera i dati dai campi di input
            name = nameTxt.Text;
            lastname = lastNameTxt.Text;
            email = Emailtxt.Text;

            // Crea il filtro per il recupero dei dati
            UserFilter filter = new UserFilter
            {
                UserName = name,
                UserLastName = lastname,
                UserEmail = email,
                UserRoles = selectedRoles,
                UserPage = paginationControl.CurrentPage
            };

            // Filtro per il conteggio delle pagine
            UserFilter filterPage = new UserFilter
            {
                UserName = name,
                UserLastName = lastname,
                UserEmail = email,
                UserRoles = selectedRoles
            };

            // Recupera i dati filtrati e aggiorna la DataGridView
            IEnumerable<UserRoleDTO> query = _userService.GetAll(filter);
            userDgv.DataSource = query.ToList();

            // Aggiungi la colonna per i ruoli, se non presente
            if (!userDgv.Columns.Contains("Roles"))
            {
                DataGridViewTextBoxColumn rolesColumn = new DataGridViewTextBoxColumn
                {
                    Name = "Roles",
                    HeaderText = "Roles",
                    DataPropertyName = "RolesAsString" // Bind to the computed property
                };
                userDgv.Columns.Add(rolesColumn);
            }

            // Aggiorna il numero massimo di pagine per la paginazione
            int totalRecords = _userService.Count(filterPage);
            int maxPages = (int)Math.Ceiling((double)totalRecords / itemsPage);
            paginationControl.maxPage = maxPages.ToString();
            paginationControl.SetPageLbl($"{paginationControl.CurrentPage}/{maxPages}");

            // Imposta la visibilità e le colonne della DataGridView
            if (!paginationControl.Visible)
            {
                SetCheckBoxes();
            }
        }
        private void SetCheckBoxes()
        {
            UserDGV cdgv = _userService.GetUserDGV();
            UserIDTsmi.Checked = cdgv.ShowID;
            UserNameTsmi.Checked = cdgv.ShowName;
            UserLastNameTsmi.Checked = cdgv.ShowLastName;
            UserEmailTsmi.Checked = cdgv.ShowEmail;
            UserrRoleTsmi.Checked = cdgv.ShowRoles;
            paginationControl.Visible = true;
            userDgv.Columns["UserID"].Visible = cdgv.ShowID;
            userDgv.Columns["Name"].Visible = cdgv.ShowName;
            userDgv.Columns["LastName"].Visible = cdgv.ShowLastName;
            userDgv.Columns["Email"].Visible = cdgv.ShowEmail;
            userDgv.Columns["Roles"].Visible = cdgv.ShowRoles;
        }
        private void MyControl_ButtonClicked_Pagination(object sender, EventArgs e)
        {


            UserFilter filter = new UserFilter
            {
                UserName = name,
                UserLastName = lastname,
                UserEmail = email,
                UserRoles = selectedRoles,
                UserPage = paginationControl.CurrentPage

            };

            IEnumerable<UserRoleDTO> query = _userService.GetAll(filter);
            userDgv.DataSource = query.ToList();
        }


        private void PaginationUserControl_SingleLeftArrowEvent(object? sender, EventArgs e)
        {
            if (paginationControl.CurrentPage <= 1)
                return;
            paginationControl.CurrentPage = paginationControl.CurrentPage - 1;
            paginationControl.SetPageLbl(paginationControl.CurrentPage + "/" + paginationControl.GetmaxPage());
            MyControl_ButtonClicked_Pagination(sender, e);
        }

        private void PaginationUserControl_DoubleLeftArrowEvent(object? sender, EventArgs e)
        {

            paginationControl.CurrentPage = 1;
            paginationControl.SetPageLbl(paginationControl.CurrentPage + "/" + paginationControl.GetmaxPage());
            MyControl_ButtonClicked_Pagination(sender, e);
        }

        private void PaginationUserControl_DoubleRightArrowEvent(object? sender, EventArgs e)
        {
            paginationControl.CurrentPage = int.Parse(paginationControl.GetmaxPage());
            paginationControl.SetPageLbl(paginationControl.CurrentPage + "/" + paginationControl.GetmaxPage());
            MyControl_ButtonClicked_Pagination(sender, e);
        }

        private void PaginationUserControl_SingleRightArrowEvent(object? sender, EventArgs e)
        {
            if (paginationControl.CurrentPage >= int.Parse(paginationControl.GetmaxPage()))
                return;
            paginationControl.CurrentPage++;
            paginationControl.SetPageLbl(paginationControl.CurrentPage + "/" + paginationControl.GetmaxPage());
            MyControl_ButtonClicked_Pagination(sender, e);

        }




        public virtual void MyControl_OpenDetails_Clicked(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void CustomerGridForm_Resize(object sender, EventArgs e)
        {

            PaginationPanel.Location = new Point((Width - PaginationPanel.Width) / 2, 0);
            paginationControl.Location = new Point((PaginationPanel.Width - paginationControl.Width) / 2,
                (PaginationPanel.Height - paginationControl.Height) / 2);


            int newHeight = (int)((Height - FilterPanel.Top) * 0.9);
            if (FilterPanel.Height != newHeight)
            {
                FilterPanel.Height = newHeight;
            }
        }

        private void userDgv_RightClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                RightClickDgv.Show(userDgv, userDgv.PointToClient(Cursor.Position));
            }
        }

        private void ContextMenuStripCheckEvent(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem tsmi)
            {
                string name = tsmi.Name;
                switch (name)
                {
                    case "UserIDTsmi":
                        userDgv.Columns["UserID"].Visible = tsmi.Checked;
                        break;
                    case "UserNameTsmi":
                        userDgv.Columns["Name"].Visible = tsmi.Checked;
                        break;
                    case "UserLastNameTsmi":
                        userDgv.Columns["LastName"].Visible = tsmi.Checked;
                        break;
                    case "UserEmailTsmi":
                        userDgv.Columns["Email"].Visible = tsmi.Checked;
                        break;
                    case "UserRoleTsmi":
                        userDgv.Columns["RoleAsString"].Visible = tsmi.Checked;
                        break;
                    default:
                        break;
                }
                UserDGV cdgv = new UserDGV
                {
                    ShowID = UserIDTsmi.Checked,
                    ShowLastName = UserLastNameTsmi.Checked,
                    ShowEmail = UserEmailTsmi.Checked,
                    ShowRoles = UserrRoleTsmi.Checked,
                    ShowName = UserNameTsmi.Checked,
                    UserID = UserAccessInfo.RefreshUserID
                };
                _userService.PostUserDGV(cdgv);

            }
        }

        private void rolesListBox_Click(object sender, EventArgs e)
        {
            CheckedListBox clb = sender as CheckedListBox;
            int index = clb.SelectedIndex;

            bool checkState = !clb.GetItemChecked(index); // Inverti lo stato
            clb.SetItemChecked(index, checkState); // Aggiorna il primo elemento


        }

        private void rolesListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            CheckedListBox clb = sender as CheckedListBox;

            if (e.Index == 0) // Se è il primo elemento (Seleziona/Deseleziona tutto)
            {
                this.BeginInvoke(new Action(() =>
                {
                    bool checkState = e.NewValue == CheckState.Checked;
                    for (int i = 1; i < clb.Items.Count; i++)
                    {
                        clb.SetItemChecked(i, checkState);
                    }
                }));
            }
            else // Se si sta modificando un altro elemento
            {
                this.BeginInvoke(new Action(() =>
                {
                    bool allChecked = true;
                    for (int i = 1; i < clb.Items.Count; i++)
                    {
                        if (!clb.GetItemChecked(i))
                        {
                            allChecked = false;
                            break;
                        }
                    }
                    clb.SetItemChecked(0, allChecked); // Se tutti gli elementi sono checkati, checka anche il primo
                }));
            }
        }

    }
}

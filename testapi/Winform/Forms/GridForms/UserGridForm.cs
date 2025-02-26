using API.Models.Filters;
using Winform.Entities.DTO;
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
            RightSideBar.closeBtnEvent += RightSideBar_closeBtnEvent;

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
        }

        private void MyControl_ButtonClicked(object sender, EventArgs e)
        {
            paginationControl.CurrentPage = 1;

            selectedRoles = new List<string>();

            if (!rolesListBox.GetItemChecked(0))
            {
                for (int i = 1; i < rolesListBox.Items.Count; i++) // Inizia da 1 per escludere il primo elemento
                {
                    if (!rolesListBox.GetItemChecked(i)) // Verifica se l'elemento è selezionato
                    {
                        selectedRoles.Add(rolesListBox.Items[i].ToString()); // Aggiunge il testo dell'elemento alla lista
                    }
                }
            }

            name = nameTxt.Text;
            lastname = lastNameTxt.Text;
            email = Emailtxt.Text;


            UserFilter filter = new UserFilter
            {
                Name = name,
                LastName = lastname,
                Email = email,
                Roles = selectedRoles,
                page = paginationControl.CurrentPage

            };
            UserFilter filterPage = new UserFilter
            {
                Name = name,
                LastName = lastname,
                Email = email,
                Roles = selectedRoles
            };

            IEnumerable<UserRoleDTO> query = _userService.GetAll(filter);
            paginationControl.maxPage = ((int)Math.Ceiling(_userService.Count(filterPage) / itemsPage)).ToString();
            paginationControl.SetPageLbl(paginationControl.CurrentPage + "/" + paginationControl.GetmaxPage());

            userDgv.DataSource = query.ToList();


            if (!paginationControl.Visible)
            {
                userDgv.Columns["UserID"].Visible = false;
                paginationControl.Visible = true;
            }

        }
        private void MyControl_ButtonClicked_Pagination(object sender, EventArgs e)
        {


            UserFilter filter = new UserFilter
            {
                Name = name,
                LastName = lastname,
                Email = email,
                Roles = selectedRoles,
                page = paginationControl.CurrentPage

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


        private void RightSideBar_closeBtnEvent(object? sender, EventArgs e)
        {
            this.Close();
        }

        public virtual void MyControl_OpenDetails_Clicked(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void CustomerGridForm_Resize(object sender, EventArgs e)
        {

            PaginationPanel.Location = new Point((Width - PaginationPanel.Width) / 2, 0);
            paginationControl.Location = new Point((PaginationPanel.Width - paginationControl.Width) / 2, (PaginationPanel.Height - paginationControl.Height) / 2);
            int newHeight = Top - FilterPanel.Top;
            if (FilterPanel.Height != newHeight)
            {
                FilterPanel.Height = newHeight;
            }
        }

        private void userDgv_RightClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hitTest = userDgv.HitTest(e.X, e.Y);
                if (hitTest.RowIndex >= 0)
                {
                    RightClickDgv.Show(userDgv, e.Location);
                }
            }
        }

        private void ContextMenuStripCheckEvent(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem tsmi)
            {
                string name = tsmi.Name;
                switch (name)
                {
                    case "CustomerIDTsmi":
                        userDgv.Columns["UserID"].Visible = tsmi.Checked;
                        break;
                    case "CustomerNameTsmi":
                        userDgv.Columns["Name"].Visible = tsmi.Checked;
                        break;
                    case "CustomerCountryTsmi":
                        userDgv.Columns["LastName"].Visible = tsmi.Checked;
                        break;
                    case "CustomerDateTsmi":
                        userDgv.Columns["Email"].Visible = tsmi.Checked;
                        break;
                    case "CustomerStatusTsmi":
                        userDgv.Columns["Role"].Visible = tsmi.Checked;
                        break;
                    default:
                        break;
                }

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

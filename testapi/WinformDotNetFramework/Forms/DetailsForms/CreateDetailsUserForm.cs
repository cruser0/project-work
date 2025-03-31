using Entity_Validator.Entity.DTO;
using Entity_Validator.Entity.Procedures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using WinformDotNetFramework.Services;

namespace WinformDotNetFramework.Forms.DetailsForms
{
    public partial class CreateDetailsUserForm : Form
    {
        UserService _userService;
        UserRoleDTO user;
        bool _detailsOnly;

        public CreateDetailsUserForm()
        {
            _userService = new UserService();
            InitializeComponent();
            _detailsOnly = false;
            checkBox1.Visible = false;
        }

        public CreateDetailsUserForm(int id)
        {
            _userService = new UserService();
            InitializeComponent();
            Init(id);
            _detailsOnly = true;
        }

        private async void Init(int id)
        {

            user = await _userService.GetById(id);
            UserNameTxt.Text = user.Name;
            UserLastNameTxt.Text = user.LastName;
            UserEmailTxt.Text = user.Email;
            foreach (var role in user.Role)
            {
                int roleIndex = rolesListBox.Items.IndexOf(role);
                if (roleIndex != -1)
                {
                    rolesListBox.SetItemChecked(roleIndex, true);
                }
            }

            checkBox1.Visible = true;

            rolesListBox.Enabled = false;
            PasswordTxt.Enabled = false;
            PasswordSeeBtn.Enabled = false;
            UserEmailTxt.Enabled = false;
            UserLastNameTxt.Enabled = false;
            UserNameTxt.Enabled = false;

            List<string> authRolesWrite = new List<string>
            {
                "UserWrite",
                "UserAdmin",
                "Admin"
            };
            List<string> authRoles = new List<string>
            {
                "UserAdmin",
                "Admin"
            };
            if (!Authorize(authRolesWrite))
            {
                SaveBtn.Visible = false;
                checkBox1.Visible = false;
            }
            if (!Authorize(authRoles))
                rolesListBox.Enabled = false;
        }
        private bool Authorize(List<string> allowedRoles)
        {
            return allowedRoles.Any(role => UserAccessInfo.Role.Contains(role));
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            rolesListBox.Enabled = checkBox1.Checked;
            PasswordTxt.Enabled = checkBox1.Checked;
            PasswordSeeBtn.Enabled = checkBox1.Checked;
            UserEmailTxt.Enabled = checkBox1.Checked;
            UserLastNameTxt.Enabled = checkBox1.Checked;
            UserNameTxt.Enabled = checkBox1.Checked;
        }
        private bool TwoListCheck(List<string> list1, List<string> list2)
        {
            list1.Sort();
            list2.Sort();
            if (list1.Count != list2.Count)
                return false;
            for (int i = 0; i < list1.Count; i++)
            {
                if (!list1[i].Equals(list2[i]))
                {
                    return false;
                }
            }
            return true;
        }

        private void PasswordSeeBtn_Click(object sender, EventArgs e)
        {
            if (PasswordTxt.PasswordChar.Equals('•'))
                PasswordTxt.PasswordChar = default(char);
            else
                PasswordTxt.PasswordChar = '•';
        }

        private void UserNameTxt_TextChanged(object sender, EventArgs e)
        {
            SaveBtn.Enabled = PasswordTxt.Text.Length > 0 &&
                UserNameTxt.Text.Length > 0 &&
                UserLastNameTxt.Text.Length > 0 &&
                UserEmailLbl.Text.Length > 0 &&
                rolesListBox.CheckedItems.Count > 0;
        }

        private void rolesListBox_CheckedItems(object sender, ItemCheckEventArgs e)
        {
            int newCheckedCount = rolesListBox.CheckedItems.Count + (e.NewValue == CheckState.Checked ? 1 : -1);

            SaveBtn.Enabled = PasswordTxt.Text.Length > 0 &&
                              UserNameTxt.Text.Length > 0 &&
                              UserLastNameTxt.Text.Length > 0 &&
                              UserEmailLbl.Text.Length > 0 &&
                              newCheckedCount > 0;
        }


        private async Task UpdateClick(bool quit = false)
        {
            var list = rolesListBox.CheckedItems;
            List<string> roles = new List<string>();
            foreach (var role in list)
            {
                roles.Add(role.ToString());
            }
            if (UserEmailTxt.Text.Equals(user.Email) &&
                UserLastNameTxt.Equals(user.LastName) &&
                string.IsNullOrEmpty(PasswordTxt.Text) &&
                UserNameTxt.Equals(user.Name) && TwoListCheck(user.Role, roles))
                return;
            UserDTOEdit si = new UserDTOEdit
            {
                Email = UserEmailTxt.Text,
                LastName = UserLastNameTxt.Text,
                Name = UserNameTxt.Text,
                Password = !string.IsNullOrEmpty(PasswordTxt.Text) ? PasswordTxt.Text : null,
            };
            AssignRoleDTO ar = new AssignRoleDTO
            {
                Roles = roles,
                UserID = user.UserID,
            };
            try
            {
                await _userService.Update(user.UserID, si);
                await _userService.EditUserRoles(ar);
                MessageBox.Show("User updated successfully!");
                if (quit) Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private async Task CreateClick(bool quit = false)
        {
            List<string> roles = rolesListBox.CheckedItems.Cast<string>().ToList();


            UserDTOCreate user = new UserDTOCreate()
            {
                Name = UserNameTxt.Text,
                LastName = UserLastNameTxt.Text,
                Email = UserEmailTxt.Text,
                Password = PasswordTxt.Text,
                Role = roles
            };

            try
            {
                await _userService.Register(user);
                MessageBox.Show("User Created Succesfully");
                if (quit) Close();

                _detailsOnly = true;
                int id = (await _userService.GetAll(new UserFilter()
                {
                    UserName = UserNameTxt.Text,
                    UserLastName = UserLastNameTxt.Text,
                    UserEmail = UserEmailTxt.Text,

                })).FirstOrDefault().UserID;

                Init(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private async void SaveEditCustomerBtn_Click(object sender, EventArgs e)
        {
            if (_detailsOnly)
            {
                await UpdateClick();
            }
            else
            {
                await CreateClick();
            }
        }

        private async void SaveQuitButton_Click(object sender, EventArgs e)
        {
            if (_detailsOnly)
            {
                await UpdateClick(true);
            }
            else
            {
                await CreateClick(true);
            }
        }
    }
}

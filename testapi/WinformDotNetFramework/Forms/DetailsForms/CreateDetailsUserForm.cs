using Entity_Validator;
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
            NameCtb.SetPropName("Name");
            LastNameCtb.SetPropName("LastName");
            EmailCtb.SetPropName("Email");
            PasswordCtb.SetPropName("Password");

            _detailsOnly = false;
            checkBox1.Visible = false;
        }

        public CreateDetailsUserForm(int id)
        {
            _userService = new UserService();
            InitializeComponent();

            NameCtb.SetPropName("Name");
            LastNameCtb.SetPropName("LastName");
            EmailCtb.SetPropName("Email");
            PasswordCtb.SetPropName("Password");
            Init(id);
            _detailsOnly = true;
        }

        private async void Init(int id)
        {

            user = await _userService.GetById(id);
            NameCtb.PropTxt.Text = user.Name;
            LastNameCtb.PropTxt.Text = user.LastName;
            EmailCtb.PropTxt.Text = user.Email;
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
            PasswordCtb.PropTxt.Enabled = false;
            PasswordSeeBtn.Enabled = false;
            EmailCtb.PropTxt.Enabled = false;
            LastNameCtb.PropTxt.Enabled = false;
            NameCtb.PropTxt.Enabled = false;

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
            PasswordCtb.PropTxt.Enabled = checkBox1.Checked;
            PasswordSeeBtn.Enabled = checkBox1.Checked;
            EmailCtb.PropTxt.Enabled = checkBox1.Checked;
            LastNameCtb.PropTxt.Enabled = checkBox1.Checked;
            NameCtb.PropTxt.Enabled = checkBox1.Checked;
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
            if (PasswordCtb.PropTxt.PasswordChar.Equals('•'))
                PasswordCtb.PropTxt.PasswordChar = default(char);
            else
                PasswordCtb.PropTxt.PasswordChar = '•';
        }

        private void NameTxt_TextChanged(object sender, EventArgs e)
        {
            SaveBtn.Enabled = PasswordCtb.PropTxt.Text.Length > 0 &&
                NameCtb.PropTxt.Text.Length > 0 &&
                LastNameCtb.PropTxt.Text.Length > 0 &&
                EmailCtb.PropTxt.Text.Length > 0 &&
                rolesListBox.CheckedItems.Count > 0;
        }

        private void rolesListBox_CheckedItems(object sender, ItemCheckEventArgs e)
        {
            int newCheckedCount = rolesListBox.CheckedItems.Count + (e.NewValue == CheckState.Checked ? 1 : -1);

            SaveBtn.Enabled = PasswordCtb.PropTxt.Text.Length > 0 &&
                              NameCtb.PropTxt.Text.Length > 0 &&
                              LastNameCtb.PropTxt.Text.Length > 0 &&
                              EmailCtb.PropTxt.Text.Length > 0 &&
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
            if (EmailCtb.PropTxt.Text.Equals(user.Email) &&
                LastNameCtb.PropTxt.Equals(user.LastName) &&
                string.IsNullOrEmpty(PasswordCtb.PropTxt.Text) &&
                NameCtb.PropTxt.Equals(user.Name) && TwoListCheck(user.Role, roles))
                return;

            UserDTOEdit si = new UserDTOEdit
            {
                Email = EmailCtb.PropTxt.Text,
                LastName = LastNameCtb.PropTxt.Text,
                Name = NameCtb.PropTxt.Text,
                Password = !string.IsNullOrEmpty(PasswordCtb.PropTxt.Text) ? PasswordCtb.PropTxt.Text : null,
            };
            AssignRoleDTO ar = new AssignRoleDTO
            {
                Roles = roles,
                UserID = user.UserID,
            };

            si.IsPost = false;
            var validated = ValidatorEntity.Validate(si);
            if (validated.Any())
            {
                UtilityFunctions.ValidateTextBoxes(panel3, si);
                return;
            }
            await _userService.Update((int)user.UserID, si);
            await _userService.EditUserRoles(ar);
            MessageBox.Show("User updated successfully!");
            if (quit) Close();

        }
        private async Task CreateClick(bool quit = false)
        {
            List<string> roles = rolesListBox.CheckedItems.Cast<string>().ToList();
            if (roles.Count == 0) { return; }

            UserDTOCreate user = new UserDTOCreate()
            {
                Name = NameCtb.PropTxt.Text,
                LastName = LastNameCtb.PropTxt.Text,
                Email = EmailCtb.PropTxt.Text,
                Password = PasswordCtb.PropTxt.Text,
                Role = roles
            };
            user.IsPost = true;
            var validated = ValidatorEntity.Validate(user);
            if (validated.Any())
            {
                UtilityFunctions.ValidateTextBoxes(panel3, user);
                return;
            }

            await _userService.Register(user);
            MessageBox.Show("User Created Succesfully");
            if (quit) Close();

            _detailsOnly = true;
            int id = (int)(await _userService.GetAll(new UserFilter()
            {
                UserName = NameCtb.PropTxt.Text,
                UserLastName = LastNameCtb.PropTxt.Text,
                UserEmail = EmailCtb.PropTxt.Text,

            })).FirstOrDefault().UserID;

            Init(id);
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

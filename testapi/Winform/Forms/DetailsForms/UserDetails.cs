using Winform.Entities.DTO;
using Winform.Services;

namespace Winform.Forms.DetailsForms
{
    public partial class UserDetails : Form
    {
        readonly UserService _userService;
        UserRoleDTO user;
        public UserDetails(int id)
        {
            _userService = new UserService();
            InitializeComponent();
            user = _userService.GetById(id);
            UserIDTxt.Text = user.UserID.ToString();
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
            rolesListBox.Enabled = false;
            PasswordTxt.Enabled = false;
            PasswordSeeBtn.Enabled = false;
            UserEmailTxt.Enabled = false;
            UserLastNameTxt.Enabled = false;
            UserNameTxt.Enabled = false;
            UserIDTxt.Enabled = false;

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
        private void SaveEditCustomerBtn_Click(object sender, EventArgs e)
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
                UserID = int.Parse(UserIDTxt.Text),
            };
            try
            {
                _userService.Update(int.Parse(UserIDTxt.Text), si);
                _userService.EditUserRoles(ar);
                MessageBox.Show("User updated successfully!");

                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void PasswordSeeBtn_Click(object sender, EventArgs e)
        {
            if (PasswordTxt.PasswordChar.Equals('*'))
                PasswordTxt.PasswordChar = default(char);
            else
                PasswordTxt.PasswordChar = '*';
        }
    }
}

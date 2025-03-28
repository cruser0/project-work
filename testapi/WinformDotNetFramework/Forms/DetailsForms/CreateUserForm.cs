using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WinformDotNetFramework.Entities.DTO;
using WinformDotNetFramework.Services;

namespace WinformDotNetFramework.Forms.DetailsForms
{
    public partial class CreateUserForm : Form
    {
        UserService _userService;
        public CreateUserForm()
        {
            _userService = new UserService();
            InitializeComponent();
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
            button1.Enabled = PasswordTxt.Text.Length > 0 &&
                UserNameTxt.Text.Length > 0 &&
                UserLastNameTxt.Text.Length > 0 &&
                UserEmailLbl.Text.Length > 0 &&
                rolesListBox.CheckedItems.Count > 0;
        }

        private void rolesListBox_CheckedItems(object sender, ItemCheckEventArgs e)
        {
            int newCheckedCount = rolesListBox.CheckedItems.Count + (e.NewValue == CheckState.Checked ? 1 : -1);

            button1.Enabled = PasswordTxt.Text.Length > 0 &&
                              UserNameTxt.Text.Length > 0 &&
                              UserLastNameTxt.Text.Length > 0 &&
                              UserEmailLbl.Text.Length > 0 &&
                              newCheckedCount > 0;
        }

        private async void SaveBtn_Click(object sender, EventArgs e)
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

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

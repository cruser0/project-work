using Winform.Entities.DTO;
using Winform.Services;

namespace Winform.Forms.AddForms
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

        private void SaveBtn_Click(object sender, EventArgs e)
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
                _userService.Register(user);
                MessageBox.Show("User Created Succesfully");
                Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

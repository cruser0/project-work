using Entity_Validator.Entity.DTO;
using System;
using System.Windows.Forms;
using WinformDotNetFramework.Services;

namespace WinformDotNetFramework.Forms
{
    public partial class LoginForm : Form
    {

        private UserService _userService;
        public LoginForm()
        {
            _userService = new UserService();
            InitializeComponent();
        }


        private async void EnterBtn_Click(object sender, EventArgs e)
        {
            UserDTO user = new UserDTO()
            {
                Email = EmailTxt.Text,
                Password = PasswordTxt.Text,
            };
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var ret = await _userService.Login(user);
                DialogResult = DialogResult.OK;
                Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var ret = await _userService.Login(new UserDTO() { Email = "Customeradmin", Password = "string" });
            DialogResult = DialogResult.OK;
            Close();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            var ret = await _userService.Login(new UserDTO() { Email = "Admin@admin.com", Password = "Admin" });
            DialogResult = DialogResult.OK;
            Close();
        }

        private void EmailTxt_TextChanged(object sender, EventArgs e)
        {
            EnterBtn.Enabled = EmailTxt.Text.Length > 0 && PasswordTxt.Text.Length > 0;
        }

        private void PasswordSeeBtn_Click(object sender, EventArgs e)
        {
            if (PasswordTxt.PasswordChar.Equals('•'))
                PasswordTxt.PasswordChar = default(char);
            else
                PasswordTxt.PasswordChar = '•';
        }

    }
}

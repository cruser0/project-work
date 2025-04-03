using Entity_Validator;
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
            EmailCtb.SetPropName("Email");
            PasswordCtb.SetPropName("Password");
            PasswordCtb.PropTxt.PasswordChar = '•';

            EmailCtb.PropTxt.TextChanged += EmailTxt_TextChanged;
            PasswordCtb.PropTxt.TextChanged += EmailTxt_TextChanged;
        }


        private async void EnterBtn_Click(object sender, EventArgs e)
        {
            UserDTO user = new UserDTO()
            {
                Email = EmailCtb.PropTxt.Text,
                Password = PasswordCtb.PropTxt.Text,
            };
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var result = ValidatorEntity.Validate(user);
                if (result.Count > 0)
                {
                    UtilityFunctions.ValidateTextBoxes(panel1, user);
                    return;
                }

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
            try
            {
                var ret = await _userService.Login(new UserDTO() { Email = "Admin@admin.com", Password = "Admin" });
                DialogResult = DialogResult.OK;
                Close();

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void EmailTxt_TextChanged(object sender, EventArgs e)
        {
            EnterBtn.Enabled = EmailCtb.PropTxt.Text.Length > 0 && PasswordCtb.PropTxt.Text.Length > 0;
        }

        private void PasswordSeeBtn_Click(object sender, EventArgs e)
        {
            if (PasswordCtb.PropTxt.PasswordChar.Equals('•'))
                PasswordCtb.PropTxt.PasswordChar = default(char);
            else
                PasswordCtb.PropTxt.PasswordChar = '•';
        }
    }
}

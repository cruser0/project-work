using Winform.Entities.DTO;
using Winform.Services;

namespace Winform.Forms
{
    public partial class LoginForm : Form
    {

        private UserService _userService;
        public LoginForm()
        {
            _userService = new UserService();
            InitializeComponent();
        }


        private void EnterBtn_Click(object sender, EventArgs e)
        {
            UserDTO user = new UserDTO()
            {
                Email = EmailTxt.Text,
                Password = PasswordTxt.Text,
            };
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var ret = _userService.Login(user);
                DialogResult = DialogResult.OK;
                Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        private void button1_Click(object sender, EventArgs e)
        {
            var ret = _userService.Login(new UserDTO() { Email = "string", Password = "string" });
            DialogResult = DialogResult.OK;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var ret = _userService.Login(new UserDTO() { Email = "Admin", Password = "Admin" });
            DialogResult = DialogResult.OK;
            Close();
        }

        private void EmailTxt_TextChanged(object sender, EventArgs e)
        {
            EnterBtn.Enabled = EmailTxt.Text.Length > 0 && PasswordTxt.Text.Length > 0;
        }
    }
}

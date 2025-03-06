using Winform.Entities.DTO;
using Winform.Services;

namespace Winform.Forms
{
    public partial class UserProfileForm : Form
    {
        UserService userService;
        public UserProfileForm()
        {
            userService = new UserService();
            InitializeComponent();
        }

        private async void UserProfileForm_Load(object sender, EventArgs e)
        {
            foreach (string role in UserAccessInfo.Role)
            {
                Label lbl = new Label();
                lbl.Text = role;
                FlowPanelRoles.Controls.Add(lbl);
            }


            UserRoleDTO user = await userService.GetById(UserAccessInfo.RefreshUserID);
            UserIDTxt.Text = user.UserID.ToString();
            UserNameTxt.Text = user.Name;
            UserLastNameTxt.Text = user.LastName;
            UserEmailTxt.Text = user.Email;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            UserNameTxt.Enabled = checkBox1.Checked;
            UserLastNameTxt.Enabled = checkBox1.Checked;
            PasswordTxt.Enabled = checkBox1.Checked;
            PasswordSeeBtn.Visible = checkBox1.Checked;
            ConfirmPasswordTxt.Visible = checkBox1.Checked;
            PasswordConfirmLbl.Visible = checkBox1.Checked;
            button1.Enabled = checkBox1.Checked;
        }

        private async void SaveEditCustomerBtn_Click(object sender, EventArgs e)
        {
            if (PasswordTxt.Text.Equals(ConfirmPasswordTxt.Text))
            {


                UserDTOEdit si = new UserDTOEdit
                {
                    LastName = UserLastNameTxt.Text,
                    Name = UserNameTxt.Text,
                    Password = !string.IsNullOrEmpty(PasswordTxt.Text) ? PasswordTxt.Text : null,
                };
                try
                {
                    await userService.Update(int.Parse(UserIDTxt.Text), si);
                    MessageBox.Show("User updated successfully!");

                    this.Close();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            else
                MessageBox.Show("The passwords don't match");
        }
        private void PasswordSeeBtn_Click(object sender, EventArgs e)
        {
            if (PasswordTxt.PasswordChar.Equals('•'))
            {
                PasswordTxt.PasswordChar = default(char);
                ConfirmPasswordTxt.PasswordChar = default(char);

            }
            else
            {
                PasswordTxt.PasswordChar = '•';
                ConfirmPasswordTxt.PasswordChar = '•';
            }
        }
    }
}

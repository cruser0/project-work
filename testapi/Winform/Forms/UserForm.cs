using Winform.Forms.control;
using Winform.Forms.DetailsForms;
using Winform.Forms.GridForms;

namespace Winform.Forms
{
    public partial class UserForm : UserGridForm
    {

        public UserForm()
        {
            //FormClosing += CloseFormEvent;
            InitializeComponent();
        }

        public override void MyControl_OpenDetails_Clicked(object sender, DataGridViewCellEventArgs e)
        {
            if (sender is DataGridView dgv)
            {
                if (e.RowIndex == -1)
                    return;

                UtilityFunctions.OpenFormDetails<UserDetailsForm>(sender, e, int.Parse(dgv.CurrentRow.Cells["UserID"].Value.ToString()));

            }
        }
        public void CloseFormEvent(object sender, FormClosingEventArgs e)
        {
            Form MainForm = Application.OpenForms.OfType<MainForm>().First();
            TableLayoutPanel minimizedPanel = (TableLayoutPanel)MainForm.Controls.Find("minimizedPanel", true)[0];

            Form? form = Application.OpenForms.OfType<UserDetailsForm>().FirstOrDefault();

            foreach (var button in minimizedPanel.Controls)
            {
                if (button is formDockButton btn)
                {
                    if (btn.getForm() is UserDetailsForm f)
                    {
                        f.Close();
                        minimizedPanel.Controls.Remove(btn);
                        return;
                    }
                }

            }

            if (form != null) form.Close();
        }

    }
}

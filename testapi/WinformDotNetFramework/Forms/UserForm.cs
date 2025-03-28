using System.Linq;
using System.Windows.Forms;
using WinformDotNetFramework.Forms.control;
using WinformDotNetFramework.Forms.DetailsForms;
using WinformDotNetFramework.Forms.GridForms;

namespace WinformDotNetFramework.Forms
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

                UtilityFunctions.OpenFormDetails<CreateDetailsUserForm>(sender, e, int.Parse(dgv.CurrentRow.Cells["UserID"].Value.ToString()));

            }
        }
        public void CloseFormEvent(object sender, FormClosingEventArgs e)
        {
            Form MainForm = Application.OpenForms.OfType<MainForm>().First();
            TableLayoutPanel minimizedPanel = (TableLayoutPanel)MainForm.Controls.Find("minimizedPanel", true)[0];

            var form = Application.OpenForms.OfType<CreateDetailsUserForm>().FirstOrDefault();

            foreach (var button in minimizedPanel.Controls)
            {
                if (button is formDockButton btn)
                {
                    if (btn.getForm() is CreateDetailsUserForm f)
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

using System.Collections.Generic;
using System.Windows.Forms;
using WinformDotNetFramework.Entities;
using WinformDotNetFramework.Forms.DetailsForms;
using WinformDotNetFramework.Forms.GridForms;

namespace WinformDotNetFramework.Forms
{
    public partial class CustomerForm : CustomerGridForm
    {

        public CustomerForm()
        {
            InitializeComponent();
        }


        public override void MyControl_OpenDetails_Clicked(object sender, DataGridViewCellEventArgs e)
        {

            if (sender is DataGridView dgv)
            {
                if (e.RowIndex == -1)
                    return;

                UtilityFunctions.OpenFormDetails<CustomerDetailsForm>(sender, e, int.Parse(dgv.CurrentRow.Cells["CustomerId"].Value.ToString()));

            }
        }


    }
}

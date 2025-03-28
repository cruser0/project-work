using System.Windows.Forms;
using WinformDotNetFramework.Forms.AddForms;
using WinformDotNetFramework.Forms.DetailsForms;
using WinformDotNetFramework.Forms.GridForms;

namespace WinformDotNetFramework.Forms
{
    public partial class CustomerInvoiceCostForm : CustomerInvoiceCostGridForm
    {

        public CustomerInvoiceCostForm()
        {
            InitializeComponent();
        }

        public override void MyControl_OpenDetails_Clicked(object sender, DataGridViewCellEventArgs e)
        {
            if (sender is DataGridView dgv)
            {
                if (e.RowIndex == -1)
                    return;

                UtilityFunctions.OpenFormDetails<CreateDetailsCustomerInvoiceCostForm>(sender, e, int.Parse(dgv.CurrentRow.Cells["CustomerInvoiceCostsId"].Value.ToString()));

            }
        }
    }
}

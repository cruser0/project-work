using System.Windows.Forms;
using WinformDotNetFramework.Forms.DetailsForms;
using WinformDotNetFramework.Forms.GridForms;

namespace WinformDotNetFramework.Forms
{
    public partial class CustomerInvoiceForm : CustomerInvoiceGridForm
    {

        public CustomerInvoiceForm()
        {

            InitializeComponent();
        }
        public override void CenterDgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (sender is DataGridView dgv)
            {
                if (e.RowIndex == -1)
                    return;

                UtilityFunctions.OpenFormDetails<CustomerInvoiceDetailsForm>(sender, e, int.Parse(dgv.CurrentRow.Cells["CustomerInvoiceId"].Value.ToString()));

            }
        }
    }
}

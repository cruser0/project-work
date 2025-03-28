using System.Windows.Forms;
using WinformDotNetFramework.Forms.AddForms;
using WinformDotNetFramework.Forms.DetailsForms;
using WinformDotNetFramework.Forms.GridForms;

namespace WinformDotNetFramework.Forms
{
    public partial class SupplierInvoiceCostsForm : SupplierInvoiceCostGridForm
    {

        public SupplierInvoiceCostsForm()
        {

            InitializeComponent();
        }

        public override void MyControl_OpenDetails_Clicked(object sender, DataGridViewCellEventArgs e)
        {
            if (sender is DataGridView dgv)
            {
                if (e.RowIndex == -1)
                    return;

                UtilityFunctions.OpenFormDetails<CreateDetailsSupplierInvoiceCostForm>(sender, e, int.Parse(dgv.CurrentRow.Cells["SupplierInvoiceCostsId"].Value.ToString()));

            }
        }
    }
}

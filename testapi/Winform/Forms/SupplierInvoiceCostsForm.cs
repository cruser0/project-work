using Winform.Forms.CreateWindow;

namespace Winform.Forms
{
    public partial class SupplierInvoiceCostsForm : SupplierInvoiceCostGridForm
    {

        public SupplierInvoiceCostsForm()
        {

            InitializeComponent();
        }

        public override void MyControl_OpenDetails_Clicked(object? sender, DataGridViewCellEventArgs e)
        {
            if (sender is DataGridView dgv)
            {
                if (e.RowIndex == -1)
                    return;

                UtilityFunctions.OpenFormDetails<SupplierInvoiceCostDetailsForm>(sender, e, int.Parse(dgv.CurrentRow.Cells["SupplierInvoiceCostId"].Value.ToString()));

            }
        }
    }
}

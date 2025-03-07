using Winform.Forms.DetailsForms;
using Winform.Forms.GridForms;

namespace Winform.Forms.AddForms
{
    public partial class CustomerInvoiceCostForm : CustomerInvoiceCostGridForm
    {

        public CustomerInvoiceCostForm()
        {
            InitializeComponent();
        }

        public override void MyControl_OpenDetails_Clicked(object? sender, DataGridViewCellEventArgs e)
        {
            if (sender is DataGridView dgv)
            {
                if (e.RowIndex == -1)
                    return;

                UtilityFunctions.OpenFormDetails<CustomerInvoiceCostDetailsForm>(sender, e, int.Parse(dgv.CurrentRow.Cells["CustomerInvoiceCostsId"].Value.ToString()));

            }
        }
    }
}

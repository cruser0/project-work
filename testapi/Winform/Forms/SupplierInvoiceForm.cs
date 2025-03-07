namespace Winform.Forms
{
    public partial class SupplierInvoiceForm : SupplierInvoiceGridForm
    {

        public SupplierInvoiceForm()
        {
            InitializeComponent();
        }
        public override void MyControl_OpenDetails_Clicked(object? sender, DataGridViewCellEventArgs e)
        {
            if (sender is DataGridView dgv)
            {
                if (e.RowIndex == -1)
                    return;

                UtilityFunctions.OpenFormDetails<SupplierInvoiceDetailsForm>(sender, e, int.Parse(dgv.CurrentRow.Cells["InvoiceId"].Value.ToString()));

            }
        }
    }
}

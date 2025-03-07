namespace Winform.Forms
{
    public partial class SupplierForm : SupplierGridForm
    {

        public SupplierForm()
        {
            InitializeComponent();
        }

        public override void SupplierDgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (sender is DataGridView dgv)
            {
                if (e.RowIndex == -1)
                    return;

                UtilityFunctions.OpenFormDetails<SupplierDetailsForm>(sender, e, int.Parse(dgv.CurrentRow.Cells["SupplierId"].Value.ToString()));

            }
        }


    }
}

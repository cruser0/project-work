namespace Winform.Forms
{
    public partial class SaleForm : SaleGridForm
    {

        public SaleForm()
        {
            InitializeComponent();
        }

        public override void MyControl_OpenDetails_Clicked(object? sender, DataGridViewCellEventArgs e)
        {
            if (sender is DataGridView dgv)
            {
                if (e.RowIndex == -1)
                    return;

                UtilityFunctions.OpenFormDetails<SaleDetailsForm>(sender, e, int.Parse(dgv.CurrentRow.Cells["SaleId"].Value.ToString()));

            }
        }
    }
}

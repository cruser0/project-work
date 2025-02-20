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
                SupplierDetailsForm cdf = new SupplierDetailsForm(int.Parse(dgv.CurrentRow.Cells[0].Value.ToString()));
                cdf.Show();
            }
            else
            {
                MessageBox.Show(sender.ToString());

            }
        }


    }
}

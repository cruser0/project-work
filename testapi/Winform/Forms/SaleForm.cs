namespace Winform.Forms
{
    public partial class SaleForm : SaleGridForm
    {
        public SaleForm()
        {
            InitializeComponent();
        }

        public override void MyControl_OpenDetails_Clicked(object sender, DataGridViewCellEventArgs e)
        {
            if (sender is DataGridView dgv)
            {
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

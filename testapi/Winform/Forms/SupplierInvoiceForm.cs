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
                SupplierInvoiceDetailsForm sid = new SupplierInvoiceDetailsForm(int.Parse(dgv.CurrentRow.Cells["InvoiceId"].Value.ToString()));
                sid.Show();
            }
            else
            {
                MessageBox.Show(sender.ToString());

            }
        }
        }
    }

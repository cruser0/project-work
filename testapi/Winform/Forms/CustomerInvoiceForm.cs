using Winform.Forms.CreateWindow;

namespace Winform.Forms
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

                foreach (Form form in Application.OpenForms.Cast<Form>().ToList())
                {
                    if (form is CustomerInvoiceDetailsForm)
                    {
                        form.Close();
                    }
                }

                CustomerInvoiceDetailsForm cdf = new CustomerInvoiceDetailsForm(int.Parse(dgv.CurrentRow.Cells[0].Value.ToString()));
                cdf.StartPosition = FormStartPosition.Manual;
                cdf.Location = new Point((Width - cdf.Width) / 2, (Height - cdf.Height) / 2);
                cdf.Show();
                cdf.BringToFront();

            }
        }
    }
}

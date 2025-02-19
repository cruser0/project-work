using Winform.Entities;
using Winform.Services;

namespace Winform.Forms
{
    public partial class CreateSupplierInvoicesForm : Form
    {
        SupplierInvoiceService _service;
        SaleService _saleService;
        SupplierService _supplierService;
        public CreateSupplierInvoicesForm()
        {
            _saleService = new SaleService();
            _supplierService = new SupplierService();
            _service = new SupplierInvoiceService();
            InitializeComponent();

        }

        private void SaveEditCustomerBtn_Click(object sender, EventArgs e)
        {

            List<string> err = new List<string>();
            if (string.IsNullOrEmpty(SaleIDTxt1.GetText()))
                err.Add("SaleID");
            if (string.IsNullOrEmpty(SupplierIDTxt1.GetText()))
                err.Add("SupplierID");
            if (string.IsNullOrEmpty(StatusCmbx.Text))
                err.Add("Status");
            if (DateClnd.Value == null)
                err.Add("Date");
            if (err.Count > 0)
                MessageBox.Show("Gli attributi : " + string.Join(",", err) + "\n Sono errati!");
            else
            {
                try
                {
                    SupplierInvoice si = new SupplierInvoice { InvoiceDate = DateClnd.Value, SaleId = int.Parse(SaleIDTxt1.GetText()), SupplierId = int.Parse(SupplierIDTxt1.GetText()), Status = StatusCmbx.Text };
                    _service.Create(si);
                    MessageBox.Show("Supplier Invoice created Successfully!");

                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }

        }
        public void SetSupplierID(string id)
        {
            SupplierIDTxt1.SetText(id);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SupplierGridForm sgf = new SupplierGridForm(this);
            sgf.ShowDialog();

        }

        private void Sgf_SupplierGridDBClick(object? sender, string e)
        {
            if (sender is DataGridView dgv)
            {
                SupplierIDTxt1.SetText(dgv.CurrentRow.Cells[0].Value.ToString());
            }
        }

        private void OpenSale_Click(object sender, EventArgs e)
        {
            SaleGridForm sgf = new SaleGridForm(this);
            sgf.ShowDialog();
        }
        public void SetSaleID(string id)
        {
            SaleIDTxt1.SetText(id);
        }
    }
}

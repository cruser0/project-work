using Winform.Forms;

namespace Winform
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            IsMdiContainer = true;
        }



        private void buttonOpenChild_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem menuItem)
            {
                Form child = menuItem.Text switch
                {
                    "Show Customers" => new CustomerForm(),
                    "Show Customer Invoices" => new CustomerInvoiceForm(),
                    "Show Suppliers" => new SupplierForm(),
                    "Show Supplier Invoices" => new SupplierInvoiceForm(),
                    //"Show Supplier Invoices Costs" => new SupplierInvoiceCostsForm(),
                    "Show Sales" => new SaleForm(),


                    "Add Supplier Invoice" => new CreateSupplierInvoicesForm(),
                    _ => throw new Exception("Unknown option")
                };

                foreach (Control ctrl in CenterPanel.Controls)
                {
                    if (ctrl is Form existingForm)
                    {
                        existingForm.Close();
                        existingForm.Dispose();
                    }
                }

                CenterPanel.Controls.Clear();

                child.TopLevel = false;
                child.FormBorderStyle = FormBorderStyle.None;
                child.Dock = DockStyle.Fill;

                CenterPanel.Controls.Add(child);
                child.Show();
            }
        }


        private void AddCustomersStripToolButton_Click(object sender, EventArgs e)
        {
            CreateCustomerForm createCustomerForm = new CreateCustomerForm();
            createCustomerForm.Show();
        }

        private void AddSuppliersStripToolButton_Click(object sender, EventArgs e)
        {
            CreateSupplierForm createSupplierForm = new CreateSupplierForm();
            createSupplierForm.Show();
        }

        private void addSupplierInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateSupplierInvoicesForm createSupplierInvoicesForm = new CreateSupplierInvoicesForm();
            createSupplierInvoicesForm.Show();
        }
    }
}

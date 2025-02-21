using Winform.Forms;
using Winform.Forms.AddForms;

namespace Winform
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
        }



        private void buttonOpenChild_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem menuItem)
            {
                Cursor.Current = Cursors.WaitCursor;

                string tabName = menuItem.Text.Substring(menuItem.Text.IndexOf(' ') + 1);

                // Controlla se esiste già una tab con lo stesso nome
                foreach (TabPage tab in tabControl1.TabPages)
                {
                    if (tab.Text == tabName)
                    {
                        tabControl1.SelectedTab = tab;
                        Cursor.Current = Cursors.Default;
                        return;
                    }
                }

                // Crea una nuova finestra solo se non esiste già
                Form child = menuItem.Text switch
                {
                    "Show Customers" => new CustomerForm(),
                    "Show Customer Invoices" => new CustomerInvoiceForm(),
                    "Show Suppliers" => new SupplierForm(),
                    "Show Supplier Invoices" => new SupplierInvoiceForm(),
                    "Show Supplier Invoices Costs" => new SupplierInvoiceCostsForm(),
                    "Show Sales" => new SaleForm(),
                    "Add Supplier Invoice" => new CreateSupplierInvoicesForm(),
                    "Show Customer Invoices Costs" => new CustomerInvoiceCostForm(),
                    _ => throw new Exception("Unknown option")
                };

                child.Tag = tabName;
                child.TopLevel = false;
                child.FormBorderStyle = FormBorderStyle.None;
                child.Dock = DockStyle.Fill;

                TabPage newPage = new TabPage { Text = tabName };
                newPage.Controls.Add(child);
                tabControl1.Controls.Add(newPage);
                tabControl1.SelectedTab = newPage;

                child.Show();

                Cursor.Current = Cursors.Default;
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

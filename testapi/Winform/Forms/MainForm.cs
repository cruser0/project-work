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

        private void OpenChildForm(Form child)
        {
            // Close all existing MDI child forms
            foreach (Form openForm in this.MdiChildren)
            {
                openForm.Close();
            }

            // Set the new form as an MDI child
            child.MdiParent = this;
            child.WindowState = FormWindowState.Maximized;
            child.Show();
        }


        private void buttonOpenChild_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem menuItem)
            {
                Form child = menuItem.Text switch
                {
                    "Show Customers" => new CustomerForm(),
                    "Show Suppliers" => new SupplierForm(),
                    _ => throw new Exception("Unknown option")
                };

                OpenChildForm(child);
            }
        }

    }
}

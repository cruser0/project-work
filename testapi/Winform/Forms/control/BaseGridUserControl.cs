using System.Collections;

namespace Winform.Forms.control
{
    public partial class BaseGridUserControl : UserControl
    {
        public event EventHandler buttonGet;
        public event EventHandler<DataGridViewCellEventArgs> dgvDoubleClick;
        public BaseGridUserControl()
        {
            InitializeComponent();
        }

        private void baseBtn_Click(object sender, EventArgs e)
        {
            buttonGet.Invoke(this, EventArgs.Empty);
        }
        private void dgvDouble_Click(object sender, DataGridViewCellEventArgs e)
        {
            dgvDoubleClick.Invoke(sender, e);
        }
        public void setDataGrid(IEnumerable data)
        {
            dataGridView1.DataSource = data;
        }
    }
}

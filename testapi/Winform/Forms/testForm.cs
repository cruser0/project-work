using System.Data;
using Winform.Entities;
using Winform.Services;

namespace Winform.Forms
{
    public partial class testForm : Form
    {
        private CustomerService _customerService;
        public testForm()
        {
            _customerService = new CustomerService();

            InitializeComponent();

            baseGridComponent.buttonGet += MyControl_ButtonClicked;
            baseGridComponent.dgvDoubleClick += MyControl_OpenDetails_Clicked;
        }
        private void MyControl_ButtonClicked(object sender, EventArgs e)
        {
            IEnumerable<Customer> query = _customerService.GetAll();

            if (!string.IsNullOrWhiteSpace(NameTxt.Text))
                query = query.Where(x => x.CustomerName.StartsWith(NameTxt.Text, StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrWhiteSpace(CountryTxt.Text))
                query = query.Where(x => x.Country.StartsWith(CountryTxt.Text, StringComparison.OrdinalIgnoreCase));

            baseGridComponent.setDataGrid(query.ToList());
        }

        private void MyControl_OpenDetails_Clicked(object sender, DataGridViewCellEventArgs e)
        {
            if (sender is DataGridView dgv)
            {
                MessageBox.Show(dgv.CurrentRow.Cells[1].Value.ToString());
            }
            else
            {
                MessageBox.Show(sender.ToString());

            }

        }

        private void baseGridComponent_Load(object sender, EventArgs e)
        {

        }
    }
}

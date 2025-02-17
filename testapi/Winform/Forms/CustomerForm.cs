using System.Data;
using Winform.Entities;
using Winform.Services;

namespace Winform.Forms
{
    public partial class CustomerForm : Form
    {
        private CustomerService _customerService;
        public CustomerForm()
        {
            _customerService = new CustomerService();

            InitializeComponent();

            baseGridComponent.buttonGet += MyControl_ButtonClicked;
            baseGridComponent.dgvDoubleClick += MyControl_OpenDetails_Clicked;
        }
        private void MyControl_ButtonClicked(object sender, EventArgs e)
        {
            IEnumerable<Customer> query = _customerService.GetAll(NameTxt.Text, CountryTxt.Text);

            baseGridComponent.setDataGrid(query.ToList());
        }

        private void MyControl_OpenDetails_Clicked(object sender, DataGridViewCellEventArgs e)
        {
            if (sender is DataGridView dgv)
            {
                CustomerDetailsForm cdf = new CustomerDetailsForm(int.Parse(dgv.CurrentRow.Cells[0].Value.ToString()));
                cdf.Show();
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

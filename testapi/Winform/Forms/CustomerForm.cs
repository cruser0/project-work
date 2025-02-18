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

            RightSideBar.searchBtnEvent += MyControl_ButtonClicked;
            RightSideBar.closeBtnEvent += RightSideBar_closeBtnEvent;
            RightSideBar.enterBtnEvent += RightSideBar_enterBtnEvent;
        }

        private void RightSideBar_enterBtnEvent(object? sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {
                MyControl_ButtonClicked(this,e);
            }
        }

        private void RightSideBar_closeBtnEvent(object? sender, EventArgs e)
        {
            this.Close();
        }

        private void MyControl_ButtonClicked(object sender, EventArgs e)
        {
            IEnumerable<Customer> query = _customerService.GetAll(NameTxt.Text, CountryTxt.Text);

            CustomerGdv.DataSource=query.ToList();
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
    }
}

using API.Models.Filters;
using Winform.Entities;
using Winform.Services;

namespace Winform.Forms
{
    public partial class CustomerGridForm : Form
    {
        private CustomerService _customerService;
        int pages;
        public CustomerGridForm()
        {
            _customerService = new CustomerService();
            pages = (int)Math.Ceiling(_customerService.Count(new CustomerFilter()) / 100.0);


            InitializeComponent();

            RightSideBar.searchBtnEvent += MyControl_ButtonClicked;
            RightSideBar.closeBtnEvent += RightSideBar_closeBtnEvent;
            RightSideBar.enterBtnEvent += RightSideBar_enterBtnEvent;
            KeyPress += RightSideBar_enterBtnEvent;

            comboBox1.SelectedIndex = 1;
            numericUpDown1.Visible = false;
            label2.Visible = false;
            numericUpDown1.Minimum = 1;
            numericUpDown1.Value = 1;
            numericUpDown1.Maximum = pages;
        }

        private void RightSideBar_enterBtnEvent(object? sender, KeyPressEventArgs e)
        {
            MyControl_ButtonClicked(this, e);
        }

        private void RightSideBar_closeBtnEvent(object? sender, EventArgs e)
        {
            this.Close();
        }

        private void MyControl_ButtonClicked(object sender, EventArgs e)
        {
            if (sender is NumericUpDown && CustomerDgv.RowCount == 0)
                return;

            CustomerFilter filter = new CustomerFilter
            {
                Name = NameTxt.Text,
                Country = CountryTxt.Text,
                Deprecated = comboBox1.SelectedIndex switch
                {
                    1 => false,
                    2 => true,
                    _ => null
                },
                page = (int)numericUpDown1.Value
            };


            IEnumerable<Customer> query = _customerService.GetAll(filter);

            CustomerDgv.DataSource = query.ToList();

            if (!numericUpDown1.Visible)
            {
                numericUpDown1.Visible = true;
                label2.Visible = true;
                label2.Text = $"{100 * ((int)numericUpDown1.Value - 1) + CustomerDgv.CurrentRow.Index + 1}/{100 * (int)numericUpDown1.Value}";
            }

        }

        private void MyControl_OpenDetails_Clicked(object sender, DataGridViewCellEventArgs e)
        {
            if (sender is DataGridView dgv)
            {
                foreach (Form form in Application.OpenForms.Cast<Form>().ToList())
                {
                    if (form is CustomerDetailsForm)
                    {
                        form.Close();
                    }
                }

                CustomerDetailsForm cdf = new CustomerDetailsForm(int.Parse(dgv.CurrentRow.Cells[0].Value.ToString()));
                cdf.StartPosition = FormStartPosition.Manual;
                cdf.Location = new Point((Width - cdf.Width) / 2, (Height - cdf.Height) / 2);
                cdf.Show();
                cdf.BringToFront();
            }
        }

        private void CustomerDgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            label2.Text = $"{100 * ((int)numericUpDown1.Value - 1) + CustomerDgv.CurrentRow.Index + 1}/{100 * (int)numericUpDown1.Value}";
        }
    }
}

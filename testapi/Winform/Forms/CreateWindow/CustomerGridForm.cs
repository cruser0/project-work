using API.Models.Filters;
using Winform.Entities;
using Winform.Services;

namespace Winform.Forms
{
    public partial class CustomerGridForm : Form
    {
        string name;
        string country;
        int status;

        private CustomerService _customerService;
        int pages;
        double itemsPage = 10.0;
        public CustomerGridForm()
        {
            _customerService = new CustomerService();
            pages = (int)Math.Ceiling(_customerService.Count(new CustomerFilter()) / itemsPage);


            InitializeComponent();
            RightSideBar.searchBtnEvent += MyControl_ButtonClicked;
            RightSideBar.closeBtnEvent += RightSideBar_closeBtnEvent;
            RightSideBar.enterBtnEvent += RightSideBar_enterBtnEvent;
            KeyPress += RightSideBar_enterBtnEvent;

            PaginationUserControl.SingleRightArrowEvent += PaginationUserControl_SingleRightArrowEvent;
            PaginationUserControl.DoubleRightArrowEvent += PaginationUserControl_DoubleRightArrowEvent;
            PaginationUserControl.DoubleLeftArrowEvent += PaginationUserControl_DoubleLeftArrowEvent;
            PaginationUserControl.SingleLeftArrowEvent += PaginationUserControl_SingleLeftArrowEvent;

            comboBox1.SelectedIndex = 1;
            PaginationUserControl.Visible = false;
            PaginationUserControl.SetMaxPage(pages.ToString());
            PaginationUserControl.CurrentPage = 1;
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());
        }
        CustomerFilter filterTest;

        private void MyControl_ButtonClicked(object sender, EventArgs e)
        {
            PaginationUserControl.CurrentPage = 1;
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
                page = PaginationUserControl.CurrentPage
            };
            CustomerFilter filterPage = new CustomerFilter
            {
                Name = NameTxt.Text,
                Country = CountryTxt.Text,
                Deprecated = comboBox1.SelectedIndex switch
                {
                    1 => false,
                    2 => true,
                    _ => null
                },
            };
            name = NameTxt.Text;
            country = CountryTxt.Text;
            status = comboBox1.SelectedIndex;

            IEnumerable<Customer> query = _customerService.GetAll(filter);
            PaginationUserControl.maxPage = ((int)Math.Ceiling(_customerService.Count(filterPage) / itemsPage)).ToString();
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());

            CustomerDgv.DataSource = query.ToList();


            if (!PaginationUserControl.Visible)
            {
                PaginationUserControl.Visible = true; 
            }

        }
        private void MyControl_ButtonClicked_Pagination(object sender, EventArgs e)
        {
            CustomerFilter filter = new CustomerFilter
            {
                Name = name,
                Country = country,
                Deprecated = status switch
                {
                    1 => false,
                    2 => true,
                    _ => null
                },
                page = PaginationUserControl.CurrentPage
            };

            IEnumerable<Customer> query = _customerService.GetAll(filter);
            CustomerDgv.DataSource = query.ToList();
        }

        private void PaginationUserControl_SingleLeftArrowEvent(object? sender, EventArgs e)
        {
            if (PaginationUserControl.CurrentPage<=1)
                return;
            PaginationUserControl.CurrentPage= PaginationUserControl.CurrentPage-1;
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage+"/"+ PaginationUserControl.GetmaxPage());
            MyControl_ButtonClicked_Pagination(sender, e);
        }

        private void PaginationUserControl_DoubleLeftArrowEvent(object? sender, EventArgs e)
        {
           
            PaginationUserControl.CurrentPage=1;
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());
            MyControl_ButtonClicked_Pagination(sender, e);
        }

        private void PaginationUserControl_DoubleRightArrowEvent(object? sender, EventArgs e)
        {
            PaginationUserControl.CurrentPage= int.Parse(PaginationUserControl.GetmaxPage());
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());
            MyControl_ButtonClicked_Pagination(sender, e);
        }

        private void PaginationUserControl_SingleRightArrowEvent(object? sender, EventArgs e)
        {
            if (PaginationUserControl.CurrentPage>=int.Parse(PaginationUserControl.GetmaxPage()))
                return;
            PaginationUserControl.CurrentPage ++;
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());
            MyControl_ButtonClicked_Pagination(sender, e);

        }

        private void RightSideBar_enterBtnEvent(object? sender, KeyPressEventArgs e)
        {
            MyControl_ButtonClicked(this, e);
        }

        private void RightSideBar_closeBtnEvent(object? sender, EventArgs e)
        {
            this.Close();
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

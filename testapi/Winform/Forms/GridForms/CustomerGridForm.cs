﻿using API.Models.Filters;
using Winform.Entities;
using Winform.Entities.Preference;
using Winform.Forms.AddForms;
using Winform.Services;
using ClosedXML.Excel;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System.Data;

namespace Winform.Forms
{
    public partial class CustomerGridForm : Form
    {
        string name;
        string country;
        int status;
        DateTime? dateFrom;
        DateTime? dateTo;

        private CustomerService _customerService;
        int pages;
        double itemsPage = 10.0;
        Form _father;
        Task<ICollection<Customer>> getAllNotFiltered;
        Task<int> countNotFiltered;
        Task<CustomerDGV> getFav;
        private UserService _userService;
        public CustomerGridForm()
        {
            Init();
        }

        public CustomerGridForm(CreateSaleForm father)
        {
            _father = father;
            Init();
        }

        private async void Init()
        {
            _customerService = new CustomerService();
            _userService = new UserService();


            InitializeComponent();
            pages = (int)Math.Ceiling(await _customerService.Count(new CustomerFilter()) / itemsPage);
            RightSideBar.searchBtnEvent += MyControl_ButtonClicked;

            PaginationUserControl.SingleRightArrowEvent += PaginationUserControl_SingleRightArrowEvent;
            PaginationUserControl.DoubleRightArrowEvent += PaginationUserControl_DoubleRightArrowEvent;
            PaginationUserControl.DoubleLeftArrowEvent += PaginationUserControl_DoubleLeftArrowEvent;
            PaginationUserControl.SingleLeftArrowEvent += PaginationUserControl_SingleLeftArrowEvent;

            comboBox1.SelectedIndex = 1;
            PaginationUserControl.Visible = false;
            PaginationUserControl.SetMaxPage(pages.ToString());
            PaginationUserControl.CurrentPage = 1;
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());
            CustomerDgv.ContextMenuStrip = RightClickDgv;
            if (!UtilityFunctions.IsAuthorized(new[] { "CustomerAdmin", "Admin" }))
            {
                CustomerIDTsmi.Visible = false;
                CustomerOriginalIDTsmi.Visible = false;
            }
        }

        private async void MyControl_ButtonClicked(object sender, EventArgs e)
        {
            PaginationUserControl.CurrentPage = 1;
            name = NameTxt.Text;
            country = CountryTxt.Text;
            status = comboBox1.SelectedIndex;
            dateFrom = DateFromClnd.Checked ? DateFromClnd.Value : null;
            dateTo = DateToClnd.Checked ? DateToClnd.Value : null;

            CustomerFilter filter = new CustomerFilter
            {
                CustomerName = name,
                CustomerCountry = country,
                CustomerDeprecated = status switch
                {
                    1 => false,
                    2 => true,
                    _ => null
                },
                CustomerCreatedDateFrom = dateFrom,
                CustomerCreatedDateTo = dateTo,
                CustomerPage = PaginationUserControl.CurrentPage

            };
            CustomerFilter filterPage = new CustomerFilter
            {
                CustomerName = name,
                CustomerCountry = country,
                CustomerDeprecated = status switch
                {
                    1 => false,
                    2 => true,
                    _ => null
                },
                CustomerCreatedDateFrom = dateFrom,
                CustomerCreatedDateTo = dateTo
            };


            var query = _customerService.GetAll(filter);
            var totalCount = _customerService.Count(filterPage);
            await Task.WhenAll(query, totalCount);
            IEnumerable<Customer> query1 = await query;
            CustomerDgv.DataSource = query1.ToList();
            PaginationUserControl.maxPage = ((int)Math.Ceiling((double)await totalCount / itemsPage)).ToString();
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());

        }

        private async Task SetCheckBoxes()
        {
            await Task.WhenAll(getFav, countNotFiltered, getAllNotFiltered);
            IEnumerable<Customer> query = await getAllNotFiltered;
            PaginationUserControl.maxPage = ((int)Math.Ceiling((double)await countNotFiltered / itemsPage)).ToString();
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());
            CustomerDgv.DataSource = query.ToList();
            CustomerDGV cdgv = await getFav;
            CustomerCountryTsmi.Checked = cdgv.ShowCountry;
            CustomerDateTsmi.Checked = cdgv.ShowDate;
            CustomerIDTsmi.Checked = cdgv.ShowID;
            CustomerStatusTsmi.Checked = cdgv.ShowStatus;
            CustomerOriginalIDTsmi.Checked = cdgv.ShowOriginalID;
            CustomerNameTsmi.Checked = cdgv.ShowName;
            PaginationUserControl.Visible = true;
            CustomerDgv.Columns["CustomerName"].Visible = cdgv.ShowName;
            CustomerDgv.Columns["Country"].Visible = cdgv.ShowCountry;
            CustomerDgv.Columns["CreatedAt"].Visible = cdgv.ShowDate;
            CustomerDgv.Columns["OriginalID"].Visible = cdgv.ShowOriginalID;
            CustomerDgv.Columns["Deprecated"].Visible = cdgv.ShowStatus;
            CustomerDgv.Columns["CustomerID"].Visible = CustomerIDTsmi.Checked;
        }
        private async void MyControl_ButtonClicked_Pagination(object sender, EventArgs e)
        {
            if (dateFrom != null)
                DateFromClnd.Checked = true;
            if (dateTo != null)
                DateToClnd.Checked = true;


            CustomerFilter filter = new CustomerFilter
            {
                CustomerName = name,
                CustomerCountry = country,
                CustomerDeprecated = status switch
                {
                    1 => false,
                    2 => true,
                    _ => null
                },
                CustomerCreatedDateFrom = dateFrom,
                CustomerCreatedDateTo = dateTo,
                CustomerPage = PaginationUserControl.CurrentPage
            };

            IEnumerable<Customer> query = await _customerService.GetAll(filter);
            CustomerDgv.DataSource = query.ToList();
        }

        private void PaginationUserControl_SingleLeftArrowEvent(object? sender, EventArgs e)
        {
            if (PaginationUserControl.CurrentPage <= 1)
                return;
            PaginationUserControl.CurrentPage = PaginationUserControl.CurrentPage - 1;
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());
            MyControl_ButtonClicked_Pagination(sender, e);
        }

        private void PaginationUserControl_DoubleLeftArrowEvent(object? sender, EventArgs e)
        {

            PaginationUserControl.CurrentPage = 1;
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());
            MyControl_ButtonClicked_Pagination(sender, e);
        }

        private void PaginationUserControl_DoubleRightArrowEvent(object? sender, EventArgs e)
        {
            PaginationUserControl.CurrentPage = int.Parse(PaginationUserControl.GetmaxPage());
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());
            MyControl_ButtonClicked_Pagination(sender, e);
        }

        private void PaginationUserControl_SingleRightArrowEvent(object? sender, EventArgs e)
        {
            if (PaginationUserControl.CurrentPage >= int.Parse(PaginationUserControl.GetmaxPage()))
                return;
            PaginationUserControl.CurrentPage++;
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());
            MyControl_ButtonClicked_Pagination(sender, e);

        }



        public virtual void MyControl_OpenDetails_Clicked(object sender, DataGridViewCellEventArgs e)
        {

            if (sender is DataGridView dgv)
            {
                if (_father is CreateSaleForm csf)
                {
                    csf.SetCustomerID(dgv.CurrentRow.Cells["CustomerID"].Value.ToString());
                }
            }
        }

        public void CustomerGridForm_Resize(object sender, EventArgs e)
        {

            panel5.Location = new System.Drawing.Point((Width - panel5.Width) / 2, 0);
            PaginationUserControl.Location = new System.Drawing.Point((panel5.Width - PaginationUserControl.Width) / 2, (panel5.Height - PaginationUserControl.Height) / 2);
            int newHeight = (int)((Height - TextBoxesRightPanel.Top) * 0.9);
            if (TextBoxesRightPanel.Height != newHeight)
            {
                TextBoxesRightPanel.Height = newHeight;
            }

        }

        private void CustomerDgv_RightClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hitTest = CustomerDgv.HitTest(e.X, e.Y);
                if (hitTest.RowIndex >= 0)
                {
                    RightClickDgv.Show(CustomerDgv, e.Location);
                }
            }
        }

        private async void ContextMenuStripCheckEvent(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem tsmi)
            {
                string name = tsmi.Name;
                switch (name)
                {
                    case "CustomerIDTsmi":
                        CustomerDgv.Columns["CustomerID"].Visible = tsmi.Checked;
                        break;
                    case "CustomerNameTsmi":
                        CustomerDgv.Columns["CustomerName"].Visible = tsmi.Checked;
                        break;
                    case "CustomerCountryTsmi":
                        CustomerDgv.Columns["Country"].Visible = tsmi.Checked;
                        break;
                    case "CustomerDateTsmi":
                        CustomerDgv.Columns["CreatedAt"].Visible = tsmi.Checked;
                        break;
                    case "CustomerOriginalIDTsmi":
                        CustomerDgv.Columns["OriginalID"].Visible = tsmi.Checked;
                        break;
                    case "CustomerStatusTsmi":
                        CustomerDgv.Columns["Deprecated"].Visible = tsmi.Checked;
                        break;
                    default:
                        break;
                }
                CustomerDGV cdgv = new CustomerDGV
                {
                    ShowDate = CustomerDateTsmi.Checked,
                    ShowID = CustomerIDTsmi.Checked,
                    ShowStatus = CustomerStatusTsmi.Checked,
                    ShowOriginalID = CustomerOriginalIDTsmi.Checked,
                    ShowCountry = CustomerCountryTsmi.Checked,
                    ShowName = CustomerNameTsmi.Checked,
                    UserID = UserAccessInfo.RefreshUserID
                };
                await _userService.PostCustomerDGV(cdgv);

            }
        }

        private async void CustomerGridForm_Load(object sender, EventArgs e)
        {
            getAllNotFiltered = _customerService.GetAll(new CustomerFilter() { CustomerPage = 1 });
            countNotFiltered = _customerService.Count(new CustomerFilter());
            getFav = _userService.GetCustomerDGV();
            await SetCheckBoxes();
        }

        private void Pdf_ClickBtn(object sender, EventArgs e)
        {
            UtilityFunctions.Pdf_ClickBtn(CustomerDgv, this);
        }


        private void Excel_ClickBtn(object sender, EventArgs e)
        {
            UtilityFunctions.Excel_ClickBtn(CustomerDgv, this);
        }


        private async void MassDeleteTSB_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
          "This action is permanent and it will delete all the history bound to this Customers!",
          "Confirm Deletion?",
          MessageBoxButtons.YesNo,
          MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    List<int> id = new List<int>();


                    HashSet<int> ids = new HashSet<int>();
                    foreach (DataGridViewCell cell in CustomerDgv.SelectedCells)
                    {
                        ids.Add(cell.RowIndex);
                    }
                    foreach (var rowid in ids)
                    {
                        if (CustomerDgv.Rows[rowid].DataBoundItem is Customer customer)
                            id.Add(customer.CustomerId);
                    }

                    if (id.Count > 0)
                    {
                        string message = await _customerService.MassDelete(id);
                        MessageBox.Show(message);
                    }
                    else
                    {
                        MessageBox.Show("No Row was selected");
                    }
                    MyControl_ButtonClicked(sender, e);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            else
            {
                MessageBox.Show("Action canceled.");
            }
        }

      
       

    }
}

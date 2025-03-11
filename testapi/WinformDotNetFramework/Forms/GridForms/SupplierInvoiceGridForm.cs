using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinformDotNetFramework.Entities.DTO;
using WinformDotNetFramework.Entities.Filters;
using WinformDotNetFramework.Entities.Preference;
using WinformDotNetFramework.Forms.AddForms;
using WinformDotNetFramework.Services;

namespace WinformDotNetFramework.Forms.GridForms
{
    public partial class SupplierInvoiceGridForm : Form
    {

        int? SaleID;
        int? SupplierID;
        DateTime? InvoiceDateFrom;
        DateTime? InvoiceDateTo;
        int? InvoiceAmountFrom;
        int? InvoiceAmountTo;
        string Status;
        Form _father;
        UserService _userService;
        SupplierInvoiceService _supplierInvoiceService;
        int pages;
        double itemsPage = 10.0;
        Task<ICollection<SupplierInvoiceSupplierDTO>> getAllNotFiltered;
        Task<int> countNotFiltered;
        Task<SupplierInvoiceDGV> getFav;
        List<string> authRoles = new List<string>
            {
                "SupplierInvoiceAdmin",
                "Admin"
            };
        public SupplierInvoiceGridForm()
        {
            Init();
        }
        public SupplierInvoiceGridForm(Form father)
        {
            _father = father;

            Init();
        }
        public SupplierInvoiceGridForm(string id)
        {
            Init();
            if (id != null)
            {
                SupplierIDTxt.SetText(id);
                MyControl_ButtonClicked(this, EventArgs.Empty);
            }
        }

        private async void Init()
        {
            _userService = new UserService();
            _supplierInvoiceService = new SupplierInvoiceService();
            InitializeComponent();
            pages = (int)Math.Ceiling(await _supplierInvoiceService.Count(new SupplierInvoiceFilter()) / itemsPage);

            StatusCmb.SelectedIndex = 0;
            RightSideBar.searchBtnEvent += MyControl_ButtonClicked;

            PaginationUserControl.SingleRightArrowEvent += PaginationUserControl_SingleRightArrowEvent;
            PaginationUserControl.DoubleRightArrowEvent += PaginationUserControl_DoubleRightArrowEvent;
            PaginationUserControl.DoubleLeftArrowEvent += PaginationUserControl_DoubleLeftArrowEvent;
            PaginationUserControl.SingleLeftArrowEvent += PaginationUserControl_SingleLeftArrowEvent;

            PaginationUserControl.SetMaxPage(pages.ToString());
            PaginationUserControl.CurrentPage = 1;
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());
            SupplierInvoiceDgv.ContextMenuStrip = RightClickDgv;
            PaginationUserControl.Visible = false;
            if (!Authorize(authRoles))
            {
                SupplierInvoiceIDTsmi.Visible = false;
                SupplierInvoiceSupplierIDTsmi.Visible = false;
            }
        }

        private bool Authorize(List<string> allowedRoles)
        {
            return allowedRoles.Any(role => UserAccessInfo.Role.Contains(role));
        }


        public virtual void MyControl_OpenDetails_Clicked(object sender, DataGridViewCellEventArgs e)
        {
            if (sender is DataGridView dgv)
            {
                if (_father is CreateSupplierInvoiceCostForm sigf)
                    sigf.SetSupplierID(dgv.CurrentRow.Cells["InvoiceID"].Value.ToString());
            }
        }

        private async void MyControl_ButtonClicked(object sender, EventArgs e)
        {
            bool flagfrom = false;
            bool flagto = false;
            if (DateFromClnd.Checked)
            {
                if (!(DateFromClnd.Value <= DateTime.Now) || !(DateFromClnd.Value > new DateTime(1975, 1, 1)))
                    flagfrom = true;
            }
            if (DateToClnd.Checked)
            {
                if (!(DateToClnd.Value <= DateTime.Now) || !(DateToClnd.Value >= DateFromClnd.Value))
                    flagto = true;
            }
            if (flagfrom && flagto)
                MessageBox.Show("Incorrect Input Date From and Date To");
            else
            {
                if (flagfrom)
                {
                    MessageBox.Show("Incorrect Input Date From");
                    return;
                }

                if (flagto)
                {
                    MessageBox.Show("Incorrect Input Date To");
                    return;
                }

            }



            PaginationUserControl.CurrentPage = 1;

            if (!string.IsNullOrEmpty(SaleIDTxt.GetText()))
            {
                SaleID = int.Parse(SaleIDTxt.GetText());
            }
            else
            {
                SaleID = null;
            }

            if (!string.IsNullOrEmpty(SupplierIDTxt.GetText()))
            {
                SupplierID = int.Parse(SupplierIDTxt.GetText());
            }
            else
            {
                SupplierID = null;
            }

            if (!string.IsNullOrEmpty(InvoiceAmountFromTxt.GetText()))
            {
                InvoiceAmountFrom = int.Parse(InvoiceAmountFromTxt.GetText());
            }
            else
            {
                InvoiceAmountFrom = null;
            }

            if (!string.IsNullOrEmpty(InvoiceAmountToTxt.GetText()))
            {
                InvoiceAmountTo = int.Parse(InvoiceAmountToTxt.GetText());
            }
            else
            {
                InvoiceAmountTo = null;
            }

            if (DateFromClnd.Checked)
            {
                InvoiceDateFrom = DateFromClnd.Value;
            }
            else
            {
                InvoiceDateFrom = null;
            }

            if (DateToClnd.Checked)
            {
                InvoiceDateTo = DateToClnd.Value;
            }
            else
            {
                InvoiceDateTo = null;
            }

            Status = StatusCmb.Text;


            SupplierInvoiceFilter filter = new SupplierInvoiceFilter
            {
                SupplierInvoiceSaleID = SaleID,
                SupplierInvoiceSupplierID = SupplierID,
                SupplierInvoiceInvoiceDateFrom = InvoiceDateFrom,
                SupplierInvoiceInvoiceDateTo = InvoiceDateTo,
                SupplierInvoiceStatus = Status,
                SupplierInvoicePage = PaginationUserControl.CurrentPage
            };
            SupplierInvoiceFilter filterPage = new SupplierInvoiceFilter
            {
                SupplierInvoiceSaleID = SaleID,
                SupplierInvoiceSupplierID = SupplierID,
                SupplierInvoiceInvoiceDateFrom = InvoiceDateFrom,
                SupplierInvoiceInvoiceDateTo = InvoiceDateTo,
                SupplierInvoiceStatus = Status,
            };


            var query = _supplierInvoiceService.GetAll(filter);
            var count = _supplierInvoiceService.Count(filterPage);
            await Task.WhenAll(count, query);
            PaginationUserControl.maxPage = ((int)Math.Ceiling((double)await count / itemsPage)).ToString();
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());

            IEnumerable<SupplierInvoiceSupplierDTO> query1 = await query;
            SupplierInvoiceDgv.DataSource = query1.ToList();
        }

        private async Task SetCheckBoxes()
        {
            await Task.WhenAll(getFav, countNotFiltered, getAllNotFiltered);
            IEnumerable<SupplierInvoiceSupplierDTO> query = await getAllNotFiltered;
            PaginationUserControl.maxPage = ((int)Math.Ceiling((double)await countNotFiltered / itemsPage)).ToString();
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());
            SupplierInvoiceDgv.DataSource = query.ToList();
            SupplierInvoiceDGV cdgv = await getFav;

            SupplierInvoiceIDTsmi.Checked = cdgv.ShowID;
            SupplierInvoiceSaleIDTsmi.Checked = cdgv.ShowSaleID;
            SupplierInvoiceInvoiceAmountTsmi.Checked = cdgv.ShowInvoiceAmount;
            SupplierInvoiceDateTsmi.Checked = cdgv.ShowInvoiceDate;
            SupplierInvoiceStatusTsmi.Checked = cdgv.ShowStatus;
            SupplierInvoiceSupplierNameTsmi.Checked = cdgv.ShowSupplierName;
            SupplierInvoiceCountryTsmi.Checked = cdgv.ShowCountry;
            SupplierInvoiceSupplierIDTsmi.Checked = cdgv.ShowSupplierID;

            SupplierInvoiceDgv.Columns["InvoiceID"].Visible = cdgv.ShowID;
            SupplierInvoiceDgv.Columns["SaleID"].Visible = cdgv.ShowSaleID;
            SupplierInvoiceDgv.Columns["InvoiceAmount"].Visible = cdgv.ShowInvoiceAmount;
            SupplierInvoiceDgv.Columns["InvoiceDate"].Visible = cdgv.ShowInvoiceDate;
            SupplierInvoiceDgv.Columns["Status"].Visible = cdgv.ShowStatus;
            SupplierInvoiceDgv.Columns["SupplierName"].Visible = cdgv.ShowSupplierName;
            SupplierInvoiceDgv.Columns["Country"].Visible = cdgv.ShowCountry;
            SupplierInvoiceDgv.Columns["SupplierID"].Visible = cdgv.ShowSupplierID;

            PaginationUserControl.Visible = true;

        }
        private async void MyControl_ButtonClicked_Pagination(object sender, EventArgs e)
        {
            SupplierInvoiceFilter filter = new SupplierInvoiceFilter
            {
                SupplierInvoiceSaleID = SaleID,
                SupplierInvoiceSupplierID = SupplierID,
                SupplierInvoiceInvoiceDateFrom = InvoiceDateFrom,
                SupplierInvoiceInvoiceDateTo = InvoiceDateTo,
                SupplierInvoiceStatus = Status,
                SupplierInvoicePage = PaginationUserControl.CurrentPage
            };

            IEnumerable<SupplierInvoiceSupplierDTO> query = await _supplierInvoiceService.GetAll(filter);
            SupplierInvoiceDgv.DataSource = query.ToList();
        }

        private void PaginationUserControl_SingleLeftArrowEvent(object sender, EventArgs e)
        {
            if (PaginationUserControl.CurrentPage <= 1)
                return;
            PaginationUserControl.CurrentPage = PaginationUserControl.CurrentPage - 1;
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());
            MyControl_ButtonClicked_Pagination(sender, e);
        }

        private void PaginationUserControl_DoubleLeftArrowEvent(object sender, EventArgs e)
        {

            PaginationUserControl.CurrentPage = 1;
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());
            MyControl_ButtonClicked_Pagination(sender, e);
        }

        private void PaginationUserControl_DoubleRightArrowEvent(object sender, EventArgs e)
        {
            PaginationUserControl.CurrentPage = int.Parse(PaginationUserControl.GetmaxPage());
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());
            MyControl_ButtonClicked_Pagination(sender, e);
        }

        private void PaginationUserControl_SingleRightArrowEvent(object sender, EventArgs e)
        {
            if (PaginationUserControl.CurrentPage >= int.Parse(PaginationUserControl.GetmaxPage()))
                return;
            PaginationUserControl.CurrentPage++;
            PaginationUserControl.SetPageLbl(PaginationUserControl.CurrentPage + "/" + PaginationUserControl.GetmaxPage());
            MyControl_ButtonClicked_Pagination(sender, e);

        }
        private void CustomerGridForm_Resize(object sender, EventArgs e)
        {
            panel2.Location = new Point((Width - panel2.Width) / 2, 0);
            PaginationUserControl.Location = new Point((panel2.Width - PaginationUserControl.Width) / 2, (panel2.Height - PaginationUserControl.Height) / 2);


            int newHeight = (int)((Height - TextBoxesRightPanel.Top) * 0.9);
            if (TextBoxesRightPanel.Height != newHeight)
            {
                TextBoxesRightPanel.Height = newHeight;
            }
        }

        private void RightClickDgvEvent(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var test = SupplierInvoiceDgv.HitTest(e.X, e.Y);
                if (test.RowIndex >= 0)
                {
                    RightClickDgv.Show(SupplierInvoiceDgv, e.Location);
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
                    case "SupplierInvoiceIDTsmi":
                        SupplierInvoiceDgv.Columns["InvoiceID"].Visible = tsmi.Checked;
                        break;
                    case "SupplierInvoiceSaleIDTsmi":
                        SupplierInvoiceDgv.Columns["SaleID"].Visible = tsmi.Checked;
                        break;
                    case "SupplierInvoiceInvoiceAmountTsmi":
                        SupplierInvoiceDgv.Columns["InvoiceAmount"].Visible = tsmi.Checked;
                        break;
                    case "SupplierInvoiceDateTsmi":
                        SupplierInvoiceDgv.Columns["InvoiceDate"].Visible = tsmi.Checked;
                        break;
                    case "SupplierInvoiceStatusTsmi":
                        SupplierInvoiceDgv.Columns["Status"].Visible = tsmi.Checked;
                        break;
                    case "SupplierInvoiceSupplierNameTsmi":
                        SupplierInvoiceDgv.Columns["SupplierName"].Visible = tsmi.Checked;
                        break;
                    case "SupplierInvoiceCountryTsmi":
                        SupplierInvoiceDgv.Columns["Country"].Visible = tsmi.Checked;
                        break;
                    case "SupplierInvoiceSupplierIDTsmi":
                        SupplierInvoiceDgv.Columns["SupplierID"].Visible = tsmi.Checked;
                        break;

                    default:
                        break;
                }
                SupplierInvoiceDGV cdgv = new SupplierInvoiceDGV
                {
                    ShowInvoiceDate = SupplierInvoiceDateTsmi.Checked,
                    ShowID = SupplierInvoiceIDTsmi.Checked,
                    ShowInvoiceAmount = SupplierInvoiceInvoiceAmountTsmi.Checked,
                    ShowSaleID = SupplierInvoiceSaleIDTsmi.Checked,
                    ShowStatus = SupplierInvoiceStatusTsmi.Checked,
                    ShowCountry = SupplierInvoiceCountryTsmi.Checked,
                    ShowSupplierName = SupplierInvoiceSupplierNameTsmi.Checked,
                    ShowSupplierID = SupplierInvoiceSupplierIDTsmi.Checked,
                    UserID = UserAccessInfo.RefreshUserID
                };
                await _userService.PostSupplierInvoiceDGV(cdgv);
            }
        }

        private async void SupplierInvoiceGridForm_Load(object sender, EventArgs e)
        {
            getAllNotFiltered = _supplierInvoiceService.GetAll(new SupplierInvoiceFilter() { SupplierInvoicePage = 1 });
            countNotFiltered = _supplierInvoiceService.Count(new SupplierInvoiceFilter());
            getFav = _userService.GetSupplierInvoiceDGV();
            await SetCheckBoxes();
        }
        private async void MassDeleteTSB_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
          "This action is permanent and it will delete all the history bound to this Supplier Invoice!",
          "Confirm Deletion?",
          MessageBoxButtons.YesNo,
          MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    List<int> id = new List<int>();


                    HashSet<int> ids = new HashSet<int>();
                    foreach (DataGridViewCell cell in SupplierInvoiceDgv.SelectedCells)
                    {
                        ids.Add(cell.RowIndex);
                    }
                    foreach (var rowid in ids)
                    {
                        if (SupplierInvoiceDgv.Rows[rowid].DataBoundItem is SupplierInvoiceSupplierDTO customer)
                            id.Add(customer.InvoiceId);
                    }

                    if (id.Count > 0)
                    {
                        string message = await _supplierInvoiceService.MassDelete(id);
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
        private void Pdf_ClickBtn(object sender, EventArgs e)
        {
            UtilityFunctions.Pdf_ClickBtn(SupplierInvoiceDgv, this);
        }


        private void Excel_ClickBtn(object sender, EventArgs e)
        {
            UtilityFunctions.Excel_ClickBtn(SupplierInvoiceDgv, this);
        }
    }
}

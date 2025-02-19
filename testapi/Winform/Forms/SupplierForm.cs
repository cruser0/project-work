using API.Models.Filters;
using Winform.Entities;
using Winform.Services;

namespace Winform.Forms
{
    public partial class SupplierForm : Form
    {
        private SupplierService _supplierService;
        public SupplierForm()
        {
            _supplierService = new SupplierService();

            InitializeComponent();

            RightSideBar.searchBtnEvent += MyControl_ButtonClicked;
            RightSideBar.closeBtnEvent += RightSideBar_closeBtnEvent;

            comboBox1.SelectedIndex = 1;
        }

        private void RightSideBar_closeBtnEvent(object? sender, EventArgs e)
        {
            this.Close();
        }

        private void MyControl_ButtonClicked(object sender, EventArgs e)
        {
            SupplierFilter filter = new SupplierFilter
            {
                Name = NameSupplierTxt.Text,
                Country = CountrySupplierTxt.Text,
                Deprecated = comboBox1.SelectedIndex switch
                {
                    1 => false,
                    2 => true,
                    _ => null
                }
            };


            IEnumerable<Supplier> query = _supplierService.GetAll(filter);

            SupplierDgv.DataSource = query.ToList();
        }


        private void baseGridComponent_Load(object sender, EventArgs e)
        {

        }

        private void SupplierDgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (sender is DataGridView dgv)
            {
                SupplierDetailsForm cdf = new SupplierDetailsForm(int.Parse(dgv.CurrentRow.Cells[0].Value.ToString()));
                cdf.Show();
            }
            else
            {
                MessageBox.Show(sender.ToString());

            }
        }
    }
}

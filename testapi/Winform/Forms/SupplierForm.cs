using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

            baseGridUserControl1.buttonGet += MyControl_ButtonClicked;
            baseGridUserControl1.dgvDoubleClick += MyControl_OpenDetails_Clicked;
        }
        private void MyControl_ButtonClicked(object sender, EventArgs e)
        {
            IEnumerable<Supplier> query = _supplierService.GetAll();

            if (!string.IsNullOrWhiteSpace(NameSupplierTxt.Text))
                query = query.Where(x => x.SupplierName.StartsWith(NameSupplierTxt.Text, StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrWhiteSpace(CountrySupplierTxt.Text))
                query = query.Where(x => x.Country.StartsWith(CountrySupplierTxt.Text, StringComparison.OrdinalIgnoreCase));

            baseGridUserControl1.setDataGrid(query.ToList());
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

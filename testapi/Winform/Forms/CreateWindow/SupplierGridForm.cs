using API.Models.Filters;
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

namespace Winform.Forms.CreateWindow
{
    public partial class SupplierGridForm : Form
    {
        SupplierService _service;
        CreateSupplierInvoicesForm _form;
        public SupplierGridForm(CreateSupplierInvoicesForm father)
        {
            _form = father;
            _service = new SupplierService();
            InitializeComponent();
            RightSideBar.searchBtnEvent += RightSideBar_searchBtnEvent;
        }

        private void RightSideBar_searchBtnEvent(object? sender, EventArgs e)
        {
            SupplierFilter filter = new SupplierFilter
            {
                Name = NameTxt.Text,
                Country = CountryTxt.Text,
                Deprecated = StatusCmb.SelectedIndex switch
                {
                    1 => false,
                    2 => true,
                    _ => null
                }
            };


            IEnumerable<Supplier> query = _service.GetAll(filter);

            SupplierDgv.DataSource = query.ToList();
        }

        private void SupplierDgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(sender is DataGridView dgv)
            _form.SetSupplierID(dgv.CurrentRow.Cells[0].Value.ToString());
        }
    }
}

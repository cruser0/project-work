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
using Winform.Forms.control;
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
            baseGridComponent.setDataGrid(_customerService.GetAll());
        }
        private void MyControl_OpenDetails_Clicked(object sender, DataGridViewCellEventArgs e)
        {
            if(sender is DataGridView dgv)
            {
                MessageBox.Show(dgv.CurrentRow.Cells[1].Value.ToString());
            }
            else
            {
                MessageBox.Show(sender.ToString());

            }

        }
    }
}

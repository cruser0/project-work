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

namespace Winform.Forms.AddForms
{
    public partial class CreateSaleForm : Form
    {
        SaleService _saleService;
        public CreateSaleForm()
        {
            _saleService = new SaleService();
            InitializeComponent();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            Sale sale = new Sale
            {
                BookingNumber = bntxt.Text,
                BoLnumber = boltxt.Text,
                SaleDate = saleDateDtp.Value,
                CustomerId = int.Parse(CustomerIdtxt.GetText()),
                Status = StatusCmbx.Text
            };
            try
            {
                _saleService.Create(sale);
                MessageBox.Show("Sale Created successfully!");

                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void OpenSale_Click(object sender, EventArgs e)
        {
            CustomerGridForm sgf = new CustomerGridForm(this);
            sgf.ShowDialog();
        }
        public void SetCustomerID(string id)
        {
            CustomerIdtxt.SetText(id);
        }
    }
}

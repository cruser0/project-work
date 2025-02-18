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

namespace Winform.Forms
{
    public partial class CreateSupplierInvoicesForm : Form
    {
        private string activeType;
        SupplierInvoiceService _service;
        SaleService _saleService;
        SupplierService _supplierService;
        public CreateSupplierInvoicesForm()
        {
            _saleService = new SaleService();
            _supplierService = new SupplierService();
            _service = new SupplierInvoiceService();
            InitializeComponent();
        }

        private void SaveEditCustomerBtn_Click(object sender, EventArgs e)
        {

            List<string> err=new List<string>();
            if (string.IsNullOrEmpty(SaleIDTxt.Text))
                err.Add("SaleID");
            if (string.IsNullOrEmpty(SupplierIDTxt.Text))
                err.Add("SupplierID");
            if (string.IsNullOrEmpty(StatusCmbx.Text))
                err.Add("Status");
            if (DateClnd.Value == null)
                err.Add("Date");
            if (err.Count > 0)
                MessageBox.Show("Gli attributi : "+string.Join(",", err)+"\n Sono errati!");
            else
            {
                try
                {
                SupplierInvoice si=new SupplierInvoice {InvoiceDate= DateClnd.Value,SaleId=int.Parse(SaleIDTxt.Text),SupplierId=int.Parse(SupplierIDTxt.Text),Status=StatusCmbx.Text };
                _service.Create(si);
                MessageBox.Show("Supplier Invoice created Successfully!");

                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }

        }

        private void SupplierIDTxt_Click(object sender, EventArgs e)
        {

            dataGridView1.DataSource = _supplierService.GetAll(null, null);
            activeType = "supplier";
        }

        private void SaleIDTxt_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _saleService.GetAll(new SaleFilter());
            activeType = "sale";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(sender is DataGridView dgv)
            {
            switch (activeType)
            {
                case "supplier":
                    SupplierIDTxt.Text= dgv.CurrentRow.Cells["SupplierId"].Value.ToString();
                        break;
                case "sale":
                        SaleIDTxt.Text = dgv.CurrentRow.Cells["SaleId"].Value.ToString();
                        break;
                default:
                    break;
            }
            }
        }
    }
}

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
using Winform.Forms.CreateWindow;
using Winform.Services;

namespace Winform.Forms
{
    public partial class CreateSupplierInvoicesForm : Form
    {
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
        public void SetSupplierID(string id)
        {
            SupplierIDTxt.Text = id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SupplierGridForm sgf=new SupplierGridForm(this);
            sgf.ShowDialog();

        }

        private void Sgf_SupplierGridDBClick(object? sender, string e)
        {
            if(sender is DataGridView dgv)
            {
                SupplierIDTxt.Text=dgv.CurrentRow.Cells[0].Value.ToString();
            }
        }

        private void OpenSale_Click(object sender, EventArgs e)
        {
            SaleGridForm sgf = new SaleGridForm(this);
            sgf.ShowDialog();
        }
        public void SetSaleID(string id)
        {
            SaleIDTxt.Text = id;
        }
    }
}

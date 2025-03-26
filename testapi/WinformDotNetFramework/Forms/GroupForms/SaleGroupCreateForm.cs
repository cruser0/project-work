using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using WinformDotNetFramework.Entities.DTO;
using WinformDotNetFramework.Entities.Filters;
using WinformDotNetFramework.Forms.AddForms;
using WinformDotNetFramework.Services;

namespace WinformDotNetFramework.Forms.GroupForms
{
    public partial class SaleGroupCreateForm : CreateSaleForm
    {
        SupplierInvoiceService _supplierInvoiceService;
        SupplierService _supplierService;
        public SaleGroupCreateForm()
        {
            _supplierInvoiceService = new SupplierInvoiceService();
            _supplierService= new SupplierService();
            InitializeComponent();
        }

        private async void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
           await Save();
            }catch (Exception ex) { MessageBox.Show(ex.Message); return; }

        }
        private string lastTypedTextSupplierName = "";
        private string lastTypedTextSupplierCountry = "";
        private int editingRowIndex = -1;
        private int editingColumnIndex = -1;


        private void SupplierInvoiceDgv_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (SupplierInvoiceDgv.CurrentCell is DataGridViewComboBoxCell /*&& SupplierInvoiceDgv.CurrentCell.OwningColumn.Name.Equals(SupplierNameCmbxDgv.Name)*/)
            {
                if (e.Control is ComboBox comboBox)
                {
                    comboBox.DropDownStyle = ComboBoxStyle.DropDown;
                    comboBox.AutoCompleteMode = AutoCompleteMode.None;
                    comboBox.AutoCompleteSource = AutoCompleteSource.ListItems;

                    comboBox.TextChanged -= Cmbx_TextChanged;
                    comboBox.SelectedIndexChanged -= Cmbx_SelectedIndexChanged;
                    comboBox.SelectionChangeCommitted -= Cmbx_SelectionChangeCommitted;
                    comboBox.TextChanged += Cmbx_TextChanged;
                    comboBox.SelectedIndexChanged += Cmbx_SelectedIndexChanged;
                    comboBox.SelectionChangeCommitted += Cmbx_SelectionChangeCommitted;

                    editingRowIndex = SupplierInvoiceDgv.CurrentCell.RowIndex;
                    editingColumnIndex = SupplierInvoiceDgv.CurrentCell.ColumnIndex;
                }
            }
        }
        public void Cmbx_TextChanged(object sender, EventArgs e)
        {
            if (sender is ComboBox comboBox)
            {
                if (_suppressEvents)
                        return;
                if (SupplierInvoiceDgv.CurrentCell.OwningColumn.Name.Equals(SupplierNameCmbxDgv.Name))
                    lastTypedTextSupplierName = comboBox.Text;
                if (SupplierInvoiceDgv.CurrentCell.OwningColumn.Name.Equals(SupplierCountryCmbxDgv.Name))
                    lastTypedTextSupplierCountry = comboBox.Text;
                timer.Stop();
                timer.Start();
            }
        }
        private async void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            await SetSupplierInvoiceDGV();
        }

        private async Task SetSupplierInvoiceDGV()
        {
            if (editingRowIndex < 0 || editingColumnIndex < 0) return;

            var listFiltered = await _supplierService.GetAll(new SupplierFilter()
            {
                SupplierName = !string.IsNullOrEmpty(lastTypedTextSupplierName) ? lastTypedTextSupplierName : null,
                SupplierCountry = !string.IsNullOrEmpty(lastTypedTextSupplierCountry) ? lastTypedTextSupplierCountry : null
            });

            var listItemsName = listFiltered
                .Where(x => string.IsNullOrEmpty(lastTypedTextSupplierName) || x.SupplierName.Contains(lastTypedTextSupplierName))
                .Select(x => x.SupplierName)
                .Distinct()
                .ToList();

            var listItemsCountry = listFiltered
                .Where(x => string.IsNullOrEmpty(lastTypedTextSupplierCountry) || x.Country.Contains(lastTypedTextSupplierCountry))
                .Select(x => x.Country)
                .Distinct()
                .ToList();

            if (SupplierInvoiceDgv.EditingControl is ComboBox comboBox)
            {
                comboBox.TextChanged -= Cmbx_TextChanged;
                _suppressEvents = true;

                string currentText = comboBox.Text;
                int currentIndex = comboBox.SelectionStart;

                comboBox.DataSource = null;
                if(SupplierInvoiceDgv.CurrentCell.OwningColumn.Name.Equals(SupplierCountryCmbxDgv.Name))
                    comboBox.DataSource = listItemsCountry;
                if (SupplierInvoiceDgv.CurrentCell.OwningColumn.Name.Equals(SupplierNameCmbxDgv.Name))
                    comboBox.DataSource = listItemsName;

                comboBox.Text = currentText;
                comboBox.SelectionStart = currentIndex;
                comboBox.DroppedDown = true;
                _suppressEvents = false;
                comboBox.TextChanged += Cmbx_TextChanged;

            }
        }


        public List<string> listItemsDropCmbx { get; set; }

        private bool _suppressEvents = false;



        private void Cmbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            timer.Stop();
        }
        private void Cmbx_SelectionChangeCommitted(object sender, EventArgs e)
        {
            timer.Stop();
        }

        private void SupplierInvoiceDgv_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (SupplierInvoiceDgv.CurrentCell is DataGridViewComboBoxCell /*&& SupplierInvoiceDgv.CurrentCell.OwningColumn.Name.Equals(SupplierNameCmbxDgv.Name)*/)
            {
                //if (SupplierInvoiceDgv.Rows[e.RowIndex].Cells is DataGridViewCell comboBox)
                //{
                    
                //}
            }
        }
    }
}

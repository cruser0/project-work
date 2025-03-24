using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinformDotNetFramework.Forms.AddForms;

namespace WinformDotNetFramework.Forms.control
{
    public partial class DropDownMenuAutoCompleteUserControl : UserControl
    {
        bool isSelecting = false;
        public List<string> listItemsDropCmbx { get; set; }

        public DropDownMenuAutoCompleteUserControl()
        {
            InitializeComponent();
        }

        private bool _suppressEvents = false;

        private async void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            if (_suppressEvents) return;
            _suppressEvents = true;

            try
            {
                string currentText = Cmbx.Text;
                int selectionStart = Cmbx.SelectionStart;

                if (string.IsNullOrWhiteSpace(currentText))
                {
                    Cmbx.DroppedDown = false;
                    return;
                }
                if(ParentForm is CreateCustomerInvoiceCostForm cicf)
                    await cicf.SetList(currentText);

                if(ParentForm is CreateCustomerInvoiceForm cif)
                    await cif.SetList();
                if(ParentForm is CreateSaleForm sf)
                    await sf.SetList();

                if (listItemsDropCmbx.Count > 0)
                {
                    Cmbx.BeginUpdate();
                    Cmbx.DataSource = null;
                    Cmbx.DataSource = listItemsDropCmbx;
                    Cmbx.EndUpdate();
                    Cmbx.DroppedDown = true;
                    Cmbx.Text = currentText;
                    Cmbx.SelectionStart = selectionStart;
                }
                else
                {
                    Cmbx.DroppedDown = false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error!");
            }
            finally
            {
                _suppressEvents = false;
            }
        }

        private void Cmbx_TextChanged(object sender, EventArgs e)
        {
            if (_suppressEvents) return;
            timer.Stop();
            timer.Start();
        }

        private void Cmbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            timer.Stop();
        }
        private void Cmbx_SelectionChangeCommitted(object sender, EventArgs e)
        {
            timer.Stop();
        }
    }
}

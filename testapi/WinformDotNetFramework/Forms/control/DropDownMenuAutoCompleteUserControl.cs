using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WinformDotNetFramework.Forms.DetailsForms;

namespace WinformDotNetFramework.Forms.control
{
    public partial class DropDownMenuAutoCompleteUserControl : UserControl
    {
        bool isSelecting = false;
        public List<string> listItemsDropCmbx { get; set; }

        public DropDownMenuAutoCompleteUserControl()
        {
            InitializeComponent();
            Cmbx.PropTxt.TextChanged += Cmbx_TextChanged;
            Cmbx.PropTxt.SelectedValueChanged += Cmbx_SelectedValueChanged;
        }

        private bool _suppressEvents = false;

        private async void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            if (_suppressEvents) return;
            _suppressEvents = true;

            try
            {
                string currentText = Cmbx.PropTxt.Text;
                int selectionStart = Cmbx.PropTxt.SelectionStart;

                if (string.IsNullOrWhiteSpace(currentText))
                {
                    Cmbx.PropTxt.DroppedDown = false;
                    return;
                }
                if (ParentForm is CreateDetailsCustomerInvoiceCostForm cicf)
                    await cicf.SetList(currentText);

                if (ParentForm is CreateDetailsCustomerInvoiceForm cif)
                    await cif.SetList();

                if (ParentForm is CreateDetailsSaleForm sf)
                    await sf.SetList();

                if (ParentForm is CreateDetailsSupplierInvoiceForm sif)
                    await sif.SetList();

                if (ParentForm is CreateDetailsSupplierInvoiceCostForm sicf)
                    await sicf.SetList();

                if (ParentForm is CreateDetailsCustomerInvoiceForm cidf)
                    await cidf.SetList();

                if (ParentForm is CreateDetailsSupplierInvoiceForm sidf)
                    await sidf.SetList();

                if (ParentForm is CreateDetailsSaleForm sdf)
                    await sdf.SetList();

                if (ParentForm is PdfInvoiceForm pif)
                    await pif.SetList();

                if (listItemsDropCmbx.Count > 0)
                {
                    Cmbx.PropTxt.BeginUpdate();
                    Cmbx.PropTxt.DataSource = listItemsDropCmbx;
                    Cmbx.PropTxt.DroppedDown = true;
                    Cmbx.PropTxt.Text = currentText;
                    Cmbx.PropTxt.SelectionStart = selectionStart;
                    Cmbx.PropTxt.EndUpdate();


                }
                else
                {
                    Cmbx.PropTxt.DroppedDown = false;
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




        //private void Cmbx_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    timer.Stop();
        //}

        //public void Cmbx_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (_suppressEvents) return;
        //    timer.Stop();
        //    timer.Start();
        //}

        private void Cmbx_SelectedValueChanged(object sender, EventArgs e)
        {
            timer.Stop();
        }



        public void Cmbx_TextChanged(object sender, EventArgs e)
        {
            if (_suppressEvents) return;
            timer.Stop();
            timer.Start();

        }
        //private void Cmbx_SelectionChangeCommitted(object sender, EventArgs e)
        //{
        //    timer.Stop();
        //}

    }
}

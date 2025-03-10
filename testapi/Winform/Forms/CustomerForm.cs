using ClosedXML.Excel;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System.Data;


namespace Winform.Forms
{
    public partial class CustomerForm : CustomerGridForm
    {

        public CustomerForm()
        {
            InitializeComponent();
        }


        public override void MyControl_OpenDetails_Clicked(object sender, DataGridViewCellEventArgs e)
        {

            if (sender is DataGridView dgv)
            {
                if (e.RowIndex == -1)
                    return;

                UtilityFunctions.OpenFormDetails<CustomerDetailsForm>(sender, e, int.Parse(dgv.CurrentRow.Cells["CustomerId"].Value.ToString()));

            }
        }

       
    }
}

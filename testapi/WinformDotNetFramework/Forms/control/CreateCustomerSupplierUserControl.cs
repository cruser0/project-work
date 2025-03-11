using System;
using System.Windows.Forms;
using WinformDotNetFramework.Entities.DTO;

namespace WinformDotNetFramework.Forms.control
{
    public partial class CreateCustomerSupplierUserControl : UserControl
    {
        public event EventHandler<SupplierCustomerDTO> createButton;
        public CreateCustomerSupplierUserControl()
        {
            InitializeComponent();
        }

        private void CreateSaveBtn_Click(object sender, EventArgs e)
        {
            SupplierCustomerDTO supplierCustomerDTO = new SupplierCustomerDTO { Name = CreateNameTxt.Text, Country = CreateCountryTxt.Text };
            createButton.Invoke(this, supplierCustomerDTO);
        }

        private void CreateCountryLbl_Click(object sender, EventArgs e)
        {

        }

        private void CreateNameLbl_Click(object sender, EventArgs e)
        {

        }

        private void CreateCountryTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void CreateNameTxt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

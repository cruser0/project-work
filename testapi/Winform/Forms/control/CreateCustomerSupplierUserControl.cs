using Winform.Entities.DTO;

namespace Winform.Forms.control
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
    }
}

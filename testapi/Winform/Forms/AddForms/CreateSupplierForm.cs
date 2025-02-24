using Winform.Entities;
using Winform.Services;

namespace Winform.Forms
{
    public partial class CreateSupplierForm : Form
    {
        SupplierService _supplierService;
        public CreateSupplierForm()
        {
            _supplierService = new SupplierService();
            InitializeComponent();
            CreateSupplierUserControl.createButton += CreateSupplierUserControl_createButton;
        }

        private void CreateSupplierUserControl_createButton(object? sender, Entities.DTO.SupplierCustomerDTO e)
        {
            if (!string.IsNullOrEmpty(e.Name) || !string.IsNullOrEmpty(e.Country))
            {
                Supplier supplier = new Supplier { SupplierName = e.Name, Country = e.Country };
                try
                {
                    _supplierService.Create(supplier);
                    MessageBox.Show("Supplier created Successfully!");
                    this.Close();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }

            }
            else
                MessageBox.Show("Name and Country must not be empty");
        }
    }
}

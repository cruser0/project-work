using System;
using System.Linq;
using System.Windows.Forms;
using WinformDotNetFramework.Entities.DTO;

namespace WinformDotNetFramework.Forms.control
{
    public partial class CreateCustomerSupplierUserControl : UserControl
    {
        public event EventHandler<SupplierCustomerDTO> createButton;
        public CreateCustomerSupplierUserControl()
        {
            Init();
        }
        private async void Init()
        {
            InitializeComponent();
            CountryCmbx.DataSource = (await UtilityFunctions.GetCountries()).Select(x => x.CountryName).ToList();
        }

        private void CreateSaveBtn_Click(object sender, EventArgs e)
        {
            SupplierCustomerDTO supplierCustomerDTO = new SupplierCustomerDTO { Name = CreateNameTxt.Text, Country = CountryCmbx.Text };
            createButton.Invoke(this, supplierCustomerDTO);
        }

    }
}

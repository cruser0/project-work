using API.Models.Filters;

namespace Winform.Forms.control
{
    public partial class SearchSupplier : UserControl
    {
        public SearchSupplier()
        {
            InitializeComponent();
        }

        public SupplierFilter GetFilter()
        {
            SupplierFilter filter = new SupplierFilter()
            {
                SupplierName = NameSupplierTxt.Text,
                SupplierCountry = CountrySupplierTxt.Text,
                SupplierCreatedDateFrom = DateFromClnd.Checked ? DateFromClnd.Value : null,
                SupplierCreatedDateTo = DateToClnd.Checked ? DateToClnd.Value : null,
                SupplierDeprecated = comboBox1.SelectedIndex switch
                {
                    1 => false,
                    2 => true,
                    _ => null
                },
            };

            return filter;
        }
    }
}

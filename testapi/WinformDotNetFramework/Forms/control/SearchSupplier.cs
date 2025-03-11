using System.Windows.Forms;
using WinformDotNetFramework.Entities.Filters;

namespace WinformDotNetFramework.Forms.control
{
    public partial class SearchSupplier : UserControl
    {
        public SearchSupplier()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }

        public SupplierFilter GetFilter()
        {
            SupplierFilter filter = new SupplierFilter();
            filter.SupplierName = NameSupplierTxt.Text;
            filter.SupplierCountry = CountrySupplierTxt.Text;

            if (DateFromClnd.Checked)
            {
                filter.SupplierCreatedDateFrom = DateFromClnd.Value;
            }
            else
            {
                filter.SupplierCreatedDateFrom = null;
            }

            if (DateToClnd.Checked)
            {
                filter.SupplierCreatedDateTo = DateToClnd.Value;
            }
            else
            {
                filter.SupplierCreatedDateTo = null;
            }


            // Utilizzo del switch tradizionale per SupplierDeprecated
            switch (comboBox1.SelectedIndex)
            {
                case 1:
                    filter.SupplierDeprecated = false;
                    break;
                case 2:
                    filter.SupplierDeprecated = true;
                    break;
                default:
                    filter.SupplierDeprecated = null;
                    break;
            }


            return filter;
        }
    }
}

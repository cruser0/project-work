using System.Windows.Forms;
using WinformDotNetFramework.Entities.Filters;

namespace WinformDotNetFramework.Forms.control
{
    public partial class SearchCustomer : UserControl
    {
        public SearchCustomer()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }

        public CustomerFilter GetFilter()
        {
            CustomerFilter customerfilter = new CustomerFilter
            {
                CustomerName = NameTxt.Text,
                CustomerCountry = CountryTxt.Text,
                CustomerDeprecated = null, // Default value
            };

            switch (comboBox1.SelectedIndex)
            {
                case 1:
                    customerfilter.CustomerDeprecated = false;
                    break;

                case 2:
                    customerfilter.CustomerDeprecated = true;
                    break;

                default:
                    customerfilter.CustomerDeprecated = null;
                    break;
            }

            if (DateFromClnd.Checked)
            {
                customerfilter.CustomerCreatedDateFrom = DateFromClnd.Value;
            }
            else
            {
                customerfilter.CustomerCreatedDateFrom = null;
            }

            if (DateToClnd.Checked)
            {
                customerfilter.CustomerCreatedDateTo = DateToClnd.Value;
            }
            else
            {
                customerfilter.CustomerCreatedDateTo = null;
            }

            return customerfilter;
        }
    }
}

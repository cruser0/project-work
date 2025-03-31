using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WinformDotNetFramework.Entities;
using WinformDotNetFramework.Entities.Filters;
using WinformDotNetFramework.Services;

namespace WinformDotNetFramework.Forms.control
{
    public partial class SearchCustomer : UserControl
    {
        readonly UtilityService utilityService;
        ICollection<CountryDTOGet> list = new List<CountryDTOGet>();
        public SearchCustomer()
        {
            utilityService = new UtilityService();
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            Init();

        }
        public async void Init()
        {
            CountryCmbx.DataSource = (await UtilityFunctions.GetCountries()).Select(x => x.CountryName).ToList();
        }


        public CustomerFilter GetFilter()
        {
            CustomerFilter customerfilter = new CustomerFilter
            {
                CustomerName = NameTxt.Text,
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

            if (!string.IsNullOrEmpty(CountryCmbx.Text))
            {
                if (CountryCmbx.Text.Equals("All"))
                    customerfilter.CustomerCountry = null;
                else
                    customerfilter.CustomerCountry=CountryCmbx.Text;
            }
            else
                customerfilter.CustomerCountry = null;


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

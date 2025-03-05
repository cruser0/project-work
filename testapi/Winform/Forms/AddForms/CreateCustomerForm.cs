using Winform.Entities;
using Winform.Services;

namespace Winform.Forms
{
    public partial class CreateCustomerForm : Form
    {
        CustomerService _customerService;
        UserService _userService;
        ICollection<string> prefUserPages;
        public CreateCustomerForm()
        {
            _userService= new UserService();
            _customerService = new CustomerService();
            InitializeComponent();
            prefUserPages = _userService.GetAllPreferredPagesUser();
            if (prefUserPages.Contains("Create Customer"))
            {
                FavouriteBTN.Image= global::Winform.Properties.Resources.star_yellow25x25;
            }
        }



        private void SaveBtn_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer()
            {
                CustomerName = NameTxt.Text,
                Country = CountryTxt.Text
            };

            try
            {
                _customerService.Create(customer);
                MessageBox.Show("Customer Created Succesfully");
                Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void NameTxt_TextChanged(object sender, EventArgs e)
        {
            SaveBtn.Enabled = NameTxt.Text.Length > 0 && CountryTxt.Text.Length > 0;
        }

        private void Favourite_Click(object sender, EventArgs e)
        {
            prefUserPages = _userService.GetAllPreferredPagesUser();
            if (prefUserPages.Contains("Create Customer"))
            {
                FavouriteBTN.Image = global::Winform.Properties.Resources.star_yellow25x25;
                _userService.AddUserFavouritePage(new List<string> { "Create Customer" });
            }
            else
            {
                FavouriteBTN.Image = global::Winform.Properties.Resources.star25x25;
                _userService.RemoveUserFavouritePage(new List<string> { "Create Customer" });
            }
        }
    }
}

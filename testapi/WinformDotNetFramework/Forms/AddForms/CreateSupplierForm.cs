using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WinformDotNetFramework.Entities;
using WinformDotNetFramework.Services;

namespace WinformDotNetFramework.Forms.AddForms
{
    public partial class CreateSupplierForm : Form
    {
        SupplierService _supplierService;
        UserService _userService;
        ICollection<string> prefUserPages;
        public CreateSupplierForm()
        {
            Init();

        }

        private async void Init()
        {
            _userService = new UserService();
            _supplierService = new SupplierService();
            InitializeComponent();
            prefUserPages = await _userService.GetAllPreferredPagesUser();
            CountryCmbx.DataSource = (await UtilityFunctions.GetCountries()).Select(x => x.CountryName).ToList();
        }

        private async void SaveBtn_Click(object sender, EventArgs e)
        {
            Supplier supplier = new Supplier()
            {
                SupplierName = CreateNameTxt.Text,
                Country = CountryCmbx.Text
            };
            if (supplier.Country.Equals("All"))
                MessageBox.Show("You Need to Select a country");
            else
            {
                try
                {
                    await _supplierService.Create(supplier);
                    MessageBox.Show("Supplier Created Succesfully");
                    Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void NameTxt_TextChanged(object sender, EventArgs e)
        {
            CreateSaveBtn.Enabled = CreateNameTxt.Text.Length > 0 && !CountryCmbx.Text.Equals("All") && !string.IsNullOrEmpty(CountryCmbx.Text);
        }
    }
}

using Entity_Validator.Entity.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WinformDotNetFramework.Services;

namespace WinformDotNetFramework.Forms.DetailsForms
{
    public partial class CreateDetailsCostRegistryForm : Form
    {
        CostRegistryService _costRegistryService;
        CostRegistryDTO _costRegistry;
        int costRegistryID;
        bool detailsOnly = false;
        public CreateDetailsCostRegistryForm()
        {
            Init(null);
        }
        public CreateDetailsCostRegistryForm(int id)
        {
            Init(id);
        }

        private async void Init(int? id)
        {
            InitializeComponent();
            _costRegistryService = new CostRegistryService();
            if (id != null)
            {
                int idInt = (int)id;
                _costRegistry = await _costRegistryService.GetById(idInt);
                costRegistryID = idInt;
                DescriptionTxt.Text = _costRegistry.CostRegistryName;
                UniqueCodeTxt.Text = _costRegistry.CostRegistryUniqueCode;
                DefaultQuantityIntegerTxt.SetText(_costRegistry.CostRegistryQuantity.ToString());
                DefaultCostDecimalTxt.SetText(_costRegistry.CostRegistryPrice.ToString());
                DescriptionTxt.Enabled = false;
                UniqueCodeTxt.Enabled = false;
                DefaultQuantityIntegerTxt.Enabled = false;
                DefaultCostDecimalTxt.Enabled = false;
                detailsOnly = true;
            }
            else
                detailsOnly = false;


            //List<string> authRolesWrite = new List<string>
            //{
            //    "CostRegistryWrite",
            //    "CostRegistryAdmin",
            //    "Admin"
            //};
            //List<string> authRoles = new List<string>
            //{
            //    "CostRegistryAdmin",
            //    "Admin"
            //};
            //if (!Authorize(authRolesWrite))
            //{
            //    SaveEditCostRegistryBtn.Visible = false;
            //    EditCostRegistryCbx.Visible = false;
            //}
            EditCustomerCbx.Visible = detailsOnly;
        }


        private bool Authorize(List<string> allowedRoles)
        {
            return allowedRoles.Any(role => UserAccessInfo.Role.Contains(role));
        }

        private void EditCostRegistryCbx_CheckedChanged(object sender, EventArgs e)
        {
            DescriptionTxt.Enabled = EditCustomerCbx.Checked;
            DefaultQuantityIntegerTxt.Enabled = EditCustomerCbx.Checked;
            DefaultCostDecimalTxt.Enabled = EditCustomerCbx.Checked;

            if (!EditCustomerCbx.Checked)
            {
                DescriptionTxt.Text = _costRegistry.CostRegistryName;
                DefaultQuantityIntegerTxt.Text = _costRegistry.CostRegistryQuantity.ToString();
                DefaultCostDecimalTxt.Text = _costRegistry.CostRegistryPrice.ToString();
            }

        }

        bool enabled;
        private async void SaveEditCostRegistryBtn_Click(object sender, EventArgs e)
        {
            if (detailsOnly)
            {


                CostRegistryDTOGet costRegistry = new CostRegistryDTOGet { CostRegistryName = DescriptionTxt.Text, CostRegistryQuantity = int.Parse(DefaultQuantityIntegerTxt.GetText()), CostRegistryPrice = decimal.Parse(DefaultCostDecimalTxt.GetText()) };
                try
                {
                    await _costRegistryService.Update(costRegistryID, costRegistry);
                    MessageBox.Show("CostRegistry updated successfully!");

                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            else
            {
                if (DescriptionTxt.Text.Length < 1 || string.IsNullOrEmpty(DefaultQuantityIntegerTxt.GetText()) || string.IsNullOrEmpty(DefaultCostDecimalTxt.GetText()) || UniqueCodeTxt.TextLength < 1)
                {
                    MessageBox.Show("Input data error!");
                    return;
                }
                if (decimal.Parse(DefaultCostDecimalTxt.GetText()) < 0)
                    MessageBox.Show("Input data error!");
                if (int.Parse(DefaultQuantityIntegerTxt.GetText()) < 0)
                    MessageBox.Show("Input data error!");
                CostRegistryDTO costRegistry = new CostRegistryDTO()
                {
                    CostRegistryName = DescriptionTxt.Text,
                    CostRegistryPrice = decimal.Parse(DefaultCostDecimalTxt.GetText()),
                    CostRegistryQuantity = int.Parse(DefaultQuantityIntegerTxt.GetText()),
                    CostRegistryUniqueCode = UniqueCodeTxt.Text,
                };

                try
                {
                    await _costRegistryService.Create(costRegistry);
                    MessageBox.Show("CostRegistry Created Succesfully");
                    detailsOnly = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }

            }
        }

        //private async void SaveQuitButton_Click(object sender, EventArgs e)
        //{
        //    if (detailsOnly)
        //    {

        //        switch (comboBox1.Text)
        //        {
        //            case "Active":
        //                enabled = false;
        //                break;

        //            case "Deprecated":
        //                enabled = true;
        //                break;
        //        };

        //        CostRegistry costRegistry = new CostRegistry { CostRegistryName = NameCostRegistryTxt.Text, Country = CountryCmbx.Text, Deprecated = enabled };
        //        try
        //        {
        //            await _costRegistryService.Update(costRegistryID, costRegistry);
        //            MessageBox.Show("CostRegistry updated successfully!");
        //            Close();

        //        }
        //        catch (Exception ex) { MessageBox.Show(ex.Message); }
        //    }
        //    else
        //    {
        //        if (NameCostRegistryTxt.Text.Length < 1 || CountryCmbx.Text.Equals("All") || string.IsNullOrEmpty(CountryCmbx.Text))
        //        {
        //            MessageBox.Show("Input data error!");
        //            return;
        //        }

        //        CostRegistry costRegistry = new CostRegistry()
        //        {
        //            CostRegistryName = NameCostRegistryTxt.Text,
        //            Country = CountryCmbx.Text
        //        };
        //        if (costRegistry.Country.Equals("All"))
        //            MessageBox.Show("You Need to Select a country");
        //        else
        //        {
        //            try
        //            {
        //                await _costRegistryService.Create(costRegistry);
        //                MessageBox.Show("CostRegistry Created Succesfully");
        //                Close();

        //            }
        //            catch (Exception ex)
        //            {
        //                MessageBox.Show(ex.Message);

        //            }
        //        }
        //    }
        //}
    }
}

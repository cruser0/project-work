using Entity_Validator;
using Entity_Validator.Entity.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WinformDotNetFramework.Forms.control;
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
            DescriptionCtb.SetPropName("CostRegistryName");
            CodeCtb.SetPropName("CostRegistryUniqueCode");
            QuantityCtb.SetPropName("CostRegistryQuantity");
            CostCtb.SetPropName("CostRegistryPrice");
            CostCtb.TextBoxType = TextBoxType.Decimal;
            QuantityCtb.TextBoxType = TextBoxType.Integer;

            if (id != null)
            {
                int idInt = (int)id;
                _costRegistry = await _costRegistryService.GetById(idInt);
                costRegistryID = idInt;

                DescriptionCtb.PropTxt.Text = _costRegistry.CostRegistryName;
                CodeCtb.PropTxt.Text = _costRegistry.CostRegistryUniqueCode;
                QuantityCtb.PropTxt.Text = _costRegistry.CostRegistryQuantity.ToString();
                CostCtb.PropTxt.Text = _costRegistry.CostRegistryPrice.ToString();

                DescriptionCtb.PropTxt.Enabled = false;
                CodeCtb.PropTxt.Enabled = false;
                QuantityCtb.PropTxt.Enabled = false;
                CostCtb.PropTxt.Enabled = false;

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
            DescriptionCtb.PropTxt.Enabled = EditCustomerCbx.Checked;
            QuantityCtb.PropTxt.Enabled = EditCustomerCbx.Checked;
            CostCtb.PropTxt.Enabled = EditCustomerCbx.Checked;

            if (!EditCustomerCbx.Checked)
            {
                DescriptionCtb.PropTxt.Text = _costRegistry.CostRegistryName;
                QuantityCtb.PropTxt.Text = _costRegistry.CostRegistryQuantity.ToString();
                CostCtb.PropTxt.Text = _costRegistry.CostRegistryPrice.ToString();
            }

        }

        bool enabled;
        private async void SaveEditCostRegistryBtn_Click(object sender, EventArgs e)
        {
            if (detailsOnly)
            {


                CostRegistryDTOGet costRegistry = new CostRegistryDTOGet
                {
                    CostRegistryName = DescriptionCtb.PropTxt.Text,
                    CostRegistryQuantity = int.Parse(QuantityCtb.PropTxt.Text),
                    CostRegistryPrice = decimal.Parse(CostCtb.PropTxt.Text)
                };
                try
                {
                    costRegistry.IsPost = false;
                    var result = ValidatorEntity.Validate(costRegistry);
                    UtilityFunctions.ValidateTextBoxes(panel1, costRegistry);
                    if (result.Any())
                    {
                        return;
                    }

                    await _costRegistryService.Update(costRegistryID, costRegistry);
                    MessageBox.Show("CostRegistry updated successfully!");

                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            else
            {

                CostRegistryDTO costRegistry = new CostRegistryDTO()
                {
                    CostRegistryName = DescriptionCtb.PropTxt.Text,
                    CostRegistryPrice = decimal.TryParse(CostCtb.PropTxt.Text, out decimal price) ? price : (decimal?)null,
                    CostRegistryQuantity = int.TryParse(QuantityCtb.PropTxt.Text, out int quantity) ? quantity : (int?)null,
                    CostRegistryUniqueCode = CodeCtb.PropTxt.Text,
                };

                try
                {
                    costRegistry.IsPost = true;
                    var result = ValidatorEntity.Validate(costRegistry);
                    UtilityFunctions.ValidateTextBoxes(panel1, costRegistry);
                    if (result.Any())
                    {
                        return;
                    }

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

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WinformDotNetFramework.Entities.DTO;
using WinformDotNetFramework.Services;

namespace WinformDotNetFramework.Forms
{
    public partial class UserProfileForm : Form
    {
        UserService userService;
        public UserProfileForm()
        {
            userService = new UserService();
            InitializeComponent();
        }

        private async void UserProfileForm_Load(object sender, EventArgs e)
        {
            foreach (string role in UserAccessInfo.Role)
            {
                Label lbl = new Label();
                lbl.Text = role;
                FlowPanelRoles.Controls.Add(lbl);
            }

            var prefPages=await userService.GetAllPreferredPagesUser();
            foreach (var prefPage in prefPages)
            {
                AssignImageToPrefPages(prefPage);
                
            }


            UserRoleDTO user = await userService.GetById(UserAccessInfo.RefreshUserID);
            UserIDTxt.Text = user.UserID.ToString();
            UserNameTxt.Text = user.Name;
            UserLastNameTxt.Text = user.LastName;
            UserEmailTxt.Text = user.Email;
        }

        private void AssignImageToPrefPages(string prefPage)
        {
            switch (prefPage)
            {
                case "Show Customer":
                    CustomerShowTSB.Image = CustomerShowTSB.Image == Properties.Resources.star_yellow_removebg ? Properties.Resources.star : Properties.Resources.star_yellow_removebg;
                    CustomerShowTSB.Tag = "on";
                    break;
                case "Show Customer Invoice":
                    CustomerInvoiceShowTSB.Image = CustomerInvoiceShowTSB.Image == Properties.Resources.star_yellow_removebg ? Properties.Resources.star : Properties.Resources.star_yellow_removebg;
                    CustomerInvoiceShowTSB.Tag = "on";
                    break;
                case "Show Customer Invoice Cost":
                    CustomerInvoiceCostShowTSB.Image = CustomerInvoiceCostShowTSB.Image == Properties.Resources.star_yellow_removebg ? Properties.Resources.star : Properties.Resources.star_yellow_removebg;
                    CustomerInvoiceCostShowTSB.Tag = "on";
                    break;
                case "Show Supplier":
                    SupplierShowTSB.Image = SupplierShowTSB.Image == Properties.Resources.star_yellow_removebg ? Properties.Resources.star : Properties.Resources.star_yellow_removebg;
                    SupplierShowTSB.Tag = "on";
                    break;
                case "Show Supplier Invoice":
                    SupplierInvoiceShowTSB.Image = SupplierInvoiceShowTSB.Image == Properties.Resources.star_yellow_removebg ? Properties.Resources.star : Properties.Resources.star_yellow_removebg;
                    SupplierInvoiceShowTSB.Tag = "on";
                    break;
                case "Show Supplier Invoice Cost":
                    SupplierInvoiceCostShowTSB.Image = SupplierInvoiceCostShowTSB.Image == Properties.Resources.star_yellow_removebg ? Properties.Resources.star : Properties.Resources.star_yellow_removebg;
                    SupplierInvoiceCostShowTSB.Tag = "on";
                    break;
                case "Show Sale":
                    SaleShowTSB.Image = SaleShowTSB.Image == Properties.Resources.star_yellow_removebg ? Properties.Resources.star : Properties.Resources.star_yellow_removebg;
                    SaleShowTSB.Tag = "on";
                    break;
                case "Show User":
                    UserShowTSB.Image = UserShowTSB.Image == Properties.Resources.star_yellow_removebg ? Properties.Resources.star : Properties.Resources.star_yellow_removebg;
                    UserShowTSB.Tag = "on";
                    break;
                case "Create Customer":
                    CreateCustomerTSB.Image = CreateCustomerTSB.Image == Properties.Resources.star_yellow_removebg ? Properties.Resources.star : Properties.Resources.star_yellow_removebg;
                    CreateCustomerTSB.Tag = "on";
                    break;
                case "Create Customer Invoice":
                    CreateCustomerInvoiceTSB.Image = CreateCustomerInvoiceTSB.Image == Properties.Resources.star_yellow_removebg ? Properties.Resources.star : Properties.Resources.star_yellow_removebg;
                    CreateCustomerInvoiceTSB.Tag = "on";
                    break;
                case "Create Customer Invoice Cost":
                    CreateCustomerInvoiceCostTSB.Image = CreateCustomerInvoiceCostTSB.Image == Properties.Resources.star_yellow_removebg ? Properties.Resources.star : Properties.Resources.star_yellow_removebg;
                    CreateCustomerInvoiceCostTSB.Tag = "on";
                    break;
                case "Create Supplier":
                    CreateSupplierTSB.Image = CreateSupplierTSB.Image == Properties.Resources.star_yellow_removebg ? Properties.Resources.star : Properties.Resources.star_yellow_removebg;
                    CreateSupplierTSB.Tag = "on";
                    break;
                case "Create Supplier Invoice":
                    CreateSupplierInvoiceTSB.Image = CreateSupplierInvoiceTSB.Image == Properties.Resources.star_yellow_removebg ? Properties.Resources.star : Properties.Resources.star_yellow_removebg;
                    CreateSupplierInvoiceTSB.Tag = "on";
                    break;
                case "Create Supplier Invoice Cost":
                    CreateSupplierInvoiceCostTSB.Image = CreateSupplierInvoiceCostTSB.Image == Properties.Resources.star_yellow_removebg ? Properties.Resources.star : Properties.Resources.star_yellow_removebg;
                    CreateSupplierInvoiceCostTSB.Tag = "on";
                    break;
                case "Create Sale":
                    CreateSaleTSB.Image = CreateSaleTSB.Image == Properties.Resources.star_yellow_removebg ? Properties.Resources.star : Properties.Resources.star_yellow_removebg;
                    CreateSaleTSB.Tag = "on";
                    break;
                case "Create User":
                    CreateUserTSB.Image = CreateUserTSB.Image == Properties.Resources.star_yellow_removebg ? Properties.Resources.star : Properties.Resources.star_yellow_removebg;
                    CreateUserTSB.Tag = "on";
                    break;
                case "Group Customer":
                    CustomerGroupTSb.Image = CustomerGroupTSb.Image == Properties.Resources.star_yellow_removebg ? Properties.Resources.star : Properties.Resources.star_yellow_removebg;
                    CustomerGroupTSb.Tag = "on";
                    break;
                case "Group Supplier":
                    SupplierGroupTSB.Image = SupplierGroupTSB.Image == Properties.Resources.star_yellow_removebg ? Properties.Resources.star : Properties.Resources.star_yellow_removebg;
                    SupplierGroupTSB.Tag = "on";
                    break;
                case "Report Customer Invoice":
                    CustomerInvoiceReportTSB.Image = CustomerInvoiceReportTSB.Image == Properties.Resources.star_yellow_removebg ? Properties.Resources.star : Properties.Resources.star_yellow_removebg;
                    CustomerInvoiceReportTSB.Tag = "on";
                    break;
                case "Report Supplier Invoice":
                    SupplierInvoiceReportTSB.Image = SupplierInvoiceReportTSB.Image == Properties.Resources.star_yellow_removebg ? Properties.Resources.star : Properties.Resources.star_yellow_removebg;
                    SupplierInvoiceReportTSB.Tag = "on";
                    break;
                case "Report Sale":
                    SaleReportTSB.Image = SaleReportTSB.Image == Properties.Resources.star_yellow_removebg ? Properties.Resources.star : Properties.Resources.star_yellow_removebg;
                    SaleReportTSB.Tag = "on";
                    break;
                default:
                    break;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            UserNameTxt.Enabled = checkBox1.Checked;
            UserLastNameTxt.Enabled = checkBox1.Checked;
            PasswordTxt.Enabled = checkBox1.Checked;
            PasswordSeeBtn.Visible = checkBox1.Checked;
            ConfirmPasswordTxt.Visible = checkBox1.Checked;
            PasswordConfirmLbl.Visible = checkBox1.Checked;
            button1.Enabled = checkBox1.Checked;
        }

        private async void SaveEditCustomerBtn_Click(object sender, EventArgs e)
        {
            if (PasswordTxt.Text.Equals(ConfirmPasswordTxt.Text))
            {


                UserDTOEdit si = new UserDTOEdit
                {
                    LastName = UserLastNameTxt.Text,
                    Name = UserNameTxt.Text,
                    Password = !string.IsNullOrEmpty(PasswordTxt.Text) ? PasswordTxt.Text : null,
                };
                try
                {
                    await userService.Update(int.Parse(UserIDTxt.Text), si);
                    MessageBox.Show("User updated successfully!");

                    this.Close();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            else
                MessageBox.Show("The passwords don't match");
        }
        private void PasswordSeeBtn_Click(object sender, EventArgs e)
        {
            if (PasswordTxt.PasswordChar.Equals('•'))
            {
                PasswordTxt.PasswordChar = default(char);
                ConfirmPasswordTxt.PasswordChar = default(char);

            }
            else
            {
                PasswordTxt.PasswordChar = '•';
                ConfirmPasswordTxt.PasswordChar = '•';
            }
        }

        private async void ChangePreferenceBtn_Click(object sender, EventArgs e)
        {
            if(sender is ToolStripMenuItem tsb)
            {
                if ((string)tsb.Tag == "on")
                {
                    tsb.Image = Properties.Resources.star;
                    await userService.RemoveUserFavouritePage(new List<string> { tsb.Text});
                    tsb.Tag="off";
                    if(this.Parent.Parent is MainForm mf)
                    {
                        await mf.UpdateFavoriteTab();
                    }
                }
                else
                {
                    tsb.Image=Properties.Resources.star_yellow_removebg;
                    await userService.AddUserFavouritePage(new List<string> { tsb.Text });
                    tsb.Tag = "on";
                    if (this.Parent.Parent is MainForm mf)
                    {
                       await mf.UpdateFavoriteTab();
                    }
                }


            }
        }
    }
}

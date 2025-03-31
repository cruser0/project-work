using Entity_Validator.Entity.DTO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WinformDotNetFramework.Services;

namespace WinformDotNetFramework.Forms
{
    public partial class UserProfileForm : Form
    {
        public bool ciao { get; set; }
        UserService userService;
        List<string> userPrefPages = new List<string>();
        private static readonly HashSet<string> AdminRoles = new HashSet<string>() { "Admin" };
        private static readonly HashSet<string> WriteRoles = new HashSet<string>() { "Admin", "CustomerWrite", "CustomerInvoiceWrite", "CustomerInvoiceCostWrite", "SaleWrite", "SupplierWrite", "SupplierInvoiceWrite", "SupplierInvoiceCostWrite", "UserWrite" };
        private static readonly HashSet<string> ReadRoles = new HashSet<string>() { "Admin", "CustomerRead", "CustomerInvoiceRead", "CustomerInvoiceCostRead", "SaleRead", "SupplierRead", "SupplierInvoiceRead", "SupplierInvoiceCostRead", "UserRead" };
        private static readonly HashSet<string> AdminGroupRoles = new HashSet<string>() { "Admin", "CustomerAdmin", "CustomerInvoiceAdmin", "CustomerInvoiceCostAdmin", "SaleAdmin", "SupplierAdmin", "SupplierInvoiceAdmin", "SupplierInvoiceCostAdmin", "UserAdmin" };
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

            var prefPages = await userService.GetAllPreferredPagesUser();
            foreach (var prefPage in prefPages)
            {
                userPrefPages.Add(prefPage);
                AssignImageToPrefPages(prefPage);

            }
            SetTSVisibilityByAuthorizations();


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
                    CustomerShowTS.Image = Properties.Resources.star_yellow_removebg;
                    CustomerShowTS.Tag = "1";
                    break;
                case "Show Customer Invoice":
                    CustomerInvoiceShowTS.Image = Properties.Resources.star_yellow_removebg;
                    CustomerInvoiceShowTS.Tag = "1";
                    break;
                case "Show Customer Invoice Cost":
                    CustomerInvoiceCostShowTS.Image = Properties.Resources.star_yellow_removebg;
                    CustomerInvoiceCostShowTS.Tag = "1";
                    break;
                case "Show Supplier":
                    SupplierShowTS.Image = Properties.Resources.star_yellow_removebg;
                    SupplierShowTS.Tag = "1";
                    break;
                case "Show Supplier Invoice":
                    SupplierInvoiceShowTS.Image = Properties.Resources.star_yellow_removebg;
                    SupplierInvoiceShowTS.Tag = "1";
                    break;
                case "Show Supplier Invoice Cost":
                    SupplierInvoiceCostShowTS.Image = Properties.Resources.star_yellow_removebg;
                    SupplierInvoiceCostShowTS.Tag = "1";
                    break;
                case "Show Sale":
                    SaleShowTS.Image = Properties.Resources.star_yellow_removebg;
                    SaleShowTS.Tag = "1";
                    break;
                case "Show User":
                    UserShowTS.Image = Properties.Resources.star_yellow_removebg;
                    UserShowTS.Tag = "1";
                    break;
                case "Create Customer":
                    CreateCustomerTS.Image = Properties.Resources.star_yellow_removebg;
                    CreateCustomerTS.Tag = "1";
                    break;
                case "Create Customer Invoice":
                    CreateCustomerInvoiceTS.Image = Properties.Resources.star_yellow_removebg;
                    CreateCustomerInvoiceTS.Tag = "1";
                    break;
                case "Create Customer Invoice Cost":
                    CreateCustomerInvoiceCostTS.Image = Properties.Resources.star_yellow_removebg;
                    CreateCustomerInvoiceCostTS.Tag = "1";
                    break;
                case "Create Supplier":
                    CreateSupplierTS.Image = Properties.Resources.star_yellow_removebg;
                    CreateSupplierTS.Tag = "1";
                    break;
                case "Create Supplier Invoice":
                    CreateSupplierInvoiceTS.Image = Properties.Resources.star_yellow_removebg;
                    CreateSupplierInvoiceTS.Tag = "1";
                    break;
                case "Create Supplier Invoice Cost":
                    CreateSupplierInvoiceCostTS.Image = Properties.Resources.star_yellow_removebg;
                    CreateSupplierInvoiceCostTS.Tag = "1";
                    break;
                case "Create Sale":
                    CreateSaleTS.Image = Properties.Resources.star_yellow_removebg;
                    CreateSaleTS.Tag = "1";
                    break;
                case "Create User":
                    CreateUserTS.Image = Properties.Resources.star_yellow_removebg;
                    CreateUserTS.Tag = "1";
                    break;
                case "Group Customer":
                    CustomerGroupTS.Image = Properties.Resources.star_yellow_removebg;
                    CustomerGroupTS.Tag = "1";
                    break;
                case "Group Supplier":
                    SupplierGroupTS.Image = Properties.Resources.star_yellow_removebg;
                    SupplierGroupTS.Tag = "1";
                    break;
                case "Report Customer Invoice":
                    CustomerInvoiceReportTS.Image = Properties.Resources.star_yellow_removebg;
                    CustomerInvoiceReportTS.Tag = "1";
                    break;
                case "Report Supplier Invoice":
                    SupplierInvoiceReportTS.Image = Properties.Resources.star_yellow_removebg;
                    SupplierInvoiceReportTS.Tag = "1";
                    break;
                case "Report Sale":
                    SaleReportTS.Image = Properties.Resources.star_yellow_removebg;
                    SaleReportTS.Tag = "1";
                    break;
                default:
                    break;
            }
        }
        public void SetTSVisibilityByAuthorizations()
        {
            CustomerShowTS.Visible = UtilityFunctions.IsAuthorized(new HashSet<string>() { "Admin", "CustomerRead", "CustomerWrite", "CustomerAdmin" });
            CreateCustomerTS.Visible = UtilityFunctions.IsAuthorized(new HashSet<string>() { "Admin", "CustomerWrite", "CustomerAdmin" });

            CustomerInvoiceShowTS.Visible = UtilityFunctions.IsAuthorized(new HashSet<string>() { "Admin", "CustomerInvoiceRead", "CustomerInvoiceWrite", "CustomerInvoiceAdmin" });
            CreateCustomerInvoiceTS.Visible = UtilityFunctions.IsAuthorized(new HashSet<string>() { "Admin", "CustomerInvoiceWrite", "CustomerInvoiceAdmin" });

            CustomerInvoiceCostShowTS.Visible = UtilityFunctions.IsAuthorized(new HashSet<string>() { "Admin", "CustomerInvoiceCostRead", "CustomerInvoiceCostWrite", "CustomerInvoiceCostAdmin" });
            CreateCustomerInvoiceCostTS.Visible = UtilityFunctions.IsAuthorized(new HashSet<string>() { "Admin", "CustomerInvoiceCostWrite", "CustomerInvoiceCostAdmin" });

            SupplierShowTS.Visible = UtilityFunctions.IsAuthorized(new HashSet<string>() { "Admin", "SupplierRead", "SupplierWrite", "SupplierAdmin" });
            CreateSupplierTS.Visible = UtilityFunctions.IsAuthorized(new HashSet<string>() { "Admin", "SupplierWrite", "SupplierAdmin" });

            SupplierInvoiceShowTS.Visible = UtilityFunctions.IsAuthorized(new HashSet<string>() { "Admin", "SupplierInvoiceRead", "SupplierInvoiceWrite", "SupplierInvoiceAdmin" });
            CreateSupplierInvoiceTS.Visible = UtilityFunctions.IsAuthorized(new HashSet<string>() { "Admin", "SupplierInvoiceWrite", "SupplierInvoiceAdmin" });

            SupplierInvoiceCostShowTS.Visible = UtilityFunctions.IsAuthorized(new HashSet<string>() { "Admin", "SupplierInvoiceCostRead", "SupplierInvoiceCostWrite", "SupplierInvoiceCostAdmin" });
            CreateSupplierInvoiceCostTS.Visible = UtilityFunctions.IsAuthorized(new HashSet<string>() { "Admin", "SupplierInvoiceCostWrite", "SupplierInvoiceCostAdmin" });

            SaleShowTS.Visible = UtilityFunctions.IsAuthorized(new HashSet<string>() { "Admin", "SaleRead", "SaleWrite", "SaleAdmin" });
            CreateSaleTS.Visible = UtilityFunctions.IsAuthorized(new HashSet<string>() { "Admin", "SaleWrite", "SaleAdmin" });

            UserShowTS.Visible = UtilityFunctions.IsAuthorized(new HashSet<string>() { "Admin" });
            CreateUserTS.Visible = UtilityFunctions.IsAuthorized(new HashSet<string>() { "Admin" });

            CustomerGroupTS.Visible = UtilityFunctions.IsAuthorized(ReadRoles, requireAll: true) ||
                                      UtilityFunctions.IsAuthorized(WriteRoles, requireAll: true) ||
                                      UtilityFunctions.IsAuthorized(AdminGroupRoles, requireAll: true) ||
                                      UtilityFunctions.IsAuthorized(AdminRoles);

            SupplierGroupTS.Visible = UtilityFunctions.IsAuthorized(AdminRoles) ||
                                      UtilityFunctions.IsAuthorized(new HashSet<string>() { "SupplierRead", "SupplierInvoiceRead", "SupplierInvoiceCostRead" }, requireAll: true) ||
                                      UtilityFunctions.IsAuthorized(new HashSet<string>() { "SupplierWrite", "SupplierInvoiceWrite", "SupplierInvoiceCostWrite" }, requireAll: true) ||
                                      UtilityFunctions.IsAuthorized(new HashSet<string>() { "SupplierAdmin", "SupplierInvoiceAdmin", "SupplierInvoiceCostAdmin" }, requireAll: true);

            SupplierInvoiceReportTS.Visible = UtilityFunctions.IsAuthorized(AdminRoles) ||
                                      UtilityFunctions.IsAuthorized(new HashSet<string>() { "SupplierRead", "SupplierInvoiceRead", "SupplierInvoiceCostRead", "SaleRead" }, requireAll: true) ||
                                      UtilityFunctions.IsAuthorized(new HashSet<string>() { "SupplierAdmin", "SupplierInvoiceAdmin", "SupplierInvoiceCostAdmin", "SaleAdmin" }, requireAll: true);
            CustomerInvoiceReportTS.Visible = SaleReportTS.Visible = UtilityFunctions.IsAuthorized(AdminRoles) ||
                                      UtilityFunctions.IsAuthorized(new HashSet<string>() { "CustomerRead", "CustomerInvoiceRead", "CustomerInvoiceCostRead", "SaleRead" }, requireAll: true) ||
                                      UtilityFunctions.IsAuthorized(new HashSet<string>() { "CustomerAdmin", "CustomerInvoiceAdmin", "CustomerInvoiceCostAdmin", "SaleAdmin" }, requireAll: true);

            ShowTSb.Visible = UtilityFunctions.IsAuthorized(ReadRoles) || UtilityFunctions.IsAuthorized(AdminGroupRoles);
            CreateTsb.Visible = UtilityFunctions.IsAuthorized(WriteRoles) || UtilityFunctions.IsAuthorized(AdminGroupRoles);
            ReportTsb.Visible = UtilityFunctions.IsAuthorized(AdminRoles) ||
                                      UtilityFunctions.IsAuthorized(new HashSet<string>() { "SupplierRead", "SupplierInvoiceRead", "SupplierInvoiceCostRead", "SaleRead" }, requireAll: true) ||
                                      UtilityFunctions.IsAuthorized(new HashSet<string>() { "SupplierAdmin", "SupplierInvoiceAdmin", "SupplierInvoiceCostAdmin", "SaleAdmin" }, requireAll: true) ||
                                      UtilityFunctions.IsAuthorized(new HashSet<string>() { "CustomerRead", "CustomerInvoiceRead", "CustomerInvoiceCostRead", "SaleRead" }, requireAll: true) ||
                                      UtilityFunctions.IsAuthorized(new HashSet<string>() { "CustomerAdmin", "CustomerInvoiceAdmin", "CustomerInvoiceCostAdmin", "SaleAdmin" }, requireAll: true);
            GroupTsb.Visible = UtilityFunctions.IsAuthorized(ReadRoles, requireAll: true) ||
                                      UtilityFunctions.IsAuthorized(WriteRoles, requireAll: true) ||
                                      UtilityFunctions.IsAuthorized(AdminGroupRoles, requireAll: true) ||
                                      UtilityFunctions.IsAuthorized(AdminRoles) ||
                                      UtilityFunctions.IsAuthorized(new HashSet<string>() { "SupplierRead", "SupplierInvoiceRead", "SupplierInvoiceCostRead" }, requireAll: true) ||
                                      UtilityFunctions.IsAuthorized(new HashSet<string>() { "SupplierWrite", "SupplierInvoiceWrite", "SupplierInvoiceCostWrite" }, requireAll: true) ||
                                      UtilityFunctions.IsAuthorized(new HashSet<string>() { "SupplierAdmin", "SupplierInvoiceAdmin", "SupplierInvoiceCostAdmin" }, requireAll: true);
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
            if (sender is ToolStripMenuItem tsb)
            {
                if ((string)tsb.Tag == "1")
                {
                    tsb.Image = Properties.Resources.star;
                    await userService.RemoveUserFavouritePage(new List<string> { tsb.Text });
                    tsb.Tag = "0";
                    userPrefPages.Remove(tsb.Text);
                    if (this.Parent.Parent is MainForm mf)
                    {
                        await mf.UpdateFavoriteTab();
                    }
                }
                else
                {
                    tsb.Image = Properties.Resources.star_yellow_removebg;
                    await userService.AddUserFavouritePage(new List<string> { tsb.Text });
                    tsb.Tag = "1";
                    userPrefPages.Add(tsb.Text);
                    if (this.Parent.Parent is MainForm mf)
                    {
                        await mf.UpdateFavoriteTab();
                    }
                }


            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (userPrefPages.Count == 0)
            {
                MessageBox.Show("You have no favourite pages");
            }
            else
            {
                await userService.RemoveUserFavouritePage(userPrefPages);
                userPrefPages.Clear();
                if (this.Parent.Parent is MainForm mf)
                {
                    await mf.UpdateFavoriteTab();
                }
                MessageBox.Show("Favourite pages were successfully removed");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using WinformDotNetFramework.Entities;
using WinformDotNetFramework.Entities.DTO;
using WinformDotNetFramework.Services;

namespace WinformDotNetFramework.Forms.DetailsForms
{
    public partial class CreateDetailsCustomerForm : Form
    {
        CustomerService _customerService;
        CustomerInvoiceService _customerInvoiceService;
        CustomerInvoiceSummary summary;
        Customer customer;
        int customerId;
        bool detailsOnly = false;
        public CreateDetailsCustomerForm()
        {
            Init();
            chart1.Visible = false;
            EditCustomerCbx.Visible = false;
            comboBox1.Visible = false;
            label1.Visible = false;
        }

        public CreateDetailsCustomerForm(int id)
        {
            Init();
            InitDetails(id);
        }
        private async void InitDetails(int intid)
        {
            summary = await _customerInvoiceService.GetSummary(intid);
            customer = await _customerService.GetById(intid);
            customerId = intid;

            NameCustomerTxt.Text = customer.CustomerName;
            CountryCmbx.Text = customer.Country;
            comboBox1.Text = (bool)customer.Deprecated ? "Deprecated" : "Active";
            NameCustomerTxt.Enabled = false;
            CountryCmbx.Enabled = false;
            comboBox1.Enabled = false;
            SaveEditCustomerBtn.Enabled = false;
            detailsOnly = true;

            CreateDonutChart();
        }
        private async void Init()
        {
            InitializeComponent();
            _customerService = new CustomerService();
            _customerInvoiceService = new CustomerInvoiceService();
            CountryCmbx.DataSource = (await UtilityFunctions.GetCountries()).Select(x => x.CountryName).Skip(1).ToList();

            List<string> authRolesWrite = new List<string>
            {
                "CustomerWrite",
                "CustomerAdmin",
                "Admin"
            };
            List<string> authRoles = new List<string>
            {
                "CustomerAdmin",
                "Admin"
            };
            if (!Authorize(authRolesWrite))
            {
                EditCustomerCbx.Visible = false;
                SaveEditCustomerBtn.Visible = false;
            }
        }


        private void CreateDonutChart()
        {
            int open = summary.OpenInvoices;
            int paid = summary.ClosedInvoices;

            // Make chart background transparent
            chart1.BackColor = System.Drawing.Color.Transparent;
            chart1.ChartAreas[0].BackColor = System.Drawing.Color.Transparent;

            chart1.Series.Clear();
            Series series = new Series("Payment Status")
            {
                ChartType = SeriesChartType.Doughnut,
                CustomProperties = "DoughnutRadius=50"
            };

            series.Points.AddXY($"Unpaid ({open})", open);
            series.Points.AddXY($"Paid ({paid})", paid);

            chart1.Series.Add(series);

            series.Points[0].Color = System.Drawing.Color.FromArgb(255, 200, 80, 80);
            series.Points[1].Color = System.Drawing.Color.FromArgb(255, 80, 160, 80);
            series.Color = System.Drawing.Color.Transparent;

            // Make legend transparent

            chart1.Titles.Add(new Title("Invoicing Status", Docking.Top));
            chart1.Legends.Add(new Legend("Status")
            {
                Docking = Docking.Bottom
            });
            chart1.Legends[0].BackColor = System.Drawing.Color.Transparent;
        }

        private bool Authorize(List<string> allowedRoles)
        {
            return allowedRoles.Any(role => UserAccessInfo.Role.Contains(role));
        }
        private void EditCustomerCbx_CheckedChanged(object sender, EventArgs e)
        {

            NameCustomerTxt.Enabled = EditCustomerCbx.Checked;
            CountryCmbx.Enabled = EditCustomerCbx.Checked;
            comboBox1.Enabled = EditCustomerCbx.Checked;
            SaveEditCustomerBtn.Enabled = EditCustomerCbx.Checked;

            if (!EditCustomerCbx.Checked)
            {
                NameCustomerTxt.Text = customer.CustomerName;
                CountryCmbx.Text = customer.Country;
                comboBox1.Text = (bool)customer.Deprecated ? "Deprecated" : "Active";
            }

        }

        private async Task UpdateClick(bool quit = false)
        {
            bool enabled;

            switch (comboBox1.Text)
            {
                case "Active":
                    enabled = false;
                    break;

                case "Deprecated":
                    enabled = true;
                    break;

                default:
                    enabled = false;
                    break;
            };

            Customer customer = new Customer { CustomerName = NameCustomerTxt.Text, Country = CountryCmbx.Text, Deprecated = enabled };
            try
            {
                await _customerService.Update(customerId, customer);
                MessageBox.Show("Customer updated successfully!");
                if (quit) Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private async Task CreateClick(bool quit = false)
        {
            if (NameCustomerTxt.Text.Length < 1 || string.IsNullOrEmpty(CountryCmbx.Text))
            {
                MessageBox.Show("Input data error!");
                return;
            }

            Customer customer = new Customer()
            {
                CustomerName = NameCustomerTxt.Text,
                Country = CountryCmbx.Text
            };

            try
            {
                await _customerService.Create(customer);
                MessageBox.Show("Customer Created Succesfully");
                if (quit) Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private async void SaveEditCustomerBtn_Click(object sender, EventArgs e)
        {
            if (detailsOnly)
            {
                await UpdateClick();
            }
            else
            {
                await CreateClick();
            }
        }

        private async void SaveQuitButton_Click(object sender, EventArgs e)
        {
            if (detailsOnly)
            {
                await UpdateClick(true);
            }
            else
            {
                await CreateClick(true);
            }
        }
    }
}

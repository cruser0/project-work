﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using WinformDotNetFramework.Entities;
using WinformDotNetFramework.Entities.DTO;
using WinformDotNetFramework.Services;

namespace WinformDotNetFramework.Forms.DetailsForms
{
    public partial class CreateDetailsSupplierForm : Form
    {
        SupplierService _supplierService;
        SupplierInvoiceService _supplierInvoiceService;
        SupplierInvoiceSummary summary;
        Supplier supplier;
        int supplierID;
        bool detailsOnly = false;
        public CreateDetailsSupplierForm()
        {
            Init(null);
        }
        public CreateDetailsSupplierForm(int id)
        {
            Init(id);
        }

        private async void Init(int? id)
        {
            InitializeComponent();
            _supplierService = new SupplierService();
            _supplierInvoiceService = new SupplierInvoiceService();
            _supplierService = new SupplierService();
            CountryCmbx.DataSource = (await UtilityFunctions.GetCountries()).Select(x => x.CountryName).Skip(1).ToList();
            if (id != null)
            {
                int idInt = (int)id;
                summary = await _supplierInvoiceService.GetSummary(idInt);
                supplier = await _supplierService.GetById(idInt);
                supplierID = idInt;
                NameSupplierTxt.Text = supplier.SupplierName;
                CountryCmbx.Text = supplier.Country;
                comboBox1.Text = (bool)supplier.Deprecated ? "Deprecated" : "Active";
                NameSupplierTxt.Enabled = false;
                CountryCmbx.Enabled = false;
                comboBox1.Enabled = false;
                detailsOnly = true;
                CreateDonutChart();
            }
            else
                detailsOnly = false;


            List<string> authRolesWrite = new List<string>
            {
                "SupplierWrite",
                "SupplierAdmin",
                "Admin"
            };
            List<string> authRoles = new List<string>
            {
                "SupplierAdmin",
                "Admin"
            };
            if (!Authorize(authRolesWrite))
            {
                SaveEditSupplierBtn.Visible = false;
                EditSupplierCbx.Visible = false;
            }
            chart1.Visible = detailsOnly;
            EditSupplierCbx.Visible = detailsOnly;
            comboBox1.Visible = detailsOnly;
            label1.Visible = detailsOnly;
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

            series.Points.AddXY($"Approved ({paid})", paid);
            series.Points.AddXY($"Unapproved ({open})", open);

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

        private void EditSupplierCbx_CheckedChanged(object sender, EventArgs e)
        {
            NameSupplierTxt.Enabled = EditSupplierCbx.Checked;
            CountryCmbx.Enabled = EditSupplierCbx.Checked;
            comboBox1.Enabled = EditSupplierCbx.Checked;

            if (!EditSupplierCbx.Checked)
            {
                NameSupplierTxt.Text = supplier.SupplierName;
                CountryCmbx.Text = supplier.Country;
                comboBox1.Text = (bool)supplier.Deprecated ? "Deprecated" : "Active";
            }

        }

        bool enabled;
        private async void SaveEditSupplierBtn_Click(object sender, EventArgs e)
        {
            if (detailsOnly)
            {

                switch (comboBox1.Text)
                {
                    case "Active":
                        enabled = false;
                        break;

                    case "Deprecated":
                        enabled = true;
                        break;
                };

                Supplier supplier = new Supplier { SupplierName = NameSupplierTxt.Text, Country = CountryCmbx.Text, Deprecated = enabled };
                try
                {
                    await _supplierService.Update(supplierID, supplier);
                    MessageBox.Show("Supplier updated successfully!");

                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            else
            {
                if (NameSupplierTxt.Text.Length < 1 || CountryCmbx.Text.Equals("All") || string.IsNullOrEmpty(CountryCmbx.Text))
                {
                    MessageBox.Show("Input data error!");
                    return;
                }

                Supplier supplier = new Supplier()
                {
                    SupplierName = NameSupplierTxt.Text,
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

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }
                }
            }
        }

        private async void SaveQuitButton_Click(object sender, EventArgs e)
        {
            if (detailsOnly)
            {

                switch (comboBox1.Text)
                {
                    case "Active":
                        enabled = false;
                        break;

                    case "Deprecated":
                        enabled = true;
                        break;
                };

                Supplier supplier = new Supplier { SupplierName = NameSupplierTxt.Text, Country = CountryCmbx.Text, Deprecated = enabled };
                try
                {
                    await _supplierService.Update(supplierID, supplier);
                    MessageBox.Show("Supplier updated successfully!");
                    Close();

                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            else
            {
                if (NameSupplierTxt.Text.Length < 1 || CountryCmbx.Text.Equals("All") || string.IsNullOrEmpty(CountryCmbx.Text))
                {
                    MessageBox.Show("Input data error!");
                    return;
                }

                Supplier supplier = new Supplier()
                {
                    SupplierName = NameSupplierTxt.Text,
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
        }
    }
}

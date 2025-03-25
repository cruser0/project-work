using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using WinformDotNetFramework.Entities;
using WinformDotNetFramework.Entities.DTO;
using WinformDotNetFramework.Services;

namespace WinformDotNetFramework.Forms.DetailsForms
{
    public partial class SupplierDetailsForm : Form
    {
        SupplierService _supplierService;
        SupplierInvoiceService _supplierInvoiceService;
        SupplierInvoiceSummary summary;
        Supplier supplier;
        int supplierID;
        public SupplierDetailsForm(int id)
        {
            Init(id);
        }

        private async void Init(int id)
        {
            InitializeComponent();
            _supplierService = new SupplierService();
            _supplierInvoiceService = new SupplierInvoiceService();
            summary = await _supplierInvoiceService.GetSummary(id);
            supplier = await _supplierService.GetById(id);
            CountryCmbx.DataSource = (await UtilityFunctions.GetCountries()).Select(x => x.CountryName).Skip(1).ToList();
            supplierID = id;
            NameSupplierTxt.Text = supplier.SupplierName;
            CountryCmbx.Text = supplier.Country;

            NameSupplierTxt.Enabled = false;
            CountryCmbx.Enabled = false;
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
            CreateDonutChart();
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

            if (!EditSupplierCbx.Checked)
            {
                NameSupplierTxt.Text = supplier.SupplierName;
                CountryCmbx.Text = supplier.Country;
            }

        }

        private async void SaveEditSupplierBtn_Click(object sender, EventArgs e)
        {
            Supplier supplier = new Supplier { SupplierName = NameSupplierTxt.Text, Country = CountryCmbx.Text };
            try
            {
                await _supplierService.Update(supplierID, supplier);
                MessageBox.Show("Supplier updated successfully!");

                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void SupplierGetInvoiceBtn_Click(object sender, EventArgs e)
        {
            /*
            // Close all existing MDI child forms
            var mainForm = Application.OpenForms["MainForm"] as MainForm;
            foreach (Control ctrl in mainForm.CenterPanel.Controls)
            {
                if (ctrl is Form existingForm)
                {
                    existingForm.Close();
                    existingForm.Dispose();
                }
            }
            SupplierInvoiceGridForm child = new SupplierInvoiceGridForm(IdSupplierTxt.Text);
            // Set the new form as an MDI child
            mainForm.CenterPanel.Controls.Clear();

            child.TopLevel = false;
            child.FormBorderStyle = FormBorderStyle.None;
            child.Dock = DockStyle.Fill;

            mainForm.CenterPanel.Controls.Add(child);
            child.Show();*/
        }

        private async void DeleteBtn_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
           "This action is permanent and it will delete all the history bound to this Supplier!",
           "Confirm Deletion?",
           MessageBoxButtons.YesNo,
           MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    await _supplierService.Delete(supplierID);
                    MessageBox.Show("Supplier has been deleted.");
                    this.Close();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            else
            {
                MessageBox.Show("Action canceled.");
            }
        }
    }
}

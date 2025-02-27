using System.Data;
using Winform.Entities;
using Winform.Forms.control;
using Winform.Services;

namespace Winform.Forms.AddForms
{
    public partial class CreateSupplierInvoiceCostForm : Form
    {
        MainForm mainForm = Application.OpenForms.OfType<MainForm>().First();
        SupplierInvoiceCostService _supplierInvoiceCostService;
        public CreateSupplierInvoiceCostForm()
        {
            _supplierInvoiceCostService = new SupplierInvoiceCostService();
            InitializeComponent();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            SupplierInvoiceCost supplierInvoiceCost = new SupplierInvoiceCost
            {
                SupplierInvoiceId = int.Parse(SupplierInvoiceIDIntegerTxt.GetText()),
                Cost = decimal.Parse(CostIntegerTxt.GetText()),
                Quantity = int.Parse(QuantityIntegerTxt.GetText()),
                Name = NameTxt.Text,
            };
            try
            {
                _supplierInvoiceCostService.Create(supplierInvoiceCost);
                MessageBox.Show("Supplier Invoice Cost created successfully!");

                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void OpenSupplierInvoice_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms.Cast<Form>().ToList())
            {
                if (form is SupplierInvoiceGridForm && form is not SupplierInvoiceForm)
                {
                    form.Close();
                }
            }

            TableLayoutPanel minimizedPanel = (TableLayoutPanel)mainForm.Controls.Find("minimizedPanel", true)[0];

            foreach (var button in minimizedPanel.Controls)
            {
                if (button is formDockButton btn)
                {
                    if (btn.getForm() is SupplierInvoiceGridForm form && form is not SupplierInvoiceForm)
                    {
                        form.Close();
                        minimizedPanel.Controls.Remove(btn);
                    }
                }

            }

            SupplierInvoiceGridForm cdf = new SupplierInvoiceGridForm(this);
            cdf.MdiParent = mainForm;
            cdf.Size = new Size((int)Math.Floor(mainForm.Width * 0.48),
            (int)Math.Floor(mainForm.Height * 0.40));
            cdf.Text = "Choose Supplier Invoice";
            cdf.Resize += ChildForm_Resize;
            cdf.FormClosing += ChildForm_Close;

            cdf.Show();


        }

        public void ChildForm_Close(object sender, FormClosingEventArgs e)
        {
            mainForm.BeginInvoke(new Action(UpdateMdiLayout));
        }

        private void UpdateMdiLayout()
        {
            int countOpenForms = mainForm.MdiChildren.Count(x => x.WindowState != FormWindowState.Minimized);
            mainForm.LayoutMdi(MdiLayout.ArrangeIcons);
        }


        public void ChildForm_Resize(object sender, EventArgs e)
        {
            var childForm = sender as Form;
            TableLayoutPanel minimizedPanel = (TableLayoutPanel)mainForm.Controls.Find("minimizedPanel", true)[0];

            if (childForm == null ||
                childForm.WindowState != FormWindowState.Minimized ||
                minimizedPanel.Controls.OfType<formDockButton>().Any(btn => btn.Name == childForm.Text))
            {
                return;
            }
            // Increase the column count for each new button
            minimizedPanel.ColumnCount += 1;

            // Create a new button for the minimized form
            var minimizedButton = new formDockButton(childForm.Text, childForm, minimizedPanel, mainForm)
            {
                Name = childForm.Text,
                Dock = DockStyle.Top
            };

            // Add the button to the table layout panel in the next available column
            minimizedPanel.Controls.Add(minimizedButton, minimizedPanel.ColumnCount - 1, 0);

            // Set the column style to make buttons stretch horizontally
            minimizedPanel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));

            // Hide the minimized form in the MDI parent
            childForm.Hide();

        }
        public void SetSupplierID(string id)
        {
            SupplierInvoiceIDIntegerTxt.SetText(id);
        }

    }
}

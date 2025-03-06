using Winform.Entities;
using Winform.Forms.control;
using Winform.Forms.CreateWindow;
using Winform.Services;

namespace Winform.Forms.AddForms
{
    public partial class CreateCustomerInvoiceCostForm : Form
    {
        MainForm mainForm = Application.OpenForms.OfType<MainForm>().First();
        CustomerInvoiceCostService _customerInvoiceCostService;
        public CreateCustomerInvoiceCostForm()
        {
            _customerInvoiceCostService = new CustomerInvoiceCostService();
            InitializeComponent();
            CustomerInvoiceIdTxt.ValueChanged += NameTxt_TextChanged;
            CostTxt.ValueChanged += NameTxt_TextChanged;
            QuantityTxt.ValueChanged += NameTxt_TextChanged;
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            CustomerInvoiceCost customerInvoiceCost = new CustomerInvoiceCost()
            {
                CustomerInvoiceId = int.Parse(CustomerInvoiceIdTxt.GetText()),
                Cost = decimal.Parse(CostTxt.GetText()),
                Quantity = int.Parse(QuantityTxt.GetText()),
                Name = NameTxt.Text
            };


            try
            {
                _customerInvoiceCostService.Create(customerInvoiceCost);
                MessageBox.Show("Customer Invoice Cost Created Succesfully");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void NameTxt_TextChanged(object sender, EventArgs e)
        {
            SaveBtn.Enabled =
                CustomerInvoiceIdTxt.GetText().Length > 0 &&
                CostTxt.GetText().Length > 0 &&
                QuantityTxt.GetText().Length > 0 &&
                NameTxt.Text.Length > 0;
        }

        private void OpenSale_Click(object sender, EventArgs e)
        {

            foreach (Form form in Application.OpenForms.Cast<Form>().ToList())
            {
                if (form is CustomerInvoiceGridForm && form is not CustomerInvoiceForm)
                {
                    form.Close();
                }
            }

            TableLayoutPanel minimizedPanel = (TableLayoutPanel)mainForm.Controls.Find("minimizedPanel", true)[0];

            foreach (var button in minimizedPanel.Controls)
            {
                if (button is formDockButton btn)
                {
                    if (btn.getForm() is CustomerInvoiceGridForm form && form is not CustomerInvoiceForm)
                    {
                        form.Close();
                        minimizedPanel.Controls.Remove(btn);
                    }
                }

            }

            CustomerInvoiceGridForm cdf = new CustomerInvoiceGridForm(this);
            cdf.Text = "Choose Sale";
            cdf.MdiParent = mainForm;
            cdf.Size = new Size((int)Math.Floor(mainForm.Width * 0.48),
            (int)Math.Floor(mainForm.Height * 0.40));

            cdf.Resize += ChildForm_Resize;
            cdf.FormClosing += ChildForm_Close;
            Panel mainPanel = (Panel)mainForm.Controls.Find("MainPanel", true)[0];
            mainPanel.Controls.Add(cdf);

            cdf.Show();


        }

        public void ChildForm_Close(object sender, FormClosingEventArgs e)
        {
            mainForm.BeginInvoke(new Action(UpdateMdiLayout));
        }

        private void UpdateMdiLayout()
        {
            Panel mainPanel = (Panel)mainForm.Controls.Find("MainPanel", true)[0];
            int countOpenForms = mainPanel.Controls.OfType<Form>().Count(x => x.WindowState != FormWindowState.Minimized);
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
        public void SetCustomerInvoiceID(string id)
        {
            CustomerInvoiceIdTxt.SetText(id);
        }
    }
}

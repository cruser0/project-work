using Winform.Entities;
using Winform.Forms.control;
using Winform.Services;

namespace Winform.Forms
{
    public partial class CreateSupplierInvoicesForm : Form
    {
        SupplierInvoiceService _service;
        SaleService _saleService;
        SupplierService _supplierService;
        MainForm mainForm = Application.OpenForms.OfType<MainForm>().First();

        public CreateSupplierInvoicesForm()
        {
            _saleService = new SaleService();
            _supplierService = new SupplierService();
            _service = new SupplierInvoiceService();
            InitializeComponent();

        }

        private void SaveEditCustomerBtn_Click(object sender, EventArgs e)
        {

            List<string> err = new List<string>();
            if (string.IsNullOrEmpty(SaleIDTxt1.GetText()))
                err.Add("SaleID");
            if (string.IsNullOrEmpty(SupplierIDTxt1.GetText()))
                err.Add("SupplierID");
            if (string.IsNullOrEmpty(StatusCmbx.Text))
                err.Add("Status");
            if (DateClnd.Value == null)
                err.Add("Date");
            if (err.Count > 0)
                MessageBox.Show("Gli attributi : " + string.Join(",", err) + "\n Sono errati!");
            else
            {
                try
                {
                    SupplierInvoice si = new SupplierInvoice { InvoiceDate = DateClnd.Value, SaleId = int.Parse(SaleIDTxt1.GetText()), SupplierId = int.Parse(SupplierIDTxt1.GetText()), Status = StatusCmbx.Text };
                    _service.Create(si);
                    MessageBox.Show("Supplier Invoice created Successfully!");

                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }

        }
        public void SetSupplierID(string id)
        {
            SupplierIDTxt1.SetText(id);
        }
        public void SetSaleID(string id)
        {
            SaleIDTxt1.SetText(id);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms.Cast<Form>().ToList())
            {
                if (form is SupplierGridForm && form is not SaleForm)
                {
                    form.Close();
                }
            }

            TableLayoutPanel minimizedPanel = (TableLayoutPanel)mainForm.Controls.Find("minimizedPanel", true)[0];

            foreach (var button in minimizedPanel.Controls)
            {
                if (button is formDockButton btn)
                {
                    if (btn.getForm() is SupplierGridForm form && form is not SupplierForm)
                    {
                        form.Close();
                        minimizedPanel.Controls.Remove(btn);
                    }
                }

            }

            SupplierGridForm cdf = new SupplierGridForm(this);
            cdf.MdiParent = mainForm;
            cdf.Size = new Size((int)Math.Floor(mainForm.Width * 0.48),
            (int)Math.Floor(mainForm.Height * 0.40));
            cdf.Text = "Choose Supplier";
            cdf.Resize += ChildForm_Resize;
            cdf.FormClosing += ChildForm_Close;
            Panel mainPanel = (Panel)mainForm.Controls.Find("MainPanel", true)[0];
            mainPanel.Controls.Add(cdf);

            cdf.Show();

        }
        private void OpenSale_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms.Cast<Form>().ToList())
            {
                if (form is SaleGridForm && form is not SaleForm)
                {
                    form.Close();
                }
            }

            TableLayoutPanel minimizedPanel = (TableLayoutPanel)mainForm.Controls.Find("minimizedPanel", true)[0];

            foreach (var button in minimizedPanel.Controls)
            {
                if (button is formDockButton btn)
                {
                    if (btn.getForm() is SaleGridForm form && form is not SaleForm)
                    {
                        form.Close();
                        minimizedPanel.Controls.Remove(btn);
                    }
                }

            }

            SaleGridForm cdf = new SaleGridForm(this);
            cdf.MdiParent = mainForm;
            cdf.Size = new Size((int)Math.Floor(mainForm.Width * 0.48),
            (int)Math.Floor(mainForm.Height * 0.40));
            cdf.Text = "Choose Sale";
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
            var minimizedButton = new formDockButton(childForm.Text, childForm, minimizedPanel, (MainForm)mainForm)
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
    }
}


using System.Data;
using Winform.Entities;
using Winform.Forms.control;
using Winform.Services;

namespace Winform.Forms.AddForms
{
    public partial class CreateSaleForm : Form
    {
        MainForm mainForm = Application.OpenForms.OfType<MainForm>().First();
        SaleService _saleService;
        public CreateSaleForm()
        {
            _saleService = new SaleService();
            InitializeComponent();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            Sale sale = new Sale
            {
                BookingNumber = bntxt.Text,
                BoLnumber = boltxt.Text,
                SaleDate = saleDateDtp.Value,
                CustomerId = int.Parse(CustomerIdtxt.GetText()),
                Status = StatusCmbx.Text
            };
            try
            {
                _saleService.Create(sale);
                MessageBox.Show("Sale Created successfully!");

                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void OpenSale_Click(object sender, EventArgs e)
        {

            foreach (Form form in Application.OpenForms.Cast<Form>().ToList())
            {
                if (form is CustomerGridForm && form is not CustomerForm)
                {
                    form.Close();
                }
            }

            TableLayoutPanel minimizedPanel = (TableLayoutPanel)mainForm.Controls.Find("minimizedPanel", true)[0];

            foreach (var button in minimizedPanel.Controls)
            {
                if (button is formDockButton btn)
                {
                    if (btn.getForm() is CustomerGridForm form && form is not CustomerForm)
                    {
                        form.Close();
                        minimizedPanel.Controls.Remove(btn);
                    }
                }

            }

            CustomerGridForm cdf = new CustomerGridForm(this);
            cdf.Text = "Choose Customer";
            cdf.MdiParent = mainForm;
            cdf.Size = new Size((int)Math.Floor(mainForm.Width * 0.48),
            (int)Math.Floor(mainForm.Height * 0.40));

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




        public void SetCustomerID(string id)
        {
            CustomerIdtxt.SetText(id);
        }
    }
}

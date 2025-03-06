namespace Winform.Forms.control
{
    public partial class formDockButton : UserControl
    {

        public formDockButton()
        {
            InitializeComponent();
        }

        public Button ButtonShowForm => buttonShowForm;
        Form form;
        TableLayoutPanel panel;
        MainForm mainForm;
        public formDockButton(string buttonName, Form childForm, TableLayoutPanel panelFather, MainForm mainform)
        {
            InitializeComponent();
            buttonShowForm.Text = buttonName;
            form = childForm;
            panel = panelFather;
            mainForm = mainform;
            Dock = DockStyle.Top;
        }

        public Form getForm()
        {
            return form;
        }

        public void buttonShowForm_Click(object sender, EventArgs e)
        {
            Panel mainPanel = (Panel)mainForm.Controls.Find("MainPanel", true)[0];
            int? countOpenForms = mainPanel.Controls.OfType<Form>().Count(x => x.WindowState != FormWindowState.Minimized);
            List<Form?> childrenOpen = mainPanel.Controls.OfType<Form>().Where(x => x.WindowState != FormWindowState.Minimized).ToList();

            if (countOpenForms >= 4)
                mainForm.LayoutMdi(MdiLayout.ArrangeIcons);


            form.Show();
            form.WindowState = FormWindowState.Normal;
            mainForm.LayoutMdi(MdiLayout.ArrangeIcons);
            panel.Controls.Remove(this);

        }


        private void buttonCloseForm_Click(object sender, EventArgs e)
        {

            form.Close();
            mainForm.LayoutMdi(MdiLayout.ArrangeIcons);
            panel.Controls.Remove(this);
        }
    }
}

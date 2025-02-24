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

        public void buttonShowForm_Click(object sender, EventArgs e)
        {
            form.WindowState = FormWindowState.Normal;

            form.Show();
            mainForm.LayoutMdi(MdiLayout.TileVertical);
            panel.Controls.Remove(this);

        }


        private void buttonCloseForm_Click(object sender, EventArgs e)
        {
            form.Close();
            mainForm.LayoutMdi(MdiLayout.TileVertical);
            panel.Controls.Remove(this);
        }
    }
}

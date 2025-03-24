using System.Windows.Forms;

namespace WinformDotNetFramework
{

    public partial class MDIContainerForm : Form
    {
        public MDIContainerForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.IsMdiContainer = true;
        }

        private void MDIContainerForm_LocationChanged(object sender, System.EventArgs e)
        {
            label1.Text = Location.ToString();
        }

        private void MDIContainerForm_SizeChanged(object sender, System.EventArgs e)
        {
            label1.Text = Location.ToString();
        }
    }

}

using System;
using System.Windows.Forms;

namespace WinformDotNetFramework.Forms.control
{
    public partial class StarUserControl : UserControl
    {
        public StarUserControl()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Parent.Text);
        }
    }
}

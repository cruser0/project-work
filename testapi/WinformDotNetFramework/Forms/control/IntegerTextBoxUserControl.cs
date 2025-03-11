using System;
using System.Windows.Forms;

namespace WinformDotNetFramework.Forms.control
{
    public partial class IntegerTextBoxUserControl : UserControl
    {

        public event EventHandler<EventArgs> ValueChanged;
        public IntegerTextBoxUserControl()
        {
            InitializeComponent();
            Width = NumericTxt.Width;
            Height = NumericTxt.Height;
        }

        private void NumericTxt_OnKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public string GetText()
        {
            return NumericTxt.Text;
        }

        public void SetText(string text)
        {
            NumericTxt.Text = text;
        }

        private void NumericTxt_TextChanged(object sender, EventArgs e)
        {
            ValueChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}

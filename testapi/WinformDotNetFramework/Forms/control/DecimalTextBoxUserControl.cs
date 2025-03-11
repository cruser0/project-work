using System;
using System.Linq;
using System.Windows.Forms;

namespace WinformDotNetFramework.Forms.control
{
    public partial class DecimalTextBoxUserControl : UserControl
    {
        public event EventHandler<EventArgs> ValueChanged;
        public DecimalTextBoxUserControl()
        {
            InitializeComponent();
            Width = NumericTxt.Width;
            Height = NumericTxt.Height;
        }

        private void NumericTxt_OnKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
                e.Handled = true;


            if (e.KeyChar == ',' && (sender as TextBox).Text.Contains(','))
                e.Handled = true;

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

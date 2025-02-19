namespace Winform.Forms.control
{
    public partial class IntegerTextBoxUserControl : UserControl
    {
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
    }
}

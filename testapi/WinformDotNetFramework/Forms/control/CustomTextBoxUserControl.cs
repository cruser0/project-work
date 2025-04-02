using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Windows.Forms;

namespace WinformDotNetFramework.Forms.control
{

    public enum TextBoxType
    {
        Default,
        Integer,
        Decimal
    }
    public partial class CustomTextBoxUserControl : UserControl
    {
        string _name;
        public TextBoxType TextBoxType { get; set; } = TextBoxType.Default;
        public CustomTextBoxUserControl()
        {
            InitializeComponent();
        }

        public void SetPropName(string name)
        {
            _name = name;
            PropTxt.PropName = _name;
            PropLbl.Text = _name;
        }

        public void WriteText(string text)
        {
            PropTxt.Text = text;
        }

        internal void SetBorderColor(List<ValidationResult> validationResults)
        {
            PropTxt.IsNotValid = false;
            PropTxt.ValidateProperty(validationResults);

            if (PropTxt.IsNotValid)
            {
                PropLbl.ForeColor = Color.Red;

                Errorlbl.Visible = true;
                Errorlbl.ForeColor = Color.Red;
                Errorlbl.Text = PropTxt.ErrorMessage;

            }
            else
            {
                PropLbl.ForeColor = Color.Black;

                Errorlbl.Visible = false;
            }
        }

        private void PropTxt_OnKeyPress(object sender, KeyPressEventArgs e)
        {
            switch (TextBoxType)
            {
                case TextBoxType.Decimal:
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
                        e.Handled = true;
                    if (e.KeyChar == ',' && (sender as CustomTextbox).Text.Contains(","))
                        e.Handled = true;
                    break;

                case TextBoxType.Integer:
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                        e.Handled = true;
                    break;

                default:
                    break;
            }

            return;
        }

    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Windows.Forms;

namespace WinformDotNetFramework.Forms.control
{
    public partial class CustomTextBoxUserControl : UserControl
    {
        string _name;
        public CustomTextBoxUserControl()
        {
            InitializeComponent();
            PropTxt.Tag = PropLbl;
            PropLbl.Tag = Errorlbl;
            // Errorlbl.MaximumSize = new Size(PropTxt.Width, 0);
        }

        public void SetPropName(string name)
        {
            _name = name;
            PropTxt.propName = _name;
            PropLbl.Text = _name;
        }

        public void WriteText(string text)
        {
            PropTxt.Text = text;
        }

        internal void SetBorderColor(List<ValidationResult> validationResults)
        {
            PropTxt.isNotValid = false;
            PropTxt.ValidateProperty(validationResults);

            if (PropTxt.isNotValid)
            {
                PropLbl.ForeColor = Color.Red;

                Errorlbl.Visible = true;
                Errorlbl.ForeColor = Color.Red;
                Errorlbl.Text = PropTxt.errorMessage;

            }
            else
            {
                PropLbl.ForeColor = Color.Black;

                Errorlbl.Visible = false;
            }
        }
    }
}

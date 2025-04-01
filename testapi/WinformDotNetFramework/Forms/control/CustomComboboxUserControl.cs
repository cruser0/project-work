using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformDotNetFramework.Forms.control
{
    public partial class CustomComboboxUserControl : UserControl
    {
        string _name;

        public CustomComboboxUserControl()
        {
            InitializeComponent();
            PropTxt.Tag = PropLbl;
            PropLbl.Tag = Errorlbl;
        }
        public void SetPropName(string name)
        {
            _name = name;
            PropTxt.PropName = _name;
            PropLbl.Text = _name;
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

    }
}

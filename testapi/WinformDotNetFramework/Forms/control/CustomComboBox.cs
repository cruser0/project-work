using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WinformDotNetFramework.Forms.control
{
    public partial class CustomComboBox : ComboBox
    {
        public string PropName { get; set; } = "";
        public string ErrorMessage { get; set; } = "";
        public bool IsNotValid { get; set; } = false;
        private const int WM_PAINT = 0xF;
        private int buttonWidth = SystemInformation.HorizontalScrollBarArrowWidth;
        Color borderColor = Color.Black;
        public Color BorderColor
        {
            get { return borderColor; }
            set { borderColor = value; Invalidate(); }
        }
        //m contains the windows message sent to the control
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);//creates the standard control
            if (m.Msg == WM_PAINT && DropDownStyle != ComboBoxStyle.Simple)
            {
                using (var g = Graphics.FromHwnd(Handle))
                {
                    using (var p = new Pen(BorderColor))
                    {
                        g.DrawRectangle(p, 0, 0, Width - 1, Height - 1);
                        var d = FlatStyle == FlatStyle.Popup ? 1 : 0;
                        g.DrawLine(p, Width - buttonWidth - d,
                            0, Width - buttonWidth - d, Height);
                    }
                }
            }
        }
        public void ValidateProperty(List<ValidationResult> validationResults)
        {
            if (string.IsNullOrEmpty(PropName)) return;

            foreach (var item in validationResults)
            {
                IsNotValid = PropName.Equals(item.MemberNames.First().Trim('"'));
                if (IsNotValid)
                {
                    ErrorMessage = item.ErrorMessage;
                    return;
                }
            }
        }
    }
}

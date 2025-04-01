using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace WinformDotNetFramework
{
    public partial class RedTextBox : TextBox
    {
        public bool isNotValid = false;
        public string propName = "";

        public RedTextBox()
        {
            InitializeComponent();
        }

        // Importing the GetWindowDC function from user32.dll.
        // This function retrieves a device context (DC) for the specified window.
        [DllImport("user32")]
        private static extern IntPtr GetWindowDC(IntPtr hwnd);
        // This function releases the device context (DC) previously obtained.
        [DllImport("user32")]
        private static extern int ReleaseDC(IntPtr hwnd, IntPtr hdc);

        // Constant representing the WM_NCPAINT message, used to repaint the non-client area of a window (like the border).
        private const int WM_NCPAINT = 0x85;

        // Overriding the WndProc method to intercept window messages
        // This method handles low-level window messages like painting and drawing operations.
        protected override void WndProc(ref Message m)
        {
            // Calling the base WndProc to ensure the default processing behavior of the window.
            base.WndProc(ref m);

            // If the message is WM_NCPAINT (non-client area paint) and the textbox is not valid (isNotValid is true),
            // a red border will be drawn around the textbox.
            if (m.Msg == WM_NCPAINT && isNotValid)
            {
                // Get the device context (DC) for the current window handle
                var dc = GetWindowDC(Handle);

                // Creating a Graphics object from the device context to draw custom shapes
                using (Graphics g = Graphics.FromHdc(dc))
                {
                    // Draw a red rectangle around the textbox to indicate invalidity
                    g.DrawRectangle(Pens.Red, 0, 0, Width - 1, Height - 1);
                }

                // Release the device context after the drawing operation to avoid resource leaks
                ReleaseDC(Handle, dc);

            }
        }

        public void ValidateProperty(List<ValidationResult> validationResults)
        {
            if (string.IsNullOrEmpty(propName)) return;

            foreach (var item in validationResults)
            {
                isNotValid = propName.Equals(item.MemberNames.First().Trim('"'));
                if (isNotValid) return;
            }
        }

    }
}

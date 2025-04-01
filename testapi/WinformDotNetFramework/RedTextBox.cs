using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace WinformDotNetFramework
{
    public partial class RedTextBox : TextBox
    {

        public RedTextBox()
        {
            InitializeComponent();
        }



        [DllImport("user32")]
        private static extern IntPtr GetWindowDC(IntPtr hwnd);
        private const int WM_NCPAINT = 0x85;
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (Parent is Form1 f)
            {
                if (m.Msg == WM_NCPAINT && f.Wrongtextboxes.Contains(this))
                {
                    var dc = GetWindowDC(Handle);
                    using (Graphics g = Graphics.FromHdc(dc))
                    {
                        g.DrawRectangle(Pens.Red, 0, 0, Width - 1, Height - 1);
                    }
                }

            }
        }
    }
}

using System;
using System.Windows.Forms;

namespace WinformDotNetFramework.Forms.control
{
    public partial class PaginationUserControl : UserControl
    {
        public string maxPage;
        public string labelHolder;
        public int CurrentPage { get; set; }
        public event EventHandler SingleRightArrowEvent;
        public event EventHandler SingleLeftArrowEvent;
        public event EventHandler DoubleRightArrowEvent;
        public event EventHandler DoubleLeftArrowEvent;
        public event EventHandler PageNumberTextboxEvent;
        public PaginationUserControl()
        {
            InitializeComponent();


        }
        public void SetPageLbl(string page)
        {
            string lbl = "/" + page.Split('/')[1];
            string txt = page.Split('/')[0];
            labelHolder = page;


            PageNumber.Text = lbl;
            CurrentPageTxt.Text = txt;
        }
        public void SetMaxPage(string page)
        {
            this.maxPage = page;
        }
        public string GetPageLbl()
        {
            return labelHolder;
        }
        public string GetmaxPage()
        {
            return maxPage;
        }

        private void SingleRightArrow_Click(object sender, EventArgs e)
        {
            SingleRightArrowEvent.Invoke(this, EventArgs.Empty);
        }

        private void SingleLeftArrow_Click(object sender, EventArgs e)
        {
            SingleLeftArrowEvent.Invoke(this, EventArgs.Empty);
        }

        private void DoubleRightArrow_Click(object sender, EventArgs e)
        {
            DoubleRightArrowEvent.Invoke(this, EventArgs.Empty);
        }

        private void DoubleLeftArrow_Click(object sender, EventArgs e)
        {
            DoubleLeftArrowEvent.Invoke(this, EventArgs.Empty);
        }

        private void CurrentPageTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                PageNumberTextboxEvent.Invoke(this, EventArgs.Empty);
            }
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }


}

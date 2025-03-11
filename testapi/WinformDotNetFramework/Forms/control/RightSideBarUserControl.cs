using System;
using System.Windows.Forms;

namespace WinformDotNetFramework.Forms.control
{
    public partial class RightSideBarUserControl : UserControl
    {
        public event EventHandler searchBtnEvent;
        public event EventHandler closeBtnEvent;

        public RightSideBarUserControl()
        {
            InitializeComponent();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            searchBtnEvent.Invoke(this, EventArgs.Empty);
        }

        private void CloseWindowBtn_Click(object sender, EventArgs e)
        {
            closeBtnEvent.Invoke(this, EventArgs.Empty);
        }


    }
}

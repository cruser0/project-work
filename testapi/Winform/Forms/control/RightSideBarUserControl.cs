using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winform.Forms.control
{
    public partial class RightSideBarUserControl : UserControl
    {
        public event EventHandler searchBtnEvent;
        public event EventHandler closeBtnEvent;
        public event EventHandler<KeyPressEventArgs> enterBtnEvent;
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

        private void SearchButton_KeyPress(object sender, KeyPressEventArgs e)
        {
            enterBtnEvent.Invoke(this,e);
            
        }
    }
}

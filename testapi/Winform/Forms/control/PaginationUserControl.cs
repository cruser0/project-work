using API.Models.Filters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Winform.Entities;
using Winform.Services;

namespace Winform.Forms.control
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
        public PaginationUserControl()
        {
            InitializeComponent();
            double itemsPage = 100.0;

        }
        public void SetPageLbl(string page)
        {
            labelHolder = page;
            PageNumber.Text = page;
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
    }
    
}

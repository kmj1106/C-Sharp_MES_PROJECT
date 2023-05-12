using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppFlower
{
    public partial class frmWaitAsyncForm : Form
    {
        public Action Worker { get; set; }
        public frmWaitAsyncForm(Action worker)
        {
            InitializeComponent();
            this.Worker = worker;
        }

        private void frmWaitAsyncForm_Load(object sender, EventArgs e)
        {
            var task1 = Task.Factory.StartNew(Worker);
            task1.ContinueWith((t) => this.Close(),TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}

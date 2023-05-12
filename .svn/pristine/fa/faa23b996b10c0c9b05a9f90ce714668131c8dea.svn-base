using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlowerVO;

namespace WindowsFormsFlower
{
    public partial class frmUserMain : Form
    {
        
        public UserVO LoginUser { get; set; }

        public frmUserMain()
        {
            InitializeComponent();
        }

        private void frmUserMain_Load(object sender, EventArgs e)
        {
            frmLogin login = new frmLogin();
            if (login.ShowDialog() == DialogResult.OK)
            {
                this.LoginUser = login.LoginUser;
            }
            else
            {
                Application.Exit();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            frmLogin showfrmMain = new frmLogin();

            showfrmMain.ShowDialog(this);
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            frmUser showfrmMain = new frmUser();
            showfrmMain.ShowDialog(this);
        }

        private void btnMyPage_Click(object sender, EventArgs e)
        {
            frmMyPage showfrmMain = new frmMyPage();
            showfrmMain.LoginUser = this.LoginUser;
            showfrmMain.MdiParent = this;
            showfrmMain.Show();
        }

        private void btnShoppingMall_Click(object sender, EventArgs e)
        {
            frmShoppingMall showfrmMain = new frmShoppingMall();
            showfrmMain.LoginUser = this.LoginUser;
            showfrmMain.MdiParent = this;
            showfrmMain.Show();
        }

        
    }
}

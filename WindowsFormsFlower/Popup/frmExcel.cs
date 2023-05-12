using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace WindowsFormsFlower
{
    public partial class frmExcel : Form
    {
        UserService userService = new UserService();
        string strConn = ConfigurationManager.ConnectionStrings["local"].ConnectionString;
        bool CheckID = false;

        public frmExcel()
        {
            InitializeComponent();
        }

        public string UserID
        {
            get { return txtCheckID.Text; }
            set { txtCheckID.Text = value; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCheckID.Text))
            {
                MessageBox.Show("사용하실 아이디를 입력하세요.");
                return;
            }

            UserService userService = new UserService();
            int cnt = userService.CheckUserID(txtCheckID.Text);
            if (cnt > 0)
            {
                label1.Text = "사용중인 ID";
                CheckID = false;
            }
            else
            {
                label1.Text = "사용가능한 ID";
                CheckID = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (CheckID)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("사용자ID 중복체크를 다시 하시기 바랍니다.");
            }
        }
    }
}

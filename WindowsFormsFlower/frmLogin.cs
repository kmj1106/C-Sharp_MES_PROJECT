using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
using FlowerDAC;
using FlowerVO;

namespace WindowsFormsFlower
{
    public partial class frmLogin : Form
    {
        public UserVO LoginUser { get; set; }

        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
           if (string.IsNullOrWhiteSpace(txtUserID.Text) || string.IsNullOrWhiteSpace(txtUserName.Text) || string.IsNullOrWhiteSpace(txtUserEmail.Text))
            {
                MessageBox.Show("아이디, 이름, 이메일을 모두 입력하세요.");
                return;
            }

            UserDAC dac = new UserDAC();
            bool bFlag = dac.ConfirmUser(txtUserID.Text, txtUserName.Text, txtUserEmail.Text);
            if (!bFlag)
            {
                MessageBox.Show("회원정보가 없습니다. 다시 확인하여 주십시오.");
                return;
            }

            string newPwd = CreatePassword();

            bool bResult = dac.UpdatePwd(txtUserID.Text, newPwd);
            if (bResult)
            {
                string subject = $"{txtUserName.Text}님의 비밀번호 초기화 안내 메일입니다.";
                string body = $"{txtUserName.Text}님의 비밀번호는 {newPwd}으로 초기화 되었습니다. 로그인해주십시오.";
                string to = txtUserEmail.Text;

                SendMail();
                MessageBox.Show("비밀번호를 재생성해서 메일로 발송하였습니다. 확인하여 주십시오.");
            }
            else
            {
                MessageBox.Show("비밀번호 찾기 중 오류가 발생했습니다. 다시 시도하여 주십시오..");
            }
        }

        private void SendMail()
        {

        }

        private string CreatePassword()
        {
            StringBuilder sb = new StringBuilder();

            Random rnd = new Random();
            for (int i = 0; i < 6; i++)
            {
                int temp = rnd.Next(0, 36);
                if (temp < 10)
                    sb.Append(temp);
                else
                    sb.Append((char)(temp + 55));
            }
            return sb.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmUser frm = new frmUser();
            frm.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel1.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtloginID.Text) || string.IsNullOrWhiteSpace(txtloginPwd.Text))
            {
                MessageBox.Show("아이디와 비밀번호를 입력하세요.");
                return;
            }

            UserService userservice = new UserService();
            UserVO loginUser = userservice.Login(txtloginID.Text, txtloginPwd.Text);

            if (loginUser == null)
            {
                MessageBox.Show("등록된 아이디가 아닙니다. 회원가입을 해주십시오.");
            }
            else if (loginUser.UserPwd != txtloginPwd.Text)
            {
                MessageBox.Show("비밀번호를 다시 입력하여 주십시오.");
            }
            else
            {
                this.LoginUser = loginUser;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
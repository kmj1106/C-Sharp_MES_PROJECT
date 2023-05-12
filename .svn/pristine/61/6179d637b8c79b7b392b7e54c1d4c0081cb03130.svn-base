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
using FlowerVO;

namespace WindowsFormsFlower
{
    public partial class frmUser : Form
    {
        public UserVO UserInfo
        {
            get
            {
                UserVO req = new UserVO();
                req.UserID = txtUserID.Text;
                req.UserPwd = txtUserPwd.Text;
                req.UserPwdDetail = txtUserPwdDetail.Text;
                req.UserName = txtUserName.Text;
                req.Zipcode = zipControl1.ZipCode;
                req.Address1 = zipControl1.Address1;
                req.Address2 = zipControl1.Address2;
                req.UserEmail = txtUserEmail1.Text+"@"+txtUserEmail2.Text;
                req.UserBirth = dtpUserBirth.Value;
                req.UserGender = cboGender.Text.ToString();
                req.UserPhone = txtUserPhone.Text;
       
                return req;
            }
        }

        string strConn = ConfigurationManager.ConnectionStrings["local"].ConnectionString;

        public frmUser()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmCheck frm = new frmCheck();
            frm.UserID = txtUserID.Text;

            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtUserID.Text = frm.UserID;
                txtUserID.Enabled = false;
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            if (txtUserID.Text.Length < 5)
            {
                sb.AppendLine("- 아이디를 6자리 이상 입력하세요.");
            }

            if (txtUserPwd.Text.Length < 1)
            {
                sb.AppendLine("- 비밀번호를 입력하세요.");
            }

            if (txtUserPwdDetail.Text != txtUserPwdDetail.Text)
            {
                sb.AppendLine("- 비밀번호가 같지 않습니다. 다시 입력하세요.");
            }

            if (txtUserName.Text.Length < 1)
            {
                sb.AppendLine("- 이름을 입력하세요.");
            }

            if (zipControl1.ZipCode.Length < 1)
            {
                sb.AppendLine("- 우편번호를 입력하세요.");
            }

            if (zipControl1.Address1.Length < 1)
            {
                sb.AppendLine("- 주소를 입력하세요.");
            }

            if (zipControl1.Address2.Length < 1)
            {
                sb.AppendLine("- 주소를 입력하세요.");
            }

            if (txtUserEmail1.Text.Length < 1)
            {
                sb.AppendLine("- 이메일 앞자리를 입력하세요.");
            }

            if (dtpUserBirth.Text.Length < 1)
            {
                sb.AppendLine("- 생일을 입력하세요.");
            }

            if (cboGender.Text.Length < 1)
            {
                sb.AppendLine("- 성별을 입력하세요.");
            }

            if (txtUserPhone.Text.Length < 10)
            {
                sb.AppendLine("- 전화번호를 입력하세요.");
            }

            if (sb.ToString().Length > 1)
            {
                MessageBox.Show(sb.ToString());
                return;
            }

            if (sb.ToString().Length > 1)
            {
                MessageBox.Show(sb.ToString());
                return;
            }

            UserService service = new UserService();
            int iResult = service.InsertUser(UserInfo);

            if (iResult > 0)
            {
                MessageBox.Show("회원가입이 완료되었습니다.");
                this.Close();
            }
        }

        private void frmUser_Load(object sender, EventArgs e)
        {

        }
    }
}

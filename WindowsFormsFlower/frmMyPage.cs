using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlowerVO;
using FlowerDAC;

namespace WindowsFormsFlower
{
    public partial class frmMyPage : Form
    {
        List<SaleVO> allList = null;
        SaleService saleService = new SaleService();

        public UserVO LoginUser { get; set; }

        public frmMyPage()
        {
            InitializeComponent();
        }

        private void frmMyPage_Load(object sender, EventArgs e)
        {
            txtUserID.Text = LoginUser.UserID;
            txtUserPwd.Text = LoginUser.UserPwd;
            txtUserName.Text = LoginUser.UserName;
            zipControl1.ZipCode = LoginUser.Zipcode;
            zipControl1.Address1 = LoginUser.Address1;
            zipControl1.Address2 = LoginUser.Address2;
            string[] email = LoginUser.UserEmail.Split('@');
            txtUserEmail1.Text = email[0].Trim('@');
            txtUserEmail2.Text = email[1];
            dtpUserBirth.Value = LoginUser.UserBirth;
            cboGender.SelectedIndex = cboGender.Items.IndexOf(LoginUser.UserGender);
            txtUserPhone.Text = LoginUser.UserPhone.Replace("-", "");

            DataGridViewUtil.SetInitGridView(dgvReserve);
            DataGridViewUtil.AddGridTextColumn(dgvReserve, "주문ID", "SaleID");
            DataGridViewUtil.AddGridTextColumn(dgvReserve, "주문상세ID", "SaleDetailID");
            DataGridViewUtil.AddGridTextColumn(dgvReserve, "제품이름", "ProdName");
            DataGridViewUtil.AddGridTextColumn(dgvReserve, "수량", "Quantity");
            DataGridViewUtil.AddGridTextColumn(dgvReserve, "주문상태", "IsState");
            DataGridViewUtil.AddGridTextColumn(dgvReserve, "주문날짜", "OrderDate");

            DataLoad();
        }

        private void DataLoad()
        {
            allList = saleService.GetReserveUser(LoginUser.UserID);
            dgvReserve.DataSource = allList;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtUserID.Text.Length < 1) return;

            UserVO us = new UserVO
            {
                UserID = txtUserID.Text,
                UserPwd = txtUserPwd.Text,
                UserName = txtUserName.Text,
                Zipcode = zipControl1.ZipCode,
                Address1 = zipControl1.Address1,
                Address2 = zipControl1.Address2,
                UserEmail = txtUserEmail1.Text + '@' + txtUserEmail2.Text,
                UserBirth = dtpUserBirth.Value,
                UserGender = cboGender.Text.ToString(),
                UserPhone = txtUserPhone.Text,
            };

            if (string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                MessageBox.Show("회원명을 입력해주세요.");

                return;
            }
            else if (string.IsNullOrWhiteSpace((txtUserPwd.Text)))
            {
                MessageBox.Show("비밀번호를 입력해주세요.");

                return;
            }
            else if (string.IsNullOrWhiteSpace(txtUserID.Text))
            {
                MessageBox.Show("회원 아이디를 입력해주세요.");

                return;
            }
            else if (string.IsNullOrWhiteSpace((zipControl1.ZipCode)))
            {
                MessageBox.Show("우편번호를 입력해주세요.");

                return;
            }
            else if (string.IsNullOrWhiteSpace((zipControl1.Address1)))
            {
                MessageBox.Show("주소를 입력해주세요.");

                return;
            }
            else if (string.IsNullOrWhiteSpace(txtUserEmail1.Text))
            {
                MessageBox.Show("이메일을 입력해주세요.");

                return;
            }
            else if (string.IsNullOrWhiteSpace(dtpUserBirth.Text))
            {
                MessageBox.Show("생년월일을 입력해주세요.");

                return;
            }
            else if (string.IsNullOrWhiteSpace(cboGender.Text))
            {
                MessageBox.Show("성별을 입력해주세요.");

                return;
            }
            else if (string.IsNullOrWhiteSpace(txtUserPhone.Text))
            {
                MessageBox.Show("전화번호를 입력해주세요.");

                return;
            }

            UserService service = new UserService();
            bool bResult = service.UpdateMembers(LoginUser);

            if (bResult)
            {
                MessageBox.Show("수정되었습니다.");
            }

            else
            {
                MessageBox.Show("수정 중 오류가 발생했습니다.");
            }
        }

        private void btnReserveCancel_Click(object sender, EventArgs e)
        {
            if (dgvReserve.SelectedRows.Count < 1)
            {
                MessageBox.Show("취소할 제품을 선택하여 주십시오.");
                return;
            }

            if(dgvReserve.SelectedRows[0].Cells["IsState"].Value.ToString() != "주문대기")
            {
                MessageBox.Show("주문대기 중인 제품만 취소할 수 있습니다.");
                return;
            }

            //처리
            int sdID = Convert.ToInt32(dgvReserve.SelectedRows[0].Cells["SaleDetailID"].Value);
            bool cResult  = saleService.CancelSale(sdID, true);

            if (cResult)
            {
                MessageBox.Show("취소 되었습니다.");
            }

            else
            {
                MessageBox.Show("취소 중 오류가 발생했습니다.");
            }
            DataLoad();
        }
    }
}
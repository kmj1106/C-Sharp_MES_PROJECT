using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FlowerVO;
using System.Configuration;
using FlowerDAC;
using System.Linq;

namespace WindowsFormsFlower
{
    public partial class frmMember : WindowsFormsFlower.BaseForm.frmListDetailSearch
    {
        UserService srv;
        List<UserVO> allList;
        UserService userService = new UserService();


        public frmMember()
        {
            InitializeComponent();
        }

        private void frmMember_Load(object sender, EventArgs e)
        {
            srv = new UserService();

            DataGridViewUtil.SetInitGridView(dgvUser);
            DataGridViewUtil.AddGridTextColumn(dgvUser, "회원ID", "UserID");
            DataGridViewUtil.AddGridTextColumn(dgvUser, "비밀번호", "UserPwd");
            DataGridViewUtil.AddGridTextColumn(dgvUser, "회원명", "UserName");
            DataGridViewUtil.AddGridTextColumn(dgvUser, "우편번호", "ZipCode");
            DataGridViewUtil.AddGridTextColumn(dgvUser, "주소", "Address1");
            DataGridViewUtil.AddGridTextColumn(dgvUser, "주소", "Address2");
            DataGridViewUtil.AddGridTextColumn(dgvUser, "이메일", "UserEmail", colWidth: 150);
            DataGridViewUtil.AddGridTextColumn(dgvUser, "생년월일", "UserBirth");
            DataGridViewUtil.AddGridTextColumn(dgvUser, "성별", "UserGender");
            DataGridViewUtil.AddGridTextColumn(dgvUser, "전화번호", "UserPhone", colWidth: 130);

            LoadData();
        }

        private void LoadData()
        {
            allList = srv.GetUserAllList();
            dgvUser.DataSource = allList;
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKeyword.Text))
            {
                dgvUser.DataSource = null;
                dgvUser.DataSource = allList;
            }

            string search = txtKeyword.Text.Trim();

            List<UserVO> list;
            list = (from us in allList
                    where us.UserName.Contains(search)
                    select us).ToList();

            dgvUser.DataSource = null;
            dgvUser.DataSource = list;
        }

        private void dgvUser_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string usID = dgvUser[0, e.RowIndex].Value.ToString();
            UserVO us = srv.GetUserInfo(usID);
            if (us != null)
            {
                txtUserID.Text = dgvUser["UserID", e.RowIndex].Value.ToString();
                txtUserPwd.Text = dgvUser["UserPwd", e.RowIndex].Value.ToString();
                txtUserName.Text = dgvUser["UserName", e.RowIndex].Value.ToString();
                zipControl1.ZipCode = dgvUser["ZipCode", e.RowIndex].Value.ToString();
                zipControl1.Address1 = dgvUser["Address1", e.RowIndex].Value.ToString();
                zipControl1.Address2 = dgvUser["Address2", e.RowIndex].Value.ToString();
                string[] Email = dgvUser["UserEmail", e.RowIndex].Value.ToString().Split('@');
                txtUserEmail1.Text = Email[0];
                txtUserEmail2.Text = Email[1].Replace("@", "");
                dtpUserBirth.Text = dgvUser["UserBirth", e.RowIndex].Value.ToString();
                cboGender.Text = dgvUser["UserGender", e.RowIndex].Value.ToString();
                txtUserPhone.Text = (dgvUser["UserPhone", e.RowIndex].Value != null) ? dgvUser["UserPhone", e.RowIndex].Value.ToString() : "";
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            foreach (Control ct in splitContainer2.Controls)
            {
                if (ct is TextBox txt)
                {
                    if (string.IsNullOrWhiteSpace(txt.Text))
                    {
                        MessageBox.Show($"{txt.Tag.ToString()}을 입력해주세요");
                        return;
                    }
                }
            }

            UserVO mem = new UserVO
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

            bool result = userService.InsertMembers(mem);
            if (result)
            {
                MessageBox.Show("등록이 완료되었습니다.");
                ClearControls();
                LoadData();
            }
            else
            {
                MessageBox.Show("등록 중 오류가 발생했습니다. 다시 시도하여 주십시오.");
            }
        }

        private void ClearControls()
        {
            foreach (Control ct in splitContainer2.Controls)
            {
                if (ct is TextBox txt)
                {
                    txt.Text = "";
                }
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtUserID.Text.Length < 1) return;

            UserVO mem = new UserVO
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


            bool bResult = srv.UpdateMembers(mem);


            if (bResult)
            {
                MessageBox.Show("수정되었습니다.");
                LoadData();
            }

            else
            {
                MessageBox.Show("수정 중 오류가 발생했습니다.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvUser.SelectedRows.Count < 1)
            {
                MessageBox.Show("삭제할 회원을 선택하여 주십시오.");
                return;
            }

            if (MessageBox.Show("회원 정보를 삭제하시겠습니까?", "회원 삭제", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                bool result = userService.DeleteMembers(txtUserID.Text.ToString());
                if (result)
                {
                    MessageBox.Show("정보가 삭제되었습니다.");
                    LoadData();
                }
                else
                {
                    MessageBox.Show("삭제 중 오류가 발생했습니다. 다시 시도하여 주십시오.");
                }
            }
        }
    }
}
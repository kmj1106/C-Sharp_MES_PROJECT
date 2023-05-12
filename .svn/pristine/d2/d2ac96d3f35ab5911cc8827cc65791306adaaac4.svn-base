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
    public partial class frmCustomer : WindowsFormsFlower.BaseForm.frmListListDetail
    {
        List<CustomerVO> cusAllList = null; //제품목록
        CustomerService cusService = new CustomerService();
        CustomerService srv;
        List<MaterialVO> mList = null;
        List<CustomerVO> allList;
        List<CusMatVO> cusMatAllList = null; //제품목록
        CusMatService cusMatService = new CusMatService();
        CommonService comService = new CommonService();
        public frmCustomer()
        {
            InitializeComponent();
        }

        private void frmCustomer_Load(object sender, EventArgs e)
        {
            DataGridViewUtil.SetInitGridView(dgvCustomer);
            DataGridViewUtil.AddGridTextColumn(dgvCustomer, "거래처ID", "CusID",colWidth:80);
            DataGridViewUtil.AddGridTextColumn(dgvCustomer, "거래처명", "CusName");
            DataGridViewUtil.AddGridTextColumn(dgvCustomer, "사업자번호", "Cuslicense");
            DataGridViewUtil.AddGridTextColumn(dgvCustomer, "사업자명", "CusManager");
            DataGridViewUtil.AddGridTextColumn(dgvCustomer, "담당자명", "CusCharge");
            DataGridViewUtil.AddGridTextColumn(dgvCustomer, "거래처 연락처", "CusPhone", DataGridViewContentAlignment.MiddleCenter, colWidth: 110);
            DataGridViewUtil.AddGridTextColumn(dgvCustomer, "거래처 이메일", "CusEmail", colWidth: 110);

            DataGridViewUtil.SetInitGridView(dgvCusMat);
            DataGridViewUtil.AddGridTextColumn(dgvCusMat, "거래처자재ID", "CusMatID");
            DataGridViewUtil.AddGridTextColumn(dgvCusMat, "자재ID", "MaterialID");
            DataGridViewUtil.AddGridTextColumn(dgvCusMat, "자재분류", "MatCategory");
            DataGridViewUtil.AddGridTextColumn(dgvCusMat, "자재이름", "MaterialName");

            LoadData();
        }

        private void LoadData()
        {
            cusAllList = cusService.GetCustomerAllList();
            dgvCustomer.DataSource = cusAllList;

            List<CommonVO> clist = comService.GetCodeList("Materials");
            CommonUtil.ComboBinding(cboCusID, clist, "Materials", blankText: "선택");

            MaterialService srvM = new MaterialService();
            mList = srvM.GetMaterialsAllList();
            MaterialVO blank = new MaterialVO
            {
                MaterialID = "",
                MaterialName = "선택"
            };
            mList.Insert(0, blank);

            //cboMaterialID.DisplayMember = "MaterialName";
            //cboMaterialID.ValueMember = "MaterialID";
            //cboMaterialID.DataSource = mList;


            cusMatAllList = cusMatService.GetCusMatAllList();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            //유효성체크
            foreach (Control ct in splitContainer1.Panel2.Controls)
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

            CustomerVO newCustomer = new CustomerVO
            {
                CusID = txtCusID.Text,
                CusName = txtCusName.Text,
                Cuslicense = txtCuslicense.Text,
                CusManager = txtCusManager.Text,
                CusCharge = txtCusCharge.Text,
                CusPhone = txtCusPhone.Text,
                CusEmail = txtCusEmail1.Text + "@" + txtCusEmail2.Text,
            };

            bool result = cusService.InsertCustomers(newCustomer);
            if (result)
            {
                MessageBox.Show("등록이 완료되었습니다.");
                LoadData();
                ClearControls();
            }
            else
            {
                MessageBox.Show("등록 중 오류가 발생했습니다. 다시 시도하여 주십시오.");
            }
        }

        private void ClearControls()
        {
            foreach (Control ct in splitContainer1.Panel2.Controls)
            {
                if (ct is TextBox txt)
                {
                    txt.Text = "";
                }
            }

            txtCusPhone.Text = null;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            foreach (Control ct in splitContainer1.Panel2.Controls)
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

            CustomerVO newCustomer = new CustomerVO
            {
                CusID = txtCusID.Text,
                CusName = txtCusName.Text,
                Cuslicense = txtCuslicense.Text,
                CusManager = txtCusManager.Text,
                CusCharge = txtCusCharge.Text,
                CusPhone = txtCusPhone.Text,
                CusEmail = txtCusEmail1.Text + "@" + txtCusEmail2.Text
            };

            bool result = cusService.UpdateCustomers(newCustomer);
            if (result)
            {
                MessageBox.Show("수정이 완료되었습니다.");
                ClearControls();
            }
            else
            {
                MessageBox.Show("수정 중 오류가 발생했습니다. 다시 시도하여 주십시오.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtCusID.Text))
            {
                return;
            }
            if (MessageBox.Show("정보를 삭제하시겠습니까?", "거래처 삭제", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                bool result = cusService.DeleteCustomers(Convert.ToInt32(txtCusID.Text));
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

        private void dgvCustomer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                txtCusID.Enabled = false;
                txtCusID.Text = dgvCustomer["CusID", e.RowIndex].Value.ToString();
                txtCusName.Text = dgvCustomer["CusName", e.RowIndex].Value.ToString();
                txtCuslicense.Text = dgvCustomer["Cuslicense", e.RowIndex].Value.ToString();
                txtCusManager.Text = dgvCustomer["CusManager", e.RowIndex].Value.ToString();
                txtCusCharge.Text = (dgvCustomer["CusCharge", e.RowIndex].Value != null) ? dgvCustomer["CusCharge", e.RowIndex].Value.ToString() : "";
                txtCusPhone.Text = (dgvCustomer["CusPhone", e.RowIndex].Value != null) ? dgvCustomer["CusPhone", e.RowIndex].Value.ToString() : "";
                txtCusEmail1.Text = dgvCustomer["CusEmail", e.RowIndex].Value.ToString();
                txtCusEmail2.Text = dgvCustomer["CusEmail", e.RowIndex].Value.ToString();
            };
            LoadCusMatData();
        }

        private void LoadCusMatData()
        {
            cusMatAllList = cusMatService.GetCusMatAllList();
            var cmList = (from cm in cusMatAllList
                          join m in mList on cm.MaterialID equals m.MaterialID
                          select new
                          {
                              CusMatID = cm.CusMatID,
                              MaterialID = m.MaterialID,
                              MaterialName = m.MaterialName,
                              MatCategory = m.MatCategory,
                              CusID = cm.CusID,
                          }).ToList();
            dgvCusMat.DataSource = cmList.FindAll((x) => x.CusID == txtCusID.Text);
        }

        private void cboEmail_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void btnPrSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCusSearch.Text))
            {
                dgvCustomer.DataSource = null;
                dgvCustomer.DataSource = cusAllList;
                return;
            }

            string search = txtCusSearch.Text.Trim();

            var list = (from cus in cusAllList
                        where cus.CusName.Contains(search)
                    select cus);


            dgvCustomer.DataSource = null;
            dgvCustomer.DataSource = list;
        }

        private void btnMatInsert_Click(object sender, EventArgs e)
        {
            foreach (Control ct in splitContainer2.Panel1.Controls)
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
            if (cboMaterialID.SelectedIndex < 0)
            {
                MessageBox.Show("자재를 선택해주세요");
                return;
            }
            var check = cusMatAllList.Find((x) => x.CusID == txtCusID.Text && x.MaterialID == cboMaterialID.SelectedValue.ToString());
            if (check != null)
            {
                MessageBox.Show("이미 추가된 자재입니다.");
                return;
            }
                
            
            CusMatVO newCusMat = new CusMatVO
            {
                CusID = txtCusID.Text,
                MaterialID = cboMaterialID.SelectedValue.ToString()
            };

            bool result = cusMatService.InsertCusMaterial(newCusMat);
            if (result)
            {
                MessageBox.Show("등록이 완료되었습니다.");
                LoadCusMatData();
            }
            else
            {
                MessageBox.Show("등록 중 오류가 발생했습니다. 다시 시도하여 주십시오.");
            }
        }

        private void cboCusID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCusID.SelectedIndex < 1) return;

            cboMaterialID.DataSource = null;

            string matCategory = cboCusID.SelectedValue.ToString();
            List<MaterialVO> list = mList.Where((p) => p.MatCategory == matCategory).ToList();

            cboMaterialID.DisplayMember = "MaterialName";
            cboMaterialID.ValueMember = "MaterialID";
            cboMaterialID.DataSource = list;
        }

        private void btnMatDelete_Click(object sender, EventArgs e)
        {
            if (dgvCusMat.SelectedRows.Count < 1)
            {
                MessageBox.Show("삭제할 자재를 선택하여 주십시오.");
                return;
            }

            //처리
            string cusMatID = dgvCusMat.SelectedRows[0].Cells["CusMatID"].Value.ToString();
            bool result = cusMatService.DeleteCusMaterial(cusMatID);
            if (result)
            {
                MessageBox.Show("삭제가 완료되었습니다.");
                LoadCusMatData();
            }
            else
            {
                MessageBox.Show("삭제 중 오류가 발생했습니다. 다시 시도하여 주십시오.");
            }
        }
    }
}

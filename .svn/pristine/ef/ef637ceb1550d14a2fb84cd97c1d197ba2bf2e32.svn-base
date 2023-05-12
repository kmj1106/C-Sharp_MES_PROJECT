using FlowerVO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsFlower
{
    public partial class frmProduct : WindowsFormsFlower.BaseForm.frmListDetail
    {

        List<ProductVO> prodAllList = null; //제품목록
        ProductService prodServ = new ProductService();
        CommonService comServ = new CommonService();
        public string currentFileName { get; set; }

        public frmProduct()
        {
            InitializeComponent();
            ptbProd.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void frmProduct_Load(object sender, EventArgs e)
        {

            //제품 데이터그리드뷰 컬럼 셋팅
            DataGridViewUtil.SetInitGridView(dgvProduct);
            DataGridViewUtil.AddGridTextColumn(dgvProduct, "제품ID", "ProdID", colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvProduct, "제품명", "ProdName", colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvProduct, "제품분류", "ProdType", colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvProduct, "제품단가", "ProdPrice", DataGridViewContentAlignment.MiddleRight);
            DataGridViewUtil.AddGridTextColumn(dgvProduct, "제품이미지", "ProdImage", visibility :false) ;
            DataGridViewUtil.AddGridTextColumn(dgvProduct, "최소주문수량", "MiniPordersQuantity", DataGridViewContentAlignment.MiddleRight, colWidth: 110);
            DataGridViewUtil.AddGridTextColumn(dgvProduct, "생산소요시간", "ProdTime", DataGridViewContentAlignment.MiddleRight, colWidth: 110);

            LoadData();


            List<CommonVO> list = comServ.GetCodeList("Product");
            CommonUtil.ComboBinding(cboProdType, list, "Product", blankText: "선택");
            CommonUtil.ComboBinding(cboProdTypeSearch, list, "Product", blankText: "선택");
        }

        private void LoadData()
        {
            prodAllList = prodServ.GetProductAllList();
            dgvProduct.DataSource = prodAllList;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (!CheckIsNullOrEmpty())
            {
                return;
            }

            ProductVO newProduct = new ProductVO
            {
                ProdID = txtProdID.Text,
                ProdName = txtProdName.Text,
                ProdType = cboProdType.SelectedValue.ToString(),
                ProdPrice = Convert.ToInt32(txtProdPrice.Text),
                ProdImage = currentFileName,
                MiniPordersQuantity = Convert.ToInt32(txtMiniQuantity.Text),
                ProdTime = txtProdTime.Text
            };
            
            bool result = prodServ.InsertProduct(newProduct);
            if (result)
            {
                MessageBox.Show("등록이 완료되었습니다.");
                LoadData();
            }
            else
            {
                MessageBox.Show("등록 중 오류가 발생했습니다. 다시 시도하여 주십시오.");
            }
            ClearControls();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProduct.SelectedRows.Count < 1)
            {
                MessageBox.Show("삭제할 자재를 선택하여 주십시오.");
            }

            string pID = dgvProduct.SelectedRows[0].Cells["ProdID"].Value.ToString();

            if (MessageBox.Show("정말 삭제하실겁니까?", "제품 삭제", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                bool result = prodServ.DeleteProduct(pID);
                if (result)
                {
                    MessageBox.Show("제품정보가 삭제되었습니다.");
                    LoadData();
                    
                }
                else
                {
                    MessageBox.Show("삭제 중 오류가 발생했습니다. 다시 시도하여 주십시오.");
                }
            }
            ClearControls();
        }

        private void dgvProduct_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>-1)
            {
                txtProdID.Text = dgvProduct["ProdID", e.RowIndex].Value.ToString();
                txtProdName.Text = dgvProduct["ProdName", e.RowIndex].Value.ToString();
                txtProdPrice.Text = dgvProduct["ProdPrice", e.RowIndex].Value.ToString();
                cboProdType.SelectedValue = dgvProduct["ProdType", e.RowIndex].Value.ToString();
                string serverUrl = ConfigurationManager.AppSettings["apiurl"];             
                this.currentFileName = dgvProduct["ProdImage", e.RowIndex].Value.ToString();
                string imgurl = $"{serverUrl}Uploads/{currentFileName}";
                ptbProd.ImageLocation = imgurl;
                txtProdTime.Text = dgvProduct["ProdTime", e.RowIndex].Value.ToString();
                txtMiniQuantity.Text = dgvProduct["MiniPordersQuantity", e.RowIndex].Value.ToString();

            }
        }

        private async void btnImage_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProdID.Text))
            {
                MessageBox.Show("이미지를 넣을 제품을 먼저 선택해주세요.");
                return;
            }

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Images File(*.gif;*.jpg;*.jpeg;*.png;*.bmp;*.jfif)|*.gif;*.jpg;*.jpeg;*.png;*.bmp;*.jfif";
            if (dlg.ShowDialog() == DialogResult.OK)
            {

                //파일업로드 API서비스 호출
                CallService srv = new CallService();
                FilePathVO file = await srv.ServerUpload(dlg.FileName);

                if (file.IsSuccess)
                    MessageBox.Show("업로드 완료");
                else
                    MessageBox.Show("업로드 실패");

                currentFileName = file.FileName;
                string serverUrl = ConfigurationManager.AppSettings["apiurl"];
                string imgurl = $"{serverUrl}Uploads/{currentFileName}";

                ptbProd.ImageLocation = imgurl;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!CheckIsNullOrEmpty())
                return;

            ProductVO newProduct = new ProductVO
            {
                ProdID = txtProdID.Text,
                ProdName = txtProdName.Text,
                ProdType = cboProdType.SelectedValue.ToString(),
                ProdPrice = Convert.ToInt32(txtProdPrice.Text),
                ProdImage = currentFileName,
                MiniPordersQuantity = Convert.ToInt32(txtMiniQuantity.Text),
                ProdTime = txtProdTime.Text
            };

            bool result = prodServ.UpdateProduct(newProduct);
            if (result)
            {
                MessageBox.Show("수정이 완료되었습니다.");
                LoadData();
                
            }
            else
            {
                MessageBox.Show("수정 중 오류가 발생했습니다. 다시 시도하여 주십시오.");
            }
            ClearControls();
        }

        private bool CheckIsNullOrEmpty()
        {
            foreach (Control ct in this.Controls)
            {               
                if (string.IsNullOrEmpty(ct.Text) && ct is TextBox)
                {
                    MessageBox.Show($"{ct.Tag.ToString()}값을 입력해주세요");
                    return false;
                }
            }
            if (cboProdType.SelectedIndex == 0)
            {
                MessageBox.Show($"제품 타입을 선택해주세요");
                return false;
            }

            if (string.IsNullOrEmpty(currentFileName))
            {
                MessageBox.Show($"이미지를 선택해주세요");
                return false;
            }

            return true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string prodID = txtProdSearch.Text;
            string prodType = cboProdTypeSearch.SelectedValue.ToString();

            List<ProductVO> list = prodServ.GetProductSearchList(prodID, prodType);
            dgvProduct.DataSource = list;
        }

        private void ClearControls()
        {
            foreach (Control ct in groupBox1.Controls)
            {
                if (!(ct is  Label))
                    ct.Text = "";
                if(ct is ComboBox cbo)
                {
                    cbo.SelectedIndex = 0;
                }
            }
            currentFileName = null;
            ptbProd.ImageLocation = currentFileName;
        }

    }
}

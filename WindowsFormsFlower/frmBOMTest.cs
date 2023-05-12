using FlowerVO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WindowsFormsFlower;

namespace WindowsFormsFlower
{
    public partial class frmBOMTest : WindowsFormsFlower.BaseForm.frmListDetail
    {
        List<BOMVO> bomAllList = null;
        BOMService bomService = new BOMService();
        ProductService proService = new ProductService();
        MaterialService matService = new MaterialService();
        

        List<MaterialBOMVO> materialBOMAllList = null;
        List<ProductVO> productAllList = null;
        List<MaterialVO> materialAllList = null;

        public frmBOMTest()
        {
            InitializeComponent();
        }

        private void frmBOMTest_Load(object sender, EventArgs e)
        {
            proService = new ProductService();
            matService = new MaterialService();

            //DataGridViewUtil.SetInitGridView(dgvBOMProduct);
            //DataGridViewUtil.AddGridTextColumn(dgvBOMProduct, "제품ID", "ProdID", colWidth: 100);
            //DataGridViewUtil.AddGridTextColumn(dgvBOMProduct, "제품명", "ProdName", colWidth: 100);
            //DataGridViewUtil.AddGridTextColumn(dgvBOMProduct, "제품분류", "ProdType", colWidth: 100);
            //DataGridViewUtil.AddGridTextColumn(dgvBOMProduct, "제품단가", "ProdPrice", DataGridViewContentAlignment.MiddleRight);
            //DataGridViewUtil.AddGridTextColumn(dgvBOMProduct, "제품이미지", "ProdImage", visibility: false);
            //DataGridViewUtil.AddGridTextColumn(dgvBOMProduct, "최소주문수량", "MiniPordersQuantity", DataGridViewContentAlignment.MiddleRight, colWidth: 110);
            //DataGridViewUtil.AddGridTextColumn(dgvBOMProduct, "생산소요시간", "ProdTime", DataGridViewContentAlignment.MiddleRight, colWidth: 110);


            //DataGridViewUtil.SetInitGridView(dgvBOMMat);

            //DataGridViewUtil.AddGridTextColumn(dgvBOMMat, "자재 ID", "MaterialID");
            //DataGridViewUtil.AddGridTextColumn(dgvBOMMat, "자재명", "MaterialName");
            //DataGridViewUtil.AddGridTextColumn(dgvBOMMat, "자재분류", "MaterialType");

            //DataGridViewUtil.SetInitGridView(dgvBOMMatP);

            //DataGridViewUtil.AddGridTextColumn(dgvBOMMatP, "자재 ID", "MaterialID");
            //DataGridViewUtil.AddGridTextColumn(dgvBOMMatP, "자재명", "MaterialName");
            //DataGridViewUtil.AddGridTextColumn(dgvBOMMatP, "수량", "MaterialQuantity");
            //LoadData();

        }

        private void LoadData()
        {
            productAllList = proService.GetProductAllList();
            materialAllList = matService.GetMaterialsAllList();
            
            
            //dgvBOMProduct.DataSource = productAllList;         
            //dgvBOMMat.DataSource = materialAllList;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string prodID = txtProSearch.Text;
            string prodType = txtProSearch.Text;

            //List<ProductVO> list = proService.GetProductSearchList(prodID, prodType);
            //dgvBOMProduct.DataSource = list;
        }

        private void btnItemSave_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(nmMatQuantity.Value) <= 0)
            {
                MessageBox.Show("재료 수량을 입력해주세요.");
                return;
            }

            MaterialBOMVO newMat = new MaterialBOMVO
            {
                MaterialID = txtMatID.Text,
                MaterialName = txtMatName.Text,
                MaterialQuantity = Convert.ToInt32(nmMatQuantity.Value)
            };

            materialBOMAllList.Add(newMat);

            dgvBOMMatP.DataSource = null;
            dgvBOMMatP.DataSource = materialBOMAllList;
        }

        private void btnBomSave_Click(object sender, EventArgs e)
        {
            //materialBOMAllList을 DB에 저장 
            //신규저장 (삽입)
            //수정  (삭제 => 삽입)            
            bool result = bomService.InsertBOM(txtProdID.Text, materialBOMAllList);
            if (result)
            {
                materialAllList.Clear();
                dgvBOMMatP.DataSource = null;

                MessageBox.Show("저장이 완료되었습니다.");
            }
            else
            {
                MessageBox.Show("저장 중 오류가 발생했습니다. 다시 시도하여 주십시오.");
            }


        }

        private void btnItemDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMatID.Text))
            {
                MessageBox.Show("삭제할 아이템을 선택하여 주십시오.");
            }

            //리스트에서 삭제하고, 데이터바인딩 다시
            int idx = materialBOMAllList.FindIndex((p) => p.MaterialID == txtMatID.Text);
            materialBOMAllList.RemoveAt(idx);

            dgvBOMMatP.DataSource = null;
            dgvBOMMatP.DataSource = materialBOMAllList;
        }

        private void btnBOMUpdate_Click(object sender, EventArgs e)
        {
           //지워야 함 필요 없음
        }

        private void dgvBOMProduct_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex > -1)
            //{
            //    txtProdID.Enabled = false;

            //    string ProdID = dgvBOMProduct["ProdID", e.RowIndex].Value.ToString();
            //    int idx = productAllList.FindIndex((prod) => prod.ProdID == ProdID);

            //    txtProdID.Text = productAllList[idx].ProdID;
            //    txtprodName.Text = productAllList[idx].ProdName;

            //    //이미등록된 BOM이 있으면 조회해서 materialBOMAllList 에 저장해둔다.


            //    if (materialBOMAllList == null)
            //    {
            //        materialBOMAllList = new List<MaterialBOMVO>();
            //    }

            //    dgvBOMMatP.DataSource = null;
            //    dgvBOMMatP.DataSource = materialBOMAllList;
            //}
        }

        private void dgvBOMMat_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                txtMatID.Enabled = false;

                string MaterialID = dgvBOMMat["MaterialID", e.RowIndex].Value.ToString();
                int idx = materialAllList.FindIndex((mat) => mat.MaterialID == MaterialID);

                txtMatID.Text = materialAllList[idx].MaterialID;
                txtMatName.Text = materialAllList[idx].MaterialName;
            }
        }
    }
}

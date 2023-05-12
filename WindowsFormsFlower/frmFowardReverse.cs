using FlowerVO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace WindowsFormsFlower
{
    public partial class frmFowardReverse : WindowsFormsFlower.BaseForm.frmListDetailSearch
    {
        List<BOMVO> bomAllList = null;        
        List<MaterialBOMVO> materialBOMAllList = null;
        List<ProductVO> prodAllList = null;
        List<MaterialVO> materialAllList = null;

        BOMService bomService = new BOMService();
        ProductService proService = new ProductService();
        MaterialService matService = new MaterialService();
        CommonService comServ = new CommonService();

        
        
        public string currentFileName { get; set; }
        public frmFowardReverse()
        {
            InitializeComponent();
            ptbProd.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        private void frmFowardReverse_Load(object sender, EventArgs e)
        {
            proService = new ProductService();
            matService = new MaterialService();



            DataGridViewUtil.SetInitGridView(dgvFRInfo);
            DataGridViewUtil.AddGridTextColumn(dgvFRInfo, "정보", "info");
            DataGridViewUtil.AddGridTextColumn(dgvFRInfo, "재료명", "ProdName");
            DataGridViewUtil.AddGridTextColumn(dgvFRInfo, "재료 코드", "ProdID");
            DataGridViewUtil.AddGridTextColumn(dgvFRInfo, "수량", "Quantity");
            DataGridViewUtil.AddGridTextColumn(dgvFRInfo, "단계", "levels");
            DataGridViewUtil.AddGridTextColumn(dgvFRInfo, "전개", "SortOrder");

            DataGridViewUtil.SetInitGridView(dgvFR);


            DataGridViewUtil.AddGridTextColumn(dgvFR, "재품 코드", "ProdID");
            DataGridViewUtil.AddGridTextColumn(dgvFR, "재품명", "ProdName");
            DataGridViewUtil.AddGridTextColumn(dgvFR, "유형", "ProdType");

               

            

            DataGridViewUtil.SetInitGridView(dgvRV);
            DataGridViewUtil.AddGridTextColumn(dgvRV, "재료 코드", "MaterialID");
            DataGridViewUtil.AddGridTextColumn(dgvRV, "재료명", "MaterialName");
            DataGridViewUtil.AddGridTextColumn(dgvRV, "유형", "MaterialType");



            DataGridViewUtil.SetInitGridView(dgvRVInfo);
            DataGridViewUtil.AddGridTextColumn(dgvRVInfo, "자재명", "ProdID");
            DataGridViewUtil.AddGridTextColumn(dgvRVInfo, "자재 코드", "ProdName");
            
            LoadData();

            

        }

        private void LoadData()
        {

            prodAllList = proService.GetProductBOMAllList();
            materialAllList = matService.GetMaterialsAllList();


            dgvFR.DataSource = prodAllList;
            dgvRV.DataSource = materialAllList;
        }
       

        private void button1_Click(object sender, EventArgs e) //조회
        {  //
            string prodID = txtProdCodeMain.Text;

            List<BOMVO> list = proService.GetBOMAllListFW(prodID);
            dgvFRInfo.DataSource = list;

            //string matID = txtProdCodeMain.Text;

            List<BOMVO> listRV = proService.GetBOMAllListRV(prodID);
            var listBom = (from rv in listRV
                       join p in prodAllList
                       on rv.PRNTMatCode equals p.ProdID
                       select new
                       {
                           ProdID = p.ProdID,
                           ProdName = p.ProdName
                       }).ToList();

            dgvRVInfo.DataSource = listBom;

        }

        private void dgvFR_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                txtProdNamemain.Enabled = false;

                string ProdID = dgvFR["ProdID", e.RowIndex].Value.ToString();
                int idx = prodAllList.FindIndex((bom) => bom.ProdID == ProdID);

                txtProdCodeMain.Text = prodAllList[idx].ProdID;
                txtProdNamemain.Text = prodAllList[idx].ProdName;
                txtType.Text = prodAllList[idx].ProdType;
                
                string serverUrl = ConfigurationManager.AppSettings["apiurl"];
                this.currentFileName = prodAllList[idx].ProdImage;
                string imgurl = $"{serverUrl}Uploads/{currentFileName}";
                ptbProd.ImageLocation = imgurl;

                



            }
            
        }

        private void btnFRSearch_Click(object sender, EventArgs e)
        {
            if (cboFR.SelectedIndex == 0)
            {
                LoadData();
                dgvFR.DataSource = prodAllList;
            }
            else if (cboFR.SelectedIndex == 1)
            {
                LoadData();
                prodAllList = prodAllList.FindAll((x) => x.ProdType == "완제품");
                dgvFR.DataSource = prodAllList;
            }
            else
            {
                LoadData();
                materialAllList = materialAllList.FindAll((x) => x.MaterialType == "자재");
                dgvFR.DataSource = prodAllList;
            }
        }

        private void cboFR_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboFR.SelectedIndex == 0)
            {
                dgvRV.Visible = false;
                dgvFR.Visible = true;
                dgvFRInfo.Visible = true;
                dgvRVInfo.Visible = false;
                dgvFR.DataSource = prodAllList;
            }
            else 
            {
                dgvRV.Visible = true;
                dgvFR.Visible = false;
                dgvFRInfo.Visible = false;
                dgvRVInfo.Visible = true;
                dgvRV.DataSource = materialAllList;
            }
           

        }

        private void dgvRV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex > -1)
            {
                txtProdNamemain.Enabled = false;

                string matID = dgvRV["MaterialID", e.RowIndex].Value.ToString();
                int idx = materialAllList.FindIndex((bom) => bom.MaterialID == matID);

                txtProdCodeMain.Text = materialAllList[idx].MaterialID;
                txtProdNamemain.Text = materialAllList[idx].MaterialName;
                txtType.Text = materialAllList[idx].MaterialType;
                string serverUrl = ConfigurationManager.AppSettings["apiurl"];
                this.currentFileName = materialAllList[idx].MaterialImage;
                string imgurl = $"{serverUrl}Uploads/{currentFileName}";
                ptbProd.ImageLocation = imgurl;





            }
        }
    }
}

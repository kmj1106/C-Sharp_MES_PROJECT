using FlowerVO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using WindowsFormsFlower;

namespace WindowsFormsFlower
{
    public partial class frmBOMMain : WindowsFormsFlower.BaseForm.frmDataGridBasic
    {
        List<BOMVO> BomAllList = null;
        BOMService bomService = new BOMService();
        CommonService comServ = new CommonService();

        public frmBOMMain()
        {
            InitializeComponent();
        }

        private void btnBOMSearch_Click(object sender, EventArgs e)
        {
            string prodID = txtBOMName.Text;


            List<BOMVO> list = bomService.GetBOMSearchList(prodID);
            dgvBOMMain.DataSource = list;          
        }

        private void frmBOMMain_Load(object sender, EventArgs e)
        {
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            DataGridViewButtonColumn buttonColumnt = new DataGridViewButtonColumn();
            DataGridViewUtil.SetInitGridView(dgvBOMMain);
           

            DataGridViewUtil.AddGridTextColumn(dgvBOMMain, "ProdID", "ProdID");
            DataGridViewUtil.AddGridTextColumn(dgvBOMMain, "MatID", "MatID");           
            DataGridViewUtil.AddGridTextColumn(dgvBOMMain, "부모 코드", "PRNTMatCode");
            DataGridViewUtil.AddGridTextColumn(dgvBOMMain, "수량", "Quantity");
            buttonColumn.HeaderText = "BOM등록";
            buttonColumn.Name = "BOM등록";
            buttonColumnIdx = dgvBOMMain.Columns.Add(buttonColumn);

            buttonColumnt.HeaderText = "정전개/역전개";
            buttonColumnt.Name = "정전개/역전개";
            buttonColumnIdxt = dgvBOMMain.Columns.Add(buttonColumnt);
            foreach (DataGridViewRow row in dgvBOMMain.Rows)
                row.Cells[buttonColumnIdx].Value = "BOM 등록";
            foreach (DataGridViewRow row in dgvBOMMain.Rows)
                row.Cells[buttonColumnIdxt].Value = "정전개/역전개";
            dgvBOMMain.CellClick += dgvBOMMain_CellClick;


            LoadData();

            List<CommonVO> list = comServ.GetCodeList("BOM");
            CommonUtil.ComboBinding(cboBOMType, list, "BOM", blankText: "선택");
            
        }
        
        int buttonColumnIdx;
        int buttonColumnIdxt;
        void dgvBOMMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.ColumnIndex == buttonColumnIdx)
            {
                frmBOMReg frm = new frmBOMReg();               
                frm.Show();
            }
            else
            {
                frmFowardReverse frm = new frmFowardReverse();
                frm.Show();
            }
        }
        



        private void LoadData()
        {
            BomAllList = bomService.GetBOMAllList();


            dgvBOMMain.DataSource = BomAllList;
        }
    }
}

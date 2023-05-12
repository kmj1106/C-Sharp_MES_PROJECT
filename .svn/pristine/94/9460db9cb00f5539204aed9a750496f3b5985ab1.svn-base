using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FlowerVO;

namespace WindowsFormsFlower
{
    public partial class frmOrderOutcome : WindowsFormsFlower.frmListListVertical
    {
        OutcomeService outServ = new OutcomeService();
        BOMService bomServ = new BOMService();
        SaleService saleServ = new SaleService();
        List<OrderOutcomeVO> ooList;
        List<SaleVO> sList;
        List<OrderDetailVO> odList;
        public frmOrderOutcome()
        {
            InitializeComponent();
        }

        private void frmOrderOutcome_Load(object sender, EventArgs e)
        {
            DataGridViewUtil.SetInitGridView(dgvWating);
            DataGridViewUtil.AddGridTextColumn(dgvWating, "판매ID", "SaleID");
            DataGridViewUtil.AddGridTextColumn(dgvWating, "판매상세ID", "SaleDetailID");
            DataGridViewUtil.AddGridTextColumn(dgvWating, "제품ID", "ProdID");
            DataGridViewUtil.AddGridTextColumn(dgvWating, "수량", "Quantity");
            DataGridViewUtil.AddGridTextColumn(dgvWating, "주문날짜", "OrderDate");
            DataGridViewUtil.AddGridTextColumn(dgvWating, "배송희망일", "DueDate");

            DataGridViewUtil.SetInitGridView(dgvOutcome);
            DataGridViewUtil.AddGridTextColumn(dgvOutcome, "출고ID", "OutcomeID");
            DataGridViewUtil.AddGridTextColumn(dgvOutcome, "판매상세ID", "SaleDetailID");
            DataGridViewUtil.AddGridTextColumn(dgvOutcome, "제품ID", "ProdID");
            DataGridViewUtil.AddGridTextColumn(dgvOutcome, "수량", "Quantity");
            DataGridViewUtil.AddGridTextColumn(dgvOutcome, "출고날짜", "OutcomeDate");

            LoadData();
        }

        private void LoadData()
        {
            sList = saleServ.GetSaleDetailList();
            dgvWating.DataSource = sList.FindAll((x)=>x.IsState=="준비중");
            ooList = outServ.GetOutcomeAllList();
            dgvOutcome.DataSource = ooList;
        }

        private void dgvOutcomeDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;       


        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (dgvWating.SelectedRows.Count < 1)
            {
                MessageBox.Show("출고할 판매내역을 선택하여 주십시오.");
                return;
            }

            string pID = dgvWating.SelectedRows[0].Cells["ProdID"].Value.ToString();
            int sdID = Convert.ToInt32(dgvWating.SelectedRows[0].Cells["SaleDetailID"].Value);

            var list = bomServ.GetBOMProd(pID);
            if (list.Count < 1)
            {
                MessageBox.Show($"BOM이 등록되어 있지 않습니다.");
                return;
            }

            odList = outServ.CheckIsMake(pID, sdID);

            if (odList.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                for (int i =0; i < odList.Count; i++)
                {
                    
                    sb.Append($"{odList[i].MaterialName}의 수량이 {(odList[i].Quantity * -1)}개 부족합니다\n");
                }             
                MessageBox.Show(sb.ToString());
            }
            else
            {
                List<MaterialBOMVO> bom = bomServ.GetBOMMat(pID);
                bool result = outServ.RegisterOutcome(sList.Find((x) =>x.SaleDetailID == sdID),bom);

                if (result)
                {
                    dgvWating.DataSource = null;
                    dgvOutcome.DataSource = null;

                    MessageBox.Show("출고가 처리되었습니다.");

                    bool sResult = saleServ.SaleDone(sdID);
                    LoadData();
                }
                else
                {
                    MessageBox.Show("출고처리 중 오류가 발생했습니다. 다시 시도하여 주십시오.");
                }
            }

        }

        private void btnWaitSearch_Click(object sender, EventArgs e)
        {
            string dtFrom = periodUserControl1.From;
            string dtTo = periodUserControl1.To;

            dgvWating.DataSource = sList.FindAll((x) => x.IsState == "준비중" && x.OrderDate <Convert.ToDateTime(dtFrom) && x.OrderDate > Convert.ToDateTime(dtTo));
        }
    }
}

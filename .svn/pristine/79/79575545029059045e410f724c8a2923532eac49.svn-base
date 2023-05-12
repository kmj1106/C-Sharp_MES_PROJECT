using FlowerVO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace WindowsFormsFlower
{
    public partial class frmSales : WindowsFormsFlower.frmListListVertical
    {
        SaleService saleServ = new SaleService();
        List<SaleVO> sList;
        List<SaleVO> sdList;
        List<SaleVO> RList;
        bool sResult;
        public frmSales()
        {
            InitializeComponent();
            rboAll.CheckedChanged += Button_CheckedChanged;
            rboWaiting.CheckedChanged += Button_CheckedChanged;
            rboReady.CheckedChanged += Button_CheckedChanged;
            rboEnd.CheckedChanged += Button_CheckedChanged;

        }

        private void Button_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton btn = sender as RadioButton;
            if (btn.Tag.ToString() == "전체내역")
            {
                LoadData();
                dgvSale.DataSource = sList;
            }
            else
            {
                List<SaleVO> list =
                sdList.FindAll((x) => x.IsState == btn.Tag.ToString());
                var c = (from s in sList
                         join b in list on s.SaleID equals b.SaleID
                         select s).ToList();
                dgvSale.DataSource = c;
            }
            
        }

        private void frmSales_Load(object sender, EventArgs e)
        {
            DataGridViewUtil.SetInitGridView(dgvSale);
            DataGridViewUtil.AddGridTextColumn(dgvSale, "주문ID", "SaleID");
            DataGridViewUtil.AddGridTextColumn(dgvSale, "고객ID", "UserID");
            ;
            DataGridViewUtil.AddGridTextColumn(dgvSale, "주문날짜", "OrderDate");
            DataGridViewUtil.AddGridTextColumn(dgvSale, "배송희망일", "DueDate");          

            DataGridViewUtil.SetInitGridView(dgvSaleDetail);
            DataGridViewUtil.AddGridTextColumn(dgvSaleDetail, "주문ID", "SaleDetailID");
            DataGridViewUtil.AddGridTextColumn(dgvSaleDetail, "제품ID", "ProdID");
            DataGridViewUtil.AddGridTextColumn(dgvSaleDetail, "수량", "Quantity");
            DataGridViewUtil.AddGridTextColumn(dgvSaleDetail, "주문상태", "IsState");
            LoadData();
        }

        private void LoadData()
        {
            sList = saleServ.GetSaleAllList();
            sdList = saleServ.GetSaleDetailList();
            RList = saleServ.GetReserveAllList();
            dgvSale.DataSource = sList;
        }

        private void dgvSale_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSale.SelectedRows.Count < 1)
            {
                MessageBox.Show("판매내역을 선택하여 주십시오.");
                return;
            }
            int sID = Convert.ToInt32(dgvSale.SelectedRows[0].Cells["SaleID"].Value);
            
            dgvSaleDetail.DataSource = sdList.FindAll((x) => x.SaleID == sID);
            dgvSaleDetail.ClearSelection();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (dgvSale.SelectedRows.Count < 1)
            {
                MessageBox.Show("판매내역을 선택하여 주십시오.");
                return;
            }
           
            if (dgvSaleDetail.SelectedRows.Count < 1)
            {
                int sID = Convert.ToInt32(dgvSale.SelectedRows[0].Cells["SaleID"].Value);
                sdList = saleServ.GetSaleDetailList(sID);

                if (sdList.FindAll((x) => x.IsState == "주문대기").Count > 0)
                {

                    sResult = saleServ.ComfirmSale(sID);
                    CheckResult(sResult,"승인");
                }
                else
                    MessageBox.Show("주문대기중인 내역이 아닙니다.");
            }
            else
            {
                if (dgvSaleDetail.SelectedRows[0].Cells["IsState"].Value.ToString() == "주문대기")
                {
                    int sID = Convert.ToInt32(dgvSaleDetail.SelectedRows[0].Cells["SaleDetailID"].Value);
                    sResult = saleServ.ComfirmSale(sID, Detail: true);
                    CheckResult(sResult, "승인");
                }
                else
                    MessageBox.Show("주문대기중인 내역이 아닙니다.");
            }

            
        }

        //주문 승인 체크
        private void CheckResult(bool result, string check)
        {
            if (result)
            {
                dgvSaleDetail.DataSource = null;

                MessageBox.Show($"주문이 {check}되었습니다.");
                LoadData();
            }
            else
            {
                MessageBox.Show($"주문{check} 중 오류가 발생했습니다. 다시 시도하여 주십시오.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (dgvSale.SelectedRows.Count < 1)
            {
                MessageBox.Show("판매내역을 선택하여 주십시오.");
                return;
            }

            if (dgvSaleDetail.SelectedRows.Count < 1)
            {
                int sID = Convert.ToInt32(dgvSale.SelectedRows[0].Cells["SaleID"].Value);
                sdList = saleServ.GetSaleDetailList(sID);

                if (sdList.FindAll((x) => x.IsState == "주문대기" || x.IsState == "준비중").Count > 0)
                {
                    sResult = saleServ.CancelSale(sID);
                    CheckResult(sResult,"취소");
                }
                else
                    MessageBox.Show("취소 가능한 내역이 없습니다.");
            }
            else
            {
                if (dgvSaleDetail.SelectedRows[0].Cells["IsState"].Value.ToString() != "출고완료")
                {
                    int sID = Convert.ToInt32(dgvSaleDetail.SelectedRows[0].Cells["SaleDetailID"].Value);
                    sResult = saleServ.CancelSale(sID, Detail: true);
                    CheckResult(sResult, "취소");
                }
                else
                    MessageBox.Show("취소 가능한 내역이 없습니다.");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string dtFrom = periodUserControl1.From;
            string dtTo = periodUserControl1.To;

            sList = saleServ.GetSaleSearchList(dtFrom, dtTo);
            dgvSale.DataSource = sList;
        }
    }
}

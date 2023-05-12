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
    public partial class frmOrderIncome : WindowsFormsFlower.frmListListVertical
    {
        CommonService comServ = new CommonService();
        OrderService ordServ = new OrderService();
        List<OrderIncomeVO> oList;
        List<OrderDetailVO> odList;
        List<OrderIncomeVO> oiList;
        int remain;

        public frmOrderIncome()
        {
            InitializeComponent();
            nuQuantity.Maximum = 0;
            rboAll.CheckedChanged += Button_CheckedChanged;
            rboNotin.CheckedChanged += Button_CheckedChanged;
            rboIn.CheckedChanged += Button_CheckedChanged;
        }
        private void Button_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton btn = sender as RadioButton;
            if (btn.Text == "전체내역")
            {
                LoadData();
                dgvIncome.DataSource = oList;
            }
            else if(btn.Text == "미입고") dgvIncome.DataSource = oList.FindAll((x) => x.IncomeQuantity != x.Quantity); 
            else dgvIncome.DataSource = oList.FindAll((x) => x.IncomeQuantity == x.Quantity);

        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string dtFrom = periodUserControl1.From;
            string dtTo = periodUserControl1.To;

            oList = ordServ.GetOrderSearchList(dtFrom, dtTo);
            dgvIncome.DataSource = oList;
        }

        private void frmOrderIncome_Load(object sender, EventArgs e)
        {
            DataGridViewUtil.SetInitGridView(dgvIncome);
            DataGridViewUtil.AddGridTextColumn(dgvIncome, "발주ID", "OrderID");
            DataGridViewUtil.AddGridTextColumn(dgvIncome, "발주상세ID", "OrderDetailID");
            DataGridViewUtil.AddGridTextColumn(dgvIncome, "납기일", "ReceiveDate");
            DataGridViewUtil.AddGridTextColumn(dgvIncome, "발주요청일", "RequiredDate");
            DataGridViewUtil.AddGridTextColumn(dgvIncome, "재료ID", "MaterialID");
            DataGridViewUtil.AddGridTextColumn(dgvIncome, "재료명", "MaterialName");
            DataGridViewUtil.AddGridTextColumn(dgvIncome, "총수량", "Quantity");
            DataGridViewUtil.AddGridTextColumn(dgvIncome, "입고수량", "IncomeQuantity");
            DataGridViewUtil.AddGridTextColumn(dgvIncome, "단위가격", "UnitPrice");

            DataGridViewUtil.SetInitGridView(dgvIncomeDetail);
            DataGridViewUtil.AddGridTextColumn(dgvIncomeDetail, "발주상세ID", "OrderDetailID");
            DataGridViewUtil.AddGridTextColumn(dgvIncomeDetail, "입고ID", "IncomeID");
            DataGridViewUtil.AddGridTextColumn(dgvIncomeDetail, "입고수량", "IncomeCount");
            DataGridViewUtil.AddGridTextColumn(dgvIncomeDetail, "입고날짜", "IncomeDate");

            List<CommonVO> cclist = comServ.GetCodeList("Customer");
            CommonUtil.ComboBinding(cboCustomer, cclist, "Customer", blankText: "선택");

            List<CommonVO> cmlist = comServ.GetCodeList("MaterialAll");
            CommonUtil.ComboBinding(cboMaterial, cmlist, "MaterialAll", blankText: "선택");

            LoadData();
        }

        private void LoadData()
        {
            //oList = ordServ.GetOrderAllList(true);
            odList = ordServ.GetOrderDetailAllList();
            oiList = ordServ.GetOrderIncomeAllList();



            oList = ordServ.GetOrderList();
            dgvIncome.DataSource = oList;
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {          

            if (dgvIncome.SelectedRows.Count < 1)
            {
                MessageBox.Show("입고할 입고내역을 선택하여 주십시오.");
                return;
            }          
            
            if (remain == 0)
            {
                MessageBox.Show("입고가 완료된 내역입니다.");
                return;
            }

            if (nuQuantity.Value ==0)
            {
                MessageBox.Show("입고수량을 입력해주세요.");
                return;
            }

            int odID = Convert.ToInt32(dgvIncome.SelectedRows[0].Cells["OrderDetailID"].Value);
            
            bool result = ordServ.RegisterIncome(odID, (int)nuQuantity.Value);

            if (result)
            {
                dgvIncomeDetail.DataSource = null;
                dgvIncome.DataSource = null;

                MessageBox.Show("입고가 처리되었습니다.");
                LoadData();
            }
            else
            {
                MessageBox.Show("입고처리 중 오류가 발생했습니다. 다시 시도하여 주십시오.");
            }
        }

        private void dgvIncome_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            remain = Convert.ToInt32(dgvIncome.SelectedRows[0].Cells["Quantity"].Value) - Convert.ToInt32(dgvIncome.SelectedRows[0].Cells["IncomeQuantity"].Value);
            nuQuantity.Maximum = remain;

            int odID = Convert.ToInt32(dgvIncome["OrderDetailID", e.RowIndex].Value);

            var list = oiList.FindAll((x) => x.OrderDetailID == odID);

            dgvIncomeDetail.DataSource = list;

        }

        private void nuQuantity_ValueChanged(object sender, EventArgs e)
        {
            if (nuQuantity.Value > nuQuantity.Maximum)
            {
                nuQuantity.Value = nuQuantity.Maximum;
                MessageBox.Show("입고 최대수량입니다.");
            }

            if (nuQuantity.Value < 0)
            {
                nuQuantity.Value = 0;
            }

        }

        private void cboCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCustomer.SelectedIndex < 1)
            {
                LoadData();
                return;
            }

            dgvIncome.DataSource = oList.FindAll((x) => x.CusID == cboCustomer.SelectedValue.ToString());
        }

        private void cboMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMaterial.SelectedIndex < 1)
            {
                LoadData();
                return;
            }

            dgvIncome.DataSource = oList.FindAll((x) => x.MaterialID == cboMaterial.SelectedValue.ToString());
        }
    }
}

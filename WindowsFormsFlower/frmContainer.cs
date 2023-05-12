using FlowerVO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsFlower
{
    public partial class frmContainer : WindowsFormsFlower.frmListShowAndSearch
    {
        ContainerService conServ = new ContainerService();
        CommonService comServ = new CommonService();
        OrderService ordServ = new OrderService();
        CustomerService cusServ = new CustomerService();
        List<CustomerVO> cusList;
        List<ContainerVO> cList;
        List<ContainerVO> mList;
        string curCustomer;
        List<OrderDetailVO> orderMat = new List<OrderDetailVO>();
        public frmContainer()
        {
            InitializeComponent();
        }

        private void frmContainer_Load(object sender, EventArgs e)
        {
            DataGridViewUtil.SetInitGridView(dgvContainer);
            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            chk.ValueType = typeof(bool);
            chk.Name = "OrderCheck";
            chk.HeaderText = "발주선택";
            chk.Width = 60;
            dgvContainer.Columns.Add(chk);
            DataGridViewUtil.AddGridTextColumn(dgvContainer, "자재ID", "MaterialID");
            DataGridViewUtil.AddGridTextColumn(dgvContainer, "자재명", "MaterialName");
            DataGridViewUtil.AddGridTextColumn(dgvContainer, "주거래처", "MainCustomer");
            DataGridViewUtil.AddGridTextColumn(dgvContainer, "거래처명", "CusName");
            DataGridViewUtil.AddGridTextColumn(dgvContainer, "안전재고", "SafeStock");
            DataGridViewUtil.AddGridTextColumn(dgvContainer, "위험재고", "EmergenctStock");
            DataGridViewUtil.AddGridTextColumn(dgvContainer, "현재재고", "StockQuantity");
            DataGridViewUtil.AddGridTextColumn(dgvContainer, "가격", "MatPrice");

            DataGridViewUtil.SetInitGridView(dgvMatDetail);

            DataGridViewUtil.AddGridTextColumn(dgvMatDetail, "구분", "Division");
            DataGridViewUtil.AddGridTextColumn(dgvMatDetail, "입/출고ID", "ID");
            DataGridViewUtil.AddGridTextColumn(dgvMatDetail, "날짜", "Date");
            DataGridViewUtil.AddGridTextColumn(dgvMatDetail, "수량", "Quantity");

            List<CommonVO> cclist = comServ.GetCodeList("Customer");
            CommonUtil.ComboBinding(cboCustomer, cclist, "Customer", blankText: "선택");

            LoadData();
        }

        private void LoadData()
        {
            cList =conServ.GetMaterialAllList();
            mList = conServ.GetMaterialDetailList();
            cusList = cusServ.GetCustomerAllList();

            dgvContainer.DataSource = cList;
            dgvContainer.ClearSelection();
        }

        private void dgvContainer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvContainer.SelectedRows.Count < 1)
            {
                MessageBox.Show("내역을 확인할 자재를 선택해주세요");
                return;
            }
                

            string mID = dgvContainer.SelectedRows[0].Cells["MaterialID"].Value.ToString();

            dgvMatDetail.DataSource = mList.FindAll((x) => x.MaterialID == mID);
            dgvMatDetail.ClearSelection();
        }

        private void dgvContainer_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (Convert.ToInt32(dgvContainer.Rows[e.RowIndex].Cells["StockQuantity"].Value) < Convert.ToInt32(dgvContainer.Rows[e.RowIndex].Cells["EmergenctStock"].Value))
            {
                e.CellStyle.BackColor = Color.Red;
                e.CellStyle.ForeColor = Color.White;
            }
            // 데이터가 Blue인 경우 배경색을 파랑으로 변경
            else if (Convert.ToInt32(dgvContainer.Rows[e.RowIndex].Cells["StockQuantity"].Value) < Convert.ToInt32(dgvContainer.Rows[e.RowIndex].Cells["SafeStock"].Value))
            {
                e.CellStyle.BackColor = Color.Yellow;
                e.CellStyle.ForeColor = Color.White;
            }
            // 그 외의 경우 기본 디자인으로 보여준다
            else
            {
                e.CellStyle.BackColor = Color.White;
                e.CellStyle.ForeColor = Color.Black;
            }


        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvContainer.DataSource = cList.FindAll((x) => x.MaterialName.Contains(txtMat.Text));
        }



        private void dgvContainer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Check to ensure that the row CheckBox is clicked.
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                //Reference the GridView Row.
                DataGridViewRow row = dgvContainer.Rows[e.RowIndex];


                //거래처가 선택되어있는지 확인

                if((int)row.Cells["SafeStock"].Value - (int)row.Cells["StockQuantity"].Value<1)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dgvContainer.Rows[e.RowIndex].Cells["OrderCheck"];
                    chk.Value = false;
                    dgvContainer.EndEdit();
                    dgvContainer.Update();
                    MessageBox.Show("안전재고만큼 재고가 남아있습니다.");
                    return;
                }

                if (orderMat.Count < 1)
                {
                    curCustomer = row.Cells["MainCustomer"].Value.ToString();
                    orderMat.Add(new OrderDetailVO
                    {
                        MaterialID = row.Cells["MaterialID"].Value.ToString(),
                        MaterialName = row.Cells["MaterialName"].Value.ToString(),
                        Quantity = (int)row.Cells["SafeStock"].Value - (int)row.Cells["StockQuantity"].Value,
                        UnitPrice = (int)row.Cells["MatPrice"].Value
                    });
                }
                else
                {
                    if (curCustomer != row.Cells["MainCustomer"].Value.ToString())
                    {
                        DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dgvContainer.Rows[e.RowIndex].Cells["OrderCheck"];
                        chk.Value = false;
                        dgvContainer.EndEdit();
                        dgvContainer.Update();
                        MessageBox.Show("동일한 거래처가 아닙니다.");                        
                    }
                    else
                    {
                        if (row.Cells["OrderCheck"].Value == null)
                        {
                            row.Cells["OrderCheck"].Value = !Convert.ToBoolean(row.Cells["OrderCheck"].EditedFormattedValue);
                            orderMat.Add(new OrderDetailVO
                            {
                                MaterialID = row.Cells["MaterialID"].Value.ToString(),
                                MaterialName = row.Cells["MaterialName"].Value.ToString(),
                                Quantity = (int)row.Cells["SafeStock"].Value - (int)row.Cells["StockQuantity"].Value,
                                UnitPrice = (int)row.Cells["MatPrice"].Value
                            });
                            MessageBox.Show("발주재료: " + string.Join(",", orderMat));
                        }
                        else
                        {
                            row.Cells["OrderCheck"].Value = !Convert.ToBoolean(row.Cells["OrderCheck"].EditedFormattedValue);
                            orderMat.RemoveAll((x) => x.MaterialID == row.Cells["MaterialID"].Value.ToString());
                        }

                    }
                }

                //Set the CheckBox selection.
                

            }
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            if(orderMat == null)
            {
                MessageBox.Show("발주할 자재를 선택해주세요");
            }

            CustomerVO cusInfo = cusList.Find((x) => x.CusID == curCustomer);
            if (cusInfo != null)
            {
                OrderVO quickOrder = new OrderVO
                {
                    CusID = cusInfo.CusID,
                    CusName = cusInfo.CusName,
                    RequiredDate = DateTime.Now.AddDays(3)
                };
                bool result = ordServ.RegisterOrder(quickOrder, orderMat);

                if (result)
                {
                    orderMat.Clear();
                    MessageBox.Show("발주가 승인되었습니다.");
                }
                else
                {
                    MessageBox.Show("발주승인 중 오류가 발생했습니다. 다시 시도하여 주십시오.");
                }
            }
            else
                MessageBox.Show("거래처가 없습니다");



        }

        private void cboCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCustomer.SelectedIndex < 1)
            {
                LoadData();
                return;
            }

            dgvContainer.DataSource = cList.FindAll((x)=>x.MainCustomer ==cboCustomer.SelectedValue.ToString());

        }

        private void splitContainer3_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

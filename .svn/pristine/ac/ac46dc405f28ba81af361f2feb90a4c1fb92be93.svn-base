using FlowerDAC;
using FlowerVO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data.OleDb;
using System.Linq;

namespace WindowsFormsFlower
{
    public partial class frmOrderCheck : WindowsFormsFlower.BaseForm.frmListListDetail
    {
        List<OrderDetailVO> orderList = null; //발주목록
        OrderService ordServ = new OrderService();
        MaterialService matServ = new MaterialService();
        CustomerService cusServ = new CustomerService();
        CusMatService cusmatServ = new CusMatService();
        CommonService comServ = new CommonService();
        List<MaterialVO> mlist;
        List<CustomerVO> clist;
        List<CusMatVO> cmlist;
        decimal tot;
        string curCustomer;
        string saveFileName;
        public frmOrderCheck()
        {
            InitializeComponent();
        }

        private void frmOrderCheck_Load(object sender, EventArgs e)
        {
            //제품 데이터그리드뷰 컬럼 셋팅
            DataGridViewUtil.SetInitGridView(dgvMaterial);
            DataGridViewUtil.AddGridTextColumn(dgvMaterial, "자재ID", "MaterialID");
            DataGridViewUtil.AddGridTextColumn(dgvMaterial, "자재명", "MaterialName");
            DataGridViewUtil.AddGridTextColumn(dgvMaterial, "자재분류", "MaterialType");
            DataGridViewUtil.AddGridTextColumn(dgvMaterial, "단위", "MaterialUnit");
            DataGridViewUtil.AddGridTextColumn(dgvMaterial, "최소수량", "MatStock");
            DataGridViewUtil.AddGridTextColumn(dgvMaterial, "유통기한", "MaterialToDate");
            DataGridViewUtil.AddGridTextColumn(dgvMaterial, "거래처명", "CusName");
            DataGridViewUtil.AddGridTextColumn(dgvMaterial, "거래처ID", "CusID");

            DataGridViewUtil.SetInitGridView(dgvOrderDetail);
            DataGridViewUtil.AddGridTextColumn(dgvOrderDetail, "자재ID", "MaterialID");
            DataGridViewUtil.AddGridTextColumn(dgvOrderDetail, "자재명", "MaterialName");
            DataGridViewUtil.AddGridTextColumn(dgvOrderDetail, "수량", "Quantity");
            DataGridViewUtil.AddGridTextColumn(dgvOrderDetail, "가격", "UnitPrice");
            

            LoadData();
        }

        private void LoadData(string cusID = "", string matName = "")
        {
            mlist = matServ.GetMaterialsAllList();
            clist = cusServ.GetCustomerAllList();
            cmlist = cusmatServ.GetCusMatAllList();
            var cmList = (from m in mlist
                          join cm in cmlist on m.MaterialID equals cm.MaterialID into g
                          from gg in g
                          join c in clist on gg.CusID equals c.CusID
                          select new
                          {
                              MaterialID = m.MaterialID,
                              MaterialName = m.MaterialName,
                              MaterialType = m.MaterialType,
                              MaterialUnit = m.MaterialUnit,
                              MatStock = m.MatStock,
                              MatCategory = m.MatCategory,
                              MaterialToDate = m.MaterialToDate,
                              CusID = c.CusID,
                              CusName = c.CusName,
                              Cuslicense = c.Cuslicense,
                              CusManager = c.CusManager,
                              CusCharge = c.CusCharge,
                              CusPhone = c.CusPhone,
                              CusEmail = c.CusEmail
                          }).ToList();
            if (matName == "")
            {
                dgvMaterial.DataSource = cmList.FindAll((x) => x.CusID.Contains(cusID));
                if (cusID == "")
                {
                    List<CommonVO> cclist = comServ.GetCodeList("Customer");
                    CommonUtil.ComboBinding(cboCustomer, cclist, "Customer", blankText: "선택");
                }
            }
            else
            {
                dgvMaterial.DataSource = cmList.FindAll((x) => x.MaterialName.Contains(matName));
                if(cboCustomer.SelectedIndex > 0)
                {
                    dgvMaterial.DataSource = cmList.FindAll((x) => x.MaterialName.Contains(matName) && x.CusID.Contains(cboCustomer.SelectedValue.ToString()));
                }
            }
        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            //유효성체크(재료선택은 했는지, 주문수량이 0 이상인지)
            if (lblMatName.Text == null || (int)nuQuantity.Value < 1)
            {
                MessageBox.Show("발주할 재료/수량을 선택하여 주십시오.");
                return;
            }

            //처리로직
            if (curCustomer != null && curCustomer != lblCusName.Text)
            {
                MessageBox.Show("거래처가 다릅니다");
                return;
            }
                

            if (orderList == null || orderList.Count<1)
            {
                orderList = new List<OrderDetailVO>();
                curCustomer = lblCusName.Text;
                lblCurCustomer.Text = curCustomer;
            }


            string matId = lblMatID.Text;
            int idx = orderList.FindIndex((mat) => mat.MaterialID == matId);
            if (idx >= 0)
            {
                //이미 선택된 재료가 발주목록에 추가되는 경우
                orderList[idx].Quantity += (int)nuQuantity.Value;
            }
            else
            {
                //신규로 재료를 발주목록에 추가하는 경우
                OrderDetailVO newItem = new OrderDetailVO
                {
                    MaterialID = matId,
                    MaterialName = lblMatName.Text,
                    Quantity = (int)nuQuantity.Value,
                    UnitPrice = Convert.ToDecimal(txtPrice.Text)

                };
                orderList.Add(newItem);
            }

            dtpRequiredDate.MinDate = DateTime.Now.AddDays(3);

            //orderList를 dgvOrderDetail에 바인딩
            LoadDetailData();

            
        }

        private void LoadDetailData()
        {
            dgvOrderDetail.DataSource = null;
            dgvOrderDetail.DataSource = orderList;
            tot = orderList.Sum(x => x.Quantity * x.UnitPrice);
            nuQuantity.Minimum = 0;
            txtPrice.Text = "";
            lblTot.Text = tot.ToString();

            dgvOrderDetail.ClearSelection();
        }

        private void btnOrderDel_Click(object sender, EventArgs e)
        {
            //유효성검사(삭제할 제품을 선택했는지)
            if (dgvOrderDetail.SelectedRows.Count < 1)
            {
                MessageBox.Show("삭제할 제품을 선택하여 주십시오.");
                return;
            }

            //처리
            string matId = dgvOrderDetail.SelectedRows[0].Cells["MaterialID"].Value.ToString();
            int idx = orderList.FindIndex((mat) => mat.MaterialID == matId);
            if (idx >= 0)
            {
                orderList.RemoveAt(idx);

                LoadDetailData();
            }

            if (orderList.Count < 1)
            {
                curCustomer = null;
                lblCurCustomer.Text = "";
            }
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {

            //유효성체크(orderList의 건수가 있는지)

            if (orderList == null || orderList.Count < 1)
            {
                MessageBox.Show("발주할 재료를 추가하여 주십시오.");
                return;
            }

            //처리로직(OrderVO, List<OrderDetailVO>)
            OrderVO order = new OrderVO
            {
                CusID = lblCusID.Text,
                CusName = lblCusName.Text,
                RequiredDate = Convert.ToDateTime(dtpRequiredDate.Value)
            };

            bool result = ordServ.RegisterOrder(order, orderList);
            if (result)
            {
                ExportExcel();
                orderList.Clear();
                curCustomer = null;
                dgvOrderDetail.DataSource = null;
                lblTot.Text = "0";
                lblCurCustomer.Text = "";

                MessageBox.Show("발주가 완료되었습니다.");
            }
            else
            {
                MessageBox.Show("발주처리 중 오류가 발생했습니다. 다시 시도하여 주십시오.");
            }
            
        }
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        private void ExportExcel()
        {
            //저장할 디렉토리, 파일명을 물어보고, 그 파일경로로 엑셀파일 저장
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Excel Files(*.xlsx)|*.xlsx";
            dlg.Title = "엑셀파일로 내보내기";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                saveFileName = dlg.FileName;
                WindowsFormsAppFlower.frmWaitAsyncForm frm = new WindowsFormsAppFlower.frmWaitAsyncForm(MakeExcel);
                frm.ShowDialog();
            }
        }

        private void MakeExcel()
        {
            string t_file = Application.StartupPath.ToString().Substring(0, Application.StartupPath.Length - 10) + @"\Templates\Order.xlsx";
            Excel.Application xlApp = new Excel.Application();
            //템플릿파일을 오픈하는 경우
            Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(t_file);
            //Excel.Workbook xlWorkBook = xlApp.Workbooks.Add();
            Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            xlWorkSheet.Cells[3, 3] = lblCusName.Text;
            xlWorkSheet.Cells[4, 3] = lblCusManager.Text;
            xlWorkSheet.Cells[5, 3] = lblTelNum.Text;
            xlWorkSheet.Cells[6, 3] = lblEmail.Text;
            xlWorkSheet.Cells[8, 3] = dtpRequiredDate.Value.ToShortDateString();
            xlWorkSheet.Cells[10, 3] = lblTot.Text;
            MaterialVO mat;
            for (int r = 0; r < orderList.Count; r++)
            {
                mat = mlist.Find((x) => x.MaterialID == orderList[r].MaterialID);
                xlWorkSheet.Cells[r + 14, 2] = mat.MaterialName;
                xlWorkSheet.Cells[r + 14, 5] = mat.MaterialUnit;
                xlWorkSheet.Cells[r + 14, 6] = orderList[r].Quantity;
                xlWorkSheet.Cells[r + 14, 7] = orderList[r].UnitPrice;
                xlWorkSheet.Cells[r + 14, 12] = orderList[r].Quantity * orderList[r].UnitPrice;

            }


            //xls 확장자로 저장하는 경우
            //xlWorkBook.SaveAs(dlg.FileName, Excel.XlFileFormat.xlWorkbookNormal);

            //xlsx 확장자로 저장하는 경우
            xlWorkBook.SaveCopyAs(saveFileName);
            xlWorkBook.Saved = true;

            xlWorkBook.Close(true);
            xlApp.Quit();

            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);

            MessageBox.Show("발주서 작성완료");
        }

        private void dgvMaterial_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
             
            string matID = dgvMaterial["MaterialID", e.RowIndex].Value.ToString();
            string cusID = dgvMaterial["CusID", e.RowIndex].Value.ToString();
            MaterialVO material = mlist.FirstOrDefault((x) => x.MaterialID == matID);
            CustomerVO customer = clist.FirstOrDefault((x) => x.CusID == cusID);
            {
                lblMatName.Text = material.MaterialName;
                lblMatID.Text = material.MaterialID;
                lblCusName.Text = dgvMaterial["CusName", e.RowIndex].Value.ToString();
                lblCusID.Text = dgvMaterial["CusID", e.RowIndex].Value.ToString();
                lblCusManager.Text = customer.CusManager;
                lblEmail.Text = customer.CusEmail;
                lblTelNum.Text = customer.CusPhone;
                lblStock.Text = material.MatStock;
                lblUnit.Text = material.MaterialUnit;
                nuQuantity.Minimum = Convert.ToInt32(material.MatStock);
                txtPrice.Text = material.MatPrice.ToString();


            }
        }

        private void cboCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCustomer.SelectedIndex < 1)
            {
                LoadData();
                txtMat.Text = "";
            }
            string cusID = cboCustomer.SelectedValue.ToString();
            LoadData(cusID);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData(matName:txtMat.Text);
        }
    }
}

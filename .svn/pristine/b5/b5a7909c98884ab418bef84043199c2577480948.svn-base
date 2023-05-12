using FlowerDAC;
using FlowerVO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsFlower
{
    public partial class frmShoppingMall : Form
    {
        List<SaleVO> cartList; //장바구니 
        List<ProductVO> pList; //모든 제품목록
        ProductService prodServ = new ProductService();
        CommonService comServ = new CommonService();
        SaleService saleServ = new SaleService();

        public UserVO LoginUser { get; set; }


        public frmShoppingMall()
        {
            InitializeComponent();
        }

        private void frmProductList_Load(object sender, EventArgs e)
        {
            //장바구니  생성

            //등록된 제품목록을 조회          
            pList = prodServ.GetProductAllList();

            //전달받은 List 로부터 제품user control 바인딩
            ShowProductList(pList);


            List<CommonVO> list = comServ.GetCodeList("Product");
            CommonUtil.ComboBinding(cboCategory, list, "Product", blankText: "선택");
        }

        private void ShowProductList(List<ProductVO> pList)
        {
            //ProdList수를 2로 나눈 몫의 올림
            int iRows = (int)Math.Ceiling(pList.Count / 2.0);
            int idx = 0;
            for (int r = 0; r < iRows; r++)
            {
                for (int i = 0; i < 2; i++)
                {
                    if (idx >= pList.Count) break;

                    ucProduct ctrl = new ucProduct();
                    ctrl.Location = new Point(20 + (230 * i), 10 + (130 * r));
                    ctrl.Size = new Size(203, 110);
                    ctrl.ProductInfo = pList[idx];
                    ctrl.AddCart += Ctrl_AddCart;
                    panel1.Controls.Add(ctrl);
                    idx++;
                }
            }
        }

        private void Ctrl_AddCart(object sender, EventArgs e)
        {
            ucProduct selProd = (ucProduct)sender;
            //장바구니에 담은 적이 있으면 수량과 금액이 증가, 신규로 담으면 행이 추가
            if (cartList == null)
            {
                cartList = new List<SaleVO>();
            }
            int idx = cartList.FindIndex((prod) => prod.ProdID == selProd.ProductInfo.ProdID);

            if (idx >= 0)
            {
                //이미 선택된 제품이 장바구니에 추가하는 경우
                cartList[idx].Quantity = cartList[idx].Quantity +1;
                cartList[idx].ProdPrice = cartList[idx].Quantity * selProd.ProductInfo.ProdPrice;
            }
            else
            {
                //신규로 제품을 장바구니 추가하는 경우
                SaleVO newItem = new SaleVO
                {
                    ProdID = selProd.ProductInfo.ProdID,
                    ProdName = selProd.ProductInfo.ProdName,
                    Quantity = 1,
                    ProdPrice = selProd.ProductInfo.ProdPrice,
                };
                cartList.Add(newItem);
            }

            ShowCartItem();
        }

        public void ShowCartItem()
        {
            panel2.Controls.Clear();

            int tot = 0;
            int idx = 0;
            foreach (SaleVO prod in cartList)
            {
                ucCartItem item = new ucCartItem();
                item.Location = new Point(3, 3 + (idx * 53));
                item.Size = new Size(422, 52);

                item.ProductInfo = pList.Find((x) => x.ProdID == prod.ProdID);
                item.ItemQty = prod.Quantity;

                item.DelCartItem += Item_DelCartItem;
                item.UpdateQty += Item_UpdateQty;

                panel2.Controls.Add(item);

                idx++;
                tot += prod.ProdPrice;
            }

            lblTotal.Text = $"{tot.ToString("#,##0")} 원";
        }

        private void Item_UpdateQty(object sender, CartItemQtyEventArgs e)
        {
            string pID = e.ProductID;
            int rows = cartList.FindIndex((x)=>x.ProdID ==pID);
            if (rows > -1)
            {
                int price = cartList[rows].ProdPrice / cartList[rows].Quantity; //단가
                cartList[rows].Quantity = e.Qty;
                cartList[rows].ProdPrice = e.Qty * price;
;
                ShowCartItem();
            }
        }

        private void Item_DelCartItem(object sender, CartItemEventArgs e)
        {
            string delPID = e.ProductID;
            int idx = cartList.FindIndex((x) => x.ProdID == delPID);
            if (idx > -1)
            {
                cartList.RemoveAt(idx);

                ShowCartItem();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            foreach (ucCartItem item in panel2.Controls)
            {
                item.IsChecked = checkBox1.Checked;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (ucCartItem item in panel2.Controls)
            {
                if (item.IsChecked)
                {
                    int idx = cartList.FindIndex((x) => x.ProdID == item.ProductInfo.ProdID);
                    if (idx >= 0)
                    {
                        cartList.RemoveAt(idx);

                        ShowCartItem();
                    }
                }
            }
            ShowCartItem();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();

            ShowProductList(pList.FindAll((x) => x.ProdName.Contains(txtKeyword.Text)));

        }


        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCategory.SelectedIndex > 0)
            {
                panel1.Controls.Clear();
                ShowProductList(pList.FindAll((x) => x.ProdType.Contains(cboCategory.SelectedValue.ToString())));
            }
        }

        private void lklPrice_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            SaleVO userInfo = new SaleVO
            {
                UserID = LoginUser.UserID,
                DueDate = DateTime.Now.AddDays(7),
                DueAddress1 = LoginUser.Address1,
                DueAddress2 = LoginUser.Address2,
                OrderDate = DateTime.Now
            };
            bool result = saleServ.RegisterSale(userInfo, cartList);

            if (result)
            {
                panel2.Controls.Clear();
                cartList = null;
                lblTotal.Text = "";

                MessageBox.Show("주문이 처리되었습니다.");
            }
            else
            {
                MessageBox.Show("주문처리 중 오류가 발생했습니다. 다시 시도하여 주십시오.");
            }
        }

    }
}

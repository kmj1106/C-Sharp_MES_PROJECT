using FlowerVO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsFlower
{
    public delegate void CartItemHandler(object sender, CartItemEventArgs e);
    public delegate void CartItemQtyHandler(object sender, CartItemQtyEventArgs e);

    public partial class ucCartItem : UserControl
    {
        ProductVO curProduct;
        public event CartItemHandler DelCartItem; //삭제버튼을 클릭할때 발생하는 이벤트
        public event CartItemQtyHandler UpdateQty; //수량이 변경될때 발생하는 이벤트

        public int ItemQty 
        { 
            get { return (int)numQty.Value;  }
            set { numQty.Value = value;  } 
        }

        public ProductVO ProductInfo
        {
            get
            {
                return curProduct;
            }
            set
            {
                curProduct = value;
                string serverUrl = ConfigurationManager.AppSettings["apiurl"];
                string imgurl = $"{serverUrl}Uploads/{value.ProdImage}";
                pictureBox1.ImageLocation = imgurl;
                lblProductName.Text = value.ProdName;
                lblPrice.Text = value.ProdPrice.ToString("#,##0") + " 원";
            }
        }

        public bool IsChecked 
        { 
            get { return checkBox1.Checked; }
            set { checkBox1.Checked = value; } 
        }

        public ucCartItem()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DelCartItem != null)
            {
                CartItemEventArgs args = new CartItemEventArgs();
                args.ProductID = curProduct.ProdID;
                DelCartItem(this, args);
            }
        }

        private void numQty_ValueChanged(object sender, EventArgs e)
        {
            if (UpdateQty != null)
            {
                CartItemQtyEventArgs args = new CartItemQtyEventArgs();
                args.ProductID = curProduct.ProdID;
                args.Qty = (int)numQty.Value;

                UpdateQty(this, args);
            }
        }
    }

    public class CartItemEventArgs : EventArgs
    {
        public string ProductID { get; set; }
    }

    public class CartItemQtyEventArgs : EventArgs
    {
        public string ProductID { get; set; }
        public int Qty { get; set; }
    }
}

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
    public partial class ucProduct : UserControl
    {
        ProductVO curProduct;

        public event EventHandler AddCart;

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
                lblTitle.Text = value.ProdName;
                lblPrice.Text = value.ProdPrice.ToString("#,##0") + " 원";
            }
        }

        public ucProduct()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            if (AddCart != null)
            {
                AddCart(this, null);
            }
        }
    }
}

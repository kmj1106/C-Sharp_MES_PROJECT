using FlowerVO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace WindowsFormsFlower
{

    public partial class frmChart : Form
    {
        OrderService ordServ = new OrderService();
        SaleService saleServ = new SaleService();
        ContainerService conServ = new ContainerService();
        ProductService prodServ = new ProductService();
        List<OrderVO> oList;
        List<OrderIncomeVO> oiList;
        List<SaleVO> sList;
        List<SaleVO> revenueList;
        List<ContainerVO> conList;
        List<ProductVO> pList;


        public frmChart()
        {
            InitializeComponent();
            ptbFirst.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void frmChart_Load(object sender, EventArgs e)
        {

            DataGridViewUtil.SetInitGridView(dgvRank);
            DataGridViewUtil.AddGridTextColumn(dgvRank, "순위", "Rank", colWidth: 40);
            DataGridViewUtil.AddGridTextColumn(dgvRank, "제품이름", "ProdName", colWidth: 80);
            DataGridViewUtil.AddGridTextColumn(dgvRank, "매출액", "TotPrice", colWidth: 80);


            //발주, 입고, 출고 현황 표시
            oList = ordServ.GetOrderAllList();
            lblOrder.Text = oList.FindAll((x) => x.ReceiveDate ==Convert.ToDateTime("0001-01-01")).Count.ToString();

            oiList = ordServ.GetOrderList();
            lblIncome.Text = oiList.FindAll((x) => x.IncomeQuantity != x.Quantity).Count.ToString();

            sList = saleServ.GetSaleDetailList();
            lblOutcome.Text = sList.FindAll((x) => x.IsState == "준비중").Count.ToString();

            //월별 총 매출액 char 그래프로 보여주기
            List<int> monthList = new List<int>();
            for(int i =-5; i < 1; i++)
            {
                monthList.Add(DateTime.Now.AddMonths(i).Month);
            };


            chart1.Series.Add(new Series("매출액"));
            chart1.Series[0].ChartType = SeriesChartType.Column;


            revenueList =saleServ.GetProdRevenue();
            var list = from r in revenueList
                       group r by r.Month into g
                       select new
                       {
                           Month = g.Key,
                           TotPrice = g.Sum(r => r.TotPrice)
                       };

            chart1.DataSource = list;
            chart1.ChartAreas[0].AxisX.Maximum = 12;
            chart1.ChartAreas[0].AxisX.Minimum = 7;
            chart1.ChartAreas[0].AxisX.IsMarginVisible = true;
            chart1.Series[0].XValueMember = "Month";
            chart1.Series[0].YValueMembers = "TotPrice";
            chart1.DataBind();

            //위험재고, 안전재고 현황

            conList = conServ.GetMaterialAllList();

            lblEmergency.Text = conList.FindAll((x) => x.StockQuantity < x.EmergenctStock).Count.ToString();
            lblSafe.Text = conList.FindAll((x) => x.StockQuantity > x.EmergenctStock && x.SafeStock < x.StockQuantity).Count.ToString();



            //이번달 매출 ,매입 
            lblBuy.Text = $"{saleServ.GetTotIncomeByMonth(11).ToString()}원";
            int monthSell = list.ToList().FirstOrDefault((x) => x.Month == 12)?.TotPrice ?? 0;
            lblSell.Text = $"{monthSell.ToString()}원";

            //판매순위
            var topList = (from r in revenueList
                          where r.Month == 12
                          orderby r.TotPrice descending
                           select r).Take(5);
            pList = prodServ.GetProductAllList();
            var tpList = from t in topList
                         join p in pList
                         on t.ProdID equals p.ProdID
                         select new
                         {
                             ProdID = p.ProdID,
                             ProdName = p.ProdName,
                             ProdImage = p.ProdImage,
                             TotPrice = t.TotPrice
                         };
            dgvRank.DataSource = tpList.ToList();
            string serverUrl = ConfigurationManager.AppSettings["apiurl"];
            string imgurl;
            if (tpList.Count() > 0)
                imgurl = $"{serverUrl}Uploads/{tpList.ToList()[0].ProdImage}";
            else
                imgurl = null;
            ptbFirst.ImageLocation = imgurl;
        }

        private void dgvRank_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.dgvRank.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }
    }
}

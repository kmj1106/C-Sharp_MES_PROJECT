using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Configuration;
using System.Xml;

namespace WindowsFormsFlower
{
    public partial class ZipSearchPopup : Form
    {
        public string Zipcode { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }

        public ZipSearchPopup()
        {
            InitializeComponent();
        }

        private void ZipSearchPopup_Load(object sender, EventArgs e)
        {
            DataGridViewUtil.SetInitGridView(dgvZip);
            DataGridViewUtil.AddGridTextColumn(dgvZip, "우편번호", "zipNo", colWidth: 80);
            DataGridViewUtil.AddGridTextColumn(dgvZip, "도로명주소", "roadAddr", colWidth: 200);
            DataGridViewUtil.AddGridTextColumn(dgvZip, "지번주소", "jibunAddr", colWidth: 200);
            DataGridViewUtil.AddGridTextColumn(dgvZip, "도주1", "roadAddrPart1", visibility:false);
            DataGridViewUtil.AddGridTextColumn(dgvZip, "도주2", "roadAddrPart2", visibility: false);
            DataGridViewUtil.AddGridTextColumn(dgvZip, "건물이름", "bdNm", visibility: false);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string apiKey = ConfigurationManager.AppSettings["zipAPIKey"];
            string apiUrl = $"https://www.juso.go.kr/addrlink/addrLinkApi.do?confmKey={apiKey}&currentPage=1&countPerPage=200&keyword={txtSearch.Text}";

            try
            {
                DataSet ds = new DataSet();

                WebClient wc = new WebClient();
                XmlReader read = new XmlTextReader(wc.OpenRead(apiUrl));

                ds.ReadXml(read);

                if (ds.Tables[0].Rows[0]["totalCount"].ToString() != "0")
                {
                    dgvZip.DataSource = ds.Tables[1];
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtSearch.Text.Length > 0 && e.KeyChar == 13)
                btnSearch.PerformClick();
        }

        private void dgvZip_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtJibunZipcode.Text = txtRoadZipcode.Text = dgvZip["zipNo", e.RowIndex].Value.ToString();

            txtRoadAddr1.Text = dgvZip["roadAddrPart1", e.RowIndex].Value.ToString();

            string bdNm = dgvZip["bdNm", e.RowIndex].Value.ToString();
            string addr2 = dgvZip["roadAddrPart2", e.RowIndex].Value.ToString();
            string jibun = dgvZip["jibunAddr", e.RowIndex].Value.ToString();

            txtJibunAddr1.Text = jibun;

            if (addr2.Contains(bdNm))
                txtRoadAddr2.Text = addr2;
            else
                txtRoadAddr2.Text = addr2 + bdNm;
            
            if (jibun.Contains(bdNm))
                txtJibunAddr2.Text = "";
            else
                txtJibunAddr2.Text = bdNm;
        }

        private void btnRoad_Click(object sender, EventArgs e)
        {
            Zipcode = txtRoadZipcode.Text;
            Address1 = txtRoadAddr1.Text;
            Address2 = txtRoadAddr2.Text;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnJibun_Click(object sender, EventArgs e)
        {
            Zipcode = txtJibunZipcode.Text;
            Address1 = txtJibunAddr1.Text;
            Address2 = txtJibunAddr2.Text;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

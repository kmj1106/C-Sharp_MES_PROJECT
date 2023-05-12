using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsFlower
{
    public partial class frmImageRegister : Form
    {
        string ImageID;
        string Category;
        public string destFileName { get; set; }

        public frmImageRegister(string id, string name, string category)
        {
            InitializeComponent();
            ImageID = id;
            txtImageName.Text = name;
            Category = category;

        }
        public frmImageRegister()
        {
            InitializeComponent();
        }

        private void btnSearchImage_Click(object sender, EventArgs e)
        {
            string fileName = ImageUtil.SelectImage();
            if(fileName != null)
            {
                txtImagePath.Text = fileName; //전체경로
                pictureBox1.Image = Image.FromFile(fileName);
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
            
        }

        private void btnImageSave_Click(object sender, EventArgs e)
        {
            try
            {
                string sPath = ConfigurationManager.AppSettings["uploadPath"] + $"{Category}/" + ImageID + "/";
                string localFile = txtImagePath.Text;
                string sExt = localFile.Substring(localFile.LastIndexOf("."));
                string newFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + sExt;
                this.destFileName = sPath + newFileName;

                if (!Directory.Exists(sPath)) //디렉토리가 없다면 디렉토리를 생성
                {
                    Directory.CreateDirectory(sPath);
                }
                File.Copy(localFile, destFileName, true); //파일을 복사

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}

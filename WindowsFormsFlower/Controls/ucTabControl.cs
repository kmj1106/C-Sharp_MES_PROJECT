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
    public partial class ucTabControl : TabControl
    {
        public ucTabControl()
        {
            InitializeComponent();

            this.DrawMode = TabDrawMode.OwnerDrawFixed;
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            base.OnDrawItem(e);

            try
            {
                Rectangle r = e.Bounds;
                r = this.GetTabRect(e.Index);
                r.Offset(2, 2);

                //선택된 탭의 백그라운드색상은 흰색 (나머지 탭은 기본값)
                if (this.SelectedIndex == e.Index)
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.White), e.Bounds);
                }
                //탭의 글씨
                SolidBrush titleBrush = new SolidBrush(Color.Black);
                string title = this.TabPages[e.Index].Text;
                Font f = this.Font;
                e.Graphics.DrawString(title, f, titleBrush, new Point(r.X, r.Y));

                //탭의 닫기 이미지
                //선택된 탭은 빨간색이미지, 선택이 안된 탭은 검정색이미지
                Image img;
                if (this.SelectedIndex == e.Index)
                    img = Properties.Resources.close_red;
                else
                    img = Properties.Resources.close_grey;

                Point imgLocation = new Point(18, 2);

                e.Graphics.DrawImage(img, new Point(r.X + this.GetTabRect(e.Index).Width - imgLocation.X, imgLocation.Y));

                img.Dispose();
                img = null;
            }
            catch
            {

            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}

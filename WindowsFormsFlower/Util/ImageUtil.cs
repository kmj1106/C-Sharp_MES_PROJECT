using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsFlower
{
    public class ImageUtil
    {
        public static string SelectImage()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Images File(*.gif;*.jpg;*.jpeg;*.png;*.bmp;*.jfif)|*.gif;*.jpg;*.jpeg;*.png;*.bmp;*.jfif";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                return dlg.FileName;
            }
            else
                return null;
        }
    }
}

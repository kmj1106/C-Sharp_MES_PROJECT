using FlowerVO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsFlower
{
    class CommonUtil
    {
        public static void ComboBinding(ComboBox cbo, List<CommonVO> list, string gubun,
            bool blankItem=true, string blankText="")
        {
            var codeList = list.Where((item) => item.CCategory.Equals(gubun)).ToList();
            if (blankItem)
            {
                CommonVO blank = new CommonVO
                {
                    CCode = "",
                    CName = blankText,
                    CCategory = gubun
                };
                codeList.Insert(0, blank);
            }

            cbo.DisplayMember = "CName";
            cbo.ValueMember = "CCode";
            cbo.DataSource = codeList;
        }
    }
}

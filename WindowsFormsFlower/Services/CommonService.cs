using FlowerDAC;
using FlowerVO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsFlower
{
    class CommonService
    {
        public List<CommonVO> GetCodeList(string[] categories)
        {
            CommonDAC db = new CommonDAC();
            List<CommonVO> list = db.GetCodeList(categories);
            db.Dispose();

            return list;
        }

        public List<CommonVO> GetCodeList(string category)
        {
            CommonDAC db = new CommonDAC();
            List<CommonVO> list = db.GetCodeList(category);
            db.Dispose();

            return list;
        }
    }
}

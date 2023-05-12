using FlowerDAC;
using FlowerVO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsFlower
{
    class CusMatService
    {
        public List<CusMatVO> GetCusMatAllList()
        {
            CusMatDAC db = new CusMatDAC();
            List<CusMatVO> list = db.GetCusMatAllList();
            db.Dispose();

            return list;
        }

        public bool InsertCusMaterial(CusMatVO cusMat)
        {
            CusMatDAC db = new CusMatDAC();
            bool result = db.InsertCusMaterial(cusMat);
            db.Dispose();

            return result;
        }

        public bool DeleteCusMaterial(string cusMatID)
        {
            CusMatDAC db = new CusMatDAC();
            bool result = db.DeleteCusMaterial(cusMatID);
            db.Dispose();

            return result;
        }
    }
}

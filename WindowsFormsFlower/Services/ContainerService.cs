using FlowerDAC;
using FlowerVO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsFlower
{
    class ContainerService
    {
        public List<ContainerVO> GetMaterialAllList()
        {
            ContainerDAC db = new ContainerDAC();
            List<ContainerVO> list = db.GetMaterialAllList();
            db.Dispose();

            return list;
        }

        public List<ContainerVO> GetMaterialDetailList()
        {
            ContainerDAC db = new ContainerDAC();
            List<ContainerVO> list = db.GetMaterialDetailList();
            db.Dispose();

            return list;
        }


    }
}

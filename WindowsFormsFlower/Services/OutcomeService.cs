using FlowerDAC;
using FlowerVO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsFlower
{
    public class OutcomeService
    {
        public List<OrderOutcomeVO> GetOutcomeAllList()
        {
            OrderOutcomeDAC db = new OrderOutcomeDAC();
            List<OrderOutcomeVO> list = db.GetOutcomeAllList();
            db.Dispose();

            return list;
        }

        public bool RegisterOutcome(SaleVO sdList, List<MaterialBOMVO> bom)
        {
            OrderOutcomeDAC db = new OrderOutcomeDAC();
            bool result = db.RegisterOutcome(sdList, bom);
            db.Dispose();

            return result;
        }


        public List<OrderDetailVO> CheckIsMake(string pID, int sdID)
        {
            OrderOutcomeDAC db = new OrderOutcomeDAC();
            List< OrderDetailVO> list = db.CheckIsMake(pID, sdID);
            db.Dispose();

            return list;
        }
    }
}

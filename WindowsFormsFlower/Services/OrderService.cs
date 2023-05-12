using FlowerDAC;
using FlowerVO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsFlower
{
    class OrderService
    {
        public List<OrderVO> GetOrderAllList(bool receive = false)
        {
            OrderDAC db = new OrderDAC();
            List<OrderVO> list = db.GetOrderAllList(receive);
            db.Dispose();

            return list;
        }

        public bool RegisterOrder(OrderVO ord, List<OrderDetailVO> ordDetail)
        {
            OrderDAC db = new OrderDAC();
            bool result = db.RegisterOrder(ord, ordDetail);
            db.Dispose();

            return result;
        }

        public List<OrderIncomeVO> GetOrderIncomeAllList()
        {
            OrderIncomeDAC db = new OrderIncomeDAC();
            List<OrderIncomeVO> list = db.GetOrderIncomeAllList();
            db.Dispose();

            return list;
        }

        public List<OrderIncomeVO> GetOrderSearchList(string dtFrom, string dtTo, bool receive = false)
        {
            OrderIncomeDAC db = new OrderIncomeDAC();
            List<OrderIncomeVO> list = db.GetOrderSearchList(dtFrom, dtTo,receive );
            db.Dispose();

            return list;
        }

        public List<OrderDetailVO> GetOrderDetailAllList()
        {
            OrderDAC db = new OrderDAC();
            List<OrderDetailVO> list = db.GetOrderDetailAllList();
            db.Dispose();

            return list;
        }

        public bool OrderReceive(int oID)
        {
            OrderDAC db = new OrderDAC();
            bool result = db.OrderReceive(oID);
            db.Dispose();

            return result;
        }

        public bool DeleteOrder(int oID, bool Detail = false)
        {
            OrderDAC db = new OrderDAC();
            bool result = db.DeleteOrder(oID, Detail);
            db.Dispose();

            return result;
        }

        public bool RegisterIncome(int odID, int num)
        {
            OrderIncomeDAC db = new OrderIncomeDAC();
            bool result = db.RegisterIncome(odID,num);
            db.Dispose();

            return result;
        }

        public List<OrderIncomeVO> GetOrderList()
        {
            OrderIncomeDAC db = new OrderIncomeDAC();
            List<OrderIncomeVO> list = db.GetOrderList();
            db.Dispose();

            return list;
        }


        //public bool QuickRegisterOrder(string cID, List<OrderDetailVO> ordDetail)
        //{
        //    OrderDAC db = new OrderDAC();
        //    bool result = db.QuickRegisterOrder(cID, ordDetail);
        //    db.Dispose();

        //    return result;
        //}


        //public List<OrderIncomeVO> GetOrderSearchList(string cusID, string matID, string dtFrom, string dtTo)
        //{
        //    OrderDAC db = new OrderDAC();
        //    List<OrderIncomeVO> list = db.GetOrderSearchList(cusID, dtFrom, dtTo);
        //    db.Dispose();

        //    return list;
        //}


    }
}

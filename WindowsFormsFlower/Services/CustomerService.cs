using FlowerDAC;
using FlowerVO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsFlower
{
    class CustomerService
    {
        public List<CustomerVO> GetCustomerAllList()
        {
            CustomerDAC db = new CustomerDAC();
            List<CustomerVO> list = db.GetCustomerAllList();
            db.Dispose();

            return list;
        }

        public bool InsertCustomers(CustomerVO cus)
        {
            CustomerDAC db = new CustomerDAC();
            bool result = db.InsertCustomers(cus);
            db.Dispose();

            return result;
        }

        public bool UpdateCustomers(CustomerVO cus)
        {
            CustomerDAC db = new CustomerDAC();
            bool result = db.UpdateCustomers(cus);
            db.Dispose();

            return result;
        }

        public bool DeleteCustomers(int pID)
        {
            CustomerDAC db = new CustomerDAC();
            bool result = db.DeleteCustomers(pID);
            db.Dispose();

            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerVO
{
    public class SaleVO
    {
        public int SaleID { get; set; }
        public int SaleDetailID { get; set; }
        public string UserID { get; set; }
        public string ProdID { get; set; }
        public string ProdName { get; set; }
        public int Quantity { get; set; }
        public DateTime DueDate { get; set; }
        public string DueAddress1 { get; set; }
        public string DueAddress2 { get; set; }
        public DateTime OrderDate { get; set; }
        public string IsState { get; set; }
        public int ProdPrice { get; set; }
        public int Month { get; set; }
        public int TotPrice { get; set; }

    }
}

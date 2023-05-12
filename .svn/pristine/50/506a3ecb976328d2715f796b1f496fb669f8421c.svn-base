using FlowerVO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerDAC
{
    public class ContainerDAC
    {
        SqlConnection conn;
        public ContainerDAC()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["local"].ConnectionString);
            conn.Open();
        }


        public void Dispose()
        {
            conn.Close();
        }


        public List<ContainerVO> GetMaterialAllList()
        {
            string sql = @"with IncomeCount as
(
select MaterialID, (sum(Isnull(IncomeCount,0))-sum(Isnull(ocd.Quantity,0))) StockQuantity
from OrderDetail od 
join OrderIncome oi on od.OrderDetailID = oi.OrderDetailID
left join OutcomeDetail ocd on oi.IncomeID = ocd.IncomeID
group by MaterialID
)
select m.MaterialID,MaterialName, SafeStock,EmergenctStock, Isnull(StockQuantity,0) StockQuantity,MainCustomer, MatPrice, CusName
from Materials m 
left join IncomeCount i on m.MaterialID=i.MaterialID
join Customers c on m.MainCustomer = c.CusID";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    return Helper.DataReaderMapToList<ContainerVO>(cmd.ExecuteReader());
                }
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return null;
            }
        }

        public List<ContainerVO> GetMaterialDetailList()
        {
            string sql = @"with MaterialDetail as
(
select MaterialID,oi.IncomeID,IncomeCount,IncomeDate, OutcomeID, ocd.Quantity,OutcomeDate 
from OrderDetail od 
inner join OrderIncome oi on od.OrderDetailID = oi.OrderDetailID
left join (select od.OutcomeID,IncomeID,od.Quantity,OutcomeDate 
			from OutcomeDetail od 
			inner join OrderOutcome ooc on od.OutcomeID=ooc.OutcomeID) ocd on oi.IncomeID = ocd.IncomeID
)
select MaterialID, '입고' Division, IncomeID as ID,IncomeCount as Quantity,IncomeDate as Date from MaterialDetail
Union all
select MaterialID,'출고', OutcomeID, Quantity,OutcomeDate from MaterialDetail where OutcomeID is not null";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    return Helper.DataReaderMapToList<ContainerVO>(cmd.ExecuteReader());
                }
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return null;
            }
        }
    }
}

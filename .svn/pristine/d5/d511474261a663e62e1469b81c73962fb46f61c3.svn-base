using FlowerVO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerDAC
{
    public class OrderOutcomeDAC
    {
        SqlConnection conn;
        public OrderOutcomeDAC()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["local"].ConnectionString);
            conn.Open();
        }
        public void Dispose()
        {
            conn.Close();
        }

        public List<OrderOutcomeVO> GetOutcomeAllList()
        {
            string sql = "select OutcomeID, OutcomeDate, Quantity, ProdID, SaleDetailID from OrderOutcome";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    return Helper.DataReaderMapToList<OrderOutcomeVO>(cmd.ExecuteReader());
                }
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return null;
            }
        }
        public bool RegisterOutcome(SaleVO sdList, List<MaterialBOMVO> bom)
        {
            SqlTransaction trans = conn.BeginTransaction();
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    //출고 마스터 생성
                    cmd.Connection = conn;
                    cmd.Transaction = trans;
                    cmd.CommandText = "insert into OrderOutcome (Quantity, ProdID, SaleDetailID) values (@Quantity, @ProdID, @SaleDetailID);select @@IDENTITY";

                    cmd.Parameters.AddWithValue("@SaleDetailID", sdList.SaleDetailID);
                    cmd.Parameters.AddWithValue("@ProdID", sdList.ProdID);
                    cmd.Parameters.AddWithValue("@Quantity", sdList.Quantity);
                    int newOutComeID = Convert.ToInt32(cmd.ExecuteScalar());                

                    //출고상세 내역 여러건 insert
                    cmd.Parameters.Clear();

                    cmd.CommandText = "MaterialOutcome";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@OutcomeID", SqlDbType.Int);
                    cmd.Parameters.Add("@MaterialID", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@TotCount", SqlDbType.Int);

                    foreach (MaterialBOMVO mat in bom)
                    {
                        cmd.Parameters["@OutcomeID"].Value = newOutComeID;
                        cmd.Parameters["@MaterialID"].Value = mat.MaterialID;
                        cmd.Parameters["@TotCount"].Value = mat.Quantity;

                        cmd.ExecuteNonQuery();
                    }
                    trans.Commit();
                    return true;
                }
            }
            catch (Exception err)
            {
                trans.Rollback();
                Debug.WriteLine(err.Message);
                return false;
            }
        }

        public List<OrderDetailVO> CheckIsMake(string pID, int sdID)
        {
            string sql = @"with  IsMake as
(select c.MaterialID, MaterialName, StockQuantity - b.Quantity * s.Quantity Quantity
from GetProdBOM(@ProdID) b
inner join IncomeCount() c on b.MaterialID = c.MaterialID
join SaleDetail s on s.SaleDetailID = @SaleDetailID
)select* from IsMake where Quantity < 0";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@ProdID", pID);
                    cmd.Parameters.AddWithValue("@SaleDetailID", sdID);
                    return Helper.DataReaderMapToList<OrderDetailVO>(cmd.ExecuteReader());
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

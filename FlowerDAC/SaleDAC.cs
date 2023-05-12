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
    public class SaleDAC :IDisposable
    {
        SqlConnection conn;
        public SaleDAC()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["local"].ConnectionString);
            conn.Open();
        }
        public void Dispose()
        {
            conn.Close();
        }

        public List<SaleVO> GetSaleAllList()
        {
            string sql = "select SaleID, UserID, DueDate, DueAddress1, DueAddress2, OrderDate from Sales";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    return Helper.DataReaderMapToList<SaleVO>(cmd.ExecuteReader());
                }
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return null;
            }
        }
       
        public List<SaleVO> GetReserveAllList()
        {
            string sql = @"select s.SaleID, s.UserID, s.DueDate, b.ProdID, b.IsState, b.Quantity
from Sales as s
Full outer join SaleDetail as b
On s.SaleID = b.SaleID
where USERID = @UserID ";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    return Helper.DataReaderMapToList<SaleVO>(cmd.ExecuteReader());
                }
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return null;
            }
        }

        public List<SaleVO> GetReserveUser(string uID)
        {
            string sql = @" select s.SaleID, SaleDetailID, DueAddress1, DueAddress2, ProdName, OrderDate, Quantity, IsState from Sales s
join SaleDetail sd on s.SaleID = sd.SaleID
join Products p on sd.ProdID = p.ProdID
where s.UserID = @UserID";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", uID);
                    return Helper.DataReaderMapToList<SaleVO>(cmd.ExecuteReader());
                }
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return null;
            }
        }

        public List<SaleVO> GetSaleDetailList(int sID =0)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(@"select SaleDetailID, sd.SaleID, ProdID,IsState, Quantity ,DueDate,OrderDate
from SaleDetail sd
inner
join Sales s on sd.SaleID = s.SaleID where 1 = 1");

            if (sID >0)
            {
                sb.Append(" and sd.SaleID=@SaleID");
            }
            try
            {
                using (SqlCommand cmd = new SqlCommand(sb.ToString(), conn))
                {
                    cmd.Parameters.AddWithValue("@SaleID", sID);
                    return Helper.DataReaderMapToList<SaleVO>(cmd.ExecuteReader());
                }
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return null;
            }
        }

        public bool ComfirmSale(int sID, bool Detail = false)
        {
            try
            {
                if (!Detail)
                {
                    string sql = "update SaleDetail set IsState='준비중' where SaleID=@SaleID";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@SaleID", sID);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                else
                {
                    string sql = "update SaleDetail set IsState='준비중' where SaleDetailID=@SaleDetailID";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@SaleDetailID", sID);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return false;
            }

        }


        public bool CancelSale(int sID, bool Detail = false)
        {

            try
            {
                if (!Detail)
                {
                    string sql = @"update SaleDetail set IsState='주문취소' where SaleID=@SaleID and IsState != '판매완료'";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@SaleID", sID);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                else
                {
                    string sql = @"update SaleDetail set IsState='주문취소' where SaleDetailID=@SaleDetailID and IsState != '판매완료'";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@SaleDetailID", sID);
                    cmd.ExecuteNonQuery();
                    return true;
                }

            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return false;
            }
        }

        public bool RegisterSale(SaleVO sale, List<SaleVO> cart)
        {
            SqlTransaction trans = conn.BeginTransaction();
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.Transaction = trans;

                    //OrderVO 1건 insert
                    cmd.CommandText = @"insert into Sales (UserID, DueDate, DueAddress1, DueAddress2) values(@UserID, @DueDate, @DueAddress1, @DueAddress2); select @@IDENTITY";

                    cmd.Parameters.AddWithValue("@UserID", sale.UserID);
                    cmd.Parameters.AddWithValue("@DueDate", sale.DueDate);
                    cmd.Parameters.AddWithValue("@DueAddress1", sale.DueAddress1);
                    cmd.Parameters.AddWithValue("@DueAddress2", sale.DueAddress2);

                    int newSaleID = Convert.ToInt32(cmd.ExecuteScalar());

                    //OrderDetailVO 여러건 insert
                    cmd.Parameters.Clear();

                    cmd.CommandText = @"insert into SaleDetail(SaleID, ProdID, Quantity) values(@SaleID, @ProdID,@Quantity)";

                    cmd.Parameters.AddWithValue("@SaleID", newSaleID);
                    cmd.Parameters.Add("@ProdID", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@Quantity", SqlDbType.Int);

                    foreach (SaleVO item in cart)
                    {
                        cmd.Parameters["@ProdID"].Value = item.ProdID;
                        cmd.Parameters["@Quantity"].Value = item.Quantity;

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
        public bool SaleDone(int sdID)
        {
            string sql = "Update SaleDetail set IsState ='출고완료' where SaleDetailID =@SaleDetailID ";
            try
            {
                using (SqlCommand cmd = new SqlCommand(sql,conn))
                {
                    cmd.Parameters.AddWithValue("@SaleDetailID", sdID);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return false;
            }

        }

        public List<SaleVO> GetSaleSearchList(string dtFrom, string dtTo)
        {

            string sql = @"select SaleID, UserID, DueDate, DueAddress1, DueAddress2, OrderDate from Sales where OrderDate between @dtFrom and @dtTo ";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@dtFrom", dtFrom);
                    cmd.Parameters.AddWithValue("@dtTo", dtTo);

                    return Helper.DataReaderMapToList<SaleVO>(cmd.ExecuteReader());
                }
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return null;
            }

        }

        public List<SaleVO> GetProdRevenue()
        {
            string sql = @"select p.ProdID, DATEPART(mm,OutcomeDate) as 'Month', Sum(Quantity*ProdPrice) as TotPrice from OrderOutcome oc 
join Products p on oc.ProdID = p.ProdID
group by p.ProdID,DATEPART(mm, OutcomeDate)";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    return Helper.DataReaderMapToList<SaleVO>(cmd.ExecuteReader());
                }
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return null;
            }
        }

        public int GetTotIncomeByMonth(int month)
        {
            string sql = "select [dbo].GetTotIncomeByMonth(@Month)";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Month", month);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return 0;
            }
        }
    }
}

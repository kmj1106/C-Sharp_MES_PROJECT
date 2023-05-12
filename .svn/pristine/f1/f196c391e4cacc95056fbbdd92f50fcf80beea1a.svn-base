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
    public class OrderDAC : IDisposable
    {
        SqlConnection conn;
        public OrderDAC()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["local"].ConnectionString);
            conn.Open();
        }
        public void Dispose()
        {
            conn.Close();
        }

        public List<OrderVO> GetOrderAllList(bool receive = false)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select OrderID, CusID, RequiredDate, CusName, OrderDate, ReceiveDate from [dbo].[Order] where 1=1");

            if (receive)
            {
                sb.Append(" and ReceiveDate is not null");
            }
            try
            {
                using (SqlCommand cmd = new SqlCommand(sb.ToString(), conn))
                {
                    return Helper.DataReaderMapToList<OrderVO>(cmd.ExecuteReader());
                }
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return null;
            }
        }

        public bool RegisterOrder(OrderVO ord, List<OrderDetailVO> ordDetail)
        {
            SqlTransaction trans = conn.BeginTransaction();
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.Transaction = trans;

                    //OrderVO 1건 insert
                    cmd.CommandText = @"insert into [dbo].[Order] (CusID, CusName,RequiredDate ) values(@CusID, @CusName,@RequiredDate ); select @@IDENTITY";

                    cmd.Parameters.AddWithValue("@CusID", ord.CusID);
                    cmd.Parameters.AddWithValue("@CusName", ord.CusName);
                    cmd.Parameters.AddWithValue("@RequiredDate", ord.RequiredDate);

                    int newOrderID = Convert.ToInt32(cmd.ExecuteScalar());

                    //OrderDetailVO 여러건 insert
                    cmd.Parameters.Clear();

                    cmd.CommandText = @"insert into OrderDetail(OrderID, MaterialID, Quantity, UnitPrice, MaterialName) values(@OrderID, @MaterialID, @Quantity, @UnitPrice, @MaterialName)";
                    
                    cmd.Parameters.AddWithValue("@OrderID", newOrderID);
                    cmd.Parameters.Add("@MaterialID", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@MaterialName", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@UnitPrice", SqlDbType.Money);
                    cmd.Parameters.Add("@Quantity", SqlDbType.SmallInt);

                    foreach (OrderDetailVO item in ordDetail)
                    {
                        cmd.Parameters["@MaterialID"].Value = item.MaterialID;
                        cmd.Parameters["@MaterialName"].Value = item.MaterialName;
                        cmd.Parameters["@UnitPrice"].Value = item.UnitPrice;
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

        

        public List<OrderDetailVO> GetOrderDetailAllList()
        {
            string sql = "select OrderDetailID, OrderID, MaterialID, Quantity, UnitPrice, MaterialName from OrderDetail";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    return Helper.DataReaderMapToList<OrderDetailVO>(cmd.ExecuteReader());
                }
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return null;
            }
        }

        public bool OrderReceive(int oID)
        {
            try
            {
                string sql = "Update [dbo].[Order] set ReceiveDate=@ReceiveDate where OrderID=@OrderID";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@OrderID", oID);
                cmd.Parameters.AddWithValue("@ReceiveDate", DateTime.Now);


                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return false;
            }
        }
        public bool DeleteOrder(int oID, bool Detail = false)
        {
            
            try
            {
                if (!Detail)
                {
                    string sql = @"delete from [dbo].[Order] where OrderID=@OrderID;delete from OrderDetail where OrderID=@OrderID";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@OrderID", oID);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                else
                {
                    string sql = @"delete from OrderDetail where OrderDetailID=@OrderDetailID";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@OrderDetailID", oID);
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




        public List<OrderIncomeVO> GetOrderSearchList(string cusID, string matID, string dtFrom, string dtTo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"select IncomeID, OrderDetailID, IncomeDate, IncomeCount from OrderIncome where OrderDate between @dtFrom and @dtTo ");

            if (!string.IsNullOrWhiteSpace(cusID))
            {
                sb.Append(" and CusID = @CusID ");
            }
            try
            {
                using (SqlCommand cmd = new SqlCommand(sb.ToString(), conn))
                {
                    cmd.Parameters.AddWithValue("@CusID", cusID);
                    cmd.Parameters.AddWithValue("@dtFrom", dtFrom);
                    cmd.Parameters.AddWithValue("@dtTo", dtTo);

                    return Helper.DataReaderMapToList<OrderIncomeVO>(cmd.ExecuteReader());
                }
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return null;
            }
            
        }



//        public bool QuickRegisterOrder(string cID, List<OrderDetailVO> ordDetail)
//        {

//            SqlTransaction trans = conn.BeginTransaction();
//            try
//            {
//                using (SqlCommand cmd = new SqlCommand())
//                {
//                    cmd.Connection = conn;
//                    cmd.Transaction = trans;

//                    //OrderVO 1건 insert
//                    cmd.CommandText = @"DECLARE

//@CusID nvarchar(10),
//@CusName nvarchar(20),
//@RequiredDate Datetime

//select @CusID=CusID,@CusName=CusName,@RequiredDate=dateadd(DAY, 3, GETDATE())
//from Customers where cusID = @CurrentCusID;
//insert into [Order] (CusID, CusName,RequiredDate ) values(@CusID, @CusName,@RequiredDate );select @@IDENTITY";

//                    cmd.Parameters.AddWithValue("@CurrentCusID", cID);

//                    int newOrderID = Convert.ToInt32(cmd.ExecuteScalar());

//                    //OrderDetailVO 여러건 insert
//                    cmd.Parameters.Clear();

//                    cmd.CommandText = @"insert into OrderDetail(OrderID, MaterialID, Quantity, UnitPrice, MaterialName) values(@OrderID, @MaterialID, @Quantity, @UnitPrice, @MaterialName)";

//                    cmd.Parameters.AddWithValue("@OrderID", newOrderID);
//                    cmd.Parameters.Add("@MaterialID", SqlDbType.NVarChar);
//                    cmd.Parameters.Add("@MaterialName", SqlDbType.NVarChar);
//                    cmd.Parameters.Add("@UnitPrice", SqlDbType.Int);
//                    cmd.Parameters.Add("@Quantity", SqlDbType.Int);

//                    foreach (OrderDetailVO item in ordDetail)
//                    {
//                        cmd.Parameters["@MaterialID"].Value = item.MaterialID;
//                        cmd.Parameters["@MaterialName"].Value = item.MaterialName;
//                        cmd.Parameters["@UnitPrice"].Value = item.UnitPrice;
//                        cmd.Parameters["@Quantity"].Value = item.Quantity;

//                        cmd.ExecuteNonQuery();
//                    }
//                    trans.Commit();
//                    return true;
//                }
//            }
//            catch (Exception err)
//            {
//                trans.Rollback();
//                Debug.WriteLine(err.Message);
//                return false;
//            }

//        }
    }
}

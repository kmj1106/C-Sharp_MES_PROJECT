using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerVO;

namespace FlowerDAC
{
    public class CustomerDAC : IDisposable
    {
        SqlConnection conn;

        public CustomerDAC()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["local"].ConnectionString);
            conn.Open();
        }

        public void Dispose()
        {
            conn.Close();
        }

        public List<CustomerVO> GetCustomerAllList()
        {
            string sql = "select CusID, CusName, Cuslicense, CusManager, CusCharge, CusPhone, CusEmail from Customers";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    return Helper.DataReaderMapToList<CustomerVO>(cmd.ExecuteReader());
                }
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return null;
            }
        }


        public bool InsertCustomers(CustomerVO cus)
        {
            try
            {
                string sql = @"insert into Customers(CusID, CusName, Cuslicense, CusManager, CusCharge, CusPhone, CusEmail) 
                    values(@CusID, @CusName, @Cuslicense, @CusManager, @CusCharge, @CusPhone, @CusEmail)";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@CusID", cus.CusID);
                cmd.Parameters.AddWithValue("@CusName", cus.CusName);
                cmd.Parameters.AddWithValue("@Cuslicense", cus.Cuslicense);
                cmd.Parameters.AddWithValue("@CusManager", cus.CusManager);
                cmd.Parameters.AddWithValue("@CusCharge", cus.CusCharge);
                cmd.Parameters.AddWithValue("@CusPhone", cus.CusPhone);
                cmd.Parameters.AddWithValue("@CusEmail", cus.CusEmail);

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return false;
            }
        }

        public bool UpdateCustomers(CustomerVO cus)
        {
            try
            {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = $"UPDATE Customers SET CusID=@CusID,CusName=@CusName,Cuslicense=@Cuslicense,CusManager=@CusManager,CusCharge=@CusCharge,CusPhone=@CusPhone,CusEmail=@CusEmail WHERE CusID=@CusID";

            cmd.Parameters.AddWithValue("@CusID", cus.CusID);
            cmd.Parameters.AddWithValue("@CusName", cus.CusName);
            cmd.Parameters.AddWithValue("@Cuslicense", cus.Cuslicense);
            cmd.Parameters.AddWithValue("@CusManager", cus.CusManager);
            cmd.Parameters.AddWithValue("@CusCharge", cus.CusCharge);
            cmd.Parameters.AddWithValue("@CusPhone", cus.CusPhone);
            cmd.Parameters.AddWithValue("@CusEmail", cus.CusEmail);

            cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return false;
            }
        }

        public bool DeleteCustomers(int CusID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = $"DELETE from Customers WHERE CusID=@CusID";
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@CusID", CusID);

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return false;
            }
        }
    }
}
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerVO;

namespace FlowerDAC
{
    public class CusMatDAC
    {
        SqlConnection conn;

        public CusMatDAC()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["local"].ConnectionString);
            conn.Open();
        }

        public void Dispose()
        {
            conn.Close();
        }

        public List<CusMatVO> GetCusMatAllList()
        {
            string sql = "select CusMatID, CusID, MaterialID from CustomerMaterial";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    return Helper.DataReaderMapToList<CusMatVO>(cmd.ExecuteReader());
                }
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return null;
            }
        }

        public bool InsertCusMaterial(CusMatVO cusMat)
        {
            try
            {
                string sql = @"insert into CustomerMaterial(CusID, MaterialID) 
                    values( @CusID, @MaterialID)";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@CusID", cusMat.CusID);
                cmd.Parameters.AddWithValue("@MaterialID", cusMat.MaterialID);

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return false;
            }
        }

        public bool DeleteCusMaterial(string cusMatID)
        {
            try
            {
                string sql = @"delete from CustomerMaterial where CusMatID = @CusMatID";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@CusMatID", cusMatID);

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
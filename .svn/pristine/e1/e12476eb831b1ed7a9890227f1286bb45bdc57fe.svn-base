using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using FlowerVO;

namespace FlowerDAC
{
    public class BOMDAC : IDisposable
    {
        SqlConnection conn;

        public BOMDAC()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["local"].ConnectionString);
            conn.Open();
        }

        public void Dispose()
        {
            conn.Close();
        }

        public List<BOMVO> GetBOMAllList()
        {
            string sql = @"select ProdID, MatID, PRNTMatCode, Quantity
from FWBOM";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    return Helper.DataReaderMapToList<BOMVO>(cmd.ExecuteReader());
                }
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return null;
            }
        }
        public List<BOMVO> GetBOMSearchList(string ProdID)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"select ProdID, MatID,  PRNTMatCode, Quantity
from FWBOM
where ProdID like @ProdID");
         


            using (SqlCommand cmd = new SqlCommand(sb.ToString(), conn))

            {

                cmd.Parameters.AddWithValue("@ProdID", $"%{ProdID}%");
                


                return Helper.DataReaderMapToList<BOMVO>(cmd.ExecuteReader());

            }


        }
        public bool InsertBOM(string prodID, List<MaterialBOMVO> bom)
        {
            SqlTransaction trans = conn.BeginTransaction();
            try
            {
                string sql = @"delete from FWBOM where ProdID=@ProdID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Transaction = trans;
                cmd.Parameters.AddWithValue("@ProdID", prodID);
                cmd.ExecuteNonQuery();

                cmd.Parameters.Clear();
                cmd.CommandText = @"INSERT INTO FWBOM(ProdID, MatID, PRNTMatCode, Quantity)
VALUES(@ProdID, @MatID, @PRNTMatCode, @Quantity);";

                cmd.Parameters.Add(new SqlParameter("@ProdID", System.Data.SqlDbType.NVarChar));
                cmd.Parameters.Add(new SqlParameter("@MatID", System.Data.SqlDbType.NVarChar));                
                cmd.Parameters.Add(new SqlParameter("@PRNTMatCode", System.Data.SqlDbType.NVarChar));
                cmd.Parameters.Add(new SqlParameter("@Quantity", System.Data.SqlDbType.Int));


                foreach (MaterialBOMVO item in bom)
                {
                    cmd.Parameters["@ProdID"].Value = prodID;
                    cmd.Parameters["@MatID"].Value = item.MaterialID;                    
                    cmd.Parameters["@PRNTMatCode"].Value = prodID;
                    cmd.Parameters["@Quantity"].Value = item.MaterialQuantity;

                    cmd.ExecuteNonQuery();
                }

                trans.Commit();
                return true;
            }
            catch (Exception err)
            {
                trans.Rollback();
                Debug.WriteLine(err.Message);
                throw err;
            }
        }
        public bool DeleteBOMList(string ProdID)
        {
            try
            {
                string sql = @"delete from FWBOM where ProdID=@ProdID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ProdID", ProdID);

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return false;
            }
        }


        public List<MaterialBOMVO> GetBOMProd(string pid)
        {
            
            string sql = @"select MatID as MaterialID, MaterialName, Quantity as MaterialQuantity from FWBOM b join Materials m on b.MatID = m.MaterialID  where ProdID =@ProdID";
            

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@ProdID", pid);
                    return Helper.DataReaderMapToList<MaterialBOMVO>(cmd.ExecuteReader()); ;
                }
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return null;
            }
        }

        public List<MaterialBOMVO> GetBOMMat(string pid)
        {

            string sql = @"select * from GetProdBOM(@ProdID)";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@ProdID", pid);
                    return Helper.DataReaderMapToList<MaterialBOMVO>(cmd.ExecuteReader()); ;
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

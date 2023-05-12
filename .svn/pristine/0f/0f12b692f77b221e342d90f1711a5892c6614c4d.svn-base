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
    public class CommonDAC : IDisposable
    {
        SqlConnection conn;

        public CommonDAC()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["local"].ConnectionString);
            conn.Open();
        }

        public void Dispose()
        {
            conn.Close();
        }

        public List<CommonVO> GetCodeList(string[] categories)
        {
            string category = string.Join("','", categories);

            //수정
            string sql = $@"select CCode, CName, CCategory 
from vw_codeList 
where category in ('{category}')";

            SqlCommand cmd = new SqlCommand(sql, conn);
            List<CommonVO> list;

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                list = Helper.DataReaderMapToList<CommonVO>(reader);
                //Helper.DataReaderMapToList()메서드를 실행하고
                //에러가 나지 않았는데, list = null로 경우

                while (reader.Read())
                {
                    CommonVO item = new CommonVO();
                    item.CCode = reader["CCode"].ToString();
                    item.CName = reader["CName"].ToString();
                    item.CCategory = reader["CCategory"].ToString();

                    list.Add(item);
                }
            }
            return list;
        }

        public List<CommonVO> GetCodeList(string category)
        {            
            string sql = $@"select CCode, CName, CCategory from vw_codeList where CCategory =@CCategory";
            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@CCategory", category);
                    return Helper.DataReaderMapToList<CommonVO>(cmd.ExecuteReader());
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

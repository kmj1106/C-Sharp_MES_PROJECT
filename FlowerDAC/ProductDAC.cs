using FlowerVO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlowerDAC
{
    public class ProductDAC : IDisposable
    {
        SqlConnection conn;
        public ProductDAC()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["local"].ConnectionString);
            conn.Open();
        }
        public void Dispose()
        {
            conn.Close();
        }

        public List<ProductVO> GetProductAllList()
        {
            string sql = "select ProdID, ProdName, ProdType, ProdPrice, ProdImage, MiniPordersQuantity, ProdTime from Products where IsMake =1";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    return Helper.DataReaderMapToList<ProductVO>(cmd.ExecuteReader());
                }
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return null;
            }
        }

        public bool InsertProduct(ProductVO prod)
        {
            try
            {
                string sql = "insert into Products(ProdID, ProdName, ProdType, ProdPrice, ProdImage, MiniPordersQuantity, ProdTime) values(@ProdID, @ProdName, @ProdType, @ProdPrice, @ProdImage, @MiniPordersQuantity, @ProdTime)";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ProdID", prod.ProdID);
                cmd.Parameters.AddWithValue("@ProdName", prod.ProdName);
                cmd.Parameters.AddWithValue("@ProdType", prod.ProdType);
                cmd.Parameters.AddWithValue("@ProdPrice", prod.ProdPrice);
                cmd.Parameters.AddWithValue("@ProdImage", prod.ProdImage);
                cmd.Parameters.AddWithValue("@MiniPordersQuantity", prod.MiniPordersQuantity);
                cmd.Parameters.AddWithValue("@ProdTime", prod.ProdTime);

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return false;
            }
        }

        public bool DeleteProduct(string pID)
        {          
            try
            {
                string sql = @"Update Products set IsMake=0 where ProdID=@ProdID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ProdID", pID);

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return false;
            }
        }

        public bool UpdateProduct(ProductVO prod)
        {
            try
            {
                string sql = "Update Products set ProdName=@ProdName, ProdType=@ProdType, ProdPrice=@ProdPrice, ProdImage=@ProdImage, MiniPordersQuantity=@MiniPordersQuantity, ProdTime=@ProdTime where ProdID=@ProdID";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ProdID", prod.ProdID);
                cmd.Parameters.AddWithValue("@ProdName", prod.ProdName);
                cmd.Parameters.AddWithValue("@ProdType", prod.ProdType);
                cmd.Parameters.AddWithValue("@ProdPrice", prod.ProdPrice);
                cmd.Parameters.AddWithValue("@ProdImage", prod.ProdImage);
                cmd.Parameters.AddWithValue("@MiniPordersQuantity", prod.MiniPordersQuantity);
                cmd.Parameters.AddWithValue("@ProdTime", prod.ProdTime);

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return false;
            }
        }

        public List<ProductVO> GetProductSearchList(
                    string prodID, string prodType)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"select ProdID, ProdName, ProdType, ProdPrice, ProdImage, MiniPordersQuantity, ProdTime from Products where 1=1 ");

            if (!string.IsNullOrWhiteSpace(prodID))
            {
                sb.Append(" and ProdID = @ProdID ");
            }

            if (!string.IsNullOrWhiteSpace(prodType))
            {
                sb.Append(" and ProdType = @prodType ");
            }

            using (SqlCommand cmd = new SqlCommand(sb.ToString(), conn))
            {
                cmd.Parameters.AddWithValue("@ProdID", prodID);
                cmd.Parameters.AddWithValue("@prodType", prodType);

                return Helper.DataReaderMapToList<ProductVO>(cmd.ExecuteReader());
            }
        }
        public List<ProductVO> GetProductBOMAllList()
        {
            string sql = @"
 select '완제품' as ProdType, ProdID, ProdName, ProdImage  FROM Products  
  UNION ALL
 SELECT '반자재' as MatType, MaterialID ProdID, MaterialName ProdName, MaterialImage ProdImage FROM Materials
 where[MaterialType] = '반자재'";          

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    return Helper.DataReaderMapToList<ProductVO>(cmd.ExecuteReader());
                }
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return null;
            }
        }
        
        

        public List<ProductVO> GetProductBOMSearchList(string prodName)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"select ProdID, ProdName, ProdType from Products where 1=1 ");

            if (!string.IsNullOrWhiteSpace(prodName))
            {
                sb.Append(" and ProdName = @ProdName ");
            }
            
            using (SqlCommand cmd = new SqlCommand(sb.ToString(), conn))
            {
                cmd.Parameters.AddWithValue("@ProdName", prodName);
                

                return Helper.DataReaderMapToList<ProductVO>(cmd.ExecuteReader());
            }



        }


            

            public List<BOMVO> GetBOMAllListFW(string prodID)

        {
            string sql = @"With BOM as
(
select * from
(SELECT cast(ProdID as nvarchar) ProdID, 1 Quantity, 0 Levels, cast(ProdID as varchar(300)) sortOrder
from Products
union all
select cast(MaterialID as nvarchar) ProdID, 1 Quantity, 0 Levels, cast(MaterialID as varchar(300)) sortOrder
from Materials
where MaterialType ='반자재') as bomProd
where ProdID = @prodID

union all

select  cast(A.MatID as nvarchar)  ProdID, A.Quantity, (b.levels + 1)levels, cast(B.sortOrder + '>' + A.MatID as varchar(300)) sortOrder 
from FWbom A join BOM B on A.PRNTMatCode = B.ProdID

)
-- select * from BOM
select case when b.levels = 0 then  '▶' 
       else REPLICATE('   ', b.levels) + 'L ' end + t.ProdName info,
       b.ProdID, t.ProdName, B.Quantity,levels ,sortOrder
from BOM b join [dbo].[Products] t on b.ProdID = t.ProdID
where b.Levels = 0
union 
select case when b.levels = 0 then  '▶' 
       else REPLICATE('   ', b.levels) + 'L ' end + t.[MaterialName] info,
       b.ProdID, t.[MaterialName], B.Quantity,levels ,sortOrder
from BOM b join [dbo].[Materials] t on b.ProdID = t.[MaterialID]
order by sortOrder
";
            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@prodID", prodID);
                    return Helper.DataReaderMapToList<BOMVO>(cmd.ExecuteReader());
                }
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return null;
            }
        }

        public List<BOMVO> GetBOMAllListRV(string matID)

        {
            string sql = @"
WITH BOM(MatID, PRNTMatCode, Depth) AS 
(  
        SELECT MatID, PRNTMatCode, 0 AS Depth
        FROM FWBOM
        WHERE MatID = @MatID
 
        UNION ALL
 
        SELECT b.MatID, b.PRNTMatCode, bom.Depth + 1
        FROM FWBOM AS b
    INNER JOIN BOM AS bom
        ON b.MatID = bom.PRNTMatCode
)     
select MatID, PRNTMatCode, Depth from BOM";
            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MatID", matID);
                    return Helper.DataReaderMapToList<BOMVO>(cmd.ExecuteReader());
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

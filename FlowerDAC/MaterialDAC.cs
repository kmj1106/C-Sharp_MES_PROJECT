﻿using FlowerVO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace FlowerDAC
{
   
    public class MaterialDAC : IDisposable
    {
        

        SqlConnection conn;
        public MaterialDAC()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["local"].ConnectionString);
            conn.Open();
        }


        public void Dispose()
        {
            conn.Close();
        }


        public List<MaterialVO> GetMaterialAllList()
        {
            string sql = @"select MaterialID, MaterialName, MaterialType, MaterialUnit, MatStock, MaterialImage
, MatCategory, SafeStock, EmergenctStock, MaterialToDate, MainCustomer, MatPrice 
from Materials";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    return Helper.DataReaderMapToList<MaterialVO>(cmd.ExecuteReader());
                }
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return null;
            }
        }
        public bool InsertMaterials(MaterialVO material)
        {
            try
            {
                string sql = @"insert into Materials(MaterialID, MaterialName, MaterialType, MaterialImage,MaterialUnit, MatStock, MatCategory,  SafeStock, EmergenctStock, MaterialToDate, MainCustomer,MatPrice) values(@MaterialID, @MaterialName, @MaterialType, @MaterialUnit, @MatStock, @MaterialImage, @MatCategory, @SafeStock, @EmergenctStock, @MaterialToDate, @MainCustomer, @MatPrice)";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@MaterialID", material.MaterialID);
                cmd.Parameters.AddWithValue("@MaterialName",material.MaterialName);
                cmd.Parameters.AddWithValue("@MaterialType",material.MaterialType);
                cmd.Parameters.AddWithValue("@MaterialUnit",material.MaterialUnit);
                cmd.Parameters.AddWithValue("@MatPrice", material.MatPrice);
                cmd.Parameters.AddWithValue("@MatStock",material.MatStock);
                cmd.Parameters.AddWithValue("@MaterialImage",material.MaterialImage);
                cmd.Parameters.AddWithValue("@MatCategory",material.MatCategory);               
                cmd.Parameters.AddWithValue("@SafeStock",material.SafeStock);
                cmd.Parameters.AddWithValue("@EmergenctStock",material.EmergenctStock);
                cmd.Parameters.AddWithValue("@MaterialToDate",material.MaterialToDate);
                cmd.Parameters.AddWithValue("@MainCustomer",material.MainCustomer);
                
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                throw err;
            }
        }
        public bool InsertBOMMaterials(MaterialVO material)
        {
            try
            {
                string sql = @"insert into Materials(MaterialID, MaterialName, MaterialType) values(@MaterialID, @MaterialName, @MaterialType)";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@MaterialID", material.MaterialID);
                cmd.Parameters.AddWithValue("@MaterialName", material.MaterialName);
                cmd.Parameters.AddWithValue("@MaterialType", material.MaterialType);
                

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                throw err;
            }
        }

        public bool UpdateMaterials(MaterialVO material)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = @"UPDATE Materials SET 
                MaterialName=@MaterialName,MaterialType=@MaterialType,
                MaterialUnit=@MaterialUnit,MatStock=@MatStock,MatCategory=@MatCategory,SafeStock=@SafeStock,EmergenctStock=@EmergenctStock,
MaterialToDate=@MaterialToDate,MainCustomer=@MainCustomer,MaterialImage=@MaterialImage, MatPrice= @MatPrice WHERE MaterialID=@MaterialID";
               
                cmd.Parameters.AddWithValue("@MaterialID", material.MaterialID);
                cmd.Parameters.AddWithValue("@MaterialName", material.MaterialName);
                cmd.Parameters.AddWithValue("@MaterialType", material.MaterialType);
                cmd.Parameters.AddWithValue("@MaterialUnit", material.MaterialUnit);
                cmd.Parameters.AddWithValue("@MatStock", material.MatStock);
                cmd.Parameters.AddWithValue("@MatPrice", material.MatPrice);
                cmd.Parameters.AddWithValue("@MaterialImage", material.MaterialImage);
                cmd.Parameters.AddWithValue("@MatCategory", material.MatCategory);               
                cmd.Parameters.AddWithValue("@SafeStock", material.SafeStock);
                cmd.Parameters.AddWithValue("@EmergenctStock", material.EmergenctStock);
                cmd.Parameters.AddWithValue("@MaterialToDate", material.MaterialToDate);
                cmd.Parameters.AddWithValue("@MainCustomer", material.MainCustomer);

                int iRowaFFECT = cmd.ExecuteNonQuery();
                return (iRowaFFECT> 0);
            }
            catch(Exception err)
            {
                Debug.WriteLine(err.Message);
                throw err;
            }
           
        }

        public bool DeleteMaterials(string matid)
        {
            try
            {
                string sql = @"delete from Materials where MaterialID=@MaterialID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaterialID", matid);

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return false;
            }
        }

        public List<MaterialVO> GetMaterialSearchList(string MaterialID, string MaterialName)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"select MaterialID,MaterialName,MaterialType
from Materials
where MaterialID like @materialID or MaterialName like @materialName  ");

            //if (!string.IsNullOrWhiteSpace(MaterialID))
            //{
            //    sb.Append(" and MaterialID= @MaterialID");
            //}

            //if (!string.IsNullOrWhiteSpace(MaterialName))
            //{
            //    sb.Append(" and MaterialName= @MaterialName");
            //}


            using (SqlCommand cmd = new SqlCommand(sb.ToString(), conn))
            
            {
                    
                cmd.Parameters.AddWithValue("@materialID", $"%{MaterialID}%");
                cmd.Parameters.AddWithValue("@materialName", $"%{MaterialName}%");


                return Helper.DataReaderMapToList<MaterialVO>(cmd.ExecuteReader());

            }
            

        }
    }
}

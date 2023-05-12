using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FlowerDAC
{
    public static class Helper
    {
        public static List<T> DataReaderMapToList<T>(IDataReader dr)
        {
            try
            {
                List<T> list = new List<T>();
                T obj = default(T);
                while (dr.Read())
                {
                    obj = Activator.CreateInstance<T>();
                    foreach (PropertyInfo prop in obj.GetType().GetProperties())
                    {
                        //프로퍼티는 존재하는데, reader안에 조회된 컬럼이 없는 경우
                        //reader에 조회된 컬럼은 있는데, 프로퍼티는 정의되지 않은 경우
                        if (ContainsColumn(dr, prop.Name))
                        {
                            if (!object.Equals(dr[prop.Name], DBNull.Value))
                            {
                                prop.SetValue(obj, dr[prop.Name], null);
                            }
                        }
                    }
                    list.Add(obj);
                }
                return list;
            }
            catch (Exception err)
            {
                string msg = err.Message;
                return null;
            }
        }

        private static bool ContainsColumn(IDataReader reader, string columnName)
        {
            foreach (DataRow row in reader.GetSchemaTable().Rows)
            {
                if (row["ColumnName"].ToString() == columnName)
                    return true;
            }
            return false;
        }

        public static List<T> DataTableMapToList<T>(DataTable table) where T : class, new()
        {
            try
            {
                List<T> list = new List<T>();
                foreach (var row in table.AsEnumerable())
                {
                    T obj = new T();
                    foreach (var prop in obj.GetType().GetProperties())
                    {
                        try
                        {
                            PropertyInfo propertyInfo = obj.GetType().GetProperty(prop.Name);
                            propertyInfo.SetValue(obj, Convert.ChangeType(row[prop.Name], propertyInfo.PropertyType), null);
                        }
                        catch
                        {
                            continue;
                        }
                    }
                    list.Add(obj);
                }
                return list;
            }
            catch
            {
                return null;
            }
        }
    }
}
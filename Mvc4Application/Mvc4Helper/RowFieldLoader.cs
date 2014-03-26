using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Mvc4Helper
{
    public static class RowFieldLoader
    {

        private static object ParseObject(DataRow dr, string columnName, Type returnType)
        {
            object result = null;
            if (dr.Table.Columns.Contains(columnName))
                result = dr[columnName];
            return result;
        }

        public static int GetInt(DataRow dr, string columnName)
        {
            object result = ParseObject(dr, columnName, typeof(int));
            return result == DBNull.Value ? 0 : Convert.ToInt32(result);
        }

        public static double GetDouble(DataRow dr, string columnName)
        {
            object result = ParseObject(dr, columnName, typeof(double));
            return result == DBNull.Value ? 0 : Convert.ToDouble(result);
        }

        public static decimal GetDecimal(DataRow dr, string columnName)
        {
            object result = ParseObject(dr, columnName, typeof(decimal));
            return result == DBNull.Value ? 0 : Convert.ToDecimal(result);
        }
        
        public static string GetString(DataRow dr, string columnName)
        {
            object result = ParseObject(dr, columnName, typeof(string));
            return result == DBNull.Value ? "" : Convert.ToString(result);
        }

        public static Boolean GetBoolean(DataRow dr, string columnName)
        {
            object result = ParseObject(dr, columnName, typeof(bool));
            return result == DBNull.Value ? false : Convert.ToBoolean(result);
        }

        public static DateTime GetDateTime(DataRow dr, string columnName)
        {
            object result = ParseObject(dr, columnName, typeof(DateTime));
            return result == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(result);
        }


    }
}

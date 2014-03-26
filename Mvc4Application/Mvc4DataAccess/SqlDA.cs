using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Mvc4Helper;

namespace Mvc4DataAccess
{


    public class SqlDA : IDisposable
    {

        public string ConnectionString;
        private SqlConnection _sqlConn;
        private SqlDataAdapter _sqlAdp;

     
        public SqlDA(string connectionString = null)
        {
            if (string.IsNullOrEmpty(connectionString))
                ConnectionString = Config.SqlConnectionString;
            else
                ConnectionString = connectionString;
        }

        public DataTable GetDataTable(string command, string returnedTableName = "")
        {

            DataTable dt = null;
            DataSet ds = GetDataSet(command);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                if (!string.IsNullOrEmpty(returnedTableName))               //give a specific table name
                    dt.TableName = returnedTableName;
            }       
            return dt;

        }

        public DataSet GetDataSet(string command, string returnedDataSetName = "")
        {

            DataSet ds = new DataSet();
            if (!string.IsNullOrEmpty(returnedDataSetName))
                ds.DataSetName = returnedDataSetName;

            using (_sqlConn = new SqlConnection(ConnectionString))
            {
                _sqlAdp = new SqlDataAdapter(command, _sqlConn);
                _sqlAdp.Fill(ds);
            }
            return ds;

        }


        public void Dispose()
        {
            try
            {
                if (_sqlConn != null & _sqlConn.State != ConnectionState.Closed)
                {
                    _sqlConn.Close();
                    _sqlConn.Dispose();
                }

                if (_sqlAdp != null)
                {
                    _sqlAdp.Dispose();
                }

            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            
        }
    }
}

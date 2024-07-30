using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Globalization;

/// <summary>
/// Summary description for GeneralFunction
/// </summary>
namespace GeneralFunc
{
    public class GeneralFunction
    {
        static SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Connectionname"].ToString());
        public GeneralFunction()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        static public void CheckConection()
        {
            if (null == cn)
                cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Connectionname"].ToString());
            if (cn.State != ConnectionState.Open)
                cn.Open();
        }

      
        static public SqlDataReader ExecuteReaderFunction(SqlCommand cmd)
        {
            SqlDataReader dr = null;
            try
            {
                CheckConection();
                cmd.Connection = cn;
                dr = cmd.ExecuteReader();
            }
            catch { }
            finally
            {
                cmd.Dispose();
            }
            return dr;
        }

        static public int ExecuteNonQueryFunction(SqlCommand cmd)
        {
            int returnValue = 0;
            try
            {
                CheckConection();
                cmd.Connection = cn;
                returnValue = cmd.ExecuteNonQuery();
            }
            catch { }
            finally
            {
                cn.Close();
                cmd.Dispose();
            }
            return returnValue;
        }       
    }
}
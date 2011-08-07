
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace IKSIR.ECommerce.Infrastructure.DataLayer.DataBlock
{
    public class SQLDataBlock : IDisposable
    {
        static SQLDataBlock()
        {

        }

        private static SqlConnection cnn;
        private static SqlCommand cmd;
        private static SqlDataAdapter da;
        private static DataSet ds;

        public static int ExecuteNonQuery(string ConnectionString, CommandType CommandType, string CommandText)
        {
            cnn = new SqlConnection(ConnectionString); 
            cmd = new SqlCommand(CommandText, cnn);
            cmd.CommandType = CommandType;
            OpenConnection();
            int result = cmd.ExecuteNonQuery();
            CloseConnection();
            return result;
        }
        public static int ExecuteNonQuery(string ConnectionString, CommandType CommandType, string CommandText, List<SqlParameter> parameters)
        {
            cnn = new SqlConnection(ConnectionString); 
            cmd = new SqlCommand(CommandText, cnn);
            cmd.CommandType = CommandType;
            if (parameters != null)
            {
                foreach (SqlParameter parameter in parameters)
                {
                    cmd.Parameters.Add(parameter);
                }
            }
            OpenConnection();
            int result = cmd.ExecuteNonQuery();
            CloseConnection();
            return result;
        }

        public static object ExecuteScalar(string ConnectionString, CommandType CommandType, string CommandText)
        {
            cnn = new SqlConnection(ConnectionString); 
            cmd = new SqlCommand(CommandText, cnn);
            cmd.CommandType = CommandType;
            OpenConnection();
            object result = cmd.ExecuteScalar();
            CloseConnection();
            return result;
        }
        public static object ExecuteScalar(string ConnectionString, CommandType CommandType, string CommandText, List<SqlParameter> parameters)
        {
            cnn = new SqlConnection(ConnectionString); 
            cmd = new SqlCommand(CommandText, cnn);
            cmd.CommandType = CommandType;
            if (parameters != null)
            {
                foreach (SqlParameter parameter in parameters)
                {
                    cmd.Parameters.Add(parameter);
                }
            }
            OpenConnection();
            object result = cmd.ExecuteScalar();
            CloseConnection();
            return result;
        }

        public static SqlDataReader ExecuteReader(string ConnectionString, CommandType CommandType, string CommandText)
        {
            cnn = new SqlConnection(ConnectionString); 
            cmd = new SqlCommand(CommandText, cnn);
            cmd.CommandType = CommandType;
            OpenConnection();
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }
        public static SqlDataReader ExecuteReader(string ConnectionString, CommandType CommandType, string CommandText, List<SqlParameter> parameters)
        {
            cnn = new SqlConnection(ConnectionString); 
            cmd = new SqlCommand(CommandText, cnn);
            cmd.CommandType = CommandType;
            if (parameters != null)
            {
                foreach (SqlParameter parameter in parameters)
                {
                    cmd.Parameters.Add(parameter);
                }
            }
            OpenConnection();
            
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
           

        }

        public static DataTable ExecuteDataTable(string ConnectionString, CommandType CommandType, string CommandText)
        {
            cnn = new SqlConnection(ConnectionString); 
            cmd = new SqlCommand(CommandText, cnn);
            da = new SqlDataAdapter(cmd);
            cmd.CommandType = CommandType;
            da.Fill(ds);
            ds = new DataSet();
            return ds.Tables[0];
        }
        public static DataTable ExecuteDataTable(string ConnectionString, CommandType CommandType, string CommandText, List<SqlParameter> parameters)
        {
            cnn = new SqlConnection(ConnectionString); 
            cmd = new SqlCommand(CommandText, cnn);
            da = new SqlDataAdapter(cmd);
            cmd.CommandType = CommandType;
            if (parameters != null)
            {
                foreach (SqlParameter parameter in parameters)
                {
                    cmd.Parameters.Add(parameter);
                }
            }
            ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }

        public static DataSet ExecuteDataSet(string ConnectionString, CommandType CommandType, string CommandText)
        {
            cnn = new SqlConnection(ConnectionString);
            cmd = new SqlCommand(CommandText, cnn); 
            da = new SqlDataAdapter(cmd);
            cmd.CommandType = CommandType;
            da.Fill(ds);
            ds = new DataSet();
            return ds;
        }
        public DataSet ExecuteDataSet(string ConnectionString, CommandType CommandType, string CommandText, List<SqlParameter> parameters)
        {
            cnn = new SqlConnection(ConnectionString); 
            cmd = new SqlCommand(CommandText, cnn);
            da = new SqlDataAdapter(cmd);
            cmd.CommandType = CommandType;
            if (parameters != null)
            {
                foreach (SqlParameter parameter in parameters)
                {
                    cmd.Parameters.Add(parameter);
                }
            }
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        private static void OpenConnection()
        {
            if (cnn.State == ConnectionState.Closed) cnn.Open();
        }
        private static void CloseConnection()
        {
            if (cnn.State == ConnectionState.Open) cnn.Close();
        }

        static void cnn_StateChange(object sender, StateChangeEventArgs e)
        {
            StreamWriter writer = new StreamWriter(new FileStream("C:\\Connection.txt", FileMode.Append, FileAccess.Write));
            writer.WriteLine(DateTime.Now.ToString() + "=> Bağlantı Önceki Durumu : " + e.OriginalState + " Bağlantı Durumu : " + e.CurrentState);
            writer.Close();
        }

        public void Dispose()
        {
            CloseConnection();
        }
    }
}
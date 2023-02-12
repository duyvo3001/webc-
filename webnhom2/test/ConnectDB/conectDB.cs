using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace test.ConnectDB
{
    public class conectDB
    {
        public DataTable ExcuteQuery(string query, Dictionary<string, object> parameters = null, CommandType commandtype = CommandType.StoredProcedure)
        {
            DataTable data = new DataTable();
            string connectionString = Properties.Settings.Default.connectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.CommandType = commandtype;
                    SqlDataAdapter dataAPP = new SqlDataAdapter(cmd);
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.Add(param.Key, param.Value);
                        }
                    }
                    dataAPP.Fill(data);
                    return data;
                }
                catch (Exception ex)
                {
                    return data;

                }
            }
        }
        public DataTable ExcuteQuery1(string query, Dictionary<string, object> parameters = null)
        {
            DataTable data = new DataTable();
            string connectionString = Properties.Settings.Default.connectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataAdapter dataAPP = new SqlDataAdapter(cmd);
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        { cmd.Parameters.Add(param.Key, param.Value); }
                    }
                    dataAPP.Fill(data);
                    conn.Close();
                    return data;
                }
                catch (Exception ex)
                {
                    return data;
                }
            }
        }
        public int ExcuteNonQuery(string query, Dictionary<string, object> parameters = null, CommandType commandtype = CommandType.StoredProcedure)
        {
            string connectionString = Properties.Settings.Default.connectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.CommandType = commandtype;
                    SqlDataAdapter dataAPP = new SqlDataAdapter(cmd);
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.Add(param.Key, param.Value);
                        }
                    }
                    int roweffected = cmd.ExecuteNonQuery();
                    conn.Close();
                    return roweffected;
                }
                catch (Exception ex)
                {
                    return -1;
                }
            }
        }
    }
}
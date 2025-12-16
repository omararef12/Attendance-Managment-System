using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.IO;
using System.Windows.Forms;

namespace AttendanceSystem_csharp
{
    public class DB
    {
        private static readonly string connStr = "server=localhost;user=root;password=;database=attendance_db;";
        
        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connStr);
        }
        public static int ExecuteNonQuery(string query, params MySqlParameter[] parameters)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    if(parameters != null)
                        cmd.Parameters.AddRange(parameters);
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        public static DataTable ExecuteQuery(string query, params MySqlParameter[] parameters)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    if( parameters != null )
                        cmd.Parameters.AddRange(parameters);
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }
        public static MySqlParameter Param(string name, object value)
        {
            return new MySqlParameter(name, value ?? DBNull.Value);
        }
        public static void LogError(Exception ex)
        {
            try
            {
                string folderPath = Path.Combine(Application.StartupPath, @"..\..\logs");
                folderPath = Path.GetFullPath(folderPath);
                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);
                string filePath = Path.Combine(folderPath, "errors_" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt");
                string errorText = "====================\n" +
                    "Time: " + DateTime.Now.ToString("yyyy-MM-dd HH: mm:ss") + "\n" +
                    "Message: " + ex.Message + "\n" + "StackTrace:\n" + ex.StackTrace + "\n\n";
                File.AppendAllText(filePath, errorText);
            }
            catch
            {

            }
        }
    }
}

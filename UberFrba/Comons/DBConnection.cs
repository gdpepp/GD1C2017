using System;
using System.Configuration;
using System.Data.SqlClient;

namespace WindowsFormsApplication1 {
    
    public sealed class DBConnection {

        string user = "gd";//ConfigurationManager.AppSettings["user"].ToString();
        string password = "gd2017";//ConfigurationManager.AppSettings["password"].ToString();
        string server = "localhost";//ConfigurationManager.AppSettings["server"].ToString();

        private static DBConnection instance = new DBConnection();

        public static DBConnection getInstance() {
            return instance;
        }

        public SqlConnection getConnection() {
        SqlConnection dbconn = new SqlConnection();
        dbconn.ConnectionString = "SERVER=" + server + "\\SQLSERVER2012;DATABASE=GD1C2017;UID=" + user + ";PASSWORD=" + password + ";";
        return dbconn;
        }
    }
}


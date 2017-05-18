using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace WindowsFormsApplication1 {
    
    public sealed class DBConnection {

        string user = ConfigurationManager.AppSettings["user"].ToString();
        string password = ConfigurationManager.AppSettings["password"].ToString();
        string server = ConfigurationManager.AppSettings["server"].ToString();

        private static DBConnection instance = new DBConnection();

        public static DBConnection getInstance() {
            return instance;
        }

        public SqlConnection getConnection() {
            SqlConnection dbconn = new SqlConnection();
            dbconn.ConnectionString = "SERVER=" + server + "\\SQLSERVER2012;DATABASE=GD1C2017;UID=" + user + ";PASSWORD=" + password + ";";
            return dbconn;
        }

        public void openConnection()
        {
            getConnection().Open();
        }

        public void closeConnection() {
            getConnection().Close();
        }

        public void query(String query)
        {
            try
            {
                openConnection();
                SqlCommand queryCommand = new SqlCommand(query, getConnection());
                SqlDataReader queryCommandReader = queryCommand.ExecuteReader();

                closeConnection();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message + " Query: " + query);

            }
        }

        public DataTable select_query(String query)
        {

            try
            {
                openConnection();
                SqlCommand queryCommand = new SqlCommand(query, getConnection());
                SqlDataReader queryCommandReader = queryCommand.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(queryCommandReader);
                closeConnection();
                return dataTable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " Query: " + query);
            }

            //return new DataTable();
        }
    }
}


﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.Utils
{
    class DataBaseConnector
    {

        string user = ConfigurationManager.AppSettings["user"].ToString();
        string password = ConfigurationManager.AppSettings["password"].ToString();
        string server = ConfigurationManager.AppSettings["server"].ToString();

        private static DataBaseConnector instance = null;
        private SqlConnection connectionString;

        
        private DataBaseConnector() {
            this.connectionString = new SqlConnection();
            this.connectionString.ConnectionString = "Server=" + server + "\\SQLSERVER2012;DATABASE=GD1C2017;UID=" + user + ";PASSWORD=" + password + ";";
        }

        public static DataBaseConnector getInstance() {
            if (instance == null) {
                instance = new DataBaseConnector();
            }
            return instance;
        }

        private SqlConnection getConnectionString() {
            return this.connectionString;
        }

        public void openConnection()
        {
            getConnectionString().Open();
        }

        public void closeConnection() {
            getConnectionString().Close();
        }

        public void query(String query)
        {
            try
            {
                openConnection();
                SqlCommand queryCommand = new SqlCommand(query, getConnectionString());
                SqlDataReader queryCommandReader = queryCommand.ExecuteReader();
                closeConnection();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " Query: " + query);
            }
        }

        public void executeQueryWithParameters(String query, Dictionary<String,String> dictionary) {
            openConnection();
            SqlCommand command = new SqlCommand(query, getConnectionString());
            foreach(String key in dictionary.Keys){
                command.Parameters.AddWithValue(key,dictionary[key]);
            }
            command.ExecuteNonQuery();
            closeConnection();
        }

        public void executeProcedureWithParameters(String query, Dictionary<String, Object> dictionary)
        {
            openConnection();
            SqlCommand command = new SqlCommand(query, getConnectionString());
            foreach (String key in dictionary.Keys)
            {
                command.Parameters.AddWithValue(key, dictionary[key]);
            }
            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery();
            closeConnection();
        }


        public DataTable select_query(String query)
        {

            try
            {
                openConnection();
                SqlCommand queryCommand = new SqlCommand(query, getConnectionString());
                SqlDataReader queryCommandReader = queryCommand.ExecuteReader();
                //SqlDataAdapter adapter = new SqlDataAdapter(queryCommand);
                DataTable dataTable = new DataTable();
                //adapter.Fill(dataTable);
                dataTable.Load(queryCommandReader);
                closeConnection();
                return dataTable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " Query: " + query);
            }

        }
    }

}


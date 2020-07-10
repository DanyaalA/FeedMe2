using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace FeedMe.Server.Data
{
    class MySqlConnector
    {
        private string conString = "server=localhost;user=fServer;database=feedme;port=3306;password=1234";
        private MySqlConnection conn = new MySqlConnection();

        public void InitializeConnection()
        {
            conn = new MySqlConnection(conString);
        }

        public void ExecuteQuery()
        {

            
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
            }

            conn.Close();
        }

        public MySqlCommand CreateQuery(string Query)
        {
            return new MySqlCommand(Query, conn);
        }

        public MySqlCommand AddParamter(MySqlCommand command, string paramName, string value)
        {
            command.Parameters.AddWithValue(paramName, value);
            return command;
        }
    }
}

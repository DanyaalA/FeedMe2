using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace FeedMe.Server.Data
{
    class MySqlConnector
    {
        private string conString = "server=localhost;user=fServer;database=feedme;port=3306;password=1234";
        private MySqlConnection conn = new MySqlConnection();
        public static int ErrorCode;

        public static async Task<DataTable> ExecuteQuery(string command)
        {
            string myConString = "server=localhost; port=3306; user=fServer; pwd=1234; database=feedme; persistsecurityinfo=True;"; //Connection String

            MySqlConnection conn = new MySqlConnection();
            //MySqlDataAdapter adapter;
            DataTable myTable = new DataTable();

            ErrorCode = -1; //Normal State // No Error

            try
            {
                conn.ConnectionString = myConString;
                conn.Open();

                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(command, conn);
                //adapter = mySqlDataAdapter;
                await Task.Run(() => mySqlDataAdapter.Fill(myTable));
            }
            catch (MySqlException ex)
            {
                //Debugging Tools
                Console.WriteLine(ex.Number);
                Console.WriteLine(ex.Message);
                //Add Error Handling In Below
                ErrorCode = ex.Number;

                /* Errors Are handled Directly by the Method acessing this method (This makes it easier to network the error Message)
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Undiagnosed Error Occured");
                        break;

                    case 1062:
                        Console.WriteLine("Duplicate user!");
                        break;
                }
                */
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Executing Query: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return myTable;
        }

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


using FeedMe.Server.Data;
using FeedMe.Server.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FeedMe.Server.Shared.Authentication
{
    class Login
    {
        private string username, pword;
        private Client client;
        public Login(ref Client person)
        {
            client = person;
        }

        public void AuthenticateLogin()
        {
            GetClientDetails();
            CheckDetails(username, pword);

        }

        private void GetClientDetails()
        {
            username = client.ReceiveMessage();
            pword = client.ReceiveMessage();
            client.IsVendor = Convert.ToBoolean(client.ReceiveMessage());
        }

        private async void CheckDetails(string username, string password)
        {
            string table = "Customers";
            string name = "username";
            if (client.IsVendor)
            {
                table = "Vendors";
                name = "Name";
            }
            DataTable results = await MySqlConnector.ExecuteQuery($"SELECT `{name}`, `password` FROM {table} WHERE {name} = '{username}' && `password` = '{password}'");

            if (results.Rows.Count > 0)
            {
                client.SendMessage("True");
            }
            else 
            {
                client.SendMessage("False");
            }
        }
    }
}

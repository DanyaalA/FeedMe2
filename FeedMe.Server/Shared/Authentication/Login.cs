
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

        private async void GetClientDetails()
        {
            username = await client.ReceiveMessage();
            pword = await client.ReceiveMessage();
            client.IsVendor = Convert.ToBoolean(await client.ReceiveMessage());
        }

        private async void CheckDetails(string username, string password)
        {
            string table = "Customers";
            if (client.IsVendor) table = "Vendors";
            DataTable results = await MySqlConnector.ExecuteQuery($"SELECT username, `password` FROM {table} WHERE username = '{username}' && `password` = '{password}'");

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

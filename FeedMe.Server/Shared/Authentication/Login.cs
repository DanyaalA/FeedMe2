
using FeedMe.Server.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FeedMe.Server.Shared.Authentication
{
    class Login
    {
        private string username, pword;
        public Login(Client client)
        {
            username = client.ReceiveMessage();
            pword = client.ReceiveMessage();
        }
        public void AuthenticateLogin()
        {

        }
    }
}

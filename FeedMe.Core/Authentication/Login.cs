using FeedMe.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FeedMe.Core.Authentication
{
    public class Login
    {
        public bool AuthenticateLogin(Customer cust, string username, string password, bool isVendor)
        {
            cust.Messenger.SendCommand(FeedMe.Network.Commands.Login);
            //customer.Messenger.SendMessage("Login");
            cust.Messenger.SendMessage(username);
            cust.Messenger.SendMessage(password);
            cust.Messenger.SendBoolean(isVendor);
            bool response = cust.Messenger.ReceiveBoolean();

            return response;
        }
    }
}

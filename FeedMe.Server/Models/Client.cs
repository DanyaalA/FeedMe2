using FeedMe.Network;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace FeedMe.Server.Models
{
    class Client
    {
        public Socket ClientSocket { get; set; }
        public int ClientID { get; set; }
        public string Token { get; set; }
        public bool IsVendor { get; set; }
        public bool Connected { get; set; }
        private readonly Receive receiver = new Receive();
        private readonly Send sender = new Send();

        public string ReceiveMessage()
        {
            return receiver.ReceiveMessage(ClientSocket);
        }

        public void SendMessage(string message)
        {
            sender.SendMessage(ClientSocket, message);
        }
    }
}

using FeedMe.Network;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<string> ReceiveMessage()
        {
            return await receiver.ReceiveMessage(ClientSocket);
        }

        public void SendMessage(string message)
        {
            sender.SendMessage(ClientSocket, message);
        }
    }
}

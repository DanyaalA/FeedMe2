using FeedMe.Core.Server;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Sockets;
using System.Text;

namespace FeedMe.Core.Models
{
    public class Client
    {
        public EventHandler<string> RaiseClientConnectedEvent;
        public Messenger Messenger { get; set; }
        private Socket ClientSock { get; set; }
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public bool Admin { get; set; }
        public string AvatarName { get; set; }

        public void SetClientSocket(Socket sock)
        {
            ClientSock = sock;
            UpdateMessenger();
        }

        public void UpdateMessenger()
        {
            Messenger = new Messenger(ClientSock);
            Console.WriteLine("Set New Client");
            Console.WriteLine(ClientSock.LocalEndPoint.ToString());
            Messenger.SendMessage("Hi");
        }
    }
}

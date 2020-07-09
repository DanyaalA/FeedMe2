using FeedMe.Core.Server;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Sockets;
using System.Text;

namespace FeedMe.Core.Models
{
    class Client
    {
        public Messenger Messenger { get; set; }
        private Socket clientSock { get; set; }
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public bool Admin { get; set; }
        public string AvatarName { get; set; }


        public void UpdateMessenger()
        {
            Messenger = new Messenger(clientSock);
        }
    }
}

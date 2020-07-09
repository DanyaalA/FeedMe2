using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace FeedMe.Core.Server
{
    class Messenger
    {
        private readonly Socket serverSocket;

        public Messenger(Socket sock)
        {
            serverSocket = sock;
        }

        #region Send
        public void SendMessage(string message)
        {
            FeedMe.Network.Receive.ReceiveMessage();
        }

        #endregion
    }
}

using FeedMe.Network;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;

namespace FeedMe.Core.Server
{
    class Messenger
    {
        private readonly Socket clientSock;
        private Receive receiver = new Receive();
        private Send sender = new Send();


        public Messenger(Socket sock)
        {
            clientSock = sock;
        }

        #region Send
        public void SendMessage(string message)
        {
            sender.SendMessage(clientSock, message);  
        }

        #endregion

        #region Receiver
        public string ReceiveMessage()
        {
            return receiver.ReceiveMessage(clientSock);
        }


        #endregion
    }
}

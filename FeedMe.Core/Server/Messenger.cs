using FeedMe.Network;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FeedMe.Core.Server
{
    public class Messenger
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

        public void SendInt32(int val)
        {
            sender.SendMessage(clientSock, val.ToString());
        }

        public void SendBoolean(bool Bool)
        {
            sender.SendMessage(clientSock, Bool.ToString());
        }

        public void SendCommand(Commands command)
        {
            sender.SendMessage(clientSock, ((int)command).ToString());
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

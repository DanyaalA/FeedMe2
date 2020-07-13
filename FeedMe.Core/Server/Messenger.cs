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

        public void SendCommand(Commands command)
        {
            sender.SendMessage(clientSock, command.ToString());
        }

        #endregion

        #region Receiver
        public async Task<string> ReceiveMessage()
        {
            return await receiver.ReceiveMessage(clientSock);
        }


        #endregion
    }
}

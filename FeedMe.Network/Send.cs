using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace FeedMe.Network
{
    public class Send
    {
        private void SendData(Socket sock, byte[] data)
        {
            sock.Send(data, 0, data.Length, SocketFlags.None);
            Thread.Sleep(100);
        }

        public void SendMessage(Socket sock, string message)
        {
            SendData(sock, Encoding.UTF8.GetBytes(message));
            Thread.Sleep(100);

        }
    }
}

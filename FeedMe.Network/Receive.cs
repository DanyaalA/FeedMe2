using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace FeedMe.Network
{
    class Receive
    {
        private byte[] ReceiveData(Socket sock)
        {
            byte[] buffer = new byte[1024];
            int size = sock.Receive(buffer);
            byte[] data = new byte[size];
            Array.Copy(buffer, data, size);

            return data;
        }

        public string ReceiveMessage(Socket sock)
        {
            return Encoding.UTF8.GetString(ReceiveData(sock));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace FeedMe.Network
{
    public class Receive
    {
        private async Task<byte[]> ReceiveData(Socket sock)
        {
            byte[] buffer = new byte[1024];
            int size = await Task.Run(() => sock.Receive(buffer));
            byte[] data = new byte[size];
            Array.Copy(buffer, data, size);

            return data;
        }

        public async Task<string> ReceiveMessage(Socket sock)
        {

            return Encoding.UTF8.GetString(await ReceiveData(sock));
        }
    }
}

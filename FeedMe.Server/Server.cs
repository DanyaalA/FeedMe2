using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace FeedMe.Server
{
    class Server
    {
        private Socket sSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        int PORT = 4030;
        string ADDRESS = "127.0.0.1";
        private IPEndPoint ipe;

        public void StartServer()
        {
            ipe = new IPEndPoint(IPAddress.Parse(ADDRESS), PORT);
            sSock.Bind(ipe);

            sSock.Listen(100);

            Socket clientSock = default;

            Server serverInstance = new Server();

            while (true)
            {
                clientSock = sSock.Accept();
                Thread clientThread = new Thread(() => HandleClient(clientSock));
            }
        }

        private void HandleClient(Socket sock)
        {
            Console.WriteLine("Running Da Tings");
        }
    }
}

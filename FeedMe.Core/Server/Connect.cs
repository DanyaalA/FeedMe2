using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace FeedMe.Core.Server
{
    public class Connect
    {
        public int PORT = 4030;
        public string IP_ADDRESS = "127.0.0.1";
        private Socket sSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private bool connected = false;

        public bool InitializeConnection(out Socket sock)
        {
            sock = sSock;
            if (connected) { Console.WriteLine("Already Connected"); return true; }

            int attempts = 0;

            do
            {
                try
                {
                    IPEndPoint ipe = new IPEndPoint(IPAddress.Parse(IP_ADDRESS), PORT);
                    sSock.Bind(ipe);
                    sSock.Listen(100);
                    sock = sSock;

                    if (sSock.Connected)
                    {
                        connected = true; 
                        return true;
                    }
                }
                catch
                {

                }
                attempts++;
                Console.WriteLine("Failed To Connect Retrying connection...");
                Thread.Sleep(500);


            } while (attempts < 15);

            Console.WriteLine("Cant Connect To Server");
            return false;
        }

        public void CloseConnection()
        {
            sSock.Close(500);
        }
    }
}

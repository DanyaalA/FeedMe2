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
        private string IP_ADDRESS = "127.0.0.1";
        private int PORT = 4030;
        protected internal static Socket sSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public static bool Connected = false; //Has To Be Static As its important not to connect to the server twice

        public bool InitializeConnection(out Socket sock)
        {
            sock = sSock;
            if (Connected) { Console.WriteLine("Already Connected"); return true; }

            int attempts = 0;

            do
            {
                try
                {
                    IPEndPoint ipe = new IPEndPoint(IPAddress.Parse(IP_ADDRESS), PORT);
                    sSock.Connect(ipe);
                    Connected = true;
                    sock = sSock;

                    if (sSock.Connected)
                    {
                        Connected = true; 
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
            Connected = false;
        }
    }
}

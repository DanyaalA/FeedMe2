using System;
using System.Net.Sockets;

namespace FeedMe.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Server s = new Server();
            s.StartServer();
        }
    }
}

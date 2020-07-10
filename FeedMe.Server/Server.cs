using FeedMe.Server.Models;
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



            Server serverInstance = new Server();

            Console.WriteLine("Searchign for Clients");

            while (true)
            {
                Socket clientSock = sSock.Accept();
                Console.WriteLine("Accepted Client");
                Client client = SetInfo(clientSock);

                Thread clientThread = new Thread(() => HandleClient(client));
                clientThread.Start();
            }
        }

        private Client SetInfo(Socket clientSock)
        {
            Client client = new Client
            {
                ClientID = 0,
                Connected = true,
                ClientSocket = clientSock
            };

            return client;
        }

        private void HandleClient(Client client)
        {
            Console.WriteLine("Running Da Tings");
            while (client.Connected)
            {
                string command = client.ReceiveMessage();
                Console.WriteLine(command + " Command");
                switch (command)
                {
                    case "Login":
                        string uName = client.ReceiveMessage();
                        string pWord = client.ReceiveMessage();
                        if (uName == "55" && pWord == "55")
                        {
                            client.SendMessage("True");
                        }
                        else
                        {

                            client.SendMessage("False");

                        }
                        break;
                }


            }
        }
    }
}

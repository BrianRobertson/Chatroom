﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    class Server
    {
        public static ConcurrentQueue<Message> messageQueue = new ConcurrentQueue<Message>();
        public static Client client;
        TcpListener server;
        public Server()
        {
            server = new TcpListener(IPAddress.Parse("127.0.0.1"), 9999);//starter code IP: 127.0.0.1 is default indicating "this computer". The actual IP was: 192.168.0.109 but keeps changing.
            server.Start();
        }
        public void Run()
        {
            AcceptClient();
            client.Recieve();
            Respond();
        }
        private void AcceptClient()
        {
            TcpClient clientSocket = default(TcpClient);
            clientSocket = server.AcceptTcpClient();
            Console.WriteLine("Connected");
            NetworkStream stream = clientSocket.GetStream();
            client = new Client(stream, clientSocket);
        }
        private void Respond()
        {
            Message message = default(Message);
            if (messageQueue.TryDequeue(out message))
            {
                client.Send(message.Body);
            }
        }
        private void Start()
        {
            //needed? I put this here. Is this in TcpListener class?
        }
    }
}

using System;
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
        public static Dictionary<string, Client> chatClients = new Dictionary<string, Client>();
        public Server()
        {
            //server = new TcpListener(IPAddress.Parse("127.0.0.1"), 9999);//starter code IP: 127.0.0.1 is default indicating "this computer". The actual IP was: 192.168.0.109 but keeps changing.
            //server.Start();
            try
            {
                Console.WriteLine("Starting Server");
                server = new TcpListener(IPAddress.Parse("127.0.0.1"), 9999);
                server.Start();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error starting server " + e);
            }
        }
        public void Run()
        {
            Parallel.Invoke(AcceptClient, Respond);
            //Task.Run(() => AcceptClient());
            AcceptClient();
            //client.Recieve();
            Respond();
        }
        private void AcceptClient()
        {
            try
            {
                TcpClient clientSocket = default(TcpClient);
                clientSocket = server.AcceptTcpClient();
                Console.WriteLine("Connected");
                NetworkStream stream = clientSocket.GetStream();
                client = new Client(stream, clientSocket);
                string userId = client.GetUserId();
                //add this client to dictionary here.
                chatClients.Add(client.userId, client);
                Console.WriteLine(userId + " is added to chat this chat session.");
                client.Send("Hi " + userId + ", Welcome to chat!");
                Thread clientReceiveThread = new Thread(new ThreadStart(client.Recieve));
                clientReceiveThread.Start();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error accepting client on server." + e);
            }
            //TcpClient clientSocket = default(TcpClient);
            //clientSocket = server.AcceptTcpClient();
            //Console.WriteLine("Connected");
            //NetworkStream stream = clientSocket.GetStream();
            //client = new Client(stream, clientSocket);
            ////add this client to dictionary here.
            //chatClients.Add(client.UserId, client);
        }
        private void Respond()
        {
            while (true)
            {
                Message message = default(Message);
                if (messageQueue.TryDequeue(out message))
                {
                    client.Send(message.body);
                }
            }
        }
    }
}

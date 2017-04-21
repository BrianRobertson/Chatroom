﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Client
{
    class Client
    {
        TcpClient clientSocket;
        NetworkStream stream;
        public bool clientActive;
        //string chatName;

        public Client(string IP, int port)
        {
            this.clientSocket = new TcpClient();
            this.clientSocket.Connect(IPAddress.Parse(IP), port);
            this.stream = clientSocket.GetStream();
            this.clientActive = true;
        }
        public void Chat()
        {
            while (clientActive == true)
            {
                //Thread receiveThread = new Thread(new ThreadStart(Receive));
                //receiveThread.Start();
                Send();
                Recieve();
            }
        }
        public void Send()
        {
            while (true)
            {
                try
                {
                    string messageString = UI.GetInput();
                    byte[] message = Encoding.ASCII.GetBytes(messageString);
                    stream.Write(message, 0, message.Count());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error sending message to server. " + e);
                }
            }
        }
        public void Recieve()
        {
            while (true)
            {
                try
                {
                    byte[] recievedMessage = new byte[256];
                    stream.Read(recievedMessage, 0, recievedMessage.Length);
                    UI.DisplayMessage(Encoding.ASCII.GetString(recievedMessage));
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error recieving message from server. " + e);
                }
            }
        }
        //public void StartChat()
        //{
        //    SetChatName();
        //    Chat();
        //}
        //public void SetChatName()
        //{
        //    Send();
        //    Recieve();
        //}
    }
}

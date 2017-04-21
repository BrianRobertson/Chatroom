using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Client
    {
        NetworkStream stream;
        TcpClient client;
        public string userId;
        public Nullable<DateTime> startChat;
        public Nullable<DateTime> endChat;
        public Client(NetworkStream Stream, TcpClient Client)
        {
            this.stream = Stream;
            this.client = Client;
            //UserId = "495933b6-1762-47a1-b655-483510072e73";
            this.userId = "";
            this.startChat = DateTime.Now;
        }
        public void Send(string Message)
        {
            byte[] message = Encoding.ASCII.GetBytes(Message);
            stream.Write(message, 0, message.Count());
        }
        public void Recieve()
        {
            byte[] recievedMessage = new byte[256];
            stream.Read(recievedMessage, 0, recievedMessage.Length);
            string recievedMessageString = Encoding.ASCII.GetString(recievedMessage);
            Message message = new Message(null, recievedMessageString);
            Server.messageQueue.Enqueue(message);
            Console.WriteLine(recievedMessageString);//writes to console in server.
        }
        public void GetUserId()
        {
            //char[] charsToTrim = { '\0' };
            byte[] recievedMessage = new byte[256];
            try
            {
                Send("What is your name for this chat session?");
                stream.Read(recievedMessage, 0, recievedMessage.Length);
            }
            catch (Exception e)
            {
                Console.WriteLine("New User Send/Receive Server Error" + e);
            }
            string requestedUserId = Encoding.ASCII.GetString(recievedMessage);
            userId = ValidateUserID(requestedUserId);
            // trim and prep the message somehow? recievedMessageString.Trim(charsToTrim);
        }
        public string ValidateUserID(string requestedUserId)
        {
            string validUserId;
            //switch case to validate userID
            validUserId = "hello";

            return validUserId;
        }
    }
}

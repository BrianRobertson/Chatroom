using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Message
    {
        public Client sender;
        public string body;
        public string userId;
        public DateTime messageTime;
        public Message(Client Sender, string Body)
        {
            sender = Sender;
            this.body = Body;
            userId = sender?.userId;
            messageTime = DateTime.Now;
        }
    }
}

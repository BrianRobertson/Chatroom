using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client("127.0.0.1", 9999);//starter code IP: 127.0.0.1 is default indicating "this computer". The actual IP was: 192.168.0.109 but keeps changing.
            UI.DisplayStartMessage();
            client.Chat();
            //client.Send();
            //client.Recieve(); 
            Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public static class UI
    {
        public static void DisplayStartMessage()
        {
            Console.WriteLine("Welcome To Chat.");
        }
        public static void DisplayMessage(string message)
        {
            Console.WriteLine("Recieved from server: " + message);
        }
        public static string GetInput()
        {
            return Console.ReadLine();
        }
    }
}

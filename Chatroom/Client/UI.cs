﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public static class UI
    {
        public static void DisplayMessage(string message)
        {
            Console.WriteLine("From Client side: " + message);
        }
        public static string GetInput()
        {
            return Console.ReadLine();
        }
    }
}

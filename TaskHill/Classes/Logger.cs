using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TaskHill.Classes
{
    public  class Logger
    {
        public static void Write(string[] messages,ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            string result = "";
            foreach (string message in messages)
            {
                result += message + Environment.NewLine;
            }
            Console.WriteLine(result);
            Console.WriteLine("");
        }


    }
}

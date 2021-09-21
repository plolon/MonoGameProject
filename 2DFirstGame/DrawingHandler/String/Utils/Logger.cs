using System;
using System.Collections.Generic;
using System.Text;

namespace _2DFirstGame.DrawingHandler.String.Utils
{
    public class Logger
    {
        public static void Info(string message, ConsoleColor? color)
        {
            if(color != null)
            {
                Console.ForegroundColor = color.Value;
            }
            Console.WriteLine($"{DateTime.Now}\t{message}");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}

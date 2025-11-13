using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademySystem.Presentation.Helpers
{
    public static class Helper
    {
        public static void PrintConsole(ConsoleColor color, string text)
        {
            Console.ForegroundColor= color;
            Console.WriteLine(text);
        }
        public static void PrintConsole2(ConsoleColor color, string text)
        {
            Console.ForegroundColor= color;
            Console.Write(text);
        }
    }
}

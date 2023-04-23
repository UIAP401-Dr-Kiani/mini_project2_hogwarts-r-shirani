using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hagwarts
{
    public class Menus
    {
        public static int EnterMenu()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("welcome to the Hagwarts...=)\n");
            Console.ForegroundColor= ConsoleColor.DarkBlue;
            Console.WriteLine("please enter your choice:\n");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("1.Dumbledor\n2.student\n3.professor\n4.EXIT");
            int EnterChoice = Convert.ToInt32(Console.ReadLine());
            return EnterChoice;
        }
    }
}

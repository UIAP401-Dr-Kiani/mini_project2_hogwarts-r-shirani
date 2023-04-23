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
            Console.ResetColor();
            int EnterChoice = Convert.ToInt32(Console.ReadLine());
            return EnterChoice;
        }
        public static int DumbledorMenu()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Dumbledor Menu...\n");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("please enter your choice:\n");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("1.send letter to students\n2.gardening\n3.EXIT");
            Console.ResetColor();
            int DumbledorChoice = Convert.ToInt32(Console.ReadLine());
            return DumbledorChoice;
        }
        public static int ProfessorMenu()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Professor Menu...\n");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("please enter your choice:\n");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("1.define lessons\n2.define practice\n3.set score for students\n4.confirm students grades\n5.EXIT");
            Console.ResetColor();
            int ProfessorChoice = Convert.ToInt32(Console.ReadLine());
            return ProfessorChoice;
        }
    }
}

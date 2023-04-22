using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hagwarts
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dormitory x = new Dormitory("1102");
            Console.WriteLine($"bed: {x.Bed}\nroom: {x.Room}\nfloor: {x.Floor}");
            Console.ReadKey();
        }
    }
}

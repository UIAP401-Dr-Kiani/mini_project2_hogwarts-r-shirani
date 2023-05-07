using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hagwarts
{
    public class Student:AllowedPerson
    {
        public List<string> PassedUnits { get; set; }
        public int Term { get; set; }
        public int DormitoryNumbere { get; set; }
        public string letterToDumbledor { get; set; }
        public void SendLetterToDumbledor(string name,string family,string father,List<Student> student)
        {
            foreach(var std in student)
            {
                if(std.FirstName==name)
                {
                    std.letterToDumbledor= $"hi mr.dumbledor.I am {name},{family},and my father's name is:{father}." +
                $"I wanna go back to my city.please send me a ticket.Thank you";
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("letterToDum was sent to dumbledor successfuly");
                    Console.ResetColor();
                    break;
                }
            }
        }
    }
}

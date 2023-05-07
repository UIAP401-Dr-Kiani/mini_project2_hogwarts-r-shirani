using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace hagwarts
{
    public class Dumbledore : AllowedPerson
    {
        Dormitory DormitoryList;
        public List<string> letterFromStudents { get; set; }
        public static void SendLetterToStudents(List<Student> persons)//need cabin and sit number
        {
            int i = 1;
            int trainNumber = 1;
            int trainHour = 8;
            foreach (AllowedPerson p in persons)
            {
                if (i % 50 == 0)
                {
                    trainNumber++;
                    trainHour++;
                }
                if (p.Role != Role.teacher)
                {
                    p.ReceivedLetter = $"hello dear {p.FirstName},{p.LastName}\n" +
                        $"welcome to the Hagwarts \n" +
                        $"your train information:\nTrain Number:{trainNumber}\nTrain Departure Time:{trainHour}:00\n" +
                        $"remember If you don't get to the train, you have to wait an hour for the next train";
                }
                ++i;
            }
            Console.ForegroundColor= ConsoleColor.Green;
            Console.WriteLine("letter was sent to students successfuly");
            Console.ResetColor();
        }
        public static void Gardening(Plant plant)
        {
            plant.Number += 10;//Planting ten plants
        }
        public void AnswerLetters(List<Student> students)
        {
            foreach (var x in students)//sending tickets to all requests
            {
                if (x.letterToDum== $"hi mr.dumbledor.I am {x.FirstName},{x.LastName},and my father's name is:{x.FatherName}.I wanna go back to my city.please send me a ticket.Thank you")
                {
                    x.ReceivedLetter = "ticket was sent";
                }
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("letter frome students was answerd successfuly");
            Console.ResetColor();
        }
    }
}

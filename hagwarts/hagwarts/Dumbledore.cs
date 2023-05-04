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
        public static void SendLetterToStudents(List<AllowedPerson> persons)//need cabin and sit number
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
        }
        public static void Gardening(Plant plant)
        {
            plant.Number += 10;//Planting ten plants
        }
        public void AnswerLetters()
        {
            foreach (string letter in this.letterFromStudents)//sending tickets to all requests
            {
                if (letter != "ticket was sent")
                    letterFromStudents.Add("ticket was sent");
            }
        }
    }
}

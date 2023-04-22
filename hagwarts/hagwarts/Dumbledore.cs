using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hagwarts
{
    public class Dumbledore:AllowedPerson
    {
        Dormitory DormitoryList;
        public static void SendLetter(List<AllowedPerson> persons)
        {
            int i = 1;
            int trainNumber = 1;
            int trainHour = 8;
            foreach (AllowedPerson p in persons)
            {
                if(i%50==0)
                {
                    trainNumber++;
                    trainHour++;
                }
                if(p.Role!=Role.teacher)
                {
                    p.ReceivedLetter = $"hello dear {p.FirstName},{p.LastName}\n" +
                        $"welcome to the Hagwarts \n" +
                        $"your train information:\nTrain Number:{trainNumber}\nTrain Departure Time:{trainHour}" +
                        $"remember If you don't get to the train, you have to wait an hour for the next train";
                }
                ++i;
            }
        }
    }
}

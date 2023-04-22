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
            foreach (AllowedPerson p in persons)
            {
                if(p.Role!=Role.teacher)
                {
                    p.ReceivedLetter = $"hello dear {p.FirstName},{p.LastName}" +
                        $"\nwelcome to the Hagwarts";
                }
            }

        }
    }
}

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
        public void SendLetterToDumbledor()
        {
            Dumbledore dum=new Dumbledore();
            string letterText = $"hi mr.dumbledor.I am {this.FirstName},{this.LastName},and my father's name is:{this.FatherName}." +
                $"I wanna go back to my city.please send me a ticket.Thank you";
            dum.letterFromStudents.Add(letterText);
        }
    }
}

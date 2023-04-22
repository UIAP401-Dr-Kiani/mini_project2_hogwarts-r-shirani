using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace hagwarts
{
    public class Dormitory
    {
        GroupType GroupType { get; set; }
        public int Floor { get; set; }
        public int Room { get; set; }
        public int Bed { get; set; }
        public string Gender { get; set; }
        public Dormitory(string code)//each dormitory has **6floor**10rooms**5beds
        {
            if(code.Length==3)//room number is not greater than 9
            {
                this.Bed =(int)code[0];
                this.Room = (int)code[1];
                this.Floor=(int)code[2];
            }
            else if(code.Length==4)//room number is 10
            {
                this.Bed = (int)code[0];
                this.Room =10;
                this.Floor = (int)code[3];
            }
        }
    }
}

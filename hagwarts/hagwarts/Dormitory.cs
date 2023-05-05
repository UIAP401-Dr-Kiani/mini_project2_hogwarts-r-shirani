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
        public Dormitory(int code)//each dormitory has **6floor**10rooms**5beds
        {
            if(code/1000==0)//room number is not greater than 9
            {
                this.Bed =code%10;
                this.Room = (code/10)%10;
                this.Floor = code/100;
            }
            else if(code/1000!=0)//room number is 10
            {
                this.Bed =code%10;
                this.Room =10;
                this.Floor =code/1000;
            }
        }
        public int SlytherinDormitory(int code)
        {
            this.Bed++;
            if(this.Bed==6)
            {
                this.Bed = 1;
                this.Room++;
                if(this.Room==11)
                {
                    this.Room = 1;
                    this.Floor++;
                }
            }
            if (this.Room == 10)
            {
                int dormitoryNumber = (this.Floor * 1000) + (this.Room * 10) + (this.Bed);
                return dormitoryNumber;
            }
            else
            {
                int dormitoryNumber = (this.Floor * 100) + (this.Room * 10) + (this.Bed);
                return dormitoryNumber;
            }
        }
        public int RavenclawDormitory(int code)
        {
            this.Bed++;
            if (this.Bed == 6)
            {
                this.Bed = 1;
                this.Room++;
                if (this.Room == 11)
                {
                    this.Room = 1;
                    this.Floor++;
                }
            }
            if (this.Room == 10)
            {
                int dormitoryNumber = (this.Floor * 1000) + (this.Room * 10) + (this.Bed);
                return dormitoryNumber;
            }
            else
            {
                int dormitoryNumber = (this.Floor * 100) + (this.Room * 10) + (this.Bed);
                return dormitoryNumber;
            }
        }
        public int GryffindorDormitory(int code)
        {
            this.Bed++;
            if (this.Bed == 6)
            {
                this.Bed = 1;
                this.Room++;
                if (this.Room == 11)
                {
                    this.Room = 1;
                    this.Floor++;
                }
            }
            if (this.Room == 10)
            {
                int dormitoryNumber = (this.Floor * 1000) + (this.Room * 10) + (this.Bed);
                return dormitoryNumber;
            }
            else
            {
                int dormitoryNumber = (this.Floor * 100) + (this.Room * 10) + (this.Bed);
                return dormitoryNumber;
            }
        }
        public int HufflepuffDormitory(int code)
        {
            this.Bed++;
            if (this.Bed == 6)
            {
                this.Bed = 1;
                this.Room++;
                if (this.Room == 11)
                {
                    this.Room = 1;
                    this.Floor++;
                }
            }
            if (this.Room == 10)
            {
                int dormitoryNumber = (this.Floor * 1000) + (this.Room * 10) + (this.Bed);
                return dormitoryNumber;
            }
            else
            {
                int dormitoryNumber = (this.Floor * 100) + (this.Room * 10) + (this.Bed);
                return dormitoryNumber;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hagwarts
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<AllowedPerson> persons=new List<AllowedPerson>();
            //**************************************************************for reading file
            using (StreamReader file=new StreamReader("TXT_DATA.tsv"))
            {
                string ln;
                while ((ln = file.ReadLine()) != null)
                {
                    AllowedPerson p=new AllowedPerson();
                    string[] human = ln.Split('\t').ToArray<string>();
                    p.FirstName = human[0];
                    p.LastName = human[1];
                    p.BirthDay=human[2];
                    p.Gender = human[3];
                    p.FatherName=human[4];
                    p.UserName=human[5];
                    p.Password=human[6];
                    //----------------------------------for blood type
                    if (human[7] == "Pure blood")
                        p.BreedType = BreedType.PureBlood;
                    else if(human[7] == "Half blood")
                        p.BreedType = BreedType.HalfBlood;
                    else if (human[7] == "Muggle blood")
                        p.BreedType = BreedType.MuggleBlood;
                    //------------------------------------------------

                    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~for role type
                    if (human[8] == "teacher")
                        p.Role = Role.teacher;
                    else if (human[8] == "student")
                        p.Role = Role.student;
                    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                    persons.Add(p);
                }
                file.Close();
            }
            //*****************************************************************************
            Dumbledore.SendLetter(persons);
            Console.ReadKey();
        }
    }
}

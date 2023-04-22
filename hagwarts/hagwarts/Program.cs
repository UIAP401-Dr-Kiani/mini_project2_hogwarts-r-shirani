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
            List<Person> persons=new List<Person>();
            //**************************************************************for reading file
            using (StreamReader file=new StreamReader("TXT_DATA.tsv"))
            {
                string ln;
                while ((ln = file.ReadLine()) != null)
                {
                    Person p=new Person();
                    string[] human = ln.Split('\t').ToArray<string>();
                    p.FirstName = human[0];
                    p.LastName = human[1];
                    p.BirthDay=human[2];
                    p.Gender = human[3];
                    p.FatherName=human[4];
                    p.UserName=human[5];
                    p.Password=human[6];
                    p.BreedType = human[7];
                    p.Role=human[8];
                    persons.Add(p);
                }
                file.Close();
            }
            //*****************************************************************************
            Console.ReadKey();
        }
    }
}

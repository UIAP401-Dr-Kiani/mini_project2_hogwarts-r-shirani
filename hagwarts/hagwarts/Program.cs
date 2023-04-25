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
            Plant plant=new Plant();
            List <Lesson> lessons=new List<Lesson>();
            Professor professor = new Professor();
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
            int EnterChoice=Menus.EnterMenu();
            while(EnterChoice!=4)
            {
                switch (EnterChoice)
                {
                    case 1://dumbledor
                        {
                            int DumbledorChoice=Menus.DumbledorMenu();
                            switch (DumbledorChoice)
                            {
                                case 1://send letter
                                    {
                                        Dumbledore.SendLetter(persons);//send letter to students
                                        break;
                                    }
                                case 2://gardening
                                    {
                                        Dumbledore.Gardening(plant);
                                        break;
                                    }
                                case 3://exit
                                    {
                                        break;
                                    }
                            }
                            break;
                        }
                    case 2://professor
                        {
                            int ProfessorChioce = Menus.ProfessorMenu();
                            switch (ProfessorChioce)
                            {
                                case 1://define lessons
                                    { 
                                        professor.DefineLesson(lessons);
                                        break;
                                    }
                                case 2://define practice
                                    {
                                        break;
                                    }
                                case 3://set score for students
                                    {
                                        break;
                                    }
                                case 4://confrim students grade
                                    {
                                        break;
                                    }
                                case 5://exit
                                    {
                                        break;
                                    }
                            }
                            break;
                        }
                    case 3://student
                        {
                            int StudentChoice=Menus.StudentMenu();
                            switch (StudentChoice)
                            {
                                case 1://send letter to dumbledor
                                    {
                                        break;
                                    }
                                case 2://get information
                                    {
                                        break;
                                    }
                                case 3://selecting unit
                                    {
                                        break;
                                    }
                                case 4://upload homeworks
                                    {
                                        break;
                                    }
                                case 5://exit
                                    {
                                        break;
                                    }
                            }
                            break ;
                        }
                    case 4://exit
                        break;
                }
                EnterChoice = Menus.EnterMenu();
            }
            Console.ReadKey();
        }
    }
}
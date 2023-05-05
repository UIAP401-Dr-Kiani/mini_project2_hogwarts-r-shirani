﻿using System;
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
            //****************************************************************all instances
            Dumbledore dumbledore = new Dumbledore();
            dumbledore.UserName = "ADMIN";
            dumbledore.Password = "ADMIN";
            List<Student> persons = new List<Student>();
            Plant plant = new Plant();
            List<Lesson> lessons = new List<Lesson>();
            Professor professor = new Professor();
            Student student = new Student();
            Random random = new Random();
            int SlytherinDormitoryCode = 110;
            int RavenclawDormitoryCode = 110;
            int GryffindorDormitoryCode = 110;
            int HufflepuffDormitoryCode = 110;
            //**************************************************************for reading file
            using (StreamReader file = new StreamReader("TXT_DATA.tsv"))
            {
                string ln;
                while ((ln = file.ReadLine()) != null)
                {
                    Student p = new Student();
                    string[] human = ln.Split('\t').ToArray<string>();
                    p.FirstName = human[0];
                    p.LastName = human[1];
                    p.BirthDay = human[2];
                    p.Gender = human[3];
                    p.FatherName = human[4];
                    p.UserName = human[5];
                    p.Password = human[6];
                    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~for blood type
                    if (human[7] == "Pure blood")
                        p.BreedType = BreedType.PureBlood;
                    else if (human[7] == "Half blood")
                        p.BreedType = BreedType.HalfBlood;
                    else if (human[7] == "Muggle blood")
                        p.BreedType = BreedType.MuggleBlood;
                    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~for role type
                    if (human[8] == "teacher")
                        p.Role = Role.teacher;
                    else if (human[8] == "student")
                        p.Role = Role.student;
                    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~for group type
                    p.GroupName = (GroupType)random.Next(0, 4);
                    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~for pet
                    p.Pet = (Pet)random.Next(0, 3);
                    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~for baggage
                    int baggage = random.Next(2);
                    if (baggage == 0)
                        p.Baggage = true;
                    else
                        p.Baggage = false;
                    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~for dormitory

                    if (p.GroupName == GroupType.Slytherin)
                    {
                        Dormitory dormitory = new Dormitory(SlytherinDormitoryCode);
                        p.DormitoryNumbere = dormitory.SlytherinDormitory(SlytherinDormitoryCode);
                        SlytherinDormitoryCode=p.DormitoryNumbere;
                    }
                    else if (p.GroupName == GroupType.Ravenclaw)
                    {
                        Dormitory dormitory = new Dormitory(RavenclawDormitoryCode);
                        p.DormitoryNumbere = dormitory.RavenclawDormitory(RavenclawDormitoryCode);
                        RavenclawDormitoryCode = p.DormitoryNumbere;
                    }
                    else if (p.GroupName == GroupType.Gryffindor)
                    {
                        Dormitory dormitory = new Dormitory(GryffindorDormitoryCode);
                        p.DormitoryNumbere = dormitory.GryffindorDormitory(GryffindorDormitoryCode);
                        GryffindorDormitoryCode= p.DormitoryNumbere;
                    }
                    else if (p.GroupName == GroupType.Hufflepuff)
                    {
                        Dormitory dormitory = new Dormitory(HufflepuffDormitoryCode);
                        p.DormitoryNumbere = dormitory.HufflepuffDormitory(HufflepuffDormitoryCode);
                        HufflepuffDormitoryCode= p.DormitoryNumbere;
                    }
                        
                    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                    persons.Add(p);
                }
                file.Close();
            }
            //*****************************************************************************
            int EnterChoice = Menus.EnterMenu();
            while (EnterChoice != 4)//chioce isn't EXIT
            {
                switch (EnterChoice)
                {
                    case 1://dumbledor
                        {
                            Console.WriteLine("please Enter your username:");
                            string enteredUserName = Console.ReadLine();
                            Console.WriteLine("please Enter your password:");
                            string enteredPassWord = Console.ReadLine();
                            if (enteredUserName == dumbledore.UserName && enteredPassWord == dumbledore.Password)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine("user was found successfuly\n");
                                Console.ResetColor();
                                int DumbledorChoice = Menus.DumbledorMenu();
                                switch (DumbledorChoice)
                                {
                                    case 1://send letter
                                        {
                                            Dumbledore.SendLetterToStudents(persons);//send letter to students
                                            break;
                                        }
                                    case 2://gardening
                                        {
                                            Dumbledore.Gardening(plant);
                                            break;
                                        }
                                    case 3://answer letters frome student to get tickets
                                        {
                                            dumbledore.AnswerLetters();
                                            break;
                                        }
                                    case 4://exit
                                        {
                                            break;
                                        }
                                }
                                break;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Error!\nWRONG Username or Password\ntry again");
                                Console.ResetColor();
                                break;
                            }
                        }
                    case 2://student
                        {
                            bool findUser = false;
                            Console.WriteLine("please Enter your username:");
                            string enteredUserName = Console.ReadLine();
                            Console.WriteLine("please Enter your password:");
                            string enteredPassWord = Console.ReadLine();
                            foreach (var x in persons)
                            {
                                if (x.Role == Role.student && x.Password == enteredPassWord && x.UserName == enteredUserName)
                                {
                                    Console.ForegroundColor= ConsoleColor.DarkGreen;
                                    Console.WriteLine("user was found successfuly\n");
                                    Console.ResetColor();
                                    findUser = true;
                                    int StudentChoice = Menus.StudentMenu();
                                    switch (StudentChoice)
                                    {
                                        case 1://send letter to dumbledor for going back to city
                                            {
                                                student.SendLetterToDumbledor(x.FirstName, x.LastName, x.FatherName);
                                                break;
                                            }
                                        case 2://get information
                                            {
                                                Console.ForegroundColor= ConsoleColor.Green;
                                                Console.WriteLine($"Name: {x.FirstName}\nLastName: {x.LastName}\nfather's name: {x.FatherName}\n" +
                                                    $"gender: {x.Gender}\nbirthday: {x.BirthDay}\nbreed type: {x.BreedType}\npet: {x.Pet}\n" +
                                                    $"baggage: {x.Baggage}\nGroup Name: {x.GroupName}\ncurriculum: {x.Curriculum}\nTerm: {x.Term}\n" +
                                                    $"passed units: {x.PassedUnits}\ndormitory code: {x.DormitoryNumbere}\n");
                                                Console.ResetColor();
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
                                    break;
                                }
                            }
                            if (findUser == false)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Error!\nUser with this user name and password wasn't found\ntry again");
                                Console.ResetColor();
                                break;
                            }
                            break;
                        }
                    case 3://professor
                        {
                            bool findUser = false;
                            Console.WriteLine("please Enter your username:");
                            string enteredUserName = Console.ReadLine();
                            Console.WriteLine("please Enter your password:");
                            string enteredPassWord = Console.ReadLine();
                            foreach (AllowedPerson x in persons)
                            {
                                if (x.Role == Role.teacher && x.Password == enteredPassWord && x.UserName == enteredUserName)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine("user was found successfuly\n");
                                    Console.ResetColor();
                                    findUser = true;
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
                            }
                            if (findUser == false)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Error!\nUser with this user name and password wasn't found\ntry again");
                                Console.ResetColor();
                                break;
                            }
                            break;
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
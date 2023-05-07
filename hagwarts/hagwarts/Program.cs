using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace hagwarts
{
    public class Program
    {
        static void Main(string[] args)
        {
            //****************************************************************all instances
            Dumbledore dumbledore = new Dumbledore();
            Professor professor = new Professor();
            Student student = new Student();
            dumbledore.UserName = "ADMIN";
            dumbledore.Password = "ADMIN";
            List<AllowedPerson> persons = new List<AllowedPerson>();
            Plant plant = new Plant();
            List<Lesson> lessons = new List<Lesson>();
            List<Professor> allProfessors = new List<Professor>();
            List<Student> allStudents = new List<Student>();
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
                    AllowedPerson allowedp = new AllowedPerson();
                    student = new Student();
                    professor = new Professor();
                    string[] human = ln.Split('\t').ToArray<string>();
                    allowedp.FirstName = human[0];
                    allowedp.LastName = human[1];
                    allowedp.BirthDay = human[2];
                    allowedp.Gender = human[3];
                    allowedp.FatherName = human[4];
                    allowedp.UserName = human[5];
                    allowedp.Password = human[6];
                    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~for blood type
                    if (human[7] == "Pure blood")
                        allowedp.BreedType = BreedType.PureBlood;
                    else if (human[7] == "Half blood")
                        allowedp.BreedType = BreedType.HalfBlood;
                    else if (human[7] == "Muggle blood")
                        allowedp.BreedType = BreedType.MuggleBlood;
                    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~for role type
                    if (human[8] == "teacher")
                    {
                        int baggage = random.Next(2);//for baggage
                        if (baggage == 0)
                            allowedp.Baggage = true;
                        else
                            allowedp.Baggage = false;
                        allowedp.Pet = (Pet)random.Next(0, 3);//for pet
                        allowedp.GroupName = (GroupType)random.Next(0, 3);//for group name
                        allowedp.Role = Role.teacher;
                        professor.Role = Role.teacher;
                        professor.FirstName = allowedp.FirstName;
                        professor.LastName = allowedp.LastName;
                        professor.BirthDay = allowedp.BirthDay;
                        professor.Gender = allowedp.Gender;
                        professor.FatherName = allowedp.FatherName;
                        professor.UserName = allowedp.UserName;
                        professor.Password = allowedp.Password;
                        professor.Pet = allowedp.Pet;
                        professor.Baggage = allowedp.Baggage;
                        professor.GroupName = allowedp.GroupName;
                        allProfessors.Add(professor);
                    }
                    else if (human[8] == "student")
                    {
                        int baggage = random.Next(2);//for baggage
                        if (baggage == 0)
                            allowedp.Baggage = true;
                        else
                            allowedp.Baggage = false;
                        allowedp.Pet = (Pet)random.Next(0, 3);//for pet
                        allowedp.GroupName = (GroupType)random.Next(0, 3);//for group name
                        allowedp.Role = Role.student;
                        student.Role = Role.student;
                        student.FirstName = allowedp.FirstName;
                        student.LastName = allowedp.LastName;
                        student.BirthDay = allowedp.BirthDay;
                        student.Gender = allowedp.Gender;
                        student.FatherName = allowedp.FatherName;
                        student.UserName = allowedp.UserName;
                        student.Password = allowedp.Password;
                        student.Pet = allowedp.Pet;
                        student.Baggage = allowedp.Baggage;
                        student.GroupName = allowedp.GroupName;
                        //--------------------------------------------------for dormitory code
                        if (student.GroupName == GroupType.Slytherin)
                        {
                            Dormitory dormitory = new Dormitory(SlytherinDormitoryCode);
                            student.DormitoryNumbere = dormitory.SlytherinDormitory(SlytherinDormitoryCode);
                            SlytherinDormitoryCode = student.DormitoryNumbere;
                        }
                        else if (allowedp.GroupName == GroupType.Ravenclaw)
                        {
                            Dormitory dormitory = new Dormitory(RavenclawDormitoryCode);
                            student.DormitoryNumbere = dormitory.RavenclawDormitory(RavenclawDormitoryCode);
                            RavenclawDormitoryCode = student.DormitoryNumbere;
                        }
                        else if (allowedp.GroupName == GroupType.Gryffindor)
                        {
                            Dormitory dormitory = new Dormitory(GryffindorDormitoryCode);
                            student.DormitoryNumbere = dormitory.GryffindorDormitory(GryffindorDormitoryCode);
                            GryffindorDormitoryCode = student.DormitoryNumbere;
                        }
                        else if (allowedp.GroupName == GroupType.Hufflepuff)
                        {
                            Dormitory dormitory = new Dormitory(HufflepuffDormitoryCode);
                            student.DormitoryNumbere = dormitory.HufflepuffDormitory(HufflepuffDormitoryCode);
                            HufflepuffDormitoryCode = student.DormitoryNumbere;
                        }
                        allStudents.Add(student);
                    }
                    persons.Add(allowedp);
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
                                while (DumbledorChoice != 4)
                                {
                                    switch (DumbledorChoice)
                                    {
                                        case 1://send letter
                                            {
                                                Dumbledore.SendLetterToStudents(allStudents);//send letter to students
                                                break;
                                            }
                                        case 2://gardening
                                            {
                                                Dumbledore.Gardening(plant);
                                                break;
                                            }
                                        case 3://answer letters frome student to get tickets
                                            {
                                                dumbledore.AnswerLetters(allStudents);
                                                break;
                                            }
                                        case 4://exit
                                            {
                                                break;
                                            }
                                    }
                                    DumbledorChoice = Menus.DumbledorMenu();
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Error!\nWRONG Username or Password\ntry again");
                                Console.ResetColor();
                                break;
                            }
                        }
                        break;
                    case 2://student
                        {
                            bool findUser = false;
                            Console.WriteLine("please Enter your username:");
                            string enteredUserName = Console.ReadLine();
                            Console.WriteLine("please Enter your password:");
                            string enteredPassWord = Console.ReadLine();
                            foreach (var std in allStudents)
                            {
                                if (std.Role == Role.student && std.Password == enteredPassWord && std.UserName == enteredUserName)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine("user was found successfuly\n");
                                    Console.ResetColor();
                                    findUser = true;
                                    int StudentChoice = Menus.StudentMenu();
                                    while (StudentChoice != 6)
                                    {
                                        switch (StudentChoice)
                                        {
                                            case 1://send letter to dumbledor for going back to city
                                                {
                                                    std.SendLetterToDumbledor(std.FirstName, std.LastName, std.FatherName,allStudents);
                                                    break;
                                                }
                                            case 2://get information
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                    Console.WriteLine($"Name: {std.FirstName}\nLastName: {std.LastName}\nfather's name: {std.FatherName}\n" +
                                                        $"gender: {std.Gender}\nbirthday: {std.BirthDay}\nbreed type: {std.BreedType}\npet: {std.Pet}\n" +
                                                        $"baggage: {std.Baggage}\nGroup Name: {std.GroupName}\ncurriculum: {std.Curriculum}\nTerm: {std.Term}\n" +
                                                        $"passed units: {std.PassedUnits}\ndormitory code: {std.DormitoryNumbere}\n");
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
                                            case 5://see letters from dumbledor
                                                {
                                                    Console.WriteLine(std.ReceivedLetter);
                                                    break;
                                                }
                                            case 6://exit
                                                {
                                                    break;
                                                }
                                        }
                                        StudentChoice = Menus.StudentMenu();
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
                            foreach (AllowedPerson person in persons)
                            {
                                if (person.Role == Role.teacher && person.Password == enteredPassWord && person.UserName == enteredUserName)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine("user was found successfuly\n");
                                    Console.ResetColor();
                                    findUser = true;
                                    int ProfessorChioce = Menus.ProfessorMenu();
                                    while (ProfessorChioce != 5)
                                    {
                                        switch (ProfessorChioce)
                                        {
                                            case 1://define lessons
                                                {
                                                    professor.DefineLesson(lessons, allProfessors);
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
                                        ProfessorChioce = Menus.ProfessorMenu();
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
﻿using System;
using System.Collections.Generic;
using System.Globalization;
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
        public string letterToDumbledor { get; set; }
        public void SendLetterToDumbledor(string name,string family,string father,List<Student> student)
        {
            foreach(var std in student)
            {
                if(std.FirstName==name)
                {
                    std.letterToDumbledor= $"hi mr.dumbledor.I am {name},{family},and my father's name is:{father}." +
                $"I wanna go back to my city.please send me a ticket.Thank you";
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("letterToDum was sent to dumbledor successfuly");
                    Console.ResetColor();
                    break;
                }
            }
        }
        public void SelectingUnits(List<Lesson> lessons,List<Student> students,string name,String family)
        {
            int index = 0;
            foreach(var lesson in lessons)
            {
                Console.WriteLine($"{index + 1}. {lesson.Name}");
                ++index;
            }
            Console.WriteLine($"{index}.EXIT");
            Console.WriteLine("\nplease enter your choice number");
            int choice=Convert.ToInt32(Console.ReadLine());
            while(choice!=index)
            {
                foreach (var person in students)
                {
                    if (person.FirstName == name && person.LastName == family)
                    {
                        foreach (var leSson in person.Curriculum)
                        {
                            if (leSson.ClassTime != lessons[choice - 1].ClassTime && leSson.Name != lessons[choice - 1].Name)
                            {
                                person.Curriculum.Add(lessons[choice - 1]);
                                break;
                            }
                        }
                        break;
                    }
                }
                Console.WriteLine("\nplease enter your choice number");
                choice =Convert.ToInt32(Console.ReadLine());
            }
            Console.ForegroundColor= ConsoleColor.Magenta;
            Console.WriteLine("lessons were selected successfuly");
            Console.ResetColor();
        }
    }
}

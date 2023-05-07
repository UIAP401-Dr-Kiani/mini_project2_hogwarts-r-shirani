using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hagwarts
{
    public class Professor:AllowedPerson
    {
        public bool SimultaneousTeaching { get; set; }
        public Lesson Lesson { get; set; }
        public void DefineLesson(List<Lesson> lessons,List<Professor> professor)
        {
            Lesson newLesson=new Lesson();
            Console.WriteLine("please Enter lesson's name");
            newLesson.Name=Console.ReadLine();
            Console.WriteLine("please Enter lesson's capacity");
            newLesson.Capacity=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("please Enter lesson's PresentationSemester");
            newLesson.PresentationSemester=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("please enter Class time");
            newLesson.ClassTime=Console.ReadLine();
            Console.WriteLine("please enter Professor name");
            newLesson.Professor = Console.ReadLine();
            foreach(var x in professor)
            {
                if (x.Lesson.ClassTime == newLesson.ClassTime)
                    x.SimultaneousTeaching = true;
            }
            lessons.Add(newLesson);
        }
        public void SetScor(List<Student> students)
        {
            bool findUser = false, findLesson = false;
            Console.WriteLine("please enter student's name");
            string enterStudentName=Console.ReadLine();
            Console.WriteLine("please enter student's name");
            string enterStudentFamily=Console.ReadLine();
            foreach (var student in students)
            {
                if(student.FirstName==enterStudentName && student.LastName==enterStudentFamily)
                {
                    findUser = true;
                    Console.WriteLine("please enter lesson:");
                    string enterStudentLesson=Console.ReadLine();
                    foreach(var lessonName in student.Curriculum)
                    {
                        if(lessonName.Name==enterStudentLesson)
                        {
                            findLesson = true;
                            Console.WriteLine("please enter the grade");
                            //= Convert.ToDouble(Console.ReadLine());
                        }
                    }
                    if(findLesson==false)
                    {
                        Console.ForegroundColor= ConsoleColor.Red;
                        Console.WriteLine("this lesson was not found in this student's curriculum!");
                        Console.ResetColor();
                    }
                    Console.ResetColor();
                    break;
                }
            }
            if(findUser==false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("student was not found\nplease try again");
                Console.ResetColor();
            }
        }
    }
}

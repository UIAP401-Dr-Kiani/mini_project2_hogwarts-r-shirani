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
    }
}

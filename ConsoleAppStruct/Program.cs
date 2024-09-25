using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppStruct
{
    class Program
    {
        static void Main(string[] args)
        {
            // string inputedSubjectClass = Console.ReadLine();
            string inputedSubjectClass = "10.10.2010 '3-21' 'John Doe'";

            SubjectClass mySubjectClass = InputProcessing.ConvertToSubjectClass(inputedSubjectClass);

            Console.WriteLine(mySubjectClass.Date.ToShortDateString() + " / " + mySubjectClass.ClassroomName + " / " + mySubjectClass.TeacherName);
            Console.ReadKey();
        }
    }
}

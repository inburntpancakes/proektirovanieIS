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
            string fileData = DataAccess.GetFileData();
            SubjectClass[] subjectClasses = DataProcessing.ConvertToSubjectClasses(fileData);
            
            foreach (SubjectClass sss in subjectClasses)
            {
                sss.DisplayParameters();
            }
            Console.ReadKey();
        }
    }
}

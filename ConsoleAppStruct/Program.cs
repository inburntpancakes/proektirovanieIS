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
            string[] fileData = DataAccess.AccessFileData();
            Subject[] subjects = DataProcessing.ConvertToSubjects(fileData);
            foreach (Subject subject in subjects)
            {
                Console.WriteLine($"{subject}");
            }
            Console.ReadKey();

            string userInput = "Лекция: 10.10.2010 '3-21' 'Jane Doe' 22";
            Subject userSubject = DataProcessing.ConvertToCorrespondingClass(userInput);
            DataAccess.AddFileData(userSubject);
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppStruct
{
    class DataAccess
    {
        private static string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data.txt");

        public static string[] AccessFileData()
        {
            if (File.Exists(filePath) == false) { File.Create(filePath); }
            return File.ReadAllLines(filePath);
        }

        public static void AddFileData(Subject subjectToAdd)
        {
            File.AppendAllText(filePath, "\n" + subjectToAdd.ToString());
        }
    }
}

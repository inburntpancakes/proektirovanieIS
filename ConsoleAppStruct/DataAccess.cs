using System;
using System.IO;

namespace ConsoleAppStruct
{
    public class DataAccess
    {
        private static string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data.txt");

        public static string[] AccessFileData()
        {
            if (File.Exists(filePath) == false) { File.Create(filePath); }
            return File.ReadAllLines(filePath);
        }

        public static void AddFileData(Subject subjectToAdd)
        {
            if (File.Exists(filePath) == true && File.ReadAllText(filePath) != "")
            {
                File.AppendAllText(filePath, "\n" + subjectToAdd.ToString());
                return;
            }
            File.AppendAllText(filePath, subjectToAdd.ToString());
        }
    }
}

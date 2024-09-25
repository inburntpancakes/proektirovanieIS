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
        private static string fileData = AccessFileData();

        public static string GetFileData()
        {
            return fileData;
        }

        private static string AccessFileData()
        {
            if (File.Exists(filePath) == false)
            { File.Create(filePath); }
            return File.ReadAllText(filePath);
        }
    }
}

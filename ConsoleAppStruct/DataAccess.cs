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
        private string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data.txt");

        public string[] GetFileData()
        {
            return File.ReadAllLines(filePath);
        }
    }
}

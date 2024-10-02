using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppStruct
{
    public abstract class Subject
    {
        public DateTime Date { get; set; }
        public string ClassroomName { get; set; }
        public string TeacherName { get; set; }
        public abstract override string ToString();

        public abstract void UpdateParameters(string NewParameters);
    }
}

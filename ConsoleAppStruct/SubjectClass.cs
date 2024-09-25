using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppStruct
{
    public abstract class SubjectClass
    {
        public DateTime Date { get; set; }
        public string ClassroomName { get; set; }
        public string TeacherName { get; set; }

        public abstract void DisplayParameters();
    }
}

using System;
using System.Collections.Generic;

namespace ConsoleAppStruct
{
    public abstract class Subject
    {
        public DateTime Date { get; set; }
        public string ClassroomName { get; set; }
        public string TeacherName { get; set; }
        public abstract override string ToString();

        public abstract void UpdateParameters(Dictionary<string, string> NewParameters);
    }
}

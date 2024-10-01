using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppStruct
{
    class PracticeSubject : Subject
    {
        public string AttendingGroup { get; set; }

        public override string ToString()
        {
            return $"Практика: {Date.ToShortDateString()} '{ClassroomName}' '{TeacherName}' {AttendingGroup}";
        }

        public override void UpdateParameters(List<string> NewParameters)
        {
            Date = DateTime.ParseExact(NewParameters[0], "dd.MM.yyyy", CultureInfo.InvariantCulture);
            ClassroomName = NewParameters[1];
            TeacherName = NewParameters[2];
            AttendingGroup = NewParameters[3];
        }
    }
}

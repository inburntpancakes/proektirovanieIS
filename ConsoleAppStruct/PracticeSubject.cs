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

        public override void UpdateParameters(string NewParameters)
        {
            List<string> SplitParameters = DataProcessing.GetParameters(NewParameters);
            Date = DateTime.ParseExact(SplitParameters[0], "dd.MM.yyyy", CultureInfo.InvariantCulture);
            ClassroomName = SplitParameters[1];
            TeacherName = SplitParameters[2];
            AttendingGroup = SplitParameters[3];
        }
    }
}

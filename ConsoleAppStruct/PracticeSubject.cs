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
            return $"Практика| Дата:{Date.ToShortDateString()} Кабинет:'{ClassroomName}' Преподаватель:'{TeacherName}' Группа:{AttendingGroup}";
        }

        public override void UpdateParameters(string NewParameters)
        {
            Dictionary<string, string> Parameters = DataProcessing.GetParameters(NewParameters);
            Date = DateTime.ParseExact(Parameters["Дата"], "dd.MM.yyyy", CultureInfo.InvariantCulture);
            ClassroomName = Parameters["Кабинет"];
            TeacherName = Parameters["Преподаватель"];
            AttendingGroup = Parameters["Группа"];
        }
    }
}

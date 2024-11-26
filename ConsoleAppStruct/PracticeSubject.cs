using System;
using System.Collections.Generic;
using System.Globalization;

namespace ConsoleAppStruct
{
    public class PracticeSubject : Subject
    {
        public string AttendingGroup { get; set; }

        public override string ToString()
        {
            return $"Практика| Дата:{Date.ToShortDateString()} Кабинет:'{ClassroomName}' Преподаватель:'{TeacherName}' Группа:{AttendingGroup}";
        }

        public override void UpdateParameters(Dictionary<string, string> Parameters)
        {
            ClassroomName = Parameters.ContainsKey("Кабинет") ? Parameters["Кабинет"] : throw new ArgumentException("Введен некорректный параметр Кабинет (либо не введен вовсе)");
            TeacherName = Parameters.ContainsKey("Преподаватель") ? Parameters["Преподаватель"] : throw new ArgumentException("Введен некорректный параметр Преподаватель (либо не введен вовсе)");
            AttendingGroup = Parameters.ContainsKey("Группа") ? Parameters["Группа"] : throw new ArgumentException("Введен некорректный параметр Группа (либо не введен вовсе)");

            if (Parameters.ContainsKey("Дата") && DateTime.TryParseExact(Parameters["Дата"], "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateParsed))
            { Date = dateParsed; }
            else { throw new ArgumentException("Введен некорректный параметр Дата (либо не введен вовсе)"); }
        }
    }
}

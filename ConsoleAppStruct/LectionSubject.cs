using System;
using System.Collections.Generic;
using System.Globalization;

namespace ConsoleAppStruct
{
    public class LectionSubject : Subject
    {
        public int AmountOfAttendingGroups { get; set; }

        public override string ToString()
        {
            return $"Лекция| Дата:{Date.ToShortDateString()} Кабинет:'{ClassroomName}' Преподаватель:'{TeacherName}' КолвоГрупп:{AmountOfAttendingGroups}";
        }

        public override void UpdateParameters(Dictionary<string, string> Parameters)
        {
            ClassroomName = Parameters.ContainsKey("Кабинет") ? Parameters["Кабинет"] : throw new ArgumentException("Введен некорректный параметр Кабинет (либо не введен вовсе)");
            TeacherName = Parameters.ContainsKey("Преподаватель") ? Parameters["Преподаватель"] : throw new ArgumentException("Введен некорректный параметр Преподаватель (либо не введен вовсе)");

            if (Parameters.ContainsKey("Дата") && DateTime.TryParseExact(Parameters["Дата"], "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateParsed))
            { Date = dateParsed; }
            else { throw new ArgumentException("Введен некорректный параметр Дата (либо не введен вовсе)"); }

            if (Parameters.ContainsKey("КолвоГрупп") && Int32.TryParse(Parameters["КолвоГрупп"], out int amountOfAttendingGroupsParsed))
            { AmountOfAttendingGroups = amountOfAttendingGroupsParsed; }
            else { throw new ArgumentException("Введен некорректный параметр КолвоГрупп (либо не введен вовсе)"); }
        }
    }
}

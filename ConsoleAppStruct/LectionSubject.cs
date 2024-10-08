using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppStruct
{
    class LectionSubject : Subject
    {
        public int AmountOfAttendingGroups { get; set; }

        public override string ToString()
        {
            return $"Лекция| Дата:{Date.ToShortDateString()} Кабинет:'{ClassroomName}' Преподаватель:'{TeacherName}' КолвоГрупп:{AmountOfAttendingGroups}";
        }

        public override void UpdateParameters(string NewParameters)
        {
            Dictionary<string, string> Parameters = DataProcessing.GetParameters(NewParameters);
            Date = DateTime.ParseExact(Parameters["Дата"], "dd.MM.yyyy", CultureInfo.InvariantCulture);
            ClassroomName = Parameters["Кабинет"];
            TeacherName = Parameters["Преподаватель"];
            AmountOfAttendingGroups = Convert.ToInt32(Parameters["КолвоГрупп"]);
        }
    }
}

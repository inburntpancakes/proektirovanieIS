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
            return $"Лекция: {Date.ToShortDateString()} '{ClassroomName}' '{TeacherName}' {AmountOfAttendingGroups}";
        }

        public override void UpdateParameters(List<string> NewParameters)
        {
            Date = DateTime.ParseExact(NewParameters[0], "dd.MM.yyyy", CultureInfo.InvariantCulture);
            ClassroomName = NewParameters[1];
            TeacherName = NewParameters[2];
            AmountOfAttendingGroups = Convert.ToInt32(NewParameters[3]);
        }
    }
}

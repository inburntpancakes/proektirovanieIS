using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppStruct
{
    class Lection : SubjectClass
    {
        public int AmountOfAttendingGroups { get; set; }

        public override void DisplayParameters()
        {
            Console.WriteLine(Date + " " + ClassroomName + " " + TeacherName + " " + AmountOfAttendingGroups);
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

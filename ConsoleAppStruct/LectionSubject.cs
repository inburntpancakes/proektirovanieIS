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

        public override void UpdateParameters(string NewParameters)
        {
            List<string> SplitParameters = DataProcessing.GetParameters(NewParameters);
            Date = DateTime.ParseExact(SplitParameters[0], "dd.MM.yyyy", CultureInfo.InvariantCulture);
            ClassroomName = SplitParameters[1];
            TeacherName = SplitParameters[2];
            AmountOfAttendingGroups = Convert.ToInt32(SplitParameters[3]);
        }
    }
}

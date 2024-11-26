using ConsoleAppStruct;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ConsoleAppTest
{
    [TestClass]
    public class DataAccessTests
    {
        [TestMethod]
        public void AllMethods_AccessDataThenAddData_WorksAsIntented()
        {
            DateTime date = DateTime.Today; string classroomName = "222"; string teacherName = "John Doe"; int amountOfAttendingGroups = new Random().Next();
            LectionSubject toAdd = new LectionSubject() { ClassroomName = classroomName, TeacherName = teacherName, Date = date, AmountOfAttendingGroups = amountOfAttendingGroups };
            string expected = toAdd.ToString();

            string[] origFileData = DataAccess.AccessFileData();
            DataAccess.AddFileData(toAdd);

            string[] afterAddFileData = DataAccess.AccessFileData();
            Assert.AreEqual(afterAddFileData[afterAddFileData.Length - 1], expected);
        }
    }
}

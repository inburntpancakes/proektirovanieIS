using ConsoleAppStruct;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace ConsoleAppTest
{
    [TestClass]
    public class DataProcessingTests
    {
        // naming: MethodName_Scenario_ExpectedOutcome
        [TestMethod]
        public void ConvertToCorrespondingClass_ConvertToALectionAndCheckIfInfoIsCorrect_LectionSubject()
        {
            // Arrange
            string date = "10.10.2010"; string cabinet = "3-21";
            string teacher = "Jane Doe"; int groupnum = 22;
            string userInput = $"Лекция| Дата:{date} Кабинет:'{cabinet}' Преподаватель:'{teacher}' КолвоГрупп:{groupnum}";
            // Act
            var result = DataProcessing.ConvertToCorrespondingClass(userInput);
            // Assert
            Assert.IsInstanceOfType<LectionSubject>(result);
            Assert.AreEqual<DateTime>(DateTime.ParseExact(date, "dd.MM.yyyy", CultureInfo.InvariantCulture), result.Date);
            Assert.AreEqual(cabinet, result.ClassroomName);
            Assert.AreEqual(teacher, result.TeacherName);
        }

        [TestMethod]
        public void ConvertToCorrespondingClass_ConvertToAPracticeAndCheckIfInfoIsCorrect_PracticeSubject()
        {
            string date = "10.10.2010"; string cabinet = "3-21";
            string teacher = "Jane Doe"; string groupnum = "КИ23-21Б";
            string userInput = $"Практика| Дата:{date} Кабинет:'{cabinet}' Преподаватель:'{teacher}' Группа:{groupnum}";

            var result = DataProcessing.ConvertToCorrespondingClass(userInput);

            Assert.IsInstanceOfType<PracticeSubject>(result);
            Assert.AreEqual<DateTime>(DateTime.ParseExact(date, "dd.MM.yyyy", CultureInfo.InvariantCulture), result.Date);
            Assert.AreEqual(cabinet, result.ClassroomName);
            Assert.AreEqual(teacher, result.TeacherName);
        }

        [TestMethod]
        public void GetParameters_ConvertStringParametersToDictionary_Dictionary()
        {
            string parameters = "ФИО:'Петрович Р.О.'   Погода:Солнечно Название:'Зимняя сказка'";
            int numOfParameters = 3;

            var result = DataProcessing.GetParameters(parameters);

            Assert.IsInstanceOfType<Dictionary<string, string>>(result);
            Assert.AreEqual(result.Count, numOfParameters);
            Assert.AreEqual(result["ФИО"], "Петрович Р.О.");
            Assert.AreEqual(result["Погода"], "Солнечно");
            Assert.AreEqual(result["Название"], "Зимняя сказка");
        }
    }
}
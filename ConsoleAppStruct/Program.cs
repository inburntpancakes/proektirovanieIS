using System;

namespace ConsoleAppStruct
{
    class Program
    {
        static void Main(string[] args)
        {
            // Запись данных
            string userInput = "Лекция| Дата:10.10.2010 Кабинет:'3-21' Преподаватель:'Jane Doe' КолвоГрупп:10";
            try
            {
                Subject userSubject = DataProcessing.ConvertToCorrespondingClass(userInput);
                DataAccess.AddFileData(userSubject);
            }
            catch (Exception ex) { OutputErrorMessage(ex.Message); }

            // Получение данных
            string[] fileData = DataAccess.AccessFileData();
            Subject[] subjects = DataProcessing.ConvertToSubjects(fileData);

            // Отображение данных
            foreach (Subject subject in subjects)
            {
                Console.WriteLine($"{subject}");
            }
            Console.ReadKey();
        }

        private static void OutputErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}

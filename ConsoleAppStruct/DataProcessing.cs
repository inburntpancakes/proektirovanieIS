using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleAppStruct
{
    public static class DataProcessing
    {
        public static Subject[] ConvertToSubjects(string[] subjectsToConvert)
        {
            Subject[] subjectClassesConverted = new Subject[subjectsToConvert.Length];
            int k = -1;
            foreach (string currentSubjectClass in subjectsToConvert)
            {
                k++;
                subjectClassesConverted[k] = ConvertToCorrespondingClass(currentSubjectClass);
            }
            return subjectClassesConverted;
        }

        public static Subject ConvertToCorrespondingClass(string classLine)
        {
            string correspondingClass = classLine.Contains('|') ? classLine.Split('|')[0] : throw new ArgumentException("Тип предмета не введен либо не отделен знаком |");
            int letterSkipCount = correspondingClass.Length + 1;
            string subjectParameters = classLine.Remove(0, letterSkipCount);
            switch (correspondingClass)
            {
                case "Лекция": return TransferToClass(subjectParameters, new LectionSubject());
                case "Практика": return TransferToClass(subjectParameters, new PracticeSubject());
                default: throw new ArgumentException("Введен некорректный тип предмета");
            }
        }

        public static Dictionary<string, string> GetParameters(string Input)
        {
            Dictionary<string, string> inputedParameters = new Dictionary<string, string>();

            string currentlyRecordedParameter = "";
            string currentlyRecordedKey = "";
            parameterType currentParameterType = parameterType.None;
            bool waitingForParameterKey = true;
            char separationLetterForParameter = '\0';

            foreach (char letter in Input)
            {
                if (waitingForParameterKey)
                {
                    if (char.IsWhiteSpace(letter)) { continue; }
                    if (letter == ':') { waitingForParameterKey = false; }
                    else { currentlyRecordedKey += letter; }
                    continue;
                }

                if (char.IsWhiteSpace(letter) && currentParameterType == parameterType.None) { continue; }

                if ((letter == '\'' || letter == '\"') && currentParameterType == parameterType.None)
                { currentParameterType = parameterType.RecordingWithQuotes; separationLetterForParameter = letter; continue; }

                if (char.IsWhiteSpace(letter) == false && currentParameterType == parameterType.None)
                { currentParameterType = parameterType.RecordingWithoutQuotes; }

                if (((letter == separationLetterForParameter) && currentParameterType == parameterType.RecordingWithQuotes)
                    || (char.IsWhiteSpace(letter) && currentParameterType == parameterType.RecordingWithoutQuotes))
                {
                    currentParameterType = parameterType.None;
                    inputedParameters.Add(currentlyRecordedKey, currentlyRecordedParameter);
                    waitingForParameterKey = true;
                    currentlyRecordedKey = ""; currentlyRecordedParameter = "";
                    continue;
                }

                currentlyRecordedParameter += letter;
            }
            if (currentlyRecordedParameter != "")
            { inputedParameters.Add(currentlyRecordedKey, currentlyRecordedParameter); }

            return inputedParameters;
        }

        private enum parameterType
        {
            None,
            RecordingWithQuotes,
            RecordingWithoutQuotes
        }

        private static Subject TransferToClass(string subjectParameters, Subject subjectToTransferTo)
        {
            Dictionary<string, string> formattedSubjectParameters = GetParameters(subjectParameters);
            subjectToTransferTo.UpdateParameters(formattedSubjectParameters);
            return subjectToTransferTo;
        }
    }
}

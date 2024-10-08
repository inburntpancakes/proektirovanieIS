using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace ConsoleAppStruct
{
    class DataProcessing
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
            string correspondingClass = classLine.Split('|')[0];
            int letterSkipCount = correspondingClass.Length + 1;
            string subjectParameters = classLine.Remove(0, letterSkipCount);
            switch (correspondingClass)
            {
                case "Лекция": return TransferToClass(subjectParameters, new LectionSubject());
                case "Практика": return TransferToClass(subjectParameters, new PracticeSubject());
                default: throw new ArgumentException();
            }
        }

        public static List<string> GetParametersOld(string Input)
        {
            List<string> subjectClassParameters = new List<string>();
            string currentlyRecordedParameter = "";
            bool isCurrentlyRecordingAParameter = false;
            bool recordingStringParameter = false;
            char separationLetterForParameter = '\0';

            bool recordQuotes = false;

            foreach (char letter in Input)
            {
                if (isCurrentlyRecordingAParameter & recordingStringParameter)
                {
                    if (letter == separationLetterForParameter)
                    {
                        if (recordQuotes == true) { currentlyRecordedParameter += letter; }
                        isCurrentlyRecordingAParameter = false;
                        recordingStringParameter = false;
                        subjectClassParameters.Add(currentlyRecordedParameter);
                        currentlyRecordedParameter = "";
                        continue;
                    }
                    currentlyRecordedParameter += letter;
                    continue;
                }

                if (isCurrentlyRecordingAParameter & !recordingStringParameter)
                {
                    if (char.IsWhiteSpace(letter))
                    {
                        isCurrentlyRecordingAParameter = false;
                        recordingStringParameter = false;
                        subjectClassParameters.Add(currentlyRecordedParameter);
                        currentlyRecordedParameter = "";
                        continue;
                    }
                    currentlyRecordedParameter += letter;
                    continue;
                }

                if (char.IsWhiteSpace(letter)) { continue; }
                isCurrentlyRecordingAParameter = true;
                if (letter == '\'' || letter == '\"')
                {
                    recordingStringParameter = true;
                    separationLetterForParameter = letter;
                    if (recordQuotes == true) { currentlyRecordedParameter += letter; }
                }
                else { currentlyRecordedParameter += letter; }
            }
            subjectClassParameters.Add(currentlyRecordedParameter);
            return subjectClassParameters;
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
            subjectToTransferTo.UpdateParameters(subjectParameters);
            return subjectToTransferTo;
        }
    }
}

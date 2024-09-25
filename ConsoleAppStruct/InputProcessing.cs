using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace ConsoleAppStruct
{
    class InputProcessing
    {

        public static SubjectClass ConvertToSubjectClass(string Input)
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

                if (!isCurrentlyRecordingAParameter)
                {
                    if (char.IsWhiteSpace(letter))
                    { continue; }
                    isCurrentlyRecordingAParameter = true;
                    if (letter == '\'' || letter == '\"')
                    {
                        recordingStringParameter = true;
                        separationLetterForParameter = letter;
                        if (recordQuotes == true) { currentlyRecordedParameter += letter; }
                    }
                    else { currentlyRecordedParameter += letter; }
                    continue;
                }
            }

            DateTime convertedDate = DateTime.ParseExact(subjectClassParameters[0], "dd.MM.yyyy", CultureInfo.InvariantCulture);

            SubjectClass newSubjectClass = new SubjectClass() { Date = convertedDate, ClassName = subjectClassParameters[1], TeacherName = subjectClassParameters[2] };
            return newSubjectClass;
        }
        
    }
}

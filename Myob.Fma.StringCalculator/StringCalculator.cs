using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Myob.Fma.StringCalculator
{
    public class StringCalculator
    {
        public int Add(string numberString)
        {
            var delimiters = new List<string> {",", "\n"};

            if (numberString == string.Empty) return 0;

            if (OptionalDelimiterPresent(numberString))
            {
                delimiters = new List<string> {GetDelimiterFromString(numberString)};

                numberString = GetInputToSum(numberString);
            }

//            var pattern = GetRegexPattern(delimiters);
            var separatedNums = SplitStringWithDelimiters(numberString);

            var sum = 0;

            var negativeNumbers = new List<int>();

            foreach (var stringNum in separatedNums)
            {
                var matchedNumber = stringNum.ToString();
                
                if (matchedNumber.Length > 0)
                {
                    var stringToNum = int.Parse(matchedNumber);

                    if (stringToNum < 0) negativeNumbers.Add(stringToNum);

                    if (stringToNum < 1000)
                    {
                        sum += stringToNum;
                    }
                }
            }

            if (negativeNumbers.Any())
                throw new Exception(string.Join(", ", negativeNumbers));

            return sum;
        }

        private MatchCollection SplitStringWithDelimiters(string inputString)
        {
            var regex = new Regex(@"-?\d+");

            return regex.Matches(inputString);
        }

        private bool OptionalDelimiterPresent(string inputString)
        {
            if (inputString.Length < 2) return false;

            return inputString.Substring(0, 2) == "//";
        }

        private string GetDelimiterFromString(string inputString)
        {
            var regex = new Regex(@"(?<=\//\[).+(?=\])"); // looks for the pattern //[pattern]\n

            var matches = regex.Matches(inputString);

            if (matches.Any())
            {
                return matches.First().ToString();
            }

            var indexOfLineBreak = inputString.IndexOf('\n');

            return inputString[indexOfLineBreak - 1].ToString();
        }

        private string GetInputToSum(string inputString)
        {
            var indexOfLineBreak = inputString.IndexOf('\n');
            var startOfNewLine = indexOfLineBreak + 1;
            var inputLength = (inputString.Length - 1) - indexOfLineBreak;

            return inputString.Substring(startOfNewLine, inputLength);
        }

        private string GetRegexPattern(List<string> delimiters)
        {
            var pattern = "(?<=";

            for (int i = 0; i < delimiters.Count(); i++)
            {
                if (i == delimiters.Count() - 1)
                {
                    pattern += $@"[{delimiters[i]}])-?\d+|\w";
                }
                else
                {
                    pattern += $"[{delimiters[i]}]|";
                }
            }

            return pattern;
        }
    }
}
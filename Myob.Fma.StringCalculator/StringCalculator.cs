using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace Myob.Fma.StringCalculator
{
    public class StringCalculator
    {
        public int Add(string numberString)
        {
            if (numberString == string.Empty) return 0;

            if (OptionalDelimiterPresent(numberString))
            {
                var optionalDelimiterString = GetOptionalDelimiterString(numberString);
                
                numberString = GetInputToSum(numberString);

                var delimiters = GetDelimiterMatchesFromString(optionalDelimiterString);
                
                ReplaceDelimiters(ref numberString, delimiters);
            }

            var separatedNums = SplitStringWithDelimiters(numberString);

            var sum = 0;

            var negativeNumbersFound = new List<int>();

            foreach (var stringNum in separatedNums)
            {
                var matchedNumber = stringNum.ToString();
                
                if (matchedNumber.Length > 0)
                {
                    var stringToNum = int.Parse(matchedNumber);

                    if (stringToNum < 0) negativeNumbersFound.Add(stringToNum);

                    if (stringToNum < 1000)
                    {
                        sum += stringToNum;
                    }
                }
            }

            if (negativeNumbersFound.Any())
                throw new Exception(string.Join(", ", negativeNumbersFound));

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

        private MatchCollection GetDelimiterMatchesFromString(string inputString)
        {
            var regex = new Regex(@"((?<=\//\[).*(?=\]\[))|((?<=\[).*(?=\]$))"); // looks for the pattern //[pattern]\n

            return regex.Matches(inputString);

        }

        private string GetInputToSum(string inputString)
        {
            var indexOfLineBreak = inputString.IndexOf('\n');
            var startOfNewLine = indexOfLineBreak + 1;
            var inputLength = (inputString.Length - 1) - indexOfLineBreak;

            return inputString.Substring(startOfNewLine, inputLength);
        }

        private string GetOptionalDelimiterString(string inputString)
        {
            var indexOfLineBreak = inputString.IndexOf('\n');
            return inputString.Substring(0, indexOfLineBreak);

        }

        private void ReplaceDelimiters(ref string inputString, MatchCollection delimiters)
        {
            foreach (var delimeter in delimiters)
            {
                inputString = inputString.Replace(delimeter.ToString(), ",");
            }
        }
    }
}
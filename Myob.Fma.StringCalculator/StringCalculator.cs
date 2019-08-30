using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace Myob.Fma.StringCalculator
{
    public class StringCalculator
    {
        public int Add(string input)
        {
            if (input == string.Empty) return 0;

            if (OptionalDelimiterPresent(input))
            {
                var delimiterInputSection = GetOptionalDelimiterString(input);
                
                input = FormatInputToSum(input);

                var delimiters = GetDelimiterMatchesFromString(delimiterInputSection);
                
                ReplaceDelimitersInString(ref input, delimiters);
            }

            var separatedNums = SplitStringWithDelimiters(input);

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

        private IEnumerable SplitStringWithDelimiters(string inputString)
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

        private string FormatInputToSum(string inputString)
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

        private void ReplaceDelimitersInString(ref string inputString, IEnumerable delimiters)
        {
            foreach (var delimiter in delimiters)
            {
                inputString = inputString.Replace(delimiter.ToString(), ",");
            }
        }
    }
}
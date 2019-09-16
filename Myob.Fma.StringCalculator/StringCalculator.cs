using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Linq;

namespace Myob.Fma.StringCalculator
{
    public class StringCalculator
    {
        public string EncodedString;
        
        public int Add()
        {
            if (IsEmptyString()) return 0;

            if (HasCustomDelimiter())
            {
                EncodedString = RemoveDelimitersFromCalculatableString();
            }
            
            if (IsNegativeNumbersPresent())
                throw new Exception(GetNegativeNumbers());

            var digitsAsMatchCollection = ExtractDigitsFromString();

            return GetSumOfMatchCollectionDigits(digitsAsMatchCollection);

        }

        private bool IsEmptyString()
        {
            return EncodedString == string.Empty;
        }

        private MatchCollection ExtractDigitsFromString()
        {
            var regexSearch = new Regex(@"\d+");

            return regexSearch.Matches(EncodedString);
        }

        private bool IsNegativeNumbersPresent()
        {
            var regexSearch = new Regex(@"-\d+");

            return regexSearch.Matches(EncodedString).Any();
        }

        private string GetNegativeNumbers()
        {
            var regexSearch = new Regex(@"-\d+");

            var negativeNumbersFound = regexSearch.Matches(EncodedString);

            return string.Join(", ", negativeNumbersFound.Select(d => d.ToString()));
        }

        private string RemoveDelimitersFromCalculatableString()
        {
            var delimiters = GetCustomDelimiters();

            var calculatableString = GetCalculatableString();

            foreach (var delimiter in delimiters)
            {
                var delimiterAsString = delimiter.ToString();

                calculatableString = calculatableString.Replace(delimiterAsString, " ");
            }

            return calculatableString;
        }

        private MatchCollection GetCustomDelimiters()
        {
            var regexSearch = new Regex(@"(?<=\[).{3}(?=\])");

            return regexSearch.Matches(EncodedString);
        }

        private string GetCalculatableString()
        {
            var regexSearch = new Regex(@"(?<=\])(\n).*");

            return regexSearch.Match(EncodedString).ToString();
        }

        private bool HasCustomDelimiter()
        {
            return EncodedString.Contains("//[");
        }

        private int GetSumOfMatchCollectionDigits(MatchCollection digits)
        {
            return digits.Where(d => int.Parse(d.ToString()) <= 999 ).Aggregate(0, (total, number) => total + int.Parse(number.ToString()));
        }
    }
}
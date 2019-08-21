using System;

namespace Myob.Fma.Practice.ExtensionMethods
{
    public static class MyExtensions
    {
        public static string Capitalize(this string str)
        {
            var firstLetter = str[0];
            var rest = str.Substring(1, str.Length - 1);

            return char.ToUpper(firstLetter) + rest;
        }
    }
}
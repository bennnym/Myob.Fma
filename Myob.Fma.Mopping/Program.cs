/*
 * Count the number of Duplicates
Write a function that will return the count of distinct 
case-insensitive alphabetic characters and numeric digits 
that occur more than once in the input string. 
The input string can be assumed to contain only 
alphabets (both uppercase and lowercase) and numeric digits.

Example
"abcde" -> 0 # no characters repeats more than once
"aabbcde" -> 2 # 'a' and 'b'
"aabBcde" -> 2 # 'a' occurs twice and 'b' twice (`b` and `B`)
"indivisibility" -> 1 # 'i' occurs six times
"Indivisibilities" -> 2 # 'i' occurs seven times and 's' occurs twice
"aA11" -> 2 # 'a' and '1'
"ABBA" -> 2 # 'A' and 'B' each occur twice
 */

/*
 * Psedo Code
 * public static int function(string input "aabbcde")
 *     {
 *         1. init a HashSet --> collection of unique elements 
 *         2. Loop over input, add char to the HashSet --> output: "abcde"
 *         3. Loop over the HashSet 
 *             - if (Count>1) --> add to var Occurance;
 *     }
 */
using System;
using System.Collections.Generic;
using System.Linq;

namespace Myob.Fma.Mopping
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MultipleCharCount("aabbcdefff"));

        }

        static int CountOcurances(string input)
        {
            var uniqueChars = new HashSet<char>();

            foreach (var letter in input)
            {
                uniqueChars.Add(letter);
            }

            var occur = 0;

            foreach (var character in uniqueChars)
            {
                var matches = input.Count(l => l == character);
                
                if (matches >= 2)
                {
                    occur++;
                }
            }
            
            return occur;
        }
        
        // loop through the input
        // how many of that letter is in the input
        // if matches >= 2 then add occur ++; 
        // remove the letters from the input ( there could be more than 2 )

        static int MultipleCharCount(string input)
        {
            var occur = 0;

            var word = input.ToList();
            
            foreach (var letter in input)
            {
                var matches = word.Count(l => l == letter);

                if (matches >= 2)
                {
                    occur++;

                    for (int i = 0; i < matches; i++)
                    {
                        word.Remove(letter);
                    }
                }

            }

            return occur;
        }
        
    }
}
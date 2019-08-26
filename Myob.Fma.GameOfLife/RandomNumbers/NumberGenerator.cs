using System;
using System.Collections.Generic;

namespace Myob.Fma.GameOfLife.RandomNumbers
{
    public class NumberGenerator
    {
        public static HashSet<int> Random(UserInputs userInputs)
        {
            var randomNumbers = new HashSet<int>();
            var upperLimit = userInputs.Columns * userInputs.Rows;
            var randNumberGenerator = new Random();

            while (randomNumbers.Count < userInputs.Lives)
            {
                var num = randNumberGenerator.Next(1, upperLimit);
                randomNumbers.Add(num);
            }

            return randomNumbers;
        }
    }
}
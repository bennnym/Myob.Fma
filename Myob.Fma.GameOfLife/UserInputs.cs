using System;

namespace Myob.Fma.GameOfLife
{
    public class UserInputs
    {
        
        public int Rows { get; private set; }
        public int Columns { get; private set; }
        public int Lives { get; private set; }

        public static UserInputs GenerateUserInput(string[] arguments)
        {
            if (arguments.Length != 3)
                throw new Exception("Make sure you have entered three inputs, it should be in the format: 'number of live cells' 'rows' 'columns'");

            var numberOfAliveCells = ConvertStringToNumber(arguments[0]);
            var numberOfRows = ConvertStringToNumber(arguments[1]);
            var numberOfColumns = ConvertStringToNumber(arguments[2]);

            ValidateUserNumberEnteredIsPositive(numberOfAliveCells);
            ValidateUserNumberEnteredIsPositive(numberOfColumns);
            ValidateUserNumberEnteredIsPositive(numberOfRows);

            CheckAliveCellsIsLessThanGridSize(numberOfAliveCells, numberOfColumns, numberOfRows);
            
            return new UserInputs
            {
                Rows = numberOfRows, 
                Columns = numberOfColumns, 
                Lives = numberOfAliveCells
            };
        }

        private static int ConvertStringToNumber(string input)
        {
            try
            { 
              return int.Parse(input);
            }
            catch (Exception e)
            {
                Console.WriteLine($"You must enter a valid number: {e}");
                throw;
            }
        }

        private static void ValidateUserNumberEnteredIsPositive(int entry)
        {
            if (entry <= 0 ) throw new Exception("You must enter a number greater than 0 for all arguments.");
        }

        private static void CheckAliveCellsIsLessThanGridSize(int numberOfAliveCells, int numberOfColumns, int numberOfRows)
        {
            if ( numberOfAliveCells >= numberOfColumns * numberOfRows )
                throw new Exception("Alive cells count must be less than the number of cells on the grid");
        }
    }
}
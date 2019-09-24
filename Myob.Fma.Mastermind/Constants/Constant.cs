namespace Myob.Fma.Mastermind.Constants
{
    public static class Constant
    {
        public const string Welcome =
            "Welcome to Mastermind, try and crack the code!";
        public const string Instructions = "Please enter four colours separated by a space and the computer will give you feedback" +
                                           "\nColours can be repeated so technically a sequence can all be RED RED RED RED" +
                                           "\nA Black element means you have guessed a colour in the correct position. " +
                                           "\nA White means it is in the wrong position but it is present in the code." +
                                           "\nThe returned elements are always shuffled, so they will never be the same!" +
                                            "\n";

        public const string IncorrectNumberOfColoursErrorMsg = "Error: you must enter 4 colours!" +
                                                            "\nTry again:";
        public const string InvalidColourErrorMsg = "Error: you have given an invalid colour!" +
                                                 "\nTry again:";
        public const string GuessLimitExceededErrorMsg = "Error: you must pass 4 colours";
        public const string ValidGuessMsg = "Valid guess, calculating clues...";
        
        public const string RegexColourPattern = @"BLUE|RED|GREEN|ORANGE|PURPLE|YELLOW";
        public const string RegexWordSearchPattern = @"[a-zA-Z]+";

        public const int GuessLimit = 60;
        public const int MinColoursRange = 0;
        public const int MaxColoursRange = 5;
        public const int ComputerArrayLen = 4;
    }
}
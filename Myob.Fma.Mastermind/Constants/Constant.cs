namespace Myob.Fma.Mastermind.Constants
{
    public static class Constant
    {
        public const string WelcomeInstructions = "Welcome to Mastermind, try and crack the code!" +
                                                  "\nPlease enter four colours separated by a space and the computer will give you feedback" +
                                                  "\nColours can be repeated so technically a sequence can all be RED RED RED RED" +
                                                  "\n" +
                                                  "\nAll the valid colours are Red, Blue, Green, Orange, Purple and Yellow" +
                                                  "\n" +
                                                  "\nA Black element means you have guessed a colour in the correct position. " +
                                                  "\nA White means it is in the wrong position but it is present in the code." +
                                                  "\n" +
                                                  "\nThe returned elements are always shuffled, so they will never be the same!" +
                                                  "\n";

        public const string IncorrectNumberOfColoursErrorMsg = "Error: you must enter 4 colours!" +
                                                               "\nTry again:";
        public const string InvalidColourErrorMsg = "Error: you have given an invalid colour!" +
                                                    "\nTry again:";
        public const string GuessLimitExceededErrorMsg = "Error: you are only allowed 60 guesses, game over!";
        public const string GuessCountPrompt = "Number of Guesses so far: ";
        public const string RemainingGuessesPrompt = "Guesses Remaining: ";

        public const string WinningGuess = "Black, Black, Black, Black";
        public const string WinningFeedback = "Congratulations! You cracked the code!\n\n";

        public const string ValidGuessMsg = "Valid guess, calculating clues...";
        public const string NoCluesPresent = "You didn't guess any correct colours!\n\n";
        public const string CluePrompt = "The clues for your guess are: ";

        public const string RegexColourPattern = @"BLUE|RED|GREEN|ORANGE|PURPLE|YELLOW";
        public const string RegexWordSearchPattern = @"[a-zA-Z]+";

        public const int GuessLimit = 60;
        public const int MinColoursRange = 0;
        public const int MaxColoursRange = 6;
        public const int ComputerArrayLen = 4;
        public const int BlackHintsRequiredToWin = 4;
        public const string SpaceCommaDelimiter = ", ";
        public const string NewLine = "\n";
    }
}
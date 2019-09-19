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
                                           "\nThe returned elements are always shuffled, so they will never be the same!";

        public const string RegexColourPattern = @"BLUE|RED|GREEN|ORANGE|PURPLE|YELLOW";
    }
}
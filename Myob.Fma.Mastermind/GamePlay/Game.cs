using System;
using System.Collections.Generic;
using System.Linq;
using Myob.Fma.Mastermind.Enums;
using Myob.Fma.Mastermind.GameServices.Counter;
using Myob.Fma.Mastermind.GameServices.Players;

namespace Myob.Fma.Mastermind.GamePlay
{
    public class Game : IGame
    {
        public Game(IComputerPlayer computerPlayer, IGuessCounter guessCounter)
        {
            ComputerPlayer = computerPlayer;
            GuessCounter = guessCounter;
        }
        
        public IGuessCounter GuessCounter { get; }
        public  IComputerPlayer ComputerPlayer { get; }

        public IEnumerable<HintColour> Check(GuessColour[] usersGuess)
        {
            var hints = SetExactMatchesToHints(usersGuess);
            hints = SetNonPositionMatchesToHints(usersGuess, hints);
            hints = ShuffleHints(hints);
            return hints.ToArray();
        }
        
        private List<HintColour> SetExactMatchesToHints(IEnumerable<GuessColour> usersGuess)
        {
            var numberOfExactMatches = CalculateExactMatchesInUsersGuess(usersGuess);
            return Enumerable.Repeat(HintColour.Black, numberOfExactMatches).ToList();
        }
        
        private int CalculateExactMatchesInUsersGuess(IEnumerable<GuessColour> userGuess)
        {
            var computerSelection = ComputerPlayer.GetCodeSelection();
            return userGuess.Where((colour, index) => colour == computerSelection[index]).Count();
        }

        private List<HintColour> SetNonPositionMatchesToHints(IReadOnlyList<GuessColour> userGuess,
            List<HintColour> hints)
        {
            var computerSelection = ComputerPlayer.GetCodeSelection();

            var unmatchedComputerSelection = GetListItemsThatDontHaveExactMatches(computerSelection, userGuess);
            var unmatchedUserSelection = GetListItemsThatDontHaveExactMatches(userGuess, computerSelection);

            return AddWhiteHintsToList(unmatchedComputerSelection, unmatchedUserSelection, hints);
        }
        
        private static List<GuessColour> GetListItemsThatDontHaveExactMatches(IEnumerable<GuessColour> guessColours,
            IReadOnlyList<GuessColour> comparingList)
        {
            return guessColours.Where((colour, index) => colour != comparingList[index]).ToList();
        }

        private static List<HintColour> AddWhiteHintsToList(IEnumerable<GuessColour> userSelection,
            ICollection<GuessColour> computerSelection, List<HintColour> hints)
        {
            foreach (var guess in userSelection)
            {
                if (computerSelection.Contains(guess))
                {
                    hints.Add(HintColour.White);
                    computerSelection.Remove(guess);
                }
            }
            return hints;
        }

        private List<HintColour> ShuffleHints(List<HintColour> hints)
        {
            var random = new Random();
            return hints.OrderBy(x => random.Next(int.MaxValue)).ToList();
        }
    }
}
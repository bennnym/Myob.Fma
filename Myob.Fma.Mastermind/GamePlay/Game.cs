using System;
using System.Collections.Generic;
using System.Linq;
using Myob.Fma.Mastermind.Enums;
using Myob.Fma.Mastermind.GameServices.Players;

namespace Myob.Fma.Mastermind.GamePlay
{
    public class Game : IGame
    {
        private readonly IComputerPlayer _computerPlayer;
        public Game(IComputerPlayer computerPlayer)
        {
            _computerPlayer = computerPlayer;
        }
        
        public IEnumerable<HintColour> Check(GuessColour[] usersGuess)
        {
            var hints = SetExactMatchesToHints(usersGuess);
            SetNonPositionMatchesToHints(usersGuess,ref hints);
            return ShuffleHints(hints);
        }

        public void SetComputerPlayersCode()
        {
            _computerPlayer.SetHiddenCode();
        }
        
        private List<HintColour> SetExactMatchesToHints(IEnumerable<GuessColour> usersGuess)
        {
            var numberOfExactMatches = CalculateExactMatchesInUsersGuess(usersGuess);
            return Enumerable.Repeat(HintColour.Black, numberOfExactMatches).ToList();
        }
        
        private int CalculateExactMatchesInUsersGuess(IEnumerable<GuessColour> userGuess)
        {
            var computerSelection = _computerPlayer.GetCodeSelection();
            return userGuess.Where((colour, index) => colour == computerSelection[index]).Count();
        }

        private void SetNonPositionMatchesToHints(IReadOnlyList<GuessColour> userGuess,
            ref List<HintColour> hints)
        {
            var computerSelection = _computerPlayer.GetCodeSelection();

            var unmatchedComputerSelection = GetListItemsThatDontHaveExactMatches(computerSelection, userGuess);
            var unmatchedUserSelection = GetListItemsThatDontHaveExactMatches(userGuess, computerSelection);

            AddWhiteHintsToList(unmatchedComputerSelection, unmatchedUserSelection,ref hints);
        }
        
        private static List<GuessColour> GetListItemsThatDontHaveExactMatches(IEnumerable<GuessColour> guessColours,
            IReadOnlyList<GuessColour> comparingList)
        {
            return guessColours.Where((colour, index) => colour != comparingList[index]).ToList();
        }

        private static void AddWhiteHintsToList(IEnumerable<GuessColour> userSelection,
            ICollection<GuessColour> computerSelection,ref List<HintColour> hints)
        {
            foreach (var guess in userSelection)
            {
                if (computerSelection.Contains(guess))
                {
                    hints.Add(HintColour.White);
                    computerSelection.Remove(guess);
                }
            }
        }

        private IEnumerable<HintColour> ShuffleHints(IEnumerable<HintColour> hints)
        {
            var random = new Random();
            return hints.OrderBy(x => random.Next(int.MaxValue));
        }
    }
}
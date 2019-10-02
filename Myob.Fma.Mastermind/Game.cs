using System;
using System.Collections.Generic;
using System.Linq;
using Myob.Fma.Mastermind.Enums;
using Myob.Fma.Mastermind.GameServices.Players;

namespace Myob.Fma.Mastermind
{
    public class Game
    {
        private readonly IPlayer _computerPlayer;
        private List<HintColour> _hints;

        public Game(IPlayer computerPlayer)
        {
            _computerPlayer = computerPlayer;
            _hints = new List<HintColour>();
        }

        public HintColour[] Check(GuessColour[] usersGuess)
        {
            _hints.Clear(); // make a hint object? dont make a global var instantiate a new one each time
            SetExactMatchesToHints(usersGuess);
            SetIncorrectPositionMatchesToHints(usersGuess);
            ShuffleHints();
            return _hints.ToArray();
        }

        private void SetExactMatchesToHints(GuessColour[] usersGuess)
        {
            var numberOfExactMatches = CalculateExactMatchesInUsersGuess(usersGuess);

            for (var i = 0; i < numberOfExactMatches; i++)
            {
                _hints.Add(HintColour.Black);
            }
        }

        private void SetIncorrectPositionMatchesToHints(GuessColour[] userGuess)
        {
            var computerSelection = _computerPlayer.GetCodeSelection();

            var unmatchedComputerSelection = GetListItemsThatDontHaveExactMatches(computerSelection, userGuess);
            var unmatchedUserSelection = GetListItemsThatDontHaveExactMatches(userGuess, computerSelection);

            UpdateIncorrectPositionMatchHints(unmatchedComputerSelection, unmatchedUserSelection);
        }

        private int CalculateExactMatchesInUsersGuess(GuessColour[] userGuess)
        {
            var computerSelection = _computerPlayer.GetCodeSelection();
            return userGuess.Where((colour, index) => colour == computerSelection[index]).Count();
        }

        private List<GuessColour> GetListItemsThatDontHaveExactMatches(IEnumerable<GuessColour> guessColours,
            IReadOnlyList<GuessColour> comparingList)
        {
            return guessColours.Where((colour, index) => colour != comparingList[index]).ToList();
        }

        private void UpdateIncorrectPositionMatchHints(List<GuessColour> userSelection,
            List<GuessColour> computerSelection)
        {
            foreach (var guess in userSelection)
            {
                if (computerSelection.Contains(guess))
                {
                    _hints.Add(HintColour.White);
                    computerSelection.Remove(guess);
                }
            }
        }

        private void ShuffleHints()
        {
            var random = new Random();

            _hints = _hints.OrderBy(x => random.Next(int.MaxValue)).ToList();
        }
    }
}
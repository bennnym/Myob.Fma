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

        public HintColour[] Check(GuessColour[] userGuess)
        {
            _hints.Clear();
            var exactMatches = CalculateExactMatchesInUsersGuess(userGuess);
            SetExactMatchesToHints(exactMatches);
            SetMatchesWithIncorrectPositions(userGuess);
            ShuffleHints();

            return _hints.ToArray();
        }

        private int CalculateExactMatchesInUsersGuess(GuessColour[] userGuess)
        {
            var computerSelection = _computerPlayer.GetCodeSelection();
            return computerSelection.Where((guess, index) => guess == userGuess[index]).Count();
        }

        private void SetExactMatchesToHints(int exactMatches)
        {
            for (var i = 0; i < exactMatches; i++)
            {
                _hints.Add(HintColour.Black);
            }
        }

        private void SetMatchesWithIncorrectPositions(GuessColour[] userGuess)
        {
            var computerSelection = _computerPlayer.GetCodeSelection();

            var unmatchedComputerSelection = GetListItemsThatDontHaveExactMatches(computerSelection, userGuess);
            var unmatchedUserSelection = GetListItemsThatDontHaveExactMatches(userGuess, computerSelection);

            SetNonExactMatchesToHints(unmatchedComputerSelection, unmatchedUserSelection);
        }

        private List<GuessColour> GetListItemsThatDontHaveExactMatches(IEnumerable<GuessColour> arr,
            IReadOnlyList<GuessColour> arrToCompareTo)
        {
            return arr.Where((guess, index) => guess != arrToCompareTo[index]).ToList();
        }

        private void SetNonExactMatchesToHints(List<GuessColour> unmatchedUserSelection,
            List<GuessColour> unmatchedComputerSelection)
        {
            foreach (var guess in unmatchedUserSelection)
            {
                if (unmatchedComputerSelection.Contains(guess))
                {
                    _hints.Add(HintColour.White);
                    unmatchedComputerSelection.Remove(guess);
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
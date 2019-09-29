using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using Myob.Fma.Mastermind.Enums;
using Myob.Fma.Mastermind.GameServices.Players;
using Constant = Myob.Fma.Mastermind.Constants.Constant;

namespace Myob.Fma.Mastermind
{
    public class Game
    {
        private readonly IPlayer _computerPlayer;
        private readonly List<HintColour> _hints = new List<HintColour>();

        public Game(IPlayer computerPlayer)
        {
            _computerPlayer = computerPlayer;
        }

        public HintColour[] Check(GuessColour[] userGuess)
        {
            _hints.Clear();
            var exactMatches = CalculateExactMatchesInUsersGuess(userGuess);
            SetExactMatchesToList(exactMatches);
            SetMatchesWithIncorrectPositions(userGuess);

            return _hints.ToArray();
        }

        private int CalculateExactMatchesInUsersGuess(GuessColour[] userGuess)
        {
            var computerSelection = _computerPlayer.GetCodeSelection();
            
            return computerSelection.Where((guess, index) => guess == userGuess[index]).Count();
        }

        private void SetExactMatchesToList(int exactMatches)
        {
            for (int i = 0; i < exactMatches; i++)
            {
                _hints.Add(HintColour.Black);
            }
        }

        private void SetMatchesWithIncorrectPositions(GuessColour[] userGuess)
        {
            var computerSelection = _computerPlayer.GetCodeSelection();

            var unmatchedComputerSelection = GetListItemsThatDontHaveExactMatches(computerSelection, userGuess);
            var unmatchedUserSelection = GetListItemsThatDontHaveExactMatches(userGuess, computerSelection);
                
            foreach (var guess in unmatchedUserSelection)
            {
                if (unmatchedComputerSelection.Contains(guess))
                {
                    _hints.Add(HintColour.White);
                    unmatchedComputerSelection.Remove(guess);
                }
            }
        }

        private List<GuessColour> GetListItemsThatDontHaveExactMatches(GuessColour[] arr, GuessColour[] arrToCompareTo)
        {
           return arr.Where((guess, index) => guess != arrToCompareTo[index]).ToList();
        }
    }
}
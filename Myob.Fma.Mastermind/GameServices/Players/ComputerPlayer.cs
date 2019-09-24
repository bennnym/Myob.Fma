using System;
using System.Collections.Generic;
using System.Linq;
using Myob.Fma.Mastermind.Constants;
using Myob.Fma.Mastermind.Enums;

namespace Myob.Fma.Mastermind.GameServices.Players
{
    public class ComputerPlayer : IPlayer
    {
        private GuessColour[] _codeSelection;

        public static ComputerPlayer GetPlayer()
        {
            return new ComputerPlayer()
            {
                _codeSelection = GenerateRandomColourArray()
            };
        }

        public GuessColour[] GetCodeSelection()
        {
            return _codeSelection;
        }

        public Dictionary<GuessColour, Dictionary<int, List<int>>> GetCodeSelectionDictionary()
        {
            var codeDict = new Dictionary<GuessColour, Dictionary<int, List<int>>>();

            for (int index = 0; index < _codeSelection.Length; index++)
            {
                var colour = _codeSelection[index];
                var numberOfColours = _codeSelection.Count(c => c == colour);

                if (codeDict.ContainsKey(colour))
                {
                    codeDict[colour][numberOfColours].Add(index);
                }
                
                codeDict[colour][numberOfColours] = new List<int>(){index};
            }

            return codeDict;
        }

        private static GuessColour[] GenerateRandomColourArray()
        {
            var randomNum = new Random();
            var colours = new GuessColour[4];

            for (int i = 0; i < 4; i++)
            {
                colours[i] = (GuessColour) randomNum.Next(Constant.MinColoursRange, Constant.MaxColoursRange);
            }

            return colours;
        }
    }
}
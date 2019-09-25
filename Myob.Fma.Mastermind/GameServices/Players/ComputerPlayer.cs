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

        public static ComputerPlayer CreatePlayer()
        {
            return new ComputerPlayer()
            {
                _codeSelection = GenerateRandomColourArray()
            };
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

        public virtual GuessColour[] GetCodeSelection()
        {
            return _codeSelection;
        }
    }
}
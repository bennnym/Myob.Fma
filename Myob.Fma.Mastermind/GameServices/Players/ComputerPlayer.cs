using System;
using Myob.Fma.Mastermind.Constants;
using Myob.Fma.Mastermind.Enums;

namespace Myob.Fma.Mastermind.GameServices.Players
{
    public class ComputerPlayer : IComputerPlayer
    {
        private readonly GuessColour[] _codeSelection;

        public ComputerPlayer()
        {
            _codeSelection = GenerateRandomColourArray();
        }

        private static GuessColour[] GenerateRandomColourArray()
        {
            var randomNum = new Random();
            var colours = new GuessColour[4];

            for (var i = 0; i < Constant.ComputerArrayLen; i++)
            {
                colours[i] = (GuessColour) randomNum.Next(Constant.MinColoursRange, Constant.MaxColoursRange);
            }

            return colours;
        }

        public  GuessColour[] GetCodeSelection()
        {
            return _codeSelection;
        }
    }
}
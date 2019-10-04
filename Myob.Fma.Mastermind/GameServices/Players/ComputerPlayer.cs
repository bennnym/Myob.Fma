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
            _codeSelection = new GuessColour[4];
        }

        public void SetHiddenCode()
        {
            var randomNum = new Random();

            for (var i = 0; i < Constant.ComputerArrayLen; i++)
            {
                _codeSelection[i] = (GuessColour) randomNum.Next(Constant.MinColoursRange, Constant.MaxColoursRange);
            }
        }

        public  GuessColour[] GetCodeSelection()
        {
            return _codeSelection;
        }
    }
}
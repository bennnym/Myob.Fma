using System.Collections.Generic;
using System.Linq;
using Myob.Fma.Mastermind.Enums;
using Myob.Fma.Mastermind.GameServices.Players;

namespace Myob.Fma.MastermindTests.Fakes
{
    public class FakeComputerPlayer : IPlayer
    {
        private GuessColour[] _codeSelection;

        public FakeComputerPlayer()
        {
            _codeSelection = new GuessColour[] {GuessColour.RED, GuessColour.RED, GuessColour.RED, GuessColour.RED};
        }

        public GuessColour[] GetCodeSelection()
        {
            return _codeSelection;
        }

     
    }
}
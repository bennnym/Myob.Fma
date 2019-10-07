using System.Collections.Generic;
using Myob.Fma.Mastermind.Enums;
using Myob.Fma.Mastermind.GameServices.Counter;
using Myob.Fma.Mastermind.GameServices.Players;

namespace Myob.Fma.Mastermind.GamePlay
{
    public interface IGame
    {
        void SetComputerPlayersCode();
        IEnumerable<HintColour> Check(GuessColour[] usersGuess);
    }
}
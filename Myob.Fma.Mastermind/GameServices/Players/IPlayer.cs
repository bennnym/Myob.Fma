using System.Collections.Generic;
using Myob.Fma.Mastermind.Enums;

namespace Myob.Fma.Mastermind.GameServices.Players
{
    public interface IComputerPlayer
    {
        GuessColour[] GetCodeSelection();
        void SetHiddenCode();
    }
}
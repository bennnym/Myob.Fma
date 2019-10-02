using System.Collections.Generic;
using Myob.Fma.Mastermind.Enums;

namespace Myob.Fma.Mastermind.GameServices.Input.Processor
{
    public interface IInputProcessor
    {
        GuessColour[] GetUsersColourGuess();
    }
}
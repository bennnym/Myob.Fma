using System.Collections.Generic;

namespace Myob.Fma.Mastermind.GameServices.Input.Processor
{
    public interface IInputProcessor
    {
        List<Colours> GetUsersCodeGuess();
    }
}
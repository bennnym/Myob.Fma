using System.Collections.Generic;

namespace Myob.Fma.Mastermind.GameServices.Input
{
    public interface IGameInput
    {
        List<Colours> GetUsersCodeGuess();
    }
}
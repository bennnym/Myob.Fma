using System.Collections.Generic;
using System.Drawing;

namespace Myob.Fma.Mastermind.GameServices.Input
{
    public interface IGameInput
    {
        List<Colours> GetUsersCodeGuess();
    }
}
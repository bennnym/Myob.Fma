using System.Collections.Generic;
using Myob.Fma.Mastermind.Enums;

namespace Myob.Fma.Mastermind.GameServices.Output
{
    public interface IMessageFormatter
    {
        string GetHintMessage(IEnumerable<HintColour> hintColours);
    }
}
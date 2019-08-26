using System.Collections.Generic;
using Myob.Fma.GameOfLife.BoardOperations;
using Myob.Fma.GameOfLife.Rules;

namespace Myob.Fma.GameOfLife.GameOperations
{
    public interface IGame
    {
        IBoard Board { get; }
        IList<IRule> Rules { get; }
    }
}
using System.Collections.Generic;
using Myob.Fma.GameOfLife.BoardOperations;
using Myob.Fma.GameOfLife.Rules;

namespace Myob.Fma.GameOfLife.GameOperations
{

    public class Game : IGame
    {
        public IBoard Board { get; private set; }    
        public IList<IRule> Rules { get; private set; }

        public Game(IBoard board, IList<IRule> rules)
        {
            Board = board;
            Rules = rules;
        }
    }
}
using System.Collections.Generic;
using Myob.Fma.GameOfLife.BoardOperations;
using Myob.Fma.GameOfLife.Rules;

namespace Myob.Fma.GameOfLife.GameOperations
{

    public class Game : IGame
    {
        public Board Board { get; private set; }    
        public IList<IRule> Rules { get; private set; }

        public static Game Create(Board board, IList<IRule> rules)
        {
            return new Game()
            {
                Board = board,
                Rules = rules
            };
        }
    }
}
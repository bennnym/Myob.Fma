using System.Reflection.Metadata;
using Myob.Fma.Mastermind.Enums;
using Myob.Fma.Mastermind.GameServices.Players;
using Constant = Myob.Fma.Mastermind.Constants.Constant;

namespace Myob.Fma.Mastermind
{
    public class Game
    {
        private readonly IPlayer _computerPlayer;

        public Game(IPlayer computerPlayer)
        {
            _computerPlayer = computerPlayer;
        }

        public HintColour[] Check(GuessColour[] userGuess)
        {
            var computerSelection = _computerPlayer.GetCodeSelection();

            for (int i = 0; i < Constant.ComputerArrayLen; i++)
            {
            }
            
            return new HintColour[]
                {
                    HintColour.Black, 
                    HintColour.Black, 
                    HintColour.Black, 
                    HintColour.Black
                };
        }
    }
}
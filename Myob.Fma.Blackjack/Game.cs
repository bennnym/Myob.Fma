using System;
using System.Collections.Generic;
using System.Linq;

namespace Myob.Fma.Blackjack
{
    public class Game
    {
        private readonly IEnumerable<ICardPlayer> _players;
        private readonly Deck _deck;

        public Game(ICardPlayer player, ICardPlayer dealer)
        {
            _players = new List<ICardPlayer>() {player, dealer};
            _deck = new Deck();
        }

        public void StartGame()
        {
            var gamePlay = true;

            GetPlayerDeposit();

            while (gamePlay)
            {
                DealOpeningHands();
                PrintOpeningHandPrompt();
                StartPlayerAndDealersTurn();
                gamePlay = AskUserToPlayAgain();
            }
        }

        private void StartPlayerAndDealersTurn()
        {
            foreach (var cardPlayer in _players)
            {
                var play = true;

                if (cardPlayer.PlayerType == PlayerClassification.Dealer)
                {
                    cardPlayer.PrintLastCard();
                }

                while (play)
                {
                    play = cardPlayer.HitOrStand();

                    if (cardPlayer.Bust) return;
                    if (!play) break;

                    cardPlayer.GetCard(_deck.DealCard());
                    cardPlayer.PrintLastCard();
                }
            }

            DetermineGameWinner();
        }

        private void DealOpeningHands()
        {
            var numberOfPlayers = _players.Count();

            for (int i = 0; i < numberOfPlayers; i++)
            {
                foreach (var player in _players)
                {
                    player.GetCard(_deck.DealCard());
                }
            }
        }

        private void PrintOpeningHandPrompt()
        {
            foreach (var cardPlayer in _players)
            {
                cardPlayer.ShowOpeningDeal();
            }
        }

        private void DetermineGameWinner()
        {
            var playerScore = 0;
            var dealerScore = 0;
            var dealerBust = false;

            foreach (var cardPlayer in _players)
            {
                if (cardPlayer.PlayerType == PlayerClassification.Player)
                {
                    playerScore = cardPlayer.FinalScore;
                }
                else
                {
                    dealerScore = cardPlayer.FinalScore;
                    dealerBust = cardPlayer.Bust;
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
            if (playerScore > dealerScore || dealerBust)
            {
                Console.WriteLine("====================================");
                Console.WriteLine("You won, nice work!");
                Console.WriteLine("====================================");
            }
            else if (dealerScore > playerScore)
            {
                Console.WriteLine("====================================");
                Console.WriteLine("Dealer wins, better luck next time!");
                Console.WriteLine("====================================");
            }
            else
            {
                Console.WriteLine("====================================");
                Console.WriteLine("Game is a draw");
                Console.WriteLine("====================================");
            }
        }

        private bool AskUserToPlayAgain()
        {
            Console.WriteLine("Play another hand? (y/n)");

            var answer = Console.ReadLine().Trim().ToLower();

            if (answer == "y")
            {
                foreach (var cardPlayer in _players)
                {
                    cardPlayer.ClearLastHand();
                }
            }

            return answer == "y";
        }

        private void GetPlayerDeposit()
        {
            foreach (var cardPlayer in _players)
            {
                if (cardPlayer.PlayerType == PlayerClassification.Player)
                {
                    cardPlayer.BettingBank.DepositFunds();
                }
            }
        }
    }
}
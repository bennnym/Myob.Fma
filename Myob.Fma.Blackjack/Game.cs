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
            DealOpeningHands();
            OpeningHandPrompt();
            StartPlayerAndDealersTurn();
            DetermineGameWinner();
        }

        private void StartPlayerAndDealersTurn()
        {
            foreach (var player in _players)
            {
                var play = true;

                if (player.PlayerType == PlayerClassification.Dealer)
                {
                    player.PrintLastCard();
                }

                while (play)
                {
                    play = player.HitOrStand();
                
                    if (player.Bust) return;
                    if (!play) break;
                
                    player.GetCard(_deck.DealCard());
                    player.PrintLastCard();
                }
            }
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

        private void OpeningHandPrompt()
        {
            foreach (var player in _players)
            {
                player.ShowOpeningDeal();
            }
        }

        private void DetermineGameWinner()
        {
            var playerScore = 0;
            var dealerScore = 0;
            var dealerBust = false;
            
            foreach (var player in _players)
            {
                if (player.PlayerType == PlayerClassification.Player)
                {
                    playerScore = player.FinalScore;
                }
                else
                {
                    dealerScore = player.FinalScore;
                    dealerBust = player.Bust;
                }
            }

            if (playerScore > dealerScore || dealerBust)
            {
                Console.WriteLine("You won, nice work!");
            }
            else if (dealerScore > playerScore)
            {
                Console.WriteLine("Dealer wins, better luck next time!");
            }
            else
            {
                Console.WriteLine("Game is a draw");
            }
            
            
                
        }
    }
}
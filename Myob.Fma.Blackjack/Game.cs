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
                if (!CheckIfPlayerHasEnoughFunds()) break;
                    
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

                    if (cardPlayer.Bust && cardPlayer.PlayerType == PlayerClassification.Player) return;
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
                foreach (var cardPlayer in _players)
                {
                    cardPlayer.GetCard(_deck.DealCard());
                }
            }
        }

        private void PrintOpeningHandPrompt()
        {
            foreach (var cardPlayer in _players)
            {
                if (cardPlayer.PlayerType == PlayerClassification.Player)
                {
                    cardPlayer.BettingBank.TakeBet();
                }

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

            foreach (var cardPlayer in _players)
            {
                if (cardPlayer.PlayerType == PlayerClassification.Player)
                {
                    if (playerScore > dealerScore || dealerBust)
                    {
                        cardPlayer.BettingBank.ProcessWin();
                    }
                    else if (dealerScore > playerScore)
                    {
                        cardPlayer.BettingBank.ProcessLoss();
                    }
                    else
                    {
                        cardPlayer.BettingBank.ProcessDraw();
                    }
                }
            }
        }

        private bool AskUserToPlayAgain()
        {
            Console.ForegroundColor = ConsoleColor.White;
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

        private bool CheckIfPlayerHasEnoughFunds()
        {
            foreach (var cardPlayer in _players)
            {
                if (cardPlayer.PlayerType == PlayerClassification.Player && cardPlayer.BettingBank.BankBalance == 0)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("====================================");
                    Console.WriteLine("You have no money left, exiting game.");
                    Console.WriteLine("====================================");
                    return false;
                }
            }

            return true;
        }
    }
}
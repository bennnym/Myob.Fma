using System;
using System.Collections.Generic;
using System.Linq;

namespace Myob.Fma.Blackjack
{
    public class Player : ICardPlayer
    {
        private readonly List<Card> _cards;

        public Player()
        {
            _cards = new List<Card>();
            PlayerType = PlayerClassification.Player;
            BettingBank = new BettingBank();
        }

        public int FinalScore { get; private set; }
        public bool Bust { get; private set; }
        public IBettingBank BettingBank { get; }
        public PlayerClassification PlayerType { get; }

        public void ShowOpeningDeal()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("====================================");
            Console.WriteLine(
                $"Player has {_cards[0].Value} of {_cards[0].Suit}s and {_cards[1].Value} of {_cards[1].Suit}s");
            Console.WriteLine($"Player total: {GetHandTotal()}");
            Console.WriteLine("====================================");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void GetCard(Card card)
        {
            _cards.Add(card);
        }

        public void ClearLastHand()
        {
            _cards.Clear();
            Bust = false;
        }

        public void PrintLastCard()
        {
            var lastCard = _cards[_cards.Count - 1];
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("====================================");
            Console.WriteLine($"You have been dealt a {lastCard.Value} of {lastCard.Suit}s");
            Console.WriteLine($"Player Total: {GetHandTotal()}");
            Console.WriteLine("====================================");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public bool HitOrStand()
        {
            if (!PlayerCanPlayOn()) return false;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Hit Or Stand? (h/s)");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;

            var answer = Console.ReadLine().Trim().ToLower();

            if (answer == "h") return true;
            if (answer == "s")
            {
                FinalScore = GetHandTotal();
                return false;
            }

            Console.WriteLine("Sorry, I do not understand those instructions try again:");
            return HitOrStand();
        }

        private int GetHandTotal()
        {
            var acesFound = _cards.FindAll(card => card.Value == "Ace").Count;
            var handTotal = _cards.Aggregate(0, (total, card) => total + card.NumericalValue);

            while (acesFound > 0 && handTotal > 21)
            {
                handTotal -= 10;
                acesFound -= 1;
            }

            return handTotal;
        }

        private bool PlayerCanPlayOn()
        {
            var handTotal = GetHandTotal();

            if (handTotal > 21)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("==================");
                Console.WriteLine("|| Player Busts ||");
                Console.WriteLine("==================");
                Console.ForegroundColor = ConsoleColor.White;
                BettingBank.ProcessLoss();
                Bust = true;
                FinalScore = handTotal;
                return false;
            }

            if (handTotal == 21)
            {
//                Console.WriteLine("You scored 21, nice work!");
                FinalScore = handTotal;
                return false;
            }

            return true;
        }
    }
}
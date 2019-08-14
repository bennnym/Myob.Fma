using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Myob.Fma.Blackjack
{
    public class Dealer : ICardPlayer
    {
        private readonly List<Card> _cards;

        public Dealer()
        {
            _cards = new List<Card>();
            PlayerType = PlayerClassification.Dealer;
        }
        
        public int FinalScore { get; private set; }
        public bool Bust { get; private set; }
        public PlayerClassification PlayerType { get; }

        public void PrintLastCard()
        {
            var lastCard = _cards[_cards.Count - 1];
            Console.WriteLine($"Dealer has been dealt a {lastCard.Value} of {lastCard.Suit}s");
            Console.WriteLine($"Dealer total: {GetHandTotal()}");
            Thread.Sleep(3000);
        }

        public void GetCard(Card card)
        {
            _cards.Add(card);
        }

        public bool HitOrStand()
        {
            var handTotal = GetHandTotal();

            if (handTotal <= 16) return true;
            if (handTotal <= 21)
            {
                FinalScore = handTotal;
                return false;
            }
            Console.WriteLine("========");
            Console.WriteLine("|| Dealer Busts ||");
            Console.WriteLine("========");
            Bust = true;
            FinalScore = handTotal;
            return false;

        }

        public void ShowOpeningDeal()
        {
            Console.WriteLine($"Dealer has {_cards[0].Value} of {_cards[0].Suit}s and a face down card.");
            Console.WriteLine($"Dealer total: {_cards[0].NumericalValue}");
            Console.WriteLine("----------------");
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
    }
}
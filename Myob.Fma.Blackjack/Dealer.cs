using System;
using System.Collections.Generic;

namespace Myob.Fma.Blackjack
{
    public class Dealer
    {
        private List<Card> cards;

        public Dealer(Card visibleCard, Card hiddenCard)
        {
            cards = new List<Card>() {visibleCard, hiddenCard};
        }

        public void ShowOpeningDeal()
        {
            Console.WriteLine($"Dealer has {cards[0].Value} of {cards[0].Suit}S");
            Console.WriteLine($"Dealer score is {cards[0].NumericalValue}");
        }
    }
}
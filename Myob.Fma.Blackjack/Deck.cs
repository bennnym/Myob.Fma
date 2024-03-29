using System;
using System.Collections.Generic;
using System.Linq;

namespace Myob.Fma.Blackjack
{
    public class Deck
    {
        private readonly List<Card> _deck;
        
        public Deck()
        {
            _deck = new List<Card>();
            PopulateDeckWithCards();
            ShuffleCards();
        }

        public Card DealCard()
        {
            var card = _deck[0];
            _deck.Remove(card);
            return card;
        }

        private void ShuffleCards()
        {
            // https://stackoverflow.com/questions/273313/randomize-a-listt
            // Fisher-Yates Shuffle
            
            Random randomNumGenerator = new Random();
            
            int cardCount = _deck.Count;  
            
            while (cardCount > 1) 
            {  
                cardCount--;  
                int nextRandomNum = randomNumGenerator.Next(cardCount + 1);  
                var value = _deck[nextRandomNum];  
                _deck[nextRandomNum] = _deck[cardCount];  
                _deck[cardCount] = value;  
            }  
        }

        private void PopulateDeckWithCards()
        {
            var suits = new [] {"Heart", "Diamond", "Spade", "Club"};
            var values = new [] {"Ace", "2", "3", "4", "5", "6", "7", "8", "9", "Ten", "Jack", "Queen", "King"};

            foreach (var suit in suits)
            {
                foreach (var value in values)
                {
                    _deck.Add(new Card(suit, value));
                }
            }
        }
        
    }
}
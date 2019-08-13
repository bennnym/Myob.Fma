using System;
using System.Collections.Generic;
using System.Linq;

namespace Myob.Fma.Blackjack
{
    public class Deck
    {
        private List<Card> _deck;
        
        public Deck()
        {
            _deck = new List<Card>();
            PopulateDeckWithCards();
        }

        public void ShuffleCards()
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
            var suits = new [] {"HEART", "DIAMOND", "SPADES", "CLUB"};
            var values = new [] {"ACE", "2", "3", "4", "5", "6", "7", "8", "9", "TEN", "JACK", "QUEEN", "KING"};

            foreach (var suit in suits)
            {
                foreach (var value in values)
                {
                    _deck.Add(new Card(suit, value));
                }
            }
        }

        public void PrintCards()
        {
            foreach (var card in _deck)
            {
                Console.WriteLine($"suit: {card.Suit}, value: {card.Value}");
            }
        }
    }
}
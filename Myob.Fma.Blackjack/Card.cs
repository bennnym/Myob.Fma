using System.Collections.Generic;

namespace Myob.Fma.Blackjack
{
    public class Card
    {
        private Dictionary<string, int> pictureCards;

        public Card(string suit, string value)
        {
            Suit = suit;
            Value = value;
            pictureCards = new Dictionary<string, int>()
            {
                {"ACE", 11},
                {"JACK", 10},
                {"QUEEN", 10},
                {"KING", 10},
                {"TEN", 10},
            };
            InitializeCardValue();
        }
        
        public string Suit { get; }
        public string Value { get; }
        public int NumericalValue { get; private set; }

        private void InitializeCardValue()
        {
            var cardConversionSuccess = int.TryParse(Value, out int cardValue);

            NumericalValue = cardConversionSuccess ? cardValue : pictureCards[Value];
        }
    }
}
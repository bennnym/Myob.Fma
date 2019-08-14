using System.Collections.Generic;

namespace Myob.Fma.Blackjack
{
    public class Card
    {
        private Dictionary<string, int> pictureCardValues;

        public Card(string suit, string value)
        {
            Suit = suit;
            Value = value;
            pictureCardValues = new Dictionary<string, int>()
            {
                {"Ace", 11},
                {"Jack", 10},
                {"Queen", 10},
                {"King", 10},
                {"Ten", 10},
            };    
            InitializeCardValue();
        }

        #region MyRegion

        public string Suit { get; }
        public string Value { get; }
        public int NumericalValue { get; private set; }

        #endregion
  

        private void InitializeCardValue()
        {
            var cardConversionSuccess = int.TryParse(Value, out int cardValue);

            NumericalValue = cardConversionSuccess ? cardValue : pictureCardValues[Value];
        }
    }
}
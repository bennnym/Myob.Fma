using System.Collections.Generic;

namespace Myob.Fma.Blackjack
{
    public class Player
    {
        private List<Card> cards;

        public Player(Card first, Card second)
        {
            cards = new List<Card>() {first, second};
        }
    }
}
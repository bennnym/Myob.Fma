using System;

namespace Myob.Fma.Blackjack
{
    class Program
    {
        static void Main(string[] args)
        {
            var deck = new Deck();
            
            deck.PrintCards();

            Console.WriteLine("-------SHUFFLED-----------");
            Console.WriteLine("-------SHUFFLED-----------");
            Console.WriteLine("-------SHUFFLED-----------");
            Console.WriteLine("-------SHUFFLED-----------");
            Console.WriteLine("-------SHUFFLED-----------");
            
            deck.ShuffleCards();
            
            deck.PrintCards();
            
            var dealer = new Dealer(new Card("SPADE", "ACE"), new Card("Heart", "KING") );
            
            dealer.ShowOpeningDeal();
        }
    }
}
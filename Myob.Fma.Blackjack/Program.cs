namespace Myob.Fma.Blackjack
{
    class Program
    {
        static void Main(string[] args)
        {    
            var player = new Player();
//            player.GetCard(new Card("club", "9"));
//            player.GetCard(new Card("club", "Ace"));
//            player.GetCard(new Card("club", "6"));
//            player.GetCard(new Card("club", "Ace"));
            var dealer = new Dealer();
            var game = new Game(player, dealer);
            
            game.StartGame();
            
        }
    }
}
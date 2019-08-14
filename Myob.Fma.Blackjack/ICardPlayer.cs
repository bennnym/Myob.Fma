namespace Myob.Fma.Blackjack
{
    public interface ICardPlayer
    {
        void ShowOpeningDeal();
        void PrintLastCard();
        void GetCard(Card card);
        bool HitOrStand();
        bool Bust { get; }
        int FinalScore { get; }
        PlayerClassification PlayerType { get; }
    }
}
namespace Myob.Fma.Blackjack
{
    public interface ICardPlayer
    {
        void ShowOpeningDeal();
        void PrintLastCard();
        void GetCard(Card card);
        bool HitOrStand();
        void ClearLastHand();
        IBettingBank BettingBank { get; }
        bool Bust { get; }
        int FinalScore { get; }
        PlayerClassification PlayerType { get; }
    }
}
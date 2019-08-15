namespace Myob.Fma.Blackjack
{
    public interface IBettingBank
    {
        int BankBalance { get; }
        int PendingBets { get; }
        void TakeBet();
        void ProcessWin();
        void ProcessLoss();
        void DepositFunds();
    }
}
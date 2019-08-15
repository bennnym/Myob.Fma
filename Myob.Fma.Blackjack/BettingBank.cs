using System;

namespace Myob.Fma.Blackjack
{
    public class BettingBank : IBettingBank
    {
        public int BankBalance { get; private set; }
        public int PendingBets { get; private set; }

        public void TakeBet()
        {
            Console.WriteLine("Place your bet amount (enter a valid number)");

            ValidateBetAmount(Console.ReadLine(), out int betAmount);
            
            BankBalance -= PendingBets;
            PendingBets = betAmount;
        }

        public void ProcessWin()
        {
            BankBalance += PendingBets;
            PendingBets = 0;
        }

        public void ProcessLoss()
        {
            BankBalance -= PendingBets;
            PendingBets = 0;
        }

        public void DepositFunds()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("How much money would you like to take to the table? please enter a number");

            var numberEntered = int.TryParse(Console.ReadLine(), out int amount);

            if (!numberEntered)
            {
                Console.WriteLine("Sorry, you have to enter a number that I can recognize, try again.");
                DepositFunds();
            }


            BankBalance += amount;
        }

        private void ValidateBetAmount(string betString, out int betInt)
        {
            var validInput = int.TryParse(betString, out int betTotal);
            
            if (!validInput)
            {
                Console.WriteLine("I am sorry, that is not a valid amount. Try again.");
                TakeBet();
            }

            if (betTotal > BankBalance)
            {
                Console.WriteLine($"You don't have enough money to bet that amount, your current balance is {BankBalance}. Try again.");
                TakeBet();
            }

            betInt = betTotal;
        }
    }
}
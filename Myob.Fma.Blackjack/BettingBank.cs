using System;

namespace Myob.Fma.Blackjack
{
    public class BettingBank : IBettingBank
    {
        public int BankBalance { get; private set; }
        public int PendingBets { get; private set; }

        public void TakeBet()
        {
            var validatedBetAmount = ValidateBetAmount();

            BankBalance -= validatedBetAmount;
            PendingBets = validatedBetAmount;
        }

        public void ProcessWin()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("====================================");
            Console.WriteLine($"Nice! you won ${PendingBets}");
            BankBalance += 2 * PendingBets;
            PendingBets = 0;
            Console.WriteLine($"Updated Balance: ${BankBalance}");
            Console.WriteLine("====================================");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void ProcessLoss()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("====================================");
            Console.WriteLine($"Sorry you lost ${PendingBets}");
            Console.WriteLine($"Updated Balance: ${BankBalance}");
            Console.WriteLine("====================================");
            Console.ForegroundColor = ConsoleColor.White;
            
            PendingBets = 0;
        }

        public void ProcessDraw()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("====================================");
            Console.WriteLine($"It is a draw, returning your original bet of ${PendingBets}");
            BankBalance += PendingBets;
            PendingBets = 0;
            Console.WriteLine($"Updated Balance: ${BankBalance}");
            Console.WriteLine("====================================");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void DepositFunds()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("====================================");
            Console.WriteLine("How much money would you like to take to the table? please enter a number:");
            Console.WriteLine("====================================");

            var numberEntered = int.TryParse(Console.ReadLine(), out int amount);

            if (!numberEntered)
            {
                Console.WriteLine("====================================");
                Console.WriteLine("Sorry, you have to enter a number that I can recognize, try again.");
                Console.WriteLine("====================================");
                DepositFunds();
            }


            BankBalance += amount;
        }

        private int ValidateBetAmount()
        {
            Console.WriteLine("====================================");
            Console.WriteLine("Place your bet (enter a valid number)");
            Console.WriteLine("====================================");

            var validInput = int.TryParse(Console.ReadLine(), out int betTotal);

            if (!validInput)
            {
                Console.WriteLine();
                Console.WriteLine("I am sorry, that is not a valid amount. Try again.");
                return ValidateBetAmount();
            }
            else if (betTotal > BankBalance)
            {
                Console.WriteLine();
                Console.WriteLine(
                    $"You don't have enough money to bet that amount, your current balance is ${BankBalance}. Try again.");
                return ValidateBetAmount();
            }

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("====================================");
            Console.WriteLine($"${betTotal} bet accepted!");
            Console.WriteLine("====================================");
            Console.ForegroundColor = ConsoleColor.White;

            return betTotal;
        }
    }
}
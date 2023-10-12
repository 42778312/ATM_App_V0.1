using System;

namespace SimpleATM
{
    class Program
    {
        static double balance = 1000.0; // Initial balance

        static void Main(string[] args)
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("ATM Menu:");
                Console.WriteLine("1. Check Balance");
                Console.WriteLine("2. Make a Deposit");
                Console.WriteLine("3. Make a Withdrawal");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine($"Your current balance: ${balance:F2}");
                            break;
                        case 2:
                            MakeDeposit();
                            break;
                        case 3:
                            MakeWithdrawal();
                            break;
                        case 4:
                            isRunning = false;
                            Console.WriteLine("Thank you for using the ATM. Goodbye!");
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please enter a valid option.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid option.");
                }
            }
        }

        static void MakeDeposit()
        {
            Console.Write("Enter the amount to deposit: $");
            if (double.TryParse(Console.ReadLine(), out double depositAmount) && depositAmount > 0)
            {
                balance += depositAmount;
                Console.WriteLine($"${depositAmount:F2} has been deposited. Your new balance: ${balance:F2}");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid deposit amount.");
            }
        }

        static void MakeWithdrawal()
        {
            Console.Write("Enter the amount to withdraw: $");
            if (double.TryParse(Console.ReadLine(), out double withdrawalAmount) && withdrawalAmount > 0)
            {
                if (balance >= withdrawalAmount)
                {
                    balance -= withdrawalAmount;
                    Console.WriteLine($"${withdrawalAmount:F2} has been withdrawn. Your new balance: ${balance:F2}");
                }
                else
                {
                    Console.WriteLine("Insufficient funds.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid withdrawal amount.");
            }
        }
    }
}


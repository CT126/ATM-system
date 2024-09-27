using System;

namespace Atm_project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string username = "Hubert Wisniewski"; 
            string pin = "1234"; 
            string inputUser, inputPin;
            double balance = 0;
            int attempts = 0;
            const int MAX_ATTEMPTS = 3;

       
            while (attempts < MAX_ATTEMPTS)
            {
                Console.Write("Enter username: ");
                inputUser = Console.ReadLine();
                Console.Write("Enter PIN: ");
                inputPin = Console.ReadLine();

                if (inputUser == username && inputPin == pin)
                {
                    Console.WriteLine("Login successful!");
                    MainMenu(ref balance);
                    return; 
                }
                else
                {
                    attempts++;
                    Console.WriteLine("What the sigma try again.");
                }
            }
            Console.WriteLine("Your not the orignal Ohio rizzler plz exit now .");
        }

        static void MainMenu(ref double balance)
        {
            string choice;
            do
            {
                Console.WriteLine("\nMain Menu:");
                Console.WriteLine("1. Check Balance");
                Console.WriteLine("2. Deposit Money");
                Console.WriteLine("3. Withdraw Money");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine($"Your balance is: ${balance}");
                        break;
                    case "2":
                        Console.Write("Enter amount to deposit: ");
                        if (double.TryParse(Console.ReadLine(), out double depositAmount) && depositAmount > 0)
                        {
                            balance += depositAmount;
                            Console.WriteLine("Deposit successful.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid deposit amount.");
                        }
                        break;
                    case "3":
                        Console.Write("Enter amount to withdraw: ");
                        if (double.TryParse(Console.ReadLine(), out double withdrawAmount))
                        {
                            if (withdrawAmount <= balance)
                            {
                                balance -= withdrawAmount;
                                Console.WriteLine("Withdrawal successful.");
                            }
                            else
                            {
                                Console.WriteLine("Insufficient funds.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid withdrawal amount.");
                        }
                        break;
                    case "4":
                        Console.WriteLine("Thank you for using the ATM.");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            } while (choice != "4");
        }
    }
}

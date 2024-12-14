using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<int, BankAccount> accounts = new Dictionary<int, BankAccount>();
        int choice;

        do
        {
            Console.Clear();
            Console.WriteLine("Simple Banking System");
            Console.WriteLine("=====================\n");
            Console.WriteLine("1. Create Account");
            Console.WriteLine("2. Deposit");
            Console.WriteLine("3. Withdraw");
            Console.WriteLine("4. View Balance");
            Console.WriteLine("5. Exit");
            Console.Write("\nEnter your choice: ");

            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        CreateAccount(accounts);
                        break;
                    case 2:
                        Deposit(accounts);
                        break;
                    case 3:
                        Withdraw(accounts);
                        break;
                    case 4:
                        ViewBalance(accounts);
                        break;
                    case 5:
                        Console.WriteLine("\nThank you for using the banking system!");
                        break;
                    default:
                        Console.WriteLine("\nInvalid choice. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("\nPlease enter a valid number.");
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();

        } while (choice != 5);
    }

    static void CreateAccount(Dictionary<int, BankAccount> accounts)
    {
        Console.Clear();
        Console.WriteLine("Create Account");
        Console.WriteLine("==============\n");

        Console.Write("Enter your name: ");
        string name = Console.ReadLine();

        Console.Write("Enter an initial deposit amount: ");
        if (decimal.TryParse(Console.ReadLine(), out decimal initialDeposit) && initialDeposit >= 0)
        {
            int accountNumber = accounts.Count + 1; // Generate a unique account number
            accounts[accountNumber] = new BankAccount(accountNumber, name, initialDeposit);
            Console.WriteLine($"\nAccount created successfully! Your account number is {accountNumber}.");
        }
        else
        {
            Console.WriteLine("\nInvalid deposit amount. Please try again.");
        }
    }

    static void Deposit(Dictionary<int, BankAccount> accounts)
    {
        Console.Clear();
        Console.WriteLine("Deposit Money");
        Console.WriteLine("=============\n");

        Console.Write("Enter your account number: ");
        if (int.TryParse(Console.ReadLine(), out int accountNumber) && accounts.ContainsKey(accountNumber))
        {
            Console.Write("Enter the amount to deposit: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal amount) && amount > 0)
            {
                accounts[accountNumber].Deposit(amount);
                Console.WriteLine("\nDeposit successful!");
            }
            else
            {
                Console.WriteLine("\nInvalid amount. Please try again.");
            }
        }
        else
        {
            Console.WriteLine("\nAccount not found. Please try again.");
        }
    }

    static void Withdraw(Dictionary<int, BankAccount> accounts)
    {
        Console.Clear();
        Console.WriteLine("Withdraw Money");
        Console.WriteLine("==============\n");

        Console.Write("Enter your account number: ");
        if (int.TryParse(Console.ReadLine(), out int accountNumber) && accounts.ContainsKey(accountNumber))
        {
            Console.Write("Enter the amount to withdraw: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal amount) && amount > 0)
            {
                if (accounts[accountNumber].Withdraw(amount))
                {
                    Console.WriteLine("\nWithdrawal successful!");
                }
                else
                {
                    Console.WriteLine("\nInsufficient balance. Please try again.");
                }
            }
            else
            {
                Console.WriteLine("\nInvalid amount. Please try again.");
            }
        }
        else
        {
            Console.WriteLine("\nAccount not found. Please try again.");
        }
    }

    static void ViewBalance(Dictionary<int, BankAccount> accounts)
    {
        Console.Clear();
        Console.WriteLine("View Balance");
        Console.WriteLine("============\n");

        Console.Write("Enter your account number: ");
        if (int.TryParse(Console.ReadLine(), out int accountNumber) && accounts.ContainsKey(accountNumber))
        {
            Console.WriteLine($"\nAccount Number: {accounts[accountNumber].AccountNumber}");
            Console.WriteLine($"Account Holder: {accounts[accountNumber].Name}");
            Console.WriteLine($"Balance: ${accounts[accountNumber].Balance:F2}");
        }
        else
        {
            Console.WriteLine("\nAccount not found. Please try again.");
        }
    }
}

class BankAccount
{
    public int AccountNumber { get; private set; }
    public string Name { get; private set; }
    public decimal Balance { get; private set; }

    public BankAccount(int accountNumber, string name, decimal initialDeposit)
    {
        AccountNumber = accountNumber;
        Name = name;
        Balance = initialDeposit;
    }

    public void Deposit(decimal amount)
    {
        Balance += amount;
    }

    public bool Withdraw(decimal amount)
    {
        if (amount <= Balance)
        {
            Balance -= amount;
            return true;
        }
        return false;
    }
}

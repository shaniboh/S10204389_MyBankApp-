using System;
using System.Collections.Generic;
using System.IO;

namespace S10204389_MyBankApp_
{
    class Program
    {
        static void Main(string[] args)
        {
            // list
            List<SavingsAccount> savingsAccList = new List<SavingsAccount>();

            // initialize data 
            InitSavingsAccount(savingsAccList);

            // menu
            while (true)
            {
                DisplayMenu(savingsAccList);
            }

        }
        // methods
        static void InitSavingsAccount(List<SavingsAccount> savingsAccList)
        {
            string[] csvLines = File.ReadAllLines("savings_account(2).csv");
            foreach (string s in csvLines)
            {
                string[] data = s.Split(',');
                string accNo = data[0];
                string accName = data[1];
                double bal = Convert.ToDouble(data[2]);
                double r = Convert.ToDouble(data[3]);

                savingsAccList.Add(new SavingsAccount(accNo, accName, bal, r));
            }
         }

        static void DisplayMenu(List<SavingsAccount> savingsAccList)
        {
            Console.WriteLine("\tMenu");
            Console.WriteLine("[1] Display all accounts");
            Console.WriteLine("[2] Deposit");
            Console.WriteLine("[3] Withdraw");
            Console.WriteLine("[4] Display details");
            Console.WriteLine("[0] Exit");

            Console.Write("Enter option");
            int option = Convert.ToInt32(Console.ReadLine());

            if (option == 1)
            {
                DisplayAll(savingsAccList);
            }
            else if (option == 2)
            {
                Console.WriteLine("Enter the Account Number: ");
                string n = Console.ReadLine();
                SavingsAccount acc1 = SearchAcc(savingsAccList, n);
                if (acc1 == null)
                {
                    Console.WriteLine("Unable to find account number. Please try again.");
                }
                else
                {
                    Console.WriteLine("Amount to deposit:");
                    double d = Convert.ToDouble(Console.ReadLine());
                    acc1.Deposit(d);
                    Console.WriteLine("{0} deposited successfully", d);
                    Console.WriteLine(acc1);
                }
            }
            else if (option == 3)
            {
                Console.WriteLine("Enter the Account Number: ");
                string n = Console.ReadLine();
                SavingsAccount acc1 = SearchAcc(savingsAccList, n);
                if (acc1 == null)
                {
                    Console.WriteLine("Unable to find account number. Please try again.");
                }
                else
                {
                    Console.WriteLine("Amount to withdraw:");
                    double w = Convert.ToDouble(Console.ReadLine());
                    if (acc1.Withdraw(w))
                    {
                        Console.WriteLine("{0} withdrawn successfully", w);
                        Console.WriteLine(acc1);
                    }
                }
            }
            else if (option == 4)
            {
                Console.WriteLine("{0,-10} {1,10} {2,10} {3,10} {4,20}", "Acc No:", "Acc Name:", "Balance:", "Rate:", "Interest Amt");
                foreach (SavingsAccount s in savingsAccList)
                {
                    Console.WriteLine("{0,-10} {1,10} {2,10} {3,10} {4,20}", s.AccNo, s.AccName, s.Balance, s.Rate, s.CalculateInterest());

                }
            }
            else if (option == 0)
            {
                Console.WriteLine("---------");
                Console.WriteLine("Goodbye!");
                Console.WriteLine("---------");
            }
            
        }

        static void DisplayAll(List<SavingsAccount> savingsAccList)
        {
            foreach (SavingsAccount s in savingsAccList)
            {
                Console.WriteLine("{0,-10} {1,10} {2,10} {3,10} {4,10} {5,10} {6,10} {7,10} {8,10}", "Acc No:",s.AccNo, "Acc Name:",s.AccName, "Balance:",s.Balance, "Rate:",s.Rate);

            }
        }

        static SavingsAccount SearchAcc(List<SavingsAccount> savingsAccountList, string accNo)
        {
            foreach (SavingsAccount s in savingsAccountList)
            {
                if (s.AccNo == accNo)
                {
                    return s;
                }
            }
            return null;
        }

    }
}

using System;
using Backend;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create customers
            Customer customer1 = new Customer("Alice", "123-456-7890", "01/01/1990");
            Customer customer2 = new Customer("Bob", "987-654-3210", "02/02/1985");
            Customer customer3 = new Customer();

            // Create accounts
            CurrentAccount currentAccount1 = new CurrentAccount();
            SavingAccount savingAccount1 = new SavingAccount();
            SavingAccount savingAccount2 = new SavingAccount();

            // Add customers to accounts
            currentAccount1.Customers.Add(customer1);
            currentAccount1.Customers.Add(customer2);

            savingAccount1.Customers.Add(customer1);
            savingAccount2.Customers.Add(customer3);

            // Add bank cards to a current account
            BankCard bankCard1 = new BankCard(customer1);
            currentAccount1.AddBankCard(bankCard1);

            // Test withdrawals and deposits
            currentAccount1.DepositMoney(500);
            currentAccount1.WithdrawMoney(200);

            savingAccount1.DepositMoney(1000);
            savingAccount2.DepositMoney(200);

            // Remove a bank card
            currentAccount1.RemoveBankCard(bankCard1);

            // Print account and card information
            Console.WriteLine(currentAccount1.ToString());
            Console.WriteLine(savingAccount1.ToString());
            Console.WriteLine(savingAccount2.ToString());
        }
    }
}

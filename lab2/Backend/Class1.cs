using System;
using System.Collections.Generic;

namespace Backend
{
    public class Customer
    {
        public static int CurrentCustomerId = 1;
        public int Id { get; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string BirthDay { get; set; }

        public Customer()
        {
            Id = CurrentCustomerId++;
            Console.Write("Enter your name: ");
            Name = Console.ReadLine();
            Console.Write("Enter your phone number: ");
            PhoneNumber = Console.ReadLine();
            Console.Write("Enter your birth date: ");
            BirthDay = Console.ReadLine();
        }

        public Customer(string name, string phoneNumber, string birthDay)
        {
            Id = CurrentCustomerId++;
            Name = name;
            PhoneNumber = phoneNumber;
            BirthDay = birthDay;
        }
    }

    public abstract class Account
    {
        protected string AccountNumber;
        protected float Balance;
        protected List<Customer> Customers;

        protected static readonly int AccountNumberLength = 10;

        public Customer this[int id] => Customers.Find(customer => customer.Id == id);

        protected Account()
        {
            Customers = new List<Customer>();
            AccountNumber = GenerateAccountNumber();
        }

        protected string GenerateAccountNumber()
        {
            Random random = new Random();
            string accountNumber = "123"; // For Saving Accounts
            for (int i = 0; i < AccountNumberLength - 3; i++)
            {
                accountNumber += random.Next(0, 10);
            }
            return accountNumber;
        }
    }

    public class SavingAccount : Account
    {
        public SavingAccount()
        {
            // Constructor logic for SavingAccount
        }
    }

    public class CurrentAccount : Account
    {
        public List<BankCard> BankCards { get; private set; }

        public CurrentAccount()
        {
            BankCards = new List<BankCard>();
            // Constructor logic for CurrentAccount
        }

        public void AddBankCard(BankCard card)
        {
            if (Balance == 0)
            {
                BankCards.Add(card);
            }
            else
            {
                Console.WriteLine("Cannot add a BankCard to an account with a non-zero balance.");
            }
        }

        public void RemoveBankCard(BankCard card)
        {
            if (Balance == 0)
            {
                BankCards.Remove(card);
            }
            else
            {
                Console.WriteLine("Cannot remove a BankCard from an account with a non-zero balance.");
            }
        }

        public void WithdrawMoney(float amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
                Console.WriteLine($"Withdrawn {amount} from account {AccountNumber}. New balance: {Balance}");
            }
            else
            {
                Console.WriteLine("Insufficient balance to make the withdrawal.");
            }
        }

        public void DepositMoney(float amount)
        {
            Balance += amount;
            Console.WriteLine($"Deposited {amount} to account {AccountNumber}. New balance: {Balance}");
        }
    }

    public abstract class Card
    {
        protected string CardNumber;
        protected string Pin;
        protected Customer Owner;

        protected static readonly int CardNumberLength = 8;

        protected Card(Customer owner)
        {
            Owner = owner;
            CardNumber = GenerateCardNumber();
        }

        protected string GenerateCardNumber()
        {
            Random random = new Random();
            string cardNumber = "";
            for (int i = 0; i < CardNumberLength; i++)
            {
                cardNumber += random.Next(0, 10);
            }
            return cardNumber;
        }
    }

    public class BankCard : Card
    {
        public BankCard(Customer owner) : base(owner)
        {
            Pin = GeneratePin();
        }

        private string GeneratePin()
        {
            Random random = new Random();
            return random.Next(1000, 10000).ToString();
        }
    }

    public class CreditCard : Card
    {
        public int Cvc { get; }
        public float CardBalance { get; set; }

        public CreditCard(Customer owner) : base(owner)
        {
            Cvc = int.Parse(CardNumber) % 987;
            CardBalance = 0;
        }

        public void WithdrawMoney(float amount)
        {
            if (CardBalance >= amount)
            {
                CardBalance -= amount;
                Console.WriteLine($"Withdrawn {amount} from CreditCard {CardNumber}. New balance: {CardBalance}");
            }
            else
            {
                Console.WriteLine("Insufficient balance to make the withdrawal.");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz9
{
    public class CreditCard
    {

        // Поля класу
        private string cardNumber;
        private string cardOwner;
        private DateTime expiryDate;
        private int pin;
        private decimal creditLimit;
        private decimal accountBalance;
        private decimal creditUsed;

        // Події класу
        public event EventHandler<AccountEventArgs> AccountRefilled;
        public event EventHandler<AccountEventArgs> MoneySpent;
        public event EventHandler<CreditEventArgs> CreditStarted;
        public event EventHandler<CreditEventArgs> LimitReached;
        public event EventHandler<EventArgs> PinChanged;

        // Конструктор класу
        public CreditCard(string cardNumber, string cardOwner, DateTime expiryDate, int pin, decimal creditLimit)
        {
            this.cardNumber = cardNumber;
            this.cardOwner = cardOwner;
            this.expiryDate = expiryDate;
            this.pin = pin;
            this.creditLimit = creditLimit;
            this.accountBalance = 0;
            this.creditUsed = 0;
        }

        // Методи класу
        public void RefillAccount(decimal amount)
        {
            accountBalance += amount;
            AccountRefilled?.Invoke(this, new AccountEventArgs(amount));
        }
        public void SpendMoney(decimal amount)
        {
            if (accountBalance + creditUsed >= amount)
            {
                if (accountBalance >= amount)
                {
                    accountBalance -= amount;
                    MoneySpent?.Invoke(this, new AccountEventArgs(amount));
                }
                else
                {
                    decimal remainingAmount = amount - accountBalance;
                    accountBalance = 0;
                    creditUsed += remainingAmount;
                    MoneySpent?.Invoke(this, new AccountEventArgs(accountBalance));
                    CreditStarted?.Invoke(this, new CreditEventArgs(remainingAmount));
                }
            }
            else
            {
                Console.WriteLine("Недостатньо коштів на рахунку та в кредитному ліміті.");
            }

            if (creditUsed >= creditLimit)
            {
                LimitReached?.Invoke(this, new CreditEventArgs(creditUsed));
            }
        }

        public void StartCredit(decimal amount)
        {
            if (creditUsed + amount <= creditLimit)
            {
                creditUsed += amount;
                CreditStarted?.Invoke(this, new CreditEventArgs(amount));
            }
            else
            {
                Console.WriteLine("Досягнено ліміту кредитних коштів.");
            }
        }

        public void ChangePin(int newPin)
        {
            pin = newPin;
            PinChanged?.Invoke(this, EventArgs.Empty);
        }

    }

    public class AccountEventArgs : EventArgs
    {
        public decimal Amount { get; set; }

        public AccountEventArgs(decimal amount)
        {
            Amount = amount;
        }
    }

    public class CreditEventArgs : EventArgs
    {
        public decimal Amount { get; set; }

        public CreditEventArgs(decimal amount)
        {
            Amount = amount;
        }
    }
    internal class cs3
    {
        public static void task_3()
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            // Створення кредитної картки
            CreditCard creditCard = new CreditCard("1234567890123456", "John Smith", new DateTime(2025, 12, 31), 1234, 5000);

            // Підписка на події
            creditCard.AccountRefilled += CreditCard_AccountRefilled;
            creditCard.MoneySpent += CreditCard_MoneySpent;
            creditCard.CreditStarted += CreditCard_CreditStarted;
            creditCard.LimitReached += CreditCard_LimitReached;
            creditCard.PinChanged += CreditCard_PinChanged;

            // Виклик методів кредитної картки
            creditCard.RefillAccount(1000);
            creditCard.SpendMoney(500);
            creditCard.StartCredit(2000);
            creditCard.SpendMoney(4000);
            creditCard.ChangePin(4321);
        }

        private static void CreditCard_AccountRefilled(object sender, AccountEventArgs e)
        {
            Console.WriteLine("Рахунок поповнено на " + e.Amount + " грн.");
        }

        private static void CreditCard_MoneySpent(object sender, AccountEventArgs e)
        {
            Console.WriteLine("З рахунку списано " + e.Amount + " грн.");
        }

        private static void CreditCard_CreditStarted(object sender, CreditEventArgs e)
        {
            Console.WriteLine("Початок використання кредитних коштів: " + e.Amount + " грн.");
        }

        private static void CreditCard_LimitReached(object sender, CreditEventArgs e)
        {
            Console.WriteLine("Досягнено ліміт кредитних коштів: " + e.Amount + " грн.");
        }

        private static void CreditCard_PinChanged(object sender, EventArgs e)
        {
            Console.WriteLine("PIN успішно змінено.");
        }
    }
}


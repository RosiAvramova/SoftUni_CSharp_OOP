using System;
using NUnit.Framework;

//in case it is not working delete the namespace or only my usings
namespace BankAccount.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        //check the Constructor 
        [Test]
        public void ConstructorShouldSetProperValue()
        {
            string name = "Gosho";
            decimal balance = 340.34m;
            var bankAccount = new BankAccount(name, balance);

            Assert.AreEqual(name, bankAccount.Name);
            Assert.AreEqual(balance, bankAccount.Balance);
        }

        //invalid length of name
        [Test]
        [TestCase("1", 3450.34)]
        [TestCase("StringWithLengthMoreThen25SymbolsWow", 3450.34)]

        public void ConstructorShouldThrowArgumentExcepcionInvalidNameLength(string name, decimal balance)
        {
            Assert.Throws<ArgumentException>(() => new BankAccount(name, balance));
        }

        //invalid balance
        [Test]
        [TestCase("Petar", -1)]
        [TestCase("Gosho", -12)]
        public void ConstructorShouldThrowArgumentExcepcionInvalidBalance(string name, decimal balance)
        {
            Assert.Throws<ArgumentException>(() => new BankAccount(name, balance));
        }

        //deposit invalid amount
        [Test]
        [TestCase(-1)]
        [TestCase(0)]
        public void Deposit_ShouldThrowInvalidOperationException_InvalidAmount(decimal amount)
        {
            var bankAccount = new BankAccount("Pesho", 200);
            Assert.Throws<InvalidOperationException>(() => bankAccount.Deposit(amount));
        }

        //balance has increase after deposit
        [Test]
        public void Deposit_ShouldIcreaseBalance()
        {
            var bankAccount = new BankAccount("Pesho", 200.12m);
            bankAccount.Deposit(20.12m);

            var expected = 220.24m;
            var actual = bankAccount.Balance;

            Assert.AreEqual(expected, actual);
        }

        //withdraw invalid amount
        [Test]
        public void Withdraw_SholdThrowsInvalideOperationException_InvalidBalance()
        {
            var bankAccount = new BankAccount("Pesho", 200.12m);

            Assert.Throws<InvalidOperationException>(() => bankAccount.Withdraw(-1));
        }

        // withdraw  with valid amount bigger then balance
        [Test]
        public void Withdraw_SholdThrowsInvalideOperationException_InsufficientFunds()
        {
            var bankAccount = new BankAccount("Pesho", 200.12m);

            var invalidAmount = 200.2m;

            Assert.Throws<InvalidOperationException>(() => bankAccount.Withdraw(invalidAmount));
        }

        //balance has decrease
        [Test]
        public void Withdrow_SholdDecreaseBalanceCorrectly()
        {
            var bankAccount = new BankAccount("Pesho", 200.12m);

            var validAmount = 100.12m;
            bankAccount.Withdraw(validAmount);
            var expected = 100m;
            var actual = bankAccount.Balance;

            Assert.AreEqual(expected, actual);
        }
    }
}
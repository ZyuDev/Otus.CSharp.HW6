using System.Collections.Generic;
using NUnit.Framework;
using SimpleBank.Entities;
using SimpleBank.Enums;
using SimpleBank.Helpers;

namespace SimpleBank.UnitTests
{
    [TestFixture]
    public class TransactionParserTests
    {
        private TransactionParser _parser;

        [SetUp]
        public void SetUp()
        {
            var accounts = new List<Account>();
            accounts.Add(new Account(){AccountNumber = "001840", Id = 1, CurrencyId = 2, OwnerId = 3});

            _parser = new TransactionParser(accounts);
        }
        
        [Test]
        public void Parse_EmptyInput_ReturnNull()
        {
            var result = _parser.Parse("");
            
            Assert.IsNull(result);
        }
        
        [Test]
        public void Parse_WrongFormat_ReturnNull()
        {
            var result = _parser.Parse("wrong format");
            
            Assert.IsNull(result);
        }
        
        [Test]
        public void Parse_WrongAccountNumber_ReturnNull()
        {
            var result = _parser.Parse("002840 + 15.5");
            
            Assert.IsNull(result);
        }

        [Test]
        public void Parse_TransactionWithoutInfo_ReturnTransaction()
        {
            var result = _parser.Parse("001840 + 15.5");
            
            Assert.AreEqual(1, result.AccountId);
            Assert.AreEqual(TransactionDirections.Plus, result.Direction);
            Assert.AreEqual(15.5, result.Amount);
        }
        
        [Test]
        public void Parse_TransactionWithInfo_ReturnTransaction()
        {
            var result = _parser.Parse("001840 + 15.5 Food");
            
            Assert.AreEqual("Food", result.Info);
        }
    }
}
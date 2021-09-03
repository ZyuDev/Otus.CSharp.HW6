using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using SimpleBank.Entities;
using SimpleBank.Enums;

namespace SimpleBank.Helpers
{
    public class TransactionParser
    {
        private readonly IEnumerable<Account> _accounts;
        private readonly List<string> _log;

        public IReadOnlyCollection<string> Log => _log;
        
        public TransactionParser(IEnumerable<Account> accounts)
        {
            _accounts = accounts;
            _log = new List<string>();
        }
        
        public Transaction Parse(string input)
        {
            ClearLog();

            if (string.IsNullOrEmpty(input))
            {
                _log.Add("Empty input.");
                return null;
            }
            
            var parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length < 3)
            {
                _log.Add($"Wrong format.");
                return null;
            }

            var accountNumber = parts[0];

            var account = _accounts.FirstOrDefault(x => x.AccountNumber == accountNumber);

            if (account == null)
            {
                _log.Add("Account not found");
                return null;
            }

            var direction = TransactionDirections.Plus;
            if (parts[1] == "-")
            {
                direction = TransactionDirections.Minus;
            }

            var nfi = new NumberFormatInfo() { NumberDecimalSeparator = "." };
            if (!Decimal.TryParse(parts[2], NumberStyles.Any, nfi, out var amount))
            {
                _log.Add("Wrong number format.");
                return null;
            }

            string info = "";
            if (parts.Length >= 4)
            {
                info = parts[3];
            }

            var transaction = new Transaction()
            {
                Period = DateTime.Now,
                AccountId = account.Id,
                Direction = direction,
                Amount = amount,
                Info = info
            };
            return transaction;
        }

        private void ClearLog()
        {
            _log.Clear();
        }
    }
}
using System;
using Npgsql;
using SimpleBank.Data.DataServices;
using SimpleBank.Entities;
using SimpleBank.Helpers;

namespace SimpleBank.Services
{
    public class TransactionInputService
    {
        private readonly string _connectionString;

        public TransactionInputService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int InputTransaction(string input)
        {

            using(var connection = new NpgsqlConnection(_connectionString))
            {
                var accountService = new AccountDataService(connection);
                var transactionService = new TransactionDataService(connection);

                var accounts = accountService.GetCollection();

                var parser = new TransactionParser(accounts);
                var transaction = parser.Parse(input);

                if (transaction == null)
                {
                    Console.WriteLine("Parse error");
                    foreach (var msg in parser.Log)
                    {
                        Console.WriteLine(msg);
                    }
                    return -1;
                }

                try
                {
                    transactionService.CreateItem(transaction);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Cannot create transactions. Message: {e.Message}");
                    return -1;
                }
            }

            return 0;
        }

    }
}
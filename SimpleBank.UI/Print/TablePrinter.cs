using System;
using System.Collections.Generic;
using Npgsql;
using SimpleBank.Data.DataServices;

namespace SimpleBank.UI.Print
{
    public class TablePrinter
    {
        private readonly string _connectionString;

        public TablePrinter(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void PrintCurrencies()
        {
           PrintHeader("Currencies");

            using(var connection = new NpgsqlConnection(_connectionString))
            {
                var service = new CurrencyDataService(connection);
                var collection = service.GetCollection();
                
                PrintCollection(collection);

            }
            
        }

        public void PrintPersons()
        {
            PrintHeader("Persons");
            
            using(var connection = new NpgsqlConnection(_connectionString))
            {
                var service = new PersonDataService(connection);
                var collection = service.GetCollection();

                PrintCollection(collection);
            }

        }

        public void PrintAccounts()
        {
            PrintHeader("Accounts");
            
            using(var connection = new NpgsqlConnection(_connectionString))
            {
                var service = new AccountDataService(connection);
                var collection = service.GetCollection();

                PrintCollection(collection);
            }

        }

        public void PrintTransactions()
        {
            PrintHeader("Transactions");
            
            using(var connection = new NpgsqlConnection(_connectionString))
            {
                var service = new TransactionDataService(connection);
                var collection = service.GetCollection();

                PrintCollection(collection);
            }

        }

        private void PrintHeader(string tableTitle)
        {
            PrintCommon.PrintDelimiter();
            Console.WriteLine(tableTitle);
            PrintCommon.PrintDelimiter();

        }

        private void PrintCollection(IEnumerable<object> collection)
        {
            var n = 1;
            foreach (var item in collection)
            {
                Console.WriteLine($@"{n}. {item}");
                n++;
            }
        }
    }
}

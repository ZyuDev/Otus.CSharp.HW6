using Npgsql;
using SimpleBank.Data;
using SimpleBank.Services;
using System;
using SimpleBank.Data.DataServices;
using SimpleBank.Data.TableServices;

namespace SimpleBank.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = @"Host = localhost; Port = 5432; Database = SimpleBank; User Id = sa; Password = 1;";

            using (var connection = new NpgsqlConnection(connectionString))
            {
                // Create DB tables if neccessary.
                var currencyTableService = new CurrencyTableService(connection);
                var personTableService = new PersonTableService(connection);
                var accountTableService = new AccountTableService(connection);
                var transactionTableService = new TransactionTableService(connection);

                var tableManager = new TableManager(currencyTableService, personTableService, accountTableService, transactionTableService);

                tableManager.CreateTables();

                // Initial DB fill.
                var dataServiceFactory = new DataServiceFactory(connection);
                
                var fillDataUoW = new FillDbUnitOfWork(dataServiceFactory);

                fillDataUoW.CreateCurrencies();
                fillDataUoW.CreatePersons();
                fillDataUoW.CreateAccounts();
            }

            Console.WriteLine("Hello World!");
        }
    }
}

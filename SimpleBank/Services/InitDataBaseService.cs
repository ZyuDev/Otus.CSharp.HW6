using System;
using Npgsql;
using SimpleBank.Data.DataServices;
using SimpleBank.Data.TableServices;

namespace SimpleBank.Services
{
    public class InitDataBaseService
    {
        private readonly string _connectionString;

        public InitDataBaseService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Init()
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                // Create DB tables if necessary.
                var factory = new TableServiceFactory(connection);

                var tableManager = new TableManager(factory);

                tableManager.CreateTables();

                // Initial DB fill.
                var dataServiceFactory = new DataServiceFactory(connection);

                var fillDataUoW = new FillDbUnitOfWork(dataServiceFactory);

                fillDataUoW.CreateCurrencies();
                fillDataUoW.CreatePersons();
                fillDataUoW.CreateAccounts();
                fillDataUoW.CreateTransactions();
                
                Console.WriteLine("App READY");

            }
        }

    }
}
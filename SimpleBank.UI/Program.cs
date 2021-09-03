using Npgsql;
using SimpleBank.Data;
using SimpleBank.Services;
using System;
using SimpleBank.Data.DataServices;
using SimpleBank.Data.TableServices;
using SimpleBank.UI.Print;

namespace SimpleBank.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = @"Host = localhost; Port = 5432; Database = SimpleBank; User Id = sa; Password = 1;";

            PrintCommon.PrintAppHeader();
            using (var connection = new NpgsqlConnection(connectionString))
            {
                // Create DB tables if neccessary.
                var currencyTableService = new CurrencyTableService(connection);
                var personTableService = new PersonTableService(connection);
                var accountTableService = new AccountTableService(connection);
                var transactionTableService = new TransactionTableService(connection);

                var tableManager = new TableManager(currencyTableService, personTableService, accountTableService,
                    transactionTableService);

                tableManager.CreateTables();

                // Initial DB fill.
                var dataServiceFactory = new DataServiceFactory(connection);

                var fillDataUoW = new FillDbUnitOfWork(dataServiceFactory);

                fillDataUoW.CreateCurrencies();
                fillDataUoW.CreatePersons();
                fillDataUoW.CreateAccounts();
                fillDataUoW.CreateTransactions();
            }

            Console.WriteLine("App READY");
            PrintCommon.PrintDelimiter();

            var fladContinue = true;
            var printer = new TablePrinter(connectionString);

            while (fladContinue)
            {
                MenuPrinter.Print();

                var key = Console.ReadKey();
                Console.WriteLine();

                switch (key.KeyChar)
                {
                    case '1':
                        printer.PrintCurrencies();
                        break;
                    case '2':
                        printer.PrintPersons();
                        break;
                    case '3':
                        printer.PrintAccounts();
                        break;
                    case '4':
                        printer.PrintTransactions();
                        break;
                    case '5':
                        break;
                    case 'e':
                        fladContinue = false;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
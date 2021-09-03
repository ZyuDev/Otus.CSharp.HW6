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
           
            var initService = new InitDataBaseService(connectionString);
            PrintCommon.PrintAppHeader();
            initService.Init();

            var flagContinue = true;
            var printer = new TablePrinter(connectionString);

            while (flagContinue)
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
                        Console.WriteLine("Enter transaction in format: [accountnumber] [+/-] [amount] <info>");
                        Console.WriteLine("Example: 0001840 - 15 MacDac");
                        var inputString = Console.ReadLine();
                        var inputService = new TransactionInputService(connectionString);
                        var result = inputService.InputTransaction(inputString);
                        if (result == 0)
                        {
                            Console.WriteLine("Transaction created");
                        }
                        break;
                    case 'e':
                        flagContinue = false;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
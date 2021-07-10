using Npgsql;
using SimpleBank.Data;
using System;

namespace SimpleBank.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = @"Host = localhost; Port = 5432; Database = SimpleBank; User Id = sa; Password = 1;";

            using (var connection = new NpgsqlConnection(connectionString))
            {

                var currencyTableService = new CurrencyTableService(connection);

                var tableExists = currencyTableService.TableExists();

                if (tableExists)
                {
                    Console.WriteLine($"Currency table exists: {tableExists}");
                }
                else
                {
                    try
                    {
                        currencyTableService.CreateTable();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Cannot create table. Message: {e.Message}");
                    }
                }




            }

            Console.WriteLine("Hello World!");
        }
    }
}

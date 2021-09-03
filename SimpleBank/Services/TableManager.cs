using SimpleBank.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleBank.Data.Abstract;
using SimpleBank.Data.TableServices;

namespace SimpleBank.Services
{
    public class TableManager
    {
        private readonly ITableServiceFactory _factory;

        public TableManager(ITableServiceFactory factory)
        {
            _factory = factory;
        }

        public void CreateTables()
        {
            CreateTable(_factory.CreateCurrencyTableService());
            CreateTable(_factory.CreatePersonTableService());
            CreateTable(_factory.CreateAccountTableService());
            CreateTable(_factory.CreateTransactionTableService());
        }

        private void CreateTable(ITableService tableService)
        {
            var tableExists = tableService.TableExists();

            if (tableExists)
            {
                Console.WriteLine($"{tableService.TableName} table exists.");
            }
            else
            {
                try
                {
                    tableService.CreateTable();
                    Console.WriteLine($"Table created {tableService.TableName}");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Cannot create table {tableService.TableName}. Message: {e.Message}");
                }
            }
        }
    }
}

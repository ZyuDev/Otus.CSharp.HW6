using SimpleBank.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBank.Services
{
    public class TableManager
    {

        private readonly ITableService _currencyTableService;
        private readonly ITableService _personTableService;
        private readonly ITableService _accountTableService;
        private readonly ITableService _transactionTableService;

        public TableManager(ITableService currencyTableService,
            ITableService personTableService,
            ITableService accountTableService,
            ITableService transactionTableService)
        {
            _currencyTableService = currencyTableService;
            _personTableService = personTableService;
            _accountTableService = accountTableService;
            _transactionTableService = transactionTableService;
        }

        public void CreateTables()
        {
            CreateTable(_currencyTableService);
            CreateTable(_personTableService);
            CreateTable(_accountTableService);
            CreateTable(_transactionTableService);
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

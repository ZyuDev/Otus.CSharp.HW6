using Npgsql;
using SimpleBank.Data.Abstract;

namespace SimpleBank.Data.TableServices
{
    public sealed class TableServiceFactory : ITableServiceFactory
    {
        private readonly NpgsqlConnection _connection;

        public TableServiceFactory(NpgsqlConnection connection)
        {
            _connection = connection;
        }

        public AccountTableService CreateAccountTableService()
        {
            return new AccountTableService(_connection);
        }

        public CurrencyTableService CreateCurrencyTableService()
        {
            return new CurrencyTableService(_connection);
        }

        public PersonTableService CreatePersonTableService()
        {
            return new PersonTableService(_connection);
        }

        public TransactionTableService CreateTransactionTableService()
        {
            return new TransactionTableService(_connection);
        }

    }
}
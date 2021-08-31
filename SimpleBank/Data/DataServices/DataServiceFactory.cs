using Npgsql;
using SimpleBank.Data.Abstract;
using SimpleBank.Entities;

namespace SimpleBank.Data.DataServices
{
    public class DataServiceFactory
    {
        private NpgsqlConnection _connection;

        public DataServiceFactory(NpgsqlConnection connection)
        {
            _connection = connection;
        }

        public ICurrencyDataService CreateCurrencyService()
        {
            return new CurrencyDataService(_connection);
        }

        public IDataService<Person> CreatePersonService()
        {
            return new PersonDataService(_connection);
        }

        public IDataService<Account> CreateAccountService()
        {
            return new AccountDataService(_connection);
        }

        public IDataService<Transaction> CreateTransactionService()
        {
            return new TransactionDataService(_connection);
        }
    }
}
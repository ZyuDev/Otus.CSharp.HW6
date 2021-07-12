using Dapper;
using Npgsql;

namespace SimpleBank.Data
{
    public class TransactionTableService: TableServiceBase
    {
        public TransactionTableService(NpgsqlConnection connection) : base(connection, "transactions")
        {

        }

        public override int CreateTable()
        {

            var query = QuerySource.CreateTableTransactions;
            var result = _connection.Execute(query);

            return result;
        }
    }
}

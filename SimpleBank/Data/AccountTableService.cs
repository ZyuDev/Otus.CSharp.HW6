using Dapper;
using Npgsql;

namespace SimpleBank.Data
{
    public class AccountTableService: TableServiceBase
    {
        public AccountTableService(NpgsqlConnection connection) : base(connection, "accounts")
        {

        }

        public override int CreateTable()
        {

            var query = QuerySource.CreateTableAccounts;
            var result = _connection.Execute(query);

            return result;
        }
    }
}

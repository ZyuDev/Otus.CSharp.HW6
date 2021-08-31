using Dapper;
using Npgsql;
using SimpleBank.Data.DataServices;

namespace SimpleBank.Data.TableServices
{
    public class AccountTableService: TableServiceBase
    {
        public AccountTableService(NpgsqlConnection connection) : base(connection, DbTableNames.AccountTableName)
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

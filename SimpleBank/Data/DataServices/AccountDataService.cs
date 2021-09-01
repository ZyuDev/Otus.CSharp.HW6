using System.Data;
using Dapper;
using Npgsql;
using SimpleBank.Entities;

namespace SimpleBank.Data.DataServices
{
    public class AccountDataService : DataServiceBase<Account>
    {
        public AccountDataService(NpgsqlConnection connection) : base(connection, DbTableNames.AccountTableName)
        {

        }

        public override int CreateItem(Account item)
        {

            var query = QuerySource.InsertAccount;
            var parameters = new DynamicParameters();
            parameters.Add("accountnumber", item.AccountNumber, DbType.String);
            parameters.Add("currencyid", item.CurrencyId, DbType.Int32);
            parameters.Add("ownerid", item.OwnerId, DbType.Int32);

            var result = _connection.Execute(query, parameters);

            return result;
        }

        public Account GetItem(string accountNumber)
        {

            var query = $"SELECT * FROM {_tableName} WHERE accountnumber = @accountNumber";
            var parameters = new DynamicParameters();
            parameters.Add("accountNumber", accountNumber, DbType.String);

            var item = _connection.QueryFirstOrDefault<Account>(query, parameters);

            return item;

        }
    }
}

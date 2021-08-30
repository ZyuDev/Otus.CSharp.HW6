using Dapper;
using Npgsql;
using SimpleBank.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBank.Data
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
            parameters.Add("middlename", item.OwnerId, DbType.Int32);

            var result = _connection.Execute(query, parameters);

            return result;
        }

        public Currency GetItem(string code)
        {

            var query = @"SELECT * FROM currencies WHERE code = @code";
            var parameters = new DynamicParameters();
            parameters.Add("code", code, DbType.String);

            var item = _connection.QueryFirstOrDefault<Currency>(query, parameters);

            return item;

        }
    }
}

using System.Data;
using Dapper;
using Npgsql;
using SimpleBank.Entities;

namespace SimpleBank.Data.DataServices
{
    public class TransactionDataService: DataServiceBase<Transaction>
    {
        public TransactionDataService(NpgsqlConnection connection) : base(connection, DbTableNames.TransactionTableName)
        {
        }

        public override int CreateItem(Transaction item)
        {
            var query = QuerySource.InsertTransaction;
            var parameters = new DynamicParameters();
            parameters.Add("period", item.Period, DbType.DateTime);
            parameters.Add("direction", item.Direction, DbType.Int32);
            parameters.Add("accountid", item.AccountId, DbType.Int32);
            parameters.Add("amount", item.Amount, DbType.Decimal);

            var result = _connection.Execute(query, parameters);

            return result;
        }
    }
}
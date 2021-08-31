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
            throw new System.NotImplementedException();
        }
    }
}
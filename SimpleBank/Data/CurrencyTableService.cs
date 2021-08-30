using Dapper;
using Npgsql;

namespace SimpleBank.Data
{
    public class CurrencyTableService: TableServiceBase
    {

        public CurrencyTableService(NpgsqlConnection connection):base(connection, DbTableNames.CurrencyTableName)
        {
        }

        public override int CreateTable()
        {

            var query = QuerySource.CreateTableCurrencies;
            var  result = _connection.Execute(query);

            return result;
        }
      
    }
}

using Npgsql;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SimpleBank.Data
{
    public class CurrencyTableService
    {

        private NpgsqlConnection _connection;

        public string TableName { get; private set; } = "currencies";

        public CurrencyTableService(NpgsqlConnection connection)
        {
            _connection = connection;
        }

        public int CreateTable()
        {

            var query = QuerySource.CreateTableCurrencies;

            var  result = _connection.Execute(query);

            return result;
        }

        public bool TableExists()
        {
            var query = QuerySource.TableExists;

            var parameters = new DynamicParameters();
            parameters.Add("schemaName", "public", DbType.String);
            parameters.Add("tableName", TableName, DbType.String);

            var result = _connection.QueryFirstOrDefault<bool>(query, parameters);

            return result;

        }
    }
}

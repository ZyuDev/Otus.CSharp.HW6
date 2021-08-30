using Dapper;
using Npgsql;
using System.Data;

namespace SimpleBank.Data
{
    public abstract class TableServiceBase : ITableService
    {
        protected readonly private NpgsqlConnection _connection;
        protected readonly string _tableName;

        public string TableName => _tableName;

        public TableServiceBase(NpgsqlConnection connection, string tableName)
        {
            _connection = connection;
            _tableName = tableName;
        }

        public abstract int CreateTable();
       

        public virtual bool TableExists()
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

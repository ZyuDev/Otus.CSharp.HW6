using Dapper;
using Npgsql;
using System.Data;

namespace SimpleBank.Data
{
    public abstract class DataServiceBase<T>: IDataService<T>
    {
        protected readonly private NpgsqlConnection _connection;
        protected readonly string _tableName;

        public string TableName => _tableName;

        public DataServiceBase(NpgsqlConnection connection, string tableName)
        {
            _connection = connection;
            _tableName = tableName;

        }

        public virtual T GetItem(int id)
        {
            var query = $"SELECT * FROM {_tableName} WHERE id = @id";
            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Int32);

            var item = _connection.QueryFirstOrDefault<T>(query, parameters);

            return item;
        }

        public virtual int Count()
        {
            var query = $"SELECT Count(1) as RowsCount FROM {_tableName}";
            var count = _connection.QueryFirstOrDefault<int>(query);

            return count;

        }

        public abstract int CreateItem(T item);
    }
}

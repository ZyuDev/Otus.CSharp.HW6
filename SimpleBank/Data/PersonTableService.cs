using Dapper;
using Npgsql;

namespace SimpleBank.Data
{
    public class PersonTableService: TableServiceBase
    {
        public PersonTableService(NpgsqlConnection connection): base(connection, "persons")
        {

        }

        public override int CreateTable()
        {

            var query = QuerySource.CreateTablePersons;
            var result = _connection.Execute(query);

            return result;
        }
    }
}

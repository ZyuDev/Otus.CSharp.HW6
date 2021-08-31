using Dapper;
using Npgsql;
using SimpleBank.Data.DataServices;

namespace SimpleBank.Data.TableServices
{
    public class PersonTableService: TableServiceBase
    {
        public PersonTableService(NpgsqlConnection connection): base(connection, DbTableNames.PersonTableName)
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

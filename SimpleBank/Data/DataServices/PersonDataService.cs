using System.Data;
using Dapper;
using Npgsql;
using SimpleBank.Entities;

namespace SimpleBank.Data.DataServices
{
    public class PersonDataService: DataServiceBase<Person>
    {
        public PersonDataService(NpgsqlConnection connection) : base(connection, DbTableNames.PersonTableName)
        {

        }

        public override int CreateItem(Person item)
        {

            var query = QuerySource.InsertPerson;
            var parameters = new DynamicParameters();
            parameters.Add("firstname", item.FirstName, DbType.String);
            parameters.Add("lastname", item.LastName, DbType.String);
            parameters.Add("middlename", item.MiddleName, DbType.String);
            parameters.Add("dateofbirth", item.DateOfBirth, DbType.DateTime);

            var result = _connection.Execute(query, parameters);

            return result;
        }
    }
}

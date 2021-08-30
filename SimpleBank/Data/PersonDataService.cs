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

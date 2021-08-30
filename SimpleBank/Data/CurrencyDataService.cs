﻿using Npgsql;
using SimpleBank.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Dapper;

namespace SimpleBank.Data
{
    public class CurrencyDataService : DataServiceBase<Currency>, ICurrencyDataService
    {
        public CurrencyDataService(NpgsqlConnection connection) : base(connection, DbTableNames.CurrencyTableName)
        {

        }

        public override int CreateItem(Currency item)
        {

            var query = $"INSERT INTO public.currencies(code, codenumeric, title) VALUES (@code, @codenumeric, @title)";
            var parameters = new DynamicParameters();
            parameters.Add("code", item.Code, DbType.String);
            parameters.Add("codenumeric", item.CodeNumeric, DbType.String);
            parameters.Add("title", item.Title, DbType.String);

            var result = _connection.Execute(query, parameters);

            return result;
        }

        public Currency GetItem(string code)
        {

            var query = @"SELECT * FROM currencies WHERE code = @code";
            var parameters = new DynamicParameters();
            parameters.Add("code", code, DbType.String);

            var item = _connection.QueryFirstOrDefault<Currency>(query, parameters);

            return item;

        }

    }
}

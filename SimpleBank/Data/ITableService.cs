using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBank.Data
{
    public interface ITableService
    {
        string TableName { get; }
        int CreateTable();
        bool TableExists();
    }
}

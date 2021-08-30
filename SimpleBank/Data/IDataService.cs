using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBank.Data
{
    public interface IDataService<T>
    {
        string TableName { get; }
        T GetItem(int id);
        int CreateItem(T item);
        int Count();

    }
}

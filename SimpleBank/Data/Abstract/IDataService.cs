using System.Collections.Generic;

namespace SimpleBank.Data.Abstract
{
    public interface IDataService<T>
    {
        string TableName { get; }
        List<T> GetCollection();
        T GetItem(int id);
        int CreateItem(T item);
        int Count();

    }
}

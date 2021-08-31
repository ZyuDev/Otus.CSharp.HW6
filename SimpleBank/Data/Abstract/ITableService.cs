namespace SimpleBank.Data.Abstract
{
    public interface ITableService
    {
        string TableName { get; }
        int CreateTable();
        bool TableExists();
    }
}

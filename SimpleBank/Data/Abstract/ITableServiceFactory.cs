using SimpleBank.Data.TableServices;

namespace SimpleBank.Data.Abstract
{
    public interface ITableServiceFactory
    {
        AccountTableService CreateAccountTableService();
        CurrencyTableService CreateCurrencyTableService();
        PersonTableService CreatePersonTableService();
        TransactionTableService CreateTransactionTableService();
    }
}
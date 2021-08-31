using SimpleBank.Entities;

namespace SimpleBank.Data.Abstract
{
    public interface ICurrencyDataService: IDataService<Currency>
    {
        Currency GetItem(string code);
    }
}
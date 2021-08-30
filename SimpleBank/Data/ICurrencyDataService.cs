using SimpleBank.Entities;

namespace SimpleBank.Data
{
    public interface ICurrencyDataService: IDataService<Currency>
    {
        Currency GetItem(string code);
    }
}
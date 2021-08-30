using SimpleBank.Data;
using SimpleBank.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBank.Services
{
    public class FillDbUnitOfWork
    {
        private ICurrencyDataService _currencyService;
        private IDataService<Person> _personService;

        public FillDbUnitOfWork(ICurrencyDataService currencyService, IDataService<Person> personDataService)
        {
            _currencyService = currencyService;
            _personService = personDataService;
        }

        public void CreateCurrencies()
        {
            var currencies = DataGenerator.StandardCurrencies();

            foreach (var item in currencies)
            {
                var savedItem = _currencyService.GetItem(item.Code);

                if (savedItem == null)
                {
                    try
                    {
                        _currencyService.CreateItem(item);
                        Console.WriteLine($"Currency {item} created");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Cannot create currency {item}. Message: {e.Message}");
                    }
                }
            }
        }

        public void CreatePersons()
        {
            var count = _personService.Count();

            if (count > 0)
            {
                return;
            }

            var persons = DataGenerator.GeneratePersons();

            foreach(var item in persons)
            {
                try
                {
                    _personService.CreateItem(item);
                    Console.WriteLine($"Person {item} created");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Cannot create person {item}. Message: {e.Message}");
                }
            }
        }
    }
}

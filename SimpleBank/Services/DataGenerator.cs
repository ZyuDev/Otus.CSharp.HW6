using SimpleBank.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBank.Services
{
    public class DataGenerator
    {
        public static List<Currency> StandardCurrencies()
        {
            var collection = new List<Currency>();

            collection.Add(new Currency() { Title = "Euro", Code = "EUR", CodeNumeric = "978" });
            collection.Add(new Currency() { Title = "US Dollar", Code = "USD", CodeNumeric = "840" });
            collection.Add(new Currency() { Title = "Рубль", Code = "RUB", CodeNumeric = "643" });
            collection.Add(new Currency() { Title = "Malawi Kwacha", Code = "MWK", CodeNumeric = "454" });
            collection.Add(new Currency() { Title = "Tugrik", Code = "MNT", CodeNumeric = "496" });

            return collection;
        }

        public static List<Person> GeneratePersons()
        {
            var persons = new List<Person>();

            persons.Add(new Person()
            {
                LastName = "Иванов",
                FirstName = "Иван",
                MiddleName = "Иванович",
                DateOfBirth = new DateTime(1970, 1, 1)
            });

            persons.Add(new Person()
            {
                LastName = "Петров",
                FirstName = "Петр",
                MiddleName = "Петрович",
                DateOfBirth = new DateTime(1975, 2, 2)
            });

            persons.Add(new Person()
            {
                LastName = "Сидоров",
                FirstName = "Сидор",
                MiddleName = "Сидорович",
                DateOfBirth = new DateTime(1980, 3, 3)
            });

            persons.Add(new Person()
            {
                LastName = "Ржевский",
                FirstName = "Дмитрий",
                MiddleName = "Иванович",
                DateOfBirth = new DateTime(1985, 4, 4)
            });

            persons.Add(new Person()
            {
                LastName = "Ростова",
                FirstName = "Наталья",
                MiddleName = "Ильинична",
                DateOfBirth = new DateTime(1990, 5, 5)
            }
            );



            return persons;
        }
    }
}

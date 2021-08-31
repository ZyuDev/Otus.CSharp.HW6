﻿using SimpleBank.Data;
using SimpleBank.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleBank.Data.Abstract;
using SimpleBank.Data.DataServices;

namespace SimpleBank.Services
{
    public class FillDbUnitOfWork
    {
        private readonly DataServiceFactory _factory;
        public FillDbUnitOfWork(DataServiceFactory factory)
        {
            _factory = factory;
        }

        public void CreateCurrencies()
        {
            var currencies = DataGenerator.StandardCurrencies();
            var currencyService = _factory.CreateCurrencyService();

            foreach (var item in currencies)
            {
                var savedItem = currencyService.GetItem(item.Code);

                if (savedItem == null)
                {
                    try
                    {
                        currencyService.CreateItem(item);
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
            var personService = _factory.CreatePersonService();
            var count = personService.Count();

            if (count > 0)
            {
                return;
            }

            var persons = DataGenerator.GeneratePersons();

            foreach(var item in persons)
            {
                try
                {
                    personService.CreateItem(item);
                    Console.WriteLine($"Person {item} created");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Cannot create person {item}. Message: {e.Message}");
                }
            }
        }

        public void CreateAccounts()
        {
            
            var accountService = _factory.CreateAccountService();

            if (accountService.Count() > 0)
            {
                return;
            }

            var currencyService = _factory.CreateCurrencyService();
            var usd = currencyService.GetItem("USD");

            if (usd == null)
            {
                Console.WriteLine("USD currency not found");
                return;
            }

            var personService = _factory.CreatePersonService();
            
            var persons = personService.GetCollection();

            foreach (var item in persons)
            {
                var newAccount = new Account()
                {
                    OwnerId = item.Id,
                    CurrencyId = usd.Id,
                    AccountNumber = $"{item.Id:0000}{usd.CodeNumeric}"
                };

                try
                {
                    accountService.CreateItem(newAccount);
                    Console.WriteLine($"Account {newAccount} created");

                }
                catch (Exception e)
                {
                    Console.WriteLine($"Cannot create account {newAccount}. Message: {e.Message}");
                }
            }
        }
    }
}

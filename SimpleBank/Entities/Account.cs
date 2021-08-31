using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBank.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public int CurrencyId { get; set; }
        public int OwnerId { get; set; }

        public override string ToString()
        {
            return AccountNumber;
        }
    }
}

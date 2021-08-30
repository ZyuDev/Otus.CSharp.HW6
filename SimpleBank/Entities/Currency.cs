using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBank.Entities
{
    public class Currency
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string CodeNumeric { get; set; }
        public string Title { get; set; }

        public override string ToString()
        {
            return $"{Code} {CodeNumeric}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBank.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {MiddleName} {LastName} - {DateOfBirth:dd.MM.yyyy}";
        }
    }
}

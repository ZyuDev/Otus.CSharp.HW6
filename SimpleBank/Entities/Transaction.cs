﻿using SimpleBank.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBank.Entities
{
    public class Transaction
    {
        public DateTime Period { get; set; }
        public TransactionDirections Direction { get; set; }
        public int AccountId { get; set; }
        public decimal Amount { get; set; }
    }
}
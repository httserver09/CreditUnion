﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace union.Models
{
    public class Transaction
    {
        [Key]
        public int id { get; set; }
        public double amount { get; set; }    
        public string description { get; set; }
        public DateTime transactionDate { get; set; }
        public string transactionStatus { get; set; }
        public int accountId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace union.Models
{
    public class Account
    {
        [Key]
        public int id { get; set; }
        public string accountType { get; set; }
        public DateTime activatedDate { get; set; }
        public int clientId { get; set; }
        public double baseAmount { get; set; }
    }
}

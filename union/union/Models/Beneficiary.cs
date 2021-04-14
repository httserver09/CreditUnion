using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace union.Models
{
    public class Beneficiary
    {
        [Key]
        public int id { get; set; }
        public string fullname { get; set; }
        public string bankName { get; set; }
        public string accountNumber { get; set; }
        public string yourRef { get; set; }
        public string beneficiaryReference { get; set; }
        public int accountId { get; set; }
    }
}

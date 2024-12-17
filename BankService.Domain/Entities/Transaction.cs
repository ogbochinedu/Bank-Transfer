using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankService.Domain.Entities
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public string FromAccount { get; set; }
        public string ToAccount { get; set; }
        public decimal Amount { get; set; }
        public string BankCode { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

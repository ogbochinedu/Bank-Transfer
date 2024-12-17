using BankService.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankService.Infrastructure.Repositories
{
    public class TransactionRepository
    {
        private readonly BankServiceDbContext _context;

        public TransactionRepository(BankServiceDbContext context)
        {
            _context = context;
        }
      
    }
}

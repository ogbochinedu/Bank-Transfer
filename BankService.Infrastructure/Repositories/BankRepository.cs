using BankService.Domain.Entities;
using BankService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankService.Infrastructure.Repositories
{
    public class BankRepository
    {
        private readonly BankServiceDbContext _context;

        public BankRepository(BankServiceDbContext context)
        {
            _context = context;
        }

        public async Task<List<Bank>> GetBanksAsync()
        {
            return await _context.Banks.ToListAsync();
        }
    }
}

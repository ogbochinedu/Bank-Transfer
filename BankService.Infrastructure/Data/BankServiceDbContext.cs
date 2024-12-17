using BankService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankService.Infrastructure.Data
{
    public class BankServiceDbContext : DbContext
    {
        public BankServiceDbContext(DbContextOptions<BankServiceDbContext> options) : base(options)
        {
        }

        public DbSet<Bank> Banks { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BankServiceDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }

}

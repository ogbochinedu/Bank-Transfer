using BankService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankService.Infrastructure.Data.Configurations
{   
        public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
        {
            public void Configure(EntityTypeBuilder<Transaction> builder)
            {
                builder.HasKey(t => t.FromAccount);

                builder.Property(t => t.FromAccount)
                    .IsRequired()
                    .HasMaxLength(10);

                builder.Property(t => t.ToAccount)
                    .IsRequired()
                    .HasMaxLength(10);

                builder.Property(t => t.Amount)
                    .IsRequired();

                builder.Property(t => t.BankCode)
                    .IsRequired()
                    .HasMaxLength(10);

                builder.Property(t => t.CreatedAt)
                    .IsRequired();
            }
        }
}

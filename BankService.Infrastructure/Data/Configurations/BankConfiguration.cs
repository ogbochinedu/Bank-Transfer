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
    public class BankConfiguration : IEntityTypeConfiguration<Bank>
        {
            public void Configure(EntityTypeBuilder<Bank> builder)
            {
                builder.HasKey(b => b.Code);

                builder.Property(b => b.Code)
                    .IsRequired()
                    .HasMaxLength(10);

                builder.Property(b => b.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            }
        }

}

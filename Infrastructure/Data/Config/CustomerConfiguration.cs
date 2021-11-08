using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Config
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FirstName).HasMaxLength(50).IsRequired(true);
            builder.Property(x => x.LastName).HasMaxLength(50).IsRequired(true);
            builder.Property(x => x.Email).HasMaxLength(100).IsRequired(true);
            builder.Property(x => x.PasswordHash).IsRequired(true);
            builder.Property(x => x.RowVersion)
                .IsConcurrencyToken()
                .HasDefaultValue(0)
                .IsRowVersion();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortfolioManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManagement.Persistence.Mappings
{
    public class TransactionMap : IEntityTypeConfiguration<Domain.Entities.Transaction>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Transaction> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();//bir bir artmasını sağlıyor

            builder.Property(a => a.Amount).IsRequired(true);
            builder.Property(a => a.TransactionPrice).IsRequired(true);
            builder.Property(a => a.TotalPrice).IsRequired(true);

            builder.HasOne<Portfolio>(a => a.Portfolio).WithMany(c => c.Transactions).HasForeignKey(a => a.PortfolioId);

            builder.Property(a => a.IsDeleted).IsRequired(true);
            builder.Property(a => a.IsActive).IsRequired(true);
            builder.ToTable("Transactions");
        }
    }
}

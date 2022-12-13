using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortfolioManagement.Domain.Entities;
using PortfolioManagement.Domain.Interfaces.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManagement.Persistence.Mappings
{
    public class PortfolioMap : IEntityTypeConfiguration<Portfolio>
    {
        public void Configure(EntityTypeBuilder<Portfolio> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();//bir bir artmasını sağlıyor

            builder.HasOne<User>(a => a.User).WithMany(c => c.Portfolios).HasForeignKey(a => a.UserId);
            builder.HasOne<Wallet>(a => a.Wallet).WithOne(c => c.Portfolio)
                .HasForeignKey<Wallet>(v => v.PortfolioId);

            builder.Property(a => a.IsDeleted).IsRequired(true);
            builder.Property(a => a.IsActive).IsRequired(true);
            builder.ToTable("Portfolios");
        }
    }
}

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
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Name).HasMaxLength(100);
            builder.Property(a => a.Name).IsRequired(true);

            builder.Property(a => a.Surname).HasMaxLength(100);
            builder.Property(a => a.Surname).IsRequired(true);

            builder.Property(a => a.UserName).HasMaxLength(100);
            builder.Property(a => a.UserName).IsRequired(true);
            builder.HasIndex(a => a.UserName).IsUnique(true);

            builder.Property(a => a.UserPassword).HasMaxLength(100);
            builder.Property(a => a.UserPassword).IsRequired(true);


            builder.Property(a => a.IsDeleted).IsRequired(true);
            builder.Property(a => a.IsActive).IsRequired(true);

            builder.ToTable("Users");
        }
    }
}

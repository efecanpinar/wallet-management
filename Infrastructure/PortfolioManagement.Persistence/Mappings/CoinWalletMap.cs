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
    public class CoinWalletMap : IEntityTypeConfiguration<CoinWallet>
    {
        public void Configure(EntityTypeBuilder<CoinWallet> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd(); //bir bir artmasını sağlıyor


            builder.ToTable("CoinWallets");
        }
    }
}

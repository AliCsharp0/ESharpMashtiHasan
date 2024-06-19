using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Shapping.DomainModel.Models.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.PageTitle).IsRequired().HasMaxLength(100);

            builder.Property(x => x.Slup).IsRequired().HasMaxLength(200);

            builder.Property(x => x.JSONLDInformation).IsRequired().HasMaxLength(4000);

            builder.Property(x => x.MataDescription).IsRequired().HasMaxLength(320);

            builder.Property(x => x.MetaKeyWord).IsRequired().HasMaxLength(160);

            builder.Property(x => x.ProductName).IsRequired().HasMaxLength(100);

            builder.Property(x => x.ImagUrl).IsRequired().HasMaxLength(400);

            builder.HasMany(x=>x.OrderDetails).WithOne(x=>x.product).HasForeignKey(x=>x.ProductID).OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.ProductFeatures).WithOne(x => x.product).HasForeignKey(x => x.ProductID).OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.ProductKeyWords).WithOne(x => x.product).HasForeignKey(x => x.ProductID).OnDelete(DeleteBehavior.Cascade);

        }
    }
}

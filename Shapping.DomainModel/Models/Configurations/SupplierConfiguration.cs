using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapping.DomainModel.Models.Configurations
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.Property(x => x.SupplierName).IsRequired().HasMaxLength(100);

            builder.Property(x => x.SupplierDescription).HasMaxLength(300);

            builder.HasMany(x => x.Products).WithOne(x => x.supplier).HasForeignKey(x => x.SupplierID).OnDelete(DeleteBehavior.NoAction);
        }
    }
}

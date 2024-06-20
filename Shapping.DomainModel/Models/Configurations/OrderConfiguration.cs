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
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(x => x.AddressID).IsRequired();

            builder.Property(x=>x.OrderDescription).HasMaxLength(400);

            builder.Property(x=>x.OrderDate).IsRequired().HasDefaultValue(DateTime.Now);

            builder.HasMany(x=>x.orderDetails).WithOne(x=>x.order).OnDelete(DeleteBehavior.NoAction).HasForeignKey(x=>x.OrderID);
        }
    }
}

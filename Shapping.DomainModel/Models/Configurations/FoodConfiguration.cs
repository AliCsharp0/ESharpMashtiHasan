using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapping.DomainModel.Models.Configurations
{
    public class FoodConfiguration : IEntityTypeConfiguration<Food>
    {
        public void Configure(EntityTypeBuilder<Food> builder)
        {
            builder.Property(x => x.FoodName).IsRequired().HasMaxLength(100);

            builder.Property(x => x.FoodIngredients).IsRequired().HasMaxLength(500);

            builder.Property(x => x.UnitPrice).IsRequired();
        }
    }
}

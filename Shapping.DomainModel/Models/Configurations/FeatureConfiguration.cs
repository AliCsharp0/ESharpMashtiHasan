using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapping.DomainModel.Models.Configurations
{
    public class FeatureConfiguration : IEntityTypeConfiguration<Feature>
    {
        public void Configure(EntityTypeBuilder<Feature> builder)
        {
            builder.HasMany(x=>x.CategoryFeatures).WithOne(x=>x.Feature).HasForeignKey(x=>x.FeatureID).OnDelete(DeleteBehavior.NoAction);

            builder.Property(x=>x.FeatureName).IsRequired().HasMaxLength(100);

           // builder.HasKey(x => x.FeatureID); in ro zamani estefadeh mikonim ke 
        }
    }
}

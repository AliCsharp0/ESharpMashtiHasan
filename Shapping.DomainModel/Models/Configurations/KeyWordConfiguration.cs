using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapping.DomainModel.Models.Configurations
{
    public class KeyWordConfiguration : IEntityTypeConfiguration<KeyWord>
    {
        public void Configure(EntityTypeBuilder<KeyWord> builder)
        {
            builder.HasMany(x=>x.ProductKeyWords).WithOne(x => x.KeyWord).HasForeignKey(x => x.KeyWordID).OnDelete(DeleteBehavior.Cascade);//cascade iani mitone pak beshe mohem nist

            builder.Property(x=>x.KeyWordText).HasMaxLength(100);

            builder.HasKey(x => x.KeyWordID);
        }
    }
}

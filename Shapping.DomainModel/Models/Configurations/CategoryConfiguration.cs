using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapping.DomainModel.Models.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x => x.CategoriesName).IsRequired().HasMaxLength(100);

            builder.HasKey(x => x.CategoryID);

            builder.HasMany(x=>x.Products).WithOne(x=>x.category).HasForeignKey(x=>x.CategoryID).OnDelete(DeleteBehavior.NoAction);//in category khaili product dare va in product ha iek Category dare 
            //hasforeignkey iani kilid id bar asase categoryid bashe va noaction iani nemitavanad delete anjam dahad.

            builder.HasMany(x => x.children).WithOne(x => x.Parent).HasForeignKey(x => x.ParentID).OnDelete(DeleteBehavior.NoAction);

            builder.Property(x=>x.ParentID).IsRequired(false);

            builder.Property(x=>x.LineAge).IsRequired(false).HasMaxLength(400);

            
        }
    }
}

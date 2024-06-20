using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapping.DomainModel.Models.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(x=>x.FirstName).IsRequired().HasMaxLength(20);

            builder.Property(x=>x.LastName).IsRequired().HasMaxLength(20);

            builder.Property(x=>x.MobileNumber).IsRequired().HasMaxLength(12);
        }
    }
}

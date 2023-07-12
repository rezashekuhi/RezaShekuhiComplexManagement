using ComplexManagment.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagment.DataLayer.EntitesMap
{
    public class ComplexUsageTypesMap : IEntityTypeConfiguration<ComplexUsageType>
    {
        public void Configure(EntityTypeBuilder<ComplexUsageType> builder)
        {
            builder.ToTable("ComplexUsageTypes");
            builder.HasKey(_=>_.ComplexId);
            builder.Property(_=>_.ComplexId).IsRequired().ValueGeneratedNever();
            
            builder.HasKey(_ => _.UsageTypeId);
            builder.Property(_ => _.UsageTypeId).IsRequired().ValueGeneratedNever();
           
        }
    }
}

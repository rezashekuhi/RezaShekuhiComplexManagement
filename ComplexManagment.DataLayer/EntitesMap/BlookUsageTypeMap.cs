using ComplexManagment.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexManagment.Persistence.Ef.EntitesMap
{
    public class BlookUsageTypeMap : IEntityTypeConfiguration<BlookUsageType>
    {
        public void Configure(EntityTypeBuilder<BlookUsageType> builder)
        {
            builder.ToTable("BlookUsageTypes");
            builder.HasKey(_ => _.BlookId);
            builder.Property(_ => _.BlookId).ValueGeneratedNever();

            builder.Property(_ => _.UsageTypeId).ValueGeneratedNever();

        }
    }
}

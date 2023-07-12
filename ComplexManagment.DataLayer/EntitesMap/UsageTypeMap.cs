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
    public class UsageTypeMap : IEntityTypeConfiguration<UsageType>
    {
        public void Configure(EntityTypeBuilder<UsageType> builder)
        {
            builder.ToTable("UsageTypes");
            builder.HasKey(_=>_.Id);
            builder.Property(_=>_.Id).ValueGeneratedOnAdd();
            builder.Property(_=>_.Title).IsRequired();
        }
    }
}

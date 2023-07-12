using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexMigration.Migrations
{
    [FluentMigrator.Migration(202307101356)]
    public class _202307101356_AddComplexUsageType : FluentMigrator.Migration
    {
        public override void Up()
        {
            Create.Table("ComplexUsageTypes")
                .WithColumn("UsageTypeId").AsInt32().PrimaryKey()
                .ForeignKey("FK_ComplexUsageTypes_UsageTypes",
                "UsageTypes", "Id")
                .WithColumn("ComplexId").AsInt32().PrimaryKey()
                .ForeignKey("FK_ComplexUsageTypes_Complexs",
                "Complexs","Id");
        }

        public override void Down()
        {
            Delete.Table("ComplexUsageTypes");
        }

    }
}

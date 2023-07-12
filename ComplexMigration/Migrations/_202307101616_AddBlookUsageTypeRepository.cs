using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexMigration.Migrations
{
    [FluentMigrator.Migration(202307101616)]
    public class _202307101616_AddBlookUsageTypeRepository : FluentMigrator.Migration
    {
        public override void Up()
        {
            Create.Table("BlookUsagetypes")
                .WithColumn("BlookId").AsInt32().PrimaryKey()
                .ForeignKey("FK_BlookUsagetypes_Blooks",
                "Blooks", "id")
                .WithColumn("UsageTypeId").AsInt32().PrimaryKey()
                .ForeignKey("FK_BlookUsagetypes_UsageTypes",
                "UsageTypes", "Id");
        }
        public override void Down()
        {
            Delete.Table("BlookUsagetypes");
        }

    }
}

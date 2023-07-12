using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexMigration.Migrations
{
    [FluentMigrator.Migration(202307101145)]
    public class _202307101145_AddUsageType : FluentMigrator.Migration
    {
        public override void Up()
        {
          Create.Table("UsageTypes")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Title").AsString().NotNullable();
        }
        public override void Down()
        {
            Delete.Table("UsageTypes");
        }

    }
}

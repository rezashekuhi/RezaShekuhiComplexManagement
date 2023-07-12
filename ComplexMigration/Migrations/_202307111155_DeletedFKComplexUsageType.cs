using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexMigration.Migrations
{
    [FluentMigrator.Migration(202307111155)]
    public class _202307111155_DeletedFKComplexUsageType : FluentMigrator.Migration
    {
        public override void Up()
        {
            Delete.ForeignKey("FK_ComplexUsageTypes_UsageTypes").OnTable("ComplexUsageTypes");
            Delete.ForeignKey("FK_ComplexUsageTypes_Complexs").OnTable("ComplexUsageTypes");
        }

        public override void Down()
        {
            Create.ForeignKey("FK_ComplexUsageTypes_Complexs")
                .FromTable("ComplexUsageTypes")
                .ForeignColumn("ComplexId")
                .ToTable("Complexs")
                .PrimaryColumn("Id");
            Create.ForeignKey("FK_ComplexUsageTypes_UsageTypes")
                .FromTable("ComplexUsageTypes")
                .ForeignColumn("UsageTypeId")
                .ToTable("Usagetypes")
                .PrimaryColumn("Id");
        }

        
    }
}

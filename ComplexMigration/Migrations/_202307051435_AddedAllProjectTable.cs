using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexMigration.Migrations
{
    [FluentMigrator.Migration(202307051435)]
    public class _202307051435_AddedAllProjectTable : FluentMigrator.Migration
    {
        public override void Up()
        {
            Create.Table("Complexs")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Name").AsString(50).NotNullable()
                .WithColumn("UnitCount").AsInt32().NotNullable();
            Create.Table("Blooks")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Name").AsString(50).NotNullable()
                .WithColumn("UnitCount").AsInt32().NotNullable()
                .WithColumn("ComplexId").AsInt32().NotNullable()
                .ForeignKey("FK_Blooks_Complexs", "Complexs", "Id");
            Create.Table("Units")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Name").AsString().NotNullable()
                .WithColumn("Resident").AsInt32().NotNullable()
                .WithColumn("BlookId").AsInt32().NotNullable()
                .ForeignKey("FK_Units_Blooks", "Blooks", "Id");
        }
        public override void Down()
        {
            Delete.Table("Units");
            Delete.Table("Blooks");
            Delete.Table("Complexs");
        }

        
    }
}

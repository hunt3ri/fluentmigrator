using System;
using FluentMigrator;
namespace Huzutech.Migrations.Migrations.Launch
{
    [Migration(10)]
    public class Mig010_CreateApiTable : Migration
    {
        public override void Up()
        {
            Create.Table("Api")
                .WithColumn("ApiId").AsInt32().PrimaryKey().Identity()
                .WithColumn("Title").AsString(100).NotNullable()
                .WithColumn("Description").AsString(500).Nullable();
        }

        public override void Down()
        {
            Delete.Table("Api");
        }
    }
}
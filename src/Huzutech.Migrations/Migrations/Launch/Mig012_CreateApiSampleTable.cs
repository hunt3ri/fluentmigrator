using System;
using FluentMigrator;
namespace Huzutech.Migrations.Migrations.Launch
{
    [Migration(12)]
    public class Mig012_CreateApiSampleTable : Migration
    {
        public override void Up()
        {
            Create.Table("ApiSample")
                .WithColumn("ApiSampleId").AsInt32().PrimaryKey().Identity()
                .WithColumn("ApiRequestId").AsInt32().NotNullable()
                .WithColumn("Title").AsString(100).NotNullable()
                .WithColumn("Description").AsString(500).Nullable()
                .WithColumn("RequestUrl").AsString(500).NotNullable()
                .WithColumn("RequestHeaders").AsString().NotNullable()
                .WithColumn("RequestBody").AsString().Nullable()
                .WithColumn("Response").AsString().Nullable();

            Create.ForeignKey("FK_ApiSample_ApiRequest").FromTable("ApiSample").ForeignColumn("ApiRequestId").ToTable("ApiRequest").PrimaryColumn("ApiRequestId");
        }

        public override void Down()
        {
           
            Delete.Table("ApiSample");
        }
    }
}
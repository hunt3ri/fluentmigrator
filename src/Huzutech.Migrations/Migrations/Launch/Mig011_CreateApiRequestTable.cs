using System;
using FluentMigrator;
namespace Huzutech.Migrations.Migrations.Launch
{
    [Migration(11)]
    public class Mig011_CreateApiRequestTable : Migration
    {
        public override void Up()
        {
            Create.Table("ApiRequest")
                .WithColumn("ApiRequestId").AsInt32().PrimaryKey().Identity()
                .WithColumn("ApiId").AsInt32().NotNullable()
                .WithColumn("Title").AsString(100).NotNullable()
                .WithColumn("Description").AsString(500).Nullable()
                .WithColumn("MethodType").AsString(10).NotNullable()
                .WithColumn("AuthRequired").AsBoolean().NotNullable()
                .WithColumn("Url").AsString(500).NotNullable()
                .WithColumn("UrlParams").AsString().Nullable()
                .WithColumn("RequestBody").AsString().Nullable()
                .WithColumn("Response").AsString().Nullable();

            Create.ForeignKey("FK_ApiRequest_Api").FromTable("ApiRequest").ForeignColumn("ApiId").ToTable("Api").PrimaryColumn("ApiId");
        }

        public override void Down()
        {
            Delete.ForeignKey("FK_ApiRequest_Api").OnTable("ApiRequest");
            Delete.Table("ApiRequest");
        }
    }
}
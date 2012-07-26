using System;
using FluentMigrator;
namespace Huzutech.Migrations.Migrations.Launch
{
	[Migration(5)]
	public class Mig005_OAuth2Client : Migration
	{
		public override void Up()
		{
			Create.Table("OAuth2Client")
				.WithColumn("OAuth2ClientId").AsInt32().PrimaryKey().Identity()
				.WithColumn("Name").AsString(200).NotNullable()
				.WithColumn("Description").AsString(500)
				.WithColumn("Author").AsString(100)
				.WithColumn("ContactInfo").AsString(200)
				.WithColumn("IconUrl").AsString(500)
				.WithColumn("ClientId").AsString(100)
				.WithColumn("SecretKey").AsString(100)
				.WithColumn("RedirectUrl").AsString(500);
		}

		public override void Down()
		{
			Delete.Table("OAuth2Client");
		}
	}
}
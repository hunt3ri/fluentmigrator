using System;
using FluentMigrator;
namespace Huzutech.Migrations.Migrations.Launch
{
	[Migration(6)]
	public class Mig006_OAuth2Token : Migration
	{
		public override void Up()
		{
			Create.Table("OAuth2Token")
				.WithColumn("OAuth2TokenId").AsInt32().PrimaryKey().Identity()
				.WithColumn("AuthorisationCode").AsString(50).NotNullable()
				.WithColumn("AccessToken").AsString(100).NotNullable()
				.WithColumn("UserId").AsInt32().NotNullable()
				.WithColumn("OAuth2ClientId").AsInt32().NotNullable()
				.WithColumn("ExpiryDate").AsDateTime().NotNullable();

			// Create calculated column
			Execute.Sql("ALTER TABLE OAuth2Token ADD ExpiresIn AS (datediff(second,getdate(),[ExpiryDate]))");

			Create.ForeignKey("FK_OAuth2Token_User").FromTable("OAuth2Token").ForeignColumn("UserId").ToTable("User").PrimaryColumn("UserId");
			Create.ForeignKey("FK_OAuth2Token_OAuth2Client").FromTable("OAuth2Token").ForeignColumn("OAuth2ClientId").ToTable(
				"OAuth2Client").PrimaryColumn("OAuth2ClientId");

		}

		public override void Down()
		{
			Delete.Table("OAuth2Token");
		}
	}
}
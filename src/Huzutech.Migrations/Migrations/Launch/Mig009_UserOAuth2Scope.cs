using System;
using FluentMigrator;
namespace Huzutech.Migrations.Migrations.Launch
{
	[Migration(9)]
	public class Mig009_UserOAuth2Scope : Migration
	{
		public override void Up()
		{
			Create.Table("UserOAuth2Scope")
				.WithColumn("UserId").AsInt32()
				.WithColumn("OAuth2ClientId").AsInt32()
				.WithColumn("OAuth2ScopeId").AsInt32();

			var compKey = new[] { "UserId", "OAuth2ClientId", "OAuth2ScopeId" };

			Create.PrimaryKey("PK_UserOAuth2Scope").OnTable("UserOAuth2Scope").Columns(compKey);

			Create.ForeignKey("FK_UserOAuth2Scope_User").FromTable("UserOAuth2Scope").ForeignColumn("UserId").ToTable("User").
				PrimaryColumn("UserId");
			Create.ForeignKey("FK_UserOAuth2Scope_OAuth2Client").FromTable("UserOAuth2Scope").ForeignColumn("OAuth2ClientId").ToTable("OAuth2Client").
				PrimaryColumn("OAuth2ClientId");
			Create.ForeignKey("FK_UserOAuth2Scope_OAuth2Scope").FromTable("UserOAuth2Scope").ForeignColumn("OAuth2ScopeId").
				ToTable("OAuth2Scope").PrimaryColumn("OAuth2ScopeId");

		}

		public override void Down()
		{
			Delete.Table("UserOAuth2Scope");
		}
	}
}
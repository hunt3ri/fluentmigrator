using System;
using FluentMigrator;
namespace Huzutech.Migrations.Migrations.Launch
{
	[Migration(8)]
	public class Mig008_OAuth2TokenScope : Migration
	{
		public override void Up()
		{
			Create.Table("OAuth2TokenScope")
				.WithColumn("OAuth2ScopeId").AsInt32()
				.WithColumn("OAuth2TokenId").AsInt32();

			var compKey = new[] { "OAuth2ScopeId", "OAuth2TokenId" };

			Create.PrimaryKey("PK_OAuth2TokenScope").OnTable("OAuth2TokenScope").Columns(compKey);

			Create.ForeignKey("FK_OAuth2TokenScope_OAuth2Scope").FromTable("OAuth2TokenScope").ForeignColumn("OAuth2ScopeId").
				ToTable("OAuth2Scope").PrimaryColumn("OAuth2ScopeId");
			Create.ForeignKey("FK_OAuth2TokenScope_OAuth2Token").FromTable("OAuth2TokenScope").ForeignColumn("OAuth2TokenId").
				ToTable("OAuth2Token").PrimaryColumn("OAuth2TokenId");

		}

		public override void Down()
		{
			Delete.Table("OAuth2TokenScope");
		}
	}
}
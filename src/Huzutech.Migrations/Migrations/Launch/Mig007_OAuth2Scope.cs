using FluentMigrator;
namespace Huzutech.Migrations.Migrations.Launch
{
	[Migration(7)]
	public class Mig007_OAuth2Scope : Migration
	{
		public override void Up()
		{
			Create.Table("OAuth2Scope")
				.WithColumn("OAuth2ScopeId").AsInt32().PrimaryKey().Identity()
				.WithColumn("Name").AsString(100).NotNullable()
				.WithColumn("Description").AsString(250);
		}

		public override void Down()
		{
			Delete.Table("OAuth2Scope");
		}
	}
}
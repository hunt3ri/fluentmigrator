using System;
using FluentMigrator;
namespace Huzutech.Migrations.Migrations.Launch
{
	[Migration(3)]
	public class Mig003_CreateUserRoleTable : Migration
	{
		public override void Up()
		{
			Create.Table("UserRole")
				.WithColumn("UserId").AsInt32().NotNullable()
				.WithColumn("RoleId").AsInt16().NotNullable();

			var compKey = new[] { "UserId", "RoleId" };

			Create.PrimaryKey("PK_UserRole").OnTable("UserRole").Columns(compKey);

			Create.ForeignKey("FK_UserRole_User").FromTable("UserRole").ForeignColumn("UserId").ToTable("User").PrimaryColumn("UserId");
			Create.ForeignKey("FK_UserRole_Role").FromTable("UserRole").ForeignColumn("RoleId").ToTable("Role").PrimaryColumn("RoleId");

		}

		public override void Down()
		{
			Delete.Table("UserRole");
		}
	}
}
using System;
using FluentMigrator;
namespace Huzutech.Migrations.Migrations.Launch
{
	[Migration(4)]
	public class Mig004_CreateLog4NetLog : Migration
	{
		public override void Up()
		{
			Create.Table("Log4NetLog")
				.WithColumn("Id").AsInt32().PrimaryKey().Identity()
				.WithColumn("Date").AsDateTime()
				.WithColumn("Thread").AsString(255)
				.WithColumn("Level").AsString(50)
				.WithColumn("Logger").AsString(255)
				.WithColumn("Message").AsString(int.MaxValue)
				.WithColumn("Exception").AsString(int.MaxValue);
		}

		public override void Down()
		{
			Delete.Table("Log4NetLog");
		}
	}
}
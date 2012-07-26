using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentMigrator.Runner;
using FluentMigrator.Runner.Announcers;
using FluentMigrator.Runner.Initialization;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Huzutech.Tests
{
	[TestFixture]
	public class TestRunner 
	{
		[Test]
		public void RunMigrations()
		{
			IAnnouncer announcer = new ConsoleAnnouncer
			{
				ShowElapsedTime = false,
				ShowSql = false
			};

			var runnerContext = new RunnerContext(announcer)
			{
				Database = "sqlserver2008",
				Connection = "",
				Target = @"C:\dev\work\fluentmigrator\src\Huzutech.Migrations\bin\Debug\Huzutech.Migrations.dll",
				Version = 1,
			};

			new TaskExecutor(runnerContext).Execute();
		}
	}
}

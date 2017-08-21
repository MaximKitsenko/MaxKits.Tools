using System;

namespace MaxKits.Patterns.Tests.Creational.Prototype.Misc
{
	internal class Program
	{
		private readonly BaseCloneableTest _test1 = new BaseCloneableTest();

		private static void Main( string[] args )
		{
			BaseCloneableTest t = new BaseCloneableTest();
			t.Init();
			t.TestShallowCapitanNumber();
			t.Init();
			t.TestShallowObjectCountry();
			t.Init();
			t.TestShallowObjectPlayer();
			t.Init();
			t.TestShallowPlayerName();
			
			t.Init();
			t.TestDeepCapitanNumber();
			t.Init();
			t.TestDeepObjectCountry();
			t.Init();
			t.TestDeepObjectPlayer();
			t.Init();
			t.TestDeepPlayerName();

			Console.ReadLine();
		}
	}
}
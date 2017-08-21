using System;
using System.Collections.Generic;
using FluentAssertions;
using MaxKits.Patterns.Tests.Creational.Prototype.Misc;
using NUnit.Framework;

namespace MaxKits.Patterns.Tests.Creational.Prototype
{
	internal class BaseCloneableTest
	{
		private FootballTeam _footballTeamRussia;
		private Player _player0;
		private Player _player1;
		private Player _player2;
		private Player _player3;
		private Country _russia;
		private Country _usa;

		[SetUp]
		public void Init()
		{
			_russia = new Country {Name = "Russia", Population = 145};
			_usa = new Country {Name = "USA", Population = 300};

			_player0 = new Player {BornCountry = _russia, Name = "Ivanov", Number = 10};
			_player1 = new Player {BornCountry = _russia, Name = "Petrov", Number = 9};
			_player2 = new Player {BornCountry = _usa, Name = "Smit", Number = 23};
			_player3 = new Player {BornCountry = _usa, Name = "Klarc", Number = 24};

			_footballTeamRussia = new FootballTeam {Players = new List<Player> {_player0, _player1}, Captan = _player0};
		}

		[Test]
		public void DeepCloneObjectAndChangeDeepProperties_CopyAndOriginalCompletelyUndependentObjects()
		{
			//a
			var originalName = _footballTeamRussia.Captan.Name;
			var originalNumber = _footballTeamRussia.Players[0].Number;
			var footballTeamCopy = _footballTeamRussia.DeepClone();

			//a
			const int newNumber = 100500;
			const string newName = "100500";

			footballTeamCopy.Captan.Number = newNumber;
			footballTeamCopy.Players[0].Name = newName;

			//a
			_footballTeamRussia.Players[0].Number.Should().Be(originalNumber);
			_footballTeamRussia.Captan.Name.Should().Be(originalName);

			footballTeamCopy.Players[0].Number.Should().Be(newNumber);
			footballTeamCopy.Captan.Name.Should().Be(newName);

			ReferenceEquals(footballTeamCopy, _footballTeamRussia).Should().BeFalse();
			ReferenceEquals(footballTeamCopy.Captan, _footballTeamRussia.Captan).Should().BeFalse();
		}


		[Test]
		public void SwallowCloneObjectAndChangeValueType_CopyAndOriginalDifferentObjectsButWithTheSameFields()
		{
			//a
			var footballTeamCopy = _footballTeamRussia.ShallowClone();

			//a
			const int newNumber = 100500;
			const string newName = "100500";

			footballTeamCopy.Captan.Number = newNumber;
			footballTeamCopy.Players[0].Name = newName;

			//a
			_footballTeamRussia.Players[0].Number.Should().Be(newNumber);
			_footballTeamRussia.Captan.Name.Should().Be(newName);

			footballTeamCopy.Players[0].Number.Should().Be(newNumber);
			footballTeamCopy.Captan.Name.Should().Be(newName);

			ReferenceEquals(footballTeamCopy, _footballTeamRussia).Should().BeFalse();
			ReferenceEquals(footballTeamCopy.Captan, _footballTeamRussia.Captan).Should().BeTrue();
		}

		//[Test]
		//public void SwallowCloneObject_CopyAndOriginalCompletelyUndependentObjects()
		//{
		//	//a
		//	var footballTeamCopy = _footballTeamRussia.ShallowClone();

		//	//a
		//	const int newNumber = 100500;
		//	const string newName = "100500";

		//	footballTeamCopy.Captan = _player2;
		//	footballTeamCopy.Players[0].Name = newName;

		//	//a
		//	_footballTeamRussia.Players[0].Number.Should().Be(newNumber);
		//	_footballTeamRussia.Captan.Name.Should().Be(newName);

		//	footballTeamCopy.Players[0].Number.Should().Be(newNumber);
		//	footballTeamCopy.Captan.Name.Should().Be(newName);

		//	ReferenceEquals(footballTeamCopy, _footballTeamRussia).Should().BeFalse();
		//	ReferenceEquals(footballTeamCopy.Captan, _footballTeamRussia.Captan).Should().BeTrue();
		//}

		public void TestShallowObjectPlayer()
		{
			/*
			------------------------SHALLOW-----------------------------------------------------
			*/
			Console.WriteLine("------------------------SHALLOW-OBJECT-PLAYER-----------");

			Console.WriteLine("footballTeamRussia:");
			Console.WriteLine(_footballTeamRussia.ToString());

			var footballTeamRussiaShallow = _footballTeamRussia.ShallowClone();
			Console.WriteLine("footballTeamRussiaShallow:");
			Console.WriteLine(footballTeamRussiaShallow.ToString());

			Console.WriteLine("\n\nfootballTeamRussia.Captan = player1");
			_footballTeamRussia.Captan = _player1;
			Console.WriteLine("footballTeamRussia");
			Console.WriteLine(_footballTeamRussia.ToString());

			Console.WriteLine("footballTeamRussiaShallow");
			Console.WriteLine(footballTeamRussiaShallow.ToString());
		}

		public void TestShallowObjectCountry()
		{
			/*
					------------------------SHALLOW-----------------------------------------------------
					*/
			Console.WriteLine("-----------------------SHALLOW-OBJECT-COUNTRY-----------");

			Console.WriteLine("footballTeamRussia:");
			Console.WriteLine(_footballTeamRussia.ToString());

			var footballTeamRussiaShallow = _footballTeamRussia.ShallowClone();
			Console.WriteLine("footballTeamRussiaShallow:");
			Console.WriteLine(footballTeamRussiaShallow.ToString());

			Console.WriteLine("\n\nfootballTeamRussia.Captan.BornCountry = usa");
			_footballTeamRussia.Captan.BornCountry = _usa;
			Console.WriteLine("footballTeamRussia");
			Console.WriteLine(_footballTeamRussia.ToString());

			Console.WriteLine("footballTeamRussiaShallow");
			Console.WriteLine(footballTeamRussiaShallow.ToString());
		}

		/////////////////////////////////

		public void TestDeepPlayerName()
		{
			/*
			------------------------DEEP--------------------------------------------------------
			*/
			Console.WriteLine("------------------------DEEEP---PLAYER-NAME-------------");

			Console.WriteLine("footballTeamRussia:");
			Console.WriteLine(_footballTeamRussia.ToString());

			var footballTeamRussiaShallow = _footballTeamRussia.DeepClone();
			Console.WriteLine("footballTeamRussiaShallow:");
			Console.WriteLine(footballTeamRussiaShallow.ToString());

			Console.WriteLine("\n\nfootballTeamRussia.Players[0].Name += \"Looser\"");
			_footballTeamRussia.Players[0].Name += "Looser";
			Console.WriteLine("footballTeamRussia");
			Console.WriteLine(_footballTeamRussia.ToString());

			Console.WriteLine("footballTeamRussiaShallow");
			Console.WriteLine(footballTeamRussiaShallow.ToString());
		}

		public void TestDeepCapitanNumber()
		{
			/*
					------------------------DEEP--------------------------------------------------------
					*/
			Console.WriteLine("-----------------------DEEP----CAPITAN-NUMBER-----------");

			Console.WriteLine("footballTeamRussia:");
			Console.WriteLine(_footballTeamRussia.ToString());

			var footballTeamRussiaShallow = _footballTeamRussia.DeepClone();
			Console.WriteLine("footballTeamRussiaShallow:");
			Console.WriteLine(footballTeamRussiaShallow.ToString());

			Console.WriteLine("\n\nfootballTeamRussia.Captan.Number = 100500");
			_footballTeamRussia.Captan.Number = 100500;
			Console.WriteLine("footballTeamRussia");
			Console.WriteLine(_footballTeamRussia.ToString());

			Console.WriteLine("footballTeamRussiaShallow");
			Console.WriteLine(footballTeamRussiaShallow.ToString());
		}

		public void TestDeepObjectPlayer()
		{
			/*
			------------------------DEEP--------------------------------------------------------
			*/
			Console.WriteLine("------------------------DEEP----OBJECT-PLAYER-----------");

			Console.WriteLine("footballTeamRussia:");
			Console.WriteLine(_footballTeamRussia.ToString());

			var footballTeamRussiaShallow = _footballTeamRussia.DeepClone();
			Console.WriteLine("footballTeamRussiaShallow:");
			Console.WriteLine(footballTeamRussiaShallow.ToString());

			Console.WriteLine("\n\nfootballTeamRussia.Captan = player1");
			_footballTeamRussia.Captan = _player1;
			Console.WriteLine("footballTeamRussia");
			Console.WriteLine(_footballTeamRussia.ToString());

			Console.WriteLine("footballTeamRussiaShallow");
			Console.WriteLine(footballTeamRussiaShallow.ToString());
		}

		public void TestDeepObjectCountry()
		{
			/*
								------------------------DEEP--------------------------------------------------------
								*/
			Console.WriteLine("-----------------------DEEP--OBJECT-COUNTRY-----------");

			Console.WriteLine("footballTeamRussia:");
			Console.WriteLine(_footballTeamRussia.ToString());

			var footballTeamRussiaShallow = _footballTeamRussia.DeepClone();
			Console.WriteLine("footballTeamRussiaShallow:");
			Console.WriteLine(footballTeamRussiaShallow.ToString());

			Console.WriteLine("\n\nfootballTeamRussia.Captan.BornCountry = usa");
			_footballTeamRussia.Captan.BornCountry = _usa;
			Console.WriteLine("footballTeamRussia");
			Console.WriteLine(_footballTeamRussia.ToString());

			Console.WriteLine("footballTeamRussiaShallow");
			Console.WriteLine(footballTeamRussiaShallow.ToString());
		}
	}
}
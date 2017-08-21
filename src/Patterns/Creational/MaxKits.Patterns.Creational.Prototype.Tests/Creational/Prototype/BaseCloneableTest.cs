using System;
using System.Collections.Generic;
using FluentAssertions;
using MaxKits.Patterns.Tests.Creational.Prototype.Misc;
using NUnit.Framework;

namespace MaxKits.Patterns.Tests.Creational.Prototype
{
	internal class BaseCloneableTest
	{
		private Country _russia;
		private Country _usa;
		private Player _player0;
		private Player _player1;
		private Player _player2;
		private Player _player3;
		private FootballTeam _footballTeamRussia;

		[SetUp]
		public void Init()
		{
			this._russia = new Country { Name = "Russia", Population = 145 };
			this._usa = new Country { Name = "USA", Population = 300 };

			this._player0 = new Player() { BornCountry = this._russia, Name = "Ivanov", Number = 10 };
			this._player1 = new Player() { BornCountry = this._russia, Name = "Petrov", Number = 9 };
			this._player2 = new Player() { BornCountry = this._usa, Name = "Smit", Number = 23 };
			this._player3 = new Player() { BornCountry = this._usa, Name = "Klarc", Number = 24 };

			this._footballTeamRussia = new FootballTeam() { Players = new List< Player > { this._player0, this._player1 }, Captan = this._player0 };
		}

		[Test]
		public void DeepCloneObject_CopyAndOriginalCompletelyUndependentObjects()
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

			object.ReferenceEquals(footballTeamCopy, _footballTeamRussia).Should().BeFalse();
		}

		public void TestShallowPlayerName()
		{
			/*
			------------------------SHALLOW-----------------------------------------------------
			*/
			Console.WriteLine( "------------------------SHALLOW-PLAYER-NAME-------------" );

			Console.WriteLine( "footballTeamRussia:" );
			Console.WriteLine( this._footballTeamRussia.ToString() );

			var footballTeamRussiaShallow = this._footballTeamRussia.ShallowClone();
			Console.WriteLine( "footballTeamRussiaShallow:" );
			Console.WriteLine( footballTeamRussiaShallow.ToString() );

			Console.WriteLine( "\n\nfootballTeamRussia.Players[0].Name += \"Looser\"" );
			this._footballTeamRussia.Players[ 0 ].Name += "Looser";
			Console.WriteLine( "footballTeamRussia" );
			Console.WriteLine( this._footballTeamRussia.ToString() );

			Console.WriteLine( "footballTeamRussiaShallow" );
			Console.WriteLine( footballTeamRussiaShallow.ToString() );
		}

		public void TestShallowCapitanNumber()
		{
			/*
		------------------------SHALLOW-----------------------------------------------------
		*/
			Console.WriteLine( "-----------------------SHALLOW-CAPITAN-NUMBER-----------" );

			Console.WriteLine( "footballTeamRussia:" );
			Console.WriteLine( this._footballTeamRussia.ToString() );

			FootballTeam footballTeamRussiaShallow = this._footballTeamRussia.ShallowClone();
			Console.WriteLine( "footballTeamRussiaShallow:" );
			Console.WriteLine( footballTeamRussiaShallow.ToString() );

			Console.WriteLine( "\n\nfootballTeamRussia.Captan.Number = 100500" );
			this._footballTeamRussia.Captan.Number = 100500;
			Console.WriteLine( "footballTeamRussia" );
			Console.WriteLine( this._footballTeamRussia.ToString() );

			Console.WriteLine( "footballTeamRussiaShallow" );
			Console.WriteLine( footballTeamRussiaShallow.ToString() );
		}

		public void TestShallowObjectPlayer()
		{
			/*
			------------------------SHALLOW-----------------------------------------------------
			*/
			Console.WriteLine( "------------------------SHALLOW-OBJECT-PLAYER-----------" );

			Console.WriteLine( "footballTeamRussia:" );
			Console.WriteLine( this._footballTeamRussia.ToString() );

			var footballTeamRussiaShallow = this._footballTeamRussia.ShallowClone();
			Console.WriteLine( "footballTeamRussiaShallow:" );
			Console.WriteLine( footballTeamRussiaShallow.ToString() );

			Console.WriteLine( "\n\nfootballTeamRussia.Captan = player1" );
			this._footballTeamRussia.Captan = this._player1;
			Console.WriteLine( "footballTeamRussia" );
			Console.WriteLine( this._footballTeamRussia.ToString() );

			Console.WriteLine( "footballTeamRussiaShallow" );
			Console.WriteLine( footballTeamRussiaShallow.ToString() );
		}

		public void TestShallowObjectCountry()
		{
			/*
					------------------------SHALLOW-----------------------------------------------------
					*/
			Console.WriteLine( "-----------------------SHALLOW-OBJECT-COUNTRY-----------" );

			Console.WriteLine( "footballTeamRussia:" );
			Console.WriteLine( this._footballTeamRussia.ToString() );

			FootballTeam footballTeamRussiaShallow = this._footballTeamRussia.ShallowClone();
			Console.WriteLine( "footballTeamRussiaShallow:" );
			Console.WriteLine( footballTeamRussiaShallow.ToString() );

			Console.WriteLine( "\n\nfootballTeamRussia.Captan.BornCountry = usa" );
			this._footballTeamRussia.Captan.BornCountry = this._usa;
			Console.WriteLine( "footballTeamRussia" );
			Console.WriteLine( this._footballTeamRussia.ToString() );

			Console.WriteLine( "footballTeamRussiaShallow" );
			Console.WriteLine( footballTeamRussiaShallow.ToString() );
		}

		/////////////////////////////////

		public void TestDeepPlayerName()
		{
			/*
			------------------------DEEP--------------------------------------------------------
			*/
			Console.WriteLine( "------------------------DEEEP---PLAYER-NAME-------------" );

			Console.WriteLine( "footballTeamRussia:" );
			Console.WriteLine( this._footballTeamRussia.ToString() );

			var footballTeamRussiaShallow = this._footballTeamRussia.DeepClone();
			Console.WriteLine( "footballTeamRussiaShallow:" );
			Console.WriteLine( footballTeamRussiaShallow.ToString() );

			Console.WriteLine( "\n\nfootballTeamRussia.Players[0].Name += \"Looser\"" );
			this._footballTeamRussia.Players[ 0 ].Name += "Looser";
			Console.WriteLine( "footballTeamRussia" );
			Console.WriteLine( this._footballTeamRussia.ToString() );

			Console.WriteLine( "footballTeamRussiaShallow" );
			Console.WriteLine( footballTeamRussiaShallow.ToString() );
		}

		public void TestDeepCapitanNumber()
		{
			/*
					------------------------DEEP--------------------------------------------------------
					*/
			Console.WriteLine( "-----------------------DEEP----CAPITAN-NUMBER-----------" );

			Console.WriteLine( "footballTeamRussia:" );
			Console.WriteLine( this._footballTeamRussia.ToString() );

			FootballTeam footballTeamRussiaShallow = this._footballTeamRussia.DeepClone();
			Console.WriteLine( "footballTeamRussiaShallow:" );
			Console.WriteLine( footballTeamRussiaShallow.ToString() );

			Console.WriteLine( "\n\nfootballTeamRussia.Captan.Number = 100500" );
			this._footballTeamRussia.Captan.Number = 100500;
			Console.WriteLine( "footballTeamRussia" );
			Console.WriteLine( this._footballTeamRussia.ToString() );

			Console.WriteLine( "footballTeamRussiaShallow" );
			Console.WriteLine( footballTeamRussiaShallow.ToString() );
		}

		public void TestDeepObjectPlayer()
		{
			/*
			------------------------DEEP--------------------------------------------------------
			*/
			Console.WriteLine( "------------------------DEEP----OBJECT-PLAYER-----------" );

			Console.WriteLine( "footballTeamRussia:" );
			Console.WriteLine( this._footballTeamRussia.ToString() );

			var footballTeamRussiaShallow = this._footballTeamRussia.DeepClone();
			Console.WriteLine( "footballTeamRussiaShallow:" );
			Console.WriteLine( footballTeamRussiaShallow.ToString() );

			Console.WriteLine( "\n\nfootballTeamRussia.Captan = player1" );
			this._footballTeamRussia.Captan = this._player1;
			Console.WriteLine( "footballTeamRussia" );
			Console.WriteLine( this._footballTeamRussia.ToString() );

			Console.WriteLine( "footballTeamRussiaShallow" );
			Console.WriteLine( footballTeamRussiaShallow.ToString() );
		}

		public void TestDeepObjectCountry()
		{
			/*
								------------------------DEEP--------------------------------------------------------
								*/
			Console.WriteLine( "-----------------------DEEP--OBJECT-COUNTRY-----------" );

			Console.WriteLine( "footballTeamRussia:" );
			Console.WriteLine( this._footballTeamRussia.ToString() );

			FootballTeam footballTeamRussiaShallow = this._footballTeamRussia.DeepClone();
			Console.WriteLine( "footballTeamRussiaShallow:" );
			Console.WriteLine( footballTeamRussiaShallow.ToString() );

			Console.WriteLine( "\n\nfootballTeamRussia.Captan.BornCountry = usa" );
			this._footballTeamRussia.Captan.BornCountry = this._usa;
			Console.WriteLine( "footballTeamRussia" );
			Console.WriteLine( this._footballTeamRussia.ToString() );

			Console.WriteLine( "footballTeamRussiaShallow" );
			Console.WriteLine( footballTeamRussiaShallow.ToString() );
		}
	}
}
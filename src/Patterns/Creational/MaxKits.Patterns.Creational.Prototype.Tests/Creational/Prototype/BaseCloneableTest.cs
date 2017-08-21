using System;
using System.Collections.Generic;
using MaxKits.Patterns.Tests.Creational.Prototype.Misc;

namespace MaxKits.Patterns.Tests.Creational.Prototype
{
	internal class BaseCloneableTest
	{
		private Country russia;
		private Country usa;
		private Player player0;
		private Player player1;
		private Player player2;
		private Player player3;
		private FootballTeam footballTeamRussia;

		public void Init()
		{
			this.russia = new Country { Name = "Russia", Population = 145 };
			this.usa = new Country { Name = "USA", Population = 100 };

			this.player0 = new Player() { BornCountry = this.russia, Name = "Ivanov", Number = 10 };
			this.player1 = new Player() { BornCountry = this.russia, Name = "Petrov", Number = 9 };
			this.player2 = new Player() { BornCountry = this.usa, Name = "Smit", Number = 23 };
			this.player3 = new Player() { BornCountry = this.usa, Name = "Klarc", Number = 24 };

			this.footballTeamRussia = new FootballTeam() { Players = new List< Player > { this.player0, this.player1 }, Captan = this.player0 };
		}

		public void DeepTest()
		{
			FootballTeam footballTeamRussiaShallow;

			/*
			------------------------DEEEP-------------------------------------------------------
			*/
			Console.WriteLine( "-----------------------DEEP-CAPITAN-NUMBER-----------" );

			Console.WriteLine( "footballTeamRussia:" );
			Console.WriteLine( this.footballTeamRussia.ToString() );

			footballTeamRussiaShallow = this.footballTeamRussia.DeepClone();
			Console.WriteLine( "footballTeamRussiaDeep:" );
			Console.WriteLine( footballTeamRussiaShallow.ToString() );

			this.footballTeamRussia.Captan.Number = 100500;
			Console.WriteLine( "\n\nfootballTeamRussia" );
			Console.WriteLine( this.footballTeamRussia.ToString() );

			Console.WriteLine( "footballTeamRussiaShallow" );
			Console.WriteLine( footballTeamRussiaShallow.ToString() );
			/*
			------------------------DEEP-----------------------------------------------------
			*/
			Console.WriteLine( "------------------------DEEP-PLAYER-NAME-------------" );

			Console.WriteLine( "footballTeamRussia:" );
			Console.WriteLine( this.footballTeamRussia.ToString() );

			footballTeamRussiaShallow = this.footballTeamRussia.DeepClone();
			Console.WriteLine( "footballTeamRussiaShallow:" );
			Console.WriteLine( footballTeamRussiaShallow.ToString() );

			this.footballTeamRussia.Players[ 0 ].Name += "Looser";
			Console.WriteLine( "\n\nfootballTeamRussia" );
			Console.WriteLine( this.footballTeamRussia.ToString() );

			Console.WriteLine( "footballTeamRussiaShallow" );
			Console.WriteLine( footballTeamRussiaShallow.ToString() );
		}

		public void TestShallowPlayerName()
		{
			/*
			------------------------SHALLOW-----------------------------------------------------
			*/
			Console.WriteLine( "------------------------SHALLOW-PLAYER-NAME-------------" );

			Console.WriteLine( "footballTeamRussia:" );
			Console.WriteLine( this.footballTeamRussia.ToString() );

			var footballTeamRussiaShallow = this.footballTeamRussia.ShallowClone();
			Console.WriteLine( "footballTeamRussiaShallow:" );
			Console.WriteLine( footballTeamRussiaShallow.ToString() );

			Console.WriteLine( "\n\nfootballTeamRussia.Players[0].Name += \"Looser\"" );
			this.footballTeamRussia.Players[ 0 ].Name += "Looser";
			Console.WriteLine( "footballTeamRussia" );
			Console.WriteLine( this.footballTeamRussia.ToString() );

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
			Console.WriteLine( this.footballTeamRussia.ToString() );

			FootballTeam footballTeamRussiaShallow = this.footballTeamRussia.ShallowClone();
			Console.WriteLine( "footballTeamRussiaShallow:" );
			Console.WriteLine( footballTeamRussiaShallow.ToString() );

			Console.WriteLine( "\n\nfootballTeamRussia.Captan.Number = 100500" );
			this.footballTeamRussia.Captan.Number = 100500;
			Console.WriteLine( "footballTeamRussia" );
			Console.WriteLine( this.footballTeamRussia.ToString() );

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
			Console.WriteLine( this.footballTeamRussia.ToString() );

			var footballTeamRussiaShallow = this.footballTeamRussia.ShallowClone();
			Console.WriteLine( "footballTeamRussiaShallow:" );
			Console.WriteLine( footballTeamRussiaShallow.ToString() );

			Console.WriteLine( "\n\nfootballTeamRussia.Captan = player1" );
			this.footballTeamRussia.Captan = this.player1;
			Console.WriteLine( "footballTeamRussia" );
			Console.WriteLine( this.footballTeamRussia.ToString() );

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
			Console.WriteLine( this.footballTeamRussia.ToString() );

			FootballTeam footballTeamRussiaShallow = this.footballTeamRussia.ShallowClone();
			Console.WriteLine( "footballTeamRussiaShallow:" );
			Console.WriteLine( footballTeamRussiaShallow.ToString() );

			Console.WriteLine( "\n\nfootballTeamRussia.Captan.BornCountry = usa" );
			this.footballTeamRussia.Captan.BornCountry = this.usa;
			Console.WriteLine( "footballTeamRussia" );
			Console.WriteLine( this.footballTeamRussia.ToString() );

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
			Console.WriteLine( this.footballTeamRussia.ToString() );

			var footballTeamRussiaShallow = this.footballTeamRussia.DeepClone();
			Console.WriteLine( "footballTeamRussiaShallow:" );
			Console.WriteLine( footballTeamRussiaShallow.ToString() );

			Console.WriteLine( "\n\nfootballTeamRussia.Players[0].Name += \"Looser\"" );
			this.footballTeamRussia.Players[ 0 ].Name += "Looser";
			Console.WriteLine( "footballTeamRussia" );
			Console.WriteLine( this.footballTeamRussia.ToString() );

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
			Console.WriteLine( this.footballTeamRussia.ToString() );

			FootballTeam footballTeamRussiaShallow = this.footballTeamRussia.DeepClone();
			Console.WriteLine( "footballTeamRussiaShallow:" );
			Console.WriteLine( footballTeamRussiaShallow.ToString() );

			Console.WriteLine( "\n\nfootballTeamRussia.Captan.Number = 100500" );
			this.footballTeamRussia.Captan.Number = 100500;
			Console.WriteLine( "footballTeamRussia" );
			Console.WriteLine( this.footballTeamRussia.ToString() );

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
			Console.WriteLine( this.footballTeamRussia.ToString() );

			var footballTeamRussiaShallow = this.footballTeamRussia.DeepClone();
			Console.WriteLine( "footballTeamRussiaShallow:" );
			Console.WriteLine( footballTeamRussiaShallow.ToString() );

			Console.WriteLine( "\n\nfootballTeamRussia.Captan = player1" );
			this.footballTeamRussia.Captan = this.player1;
			Console.WriteLine( "footballTeamRussia" );
			Console.WriteLine( this.footballTeamRussia.ToString() );

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
			Console.WriteLine( this.footballTeamRussia.ToString() );

			FootballTeam footballTeamRussiaShallow = this.footballTeamRussia.DeepClone();
			Console.WriteLine( "footballTeamRussiaShallow:" );
			Console.WriteLine( footballTeamRussiaShallow.ToString() );

			Console.WriteLine( "\n\nfootballTeamRussia.Captan.BornCountry = usa" );
			this.footballTeamRussia.Captan.BornCountry = this.usa;
			Console.WriteLine( "footballTeamRussia" );
			Console.WriteLine( this.footballTeamRussia.ToString() );

			Console.WriteLine( "footballTeamRussiaShallow" );
			Console.WriteLine( footballTeamRussiaShallow.ToString() );
		}
	}
}
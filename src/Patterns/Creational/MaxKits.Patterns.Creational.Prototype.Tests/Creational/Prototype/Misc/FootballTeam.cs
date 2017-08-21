//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="FootballTeam.cs" company="MaxSoft" author="MKitsenko">
//       Copyright (c) 17.09.2013. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using MaxKits.Patterns.Creational.Prototype;

namespace MaxKits.Patterns.Tests.Creational.Prototype.Misc
{
	[ Serializable ]
	public class FootballTeam: BaseCloneable< FootballTeam >
	{
		public List< Player > Players{ get; set; }

		public Player Captan{ get; set; }

		public override string ToString()
		{
			return string.Format( "Capitan:\n\t{0}.\nPlayers:\n{1} F{2}", this.Captan,
				this.Players.Aggregate( "", ( s, x ) => s + "\t" + x.ToString() + "\n" ), this.GetHashCode() );
		}
	}
}
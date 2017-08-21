//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="Player.cs" company="MaxSoft" author="MKitsenko">
//       Copyright (c) 17.09.2013. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

using System;
using MaxKits.Patterns.Creational.Prototype;

namespace MaxKits.Patterns.Tests.Creational.Prototype.Misc
{
	[ Serializable ]
	public class Player: BaseCloneable< Player >
	{
		public string Name{ get; set; }

		public int Number{ get; set; }

		public Country BornCountry{ get; set; }

		public override string ToString()
		{
			return string.Format( "Name: {0}, Number:{1}, Born in:{2} P{3}", this.Name, this.Number, this.BornCountry, this.GetHashCode() );
		}
	}
}
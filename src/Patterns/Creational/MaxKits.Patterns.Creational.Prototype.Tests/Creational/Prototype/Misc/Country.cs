//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="Country.cs" company="MaxSoft" author="MKitsenko">
//       Copyright (c) 17.09.2013. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

using System;
using MaxKits.Patterns.Creational.Prototype;

namespace MaxKits.Patterns.Tests.Creational.Prototype.Misc
{
	[ Serializable ]
	public class Country: BaseCloneable< Player >
	{
		public string Name{ get; set; }

		public int Population{ get; set; }

		public override string ToString()
		{
			return $"{this.Name}(Population: {this.Population}), HashCode: {this.GetHashCode()}";
		}
	}
}
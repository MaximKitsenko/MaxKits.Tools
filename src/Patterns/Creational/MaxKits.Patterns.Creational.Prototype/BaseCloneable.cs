//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="BaseCloneable.cs" company="MaxSoft" author="MKitsenko">
//       Copyright (c) 17.09.2013. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using MaxKits.Patterns.Creational.Prototype.Interfaces;

namespace MaxKits.Patterns.Creational.Prototype
{
	[ Serializable ]
	public abstract class BaseCloneable< T >: IShallowCloneable< T >, IDeepCloneable< T >
	{
		public virtual T ShallowClone()
		{
			return ( T )this.MemberwiseClone();
		}

		public virtual T DeepClone()
		{
			using( MemoryStream ms = new MemoryStream() )
			{
				BinaryFormatter bf = new BinaryFormatter();
				bf.Serialize( ms, this );
				ms.Position = 0;
				return ( T )bf.Deserialize( ms );
			}
		}
	}
}
//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="IDeepCloneable.cs" company="MaxSoft" author="MKitsenko">
//       Copyright (c) 17.09.2013. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

namespace MaxKits.Patterns.Creational.Prototype.Interfaces
{
	public interface IDeepCloneable< out T >
	{
		T DeepClone();
	}
}
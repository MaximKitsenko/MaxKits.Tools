using System.Collections.Generic;
using System.Linq;

namespace MaxKits.Tools.Extensions
{
	public static class EnumerableExtensions
	{
		/// <summary>
		/// Splits collection to collections.
		/// </summary>
		/// <typeparam name="T">Source collection base type</typeparam>
		/// <param name="src">Source collection</param>
		/// <param name="partsCount">For how many parts devide source collection</param>
		/// <returns>Collection of collections containing source collection splitted to parts</returns>
		public static IEnumerable<IEnumerable<T>> SplitSequential<T>(this IEnumerable<T> src, int partsCount)
		{
			var srcList = src as IList<T> ?? src.ToList();
			var srcCnt = srcList.Count();
			var chunkSize = srcCnt / partsCount;
			chunkSize = chunkSize == 0 ? 1 : chunkSize;
			for (var i = 0; i < partsCount; i++)
				if (i + 1 == partsCount)
					yield return srcList.Skip(i * chunkSize);
				else
					yield return srcList.Skip(i * chunkSize).Take(chunkSize);
		}
	}
}
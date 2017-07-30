using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using MaxKits.Tools.Extensions;
using NUnit.Framework;

namespace MaxKits.Tools.Tests.Extensions
{
	[TestFixture]
	public class EnumerableExtensions
	{
		[TestCaseSource(typeof(SplitSequentialTestCases), nameof(SplitSequentialTestCases.TestCases))]
		public void SplitSequential(SplitSequentialTestCase<int> testCase)
		{
			//a
			//a
			var r = testCase.Collection.SplitSequential(testCase.PartsCount).ToList();
			//a
			r.ShouldBeEquivalentTo(testCase.ResultCollection);
		}

		public class SplitSequentialTestCases
		{
			public static IEnumerable TestCases
			{
				get
				{
					yield return new TestCaseData(new SplitSequentialTestCase<int>(
								5,
								new List<int> {1, 2, 3, 4, 5},
								new List<IEnumerable<int>>
								{
									new List<int> {1},
									new List<int> {2},
									new List<int> {3},
									new List<int> {4},
									new List<int> {5}
								}))
							.SetName("When CollectionElementsCount / PartsCount >= 1 and CollectionElementsCount % PartsCount == 0")
						;
					yield return new TestCaseData(new SplitSequentialTestCase<int>(
								5,
								new List<int>(),
								new List<IEnumerable<int>>
								{
									new List<int>(),
									new List<int>(),
									new List<int>(),
									new List<int>(),
									new List<int>()
								}))
							.SetName("When CollectionElementsCount / PartsCount < 1 and CollectionElementsCount % PartsCount == 0")
						;
					yield return new TestCaseData(new SplitSequentialTestCase<int>(
								5,
								new List<int> {1, 2, 3, 4},
								new List<IEnumerable<int>>
								{
									new List<int> {1},
									new List<int> {2},
									new List<int> {3},
									new List<int> {4},
									new List<int>()
								}))
							.SetName("When CollectionElementsCount / PartsCount < 1 and CollectionElementsCount % PartsCount > 0")
						;
					yield return new TestCaseData(new SplitSequentialTestCase<int>(
								5,
								new List<int> {1, 2, 3, 4, 5, 6},
								new List<IEnumerable<int>>
								{
									new List<int> {1},
									new List<int> {2},
									new List<int> {3},
									new List<int> {4},
									new List<int> {5, 6}
								}))
							.SetName("When CollectionElementsCount / PartsCount > 1 and CollectionElementsCount % PartsCount > 0")
						;
				}
			}
		}

		public class SplitSequentialTestCase<T>
		{
			public SplitSequentialTestCase(int partsCount, IEnumerable<T> srcCollection,
				IEnumerable<IEnumerable<T>> resultCollection)
			{
				PartsCount = partsCount;
				Collection = srcCollection;
				ResultCollection = resultCollection;
			}

			public int PartsCount { get; }
			public IEnumerable<T> Collection { get; }
			public IEnumerable<IEnumerable<T>> ResultCollection { get; }
		}
	}
}
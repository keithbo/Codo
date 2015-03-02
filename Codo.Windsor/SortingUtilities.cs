namespace Codo.Windsor
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Reflection;

	/// <summary>
	/// Static helper extensions for sorting
	/// </summary>
	public static class SortingUtilities
	{
		/// <summary>
		/// Sorts an IEnumerable of types based on their DependsOnAttribute metadata, if any.
		/// This method is non-destructive and returns a new IEnumerable instance post-sort.
		/// </summary>
		/// <param name="sourceTypes">input enumerable of type objects</param>
		/// <returns>sorted output enumerable of type objects</returns>
		public static IEnumerable<Type> SortByDependsOn(this IEnumerable<Type> sourceTypes)
		{
			Dictionary<Type, IEnumerable<Type>> dependsOnMap =
				sourceTypes.ToDictionary(t => t, t => t.GetCustomAttributes<DependsOnAttribute>().Select(a => a.TargetType));

			List<Type> installerTypesList = sourceTypes.ToList();
			installerTypesList.Sort(
				(t1, t2) =>
				{
					IEnumerable<Type> c1 = dependsOnMap[t1];
					IEnumerable<Type> c2 = dependsOnMap[t2];
					bool t1DependsOnT2 = c1.Contains(t2);
					bool t2DependsOnT1 = c2.Contains(t1);

					if (t1DependsOnT2 && t2DependsOnT1)
					{
						throw new InvalidOperationException("Circular DependsOn TargetType found");
					}

					if (t1DependsOnT2)
					{
						return 1;
					}
					else if (t2DependsOnT1)
					{
						return -1;
					}
					else
					{
						return 0;
					}
				});

			return installerTypesList;
		}
	}
}

namespace Codo.Windsor
{
	using System;

	/// <summary>
	/// DependsOnAttribute defines a class dependency on another type.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
	public sealed class DependsOnAttribute : Attribute
	{
		/// <summary>
		/// The target dependency type
		/// </summary>
		public Type TargetType { get; private set; }

		/// <summary>
		/// Constructs a new DependsOnAttribute with a target type
		/// </summary>
		/// <param name="targetType">Type</param>
		public DependsOnAttribute(Type targetType)
		{
			TargetType = targetType;
		}
	}
}

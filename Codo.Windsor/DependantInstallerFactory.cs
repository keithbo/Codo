namespace Codo.Windsor
{
	using Castle.Windsor.Installer;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Reflection;

	/// <summary>
	/// This InstallerFactory implementation will sort IWindsorInstaller instances based on any
	/// DependsOnAttribute metadata attached to them.
	/// Installers with no dependency on eachother are considered equal for purposes of sorting.
	/// This factory only ensures that installers with dependencies come after their dependency is loaded.
	/// </summary>
	public class DependantInstallerFactory : InstallerFactory
	{
		/// <summary>
		/// Sorts an IEnumerable of installer types based on their DependsOnAttribute relations.
		/// </summary>
		/// <param name="installerTypes">input IEnumerable of type objects</param>
		/// <returns>sorted output IEnumerable of type objects</returns>
		public override IEnumerable<Type> Select(IEnumerable<Type> installerTypes)
		{
			return installerTypes.SortByDependsOn();
		}
	}
}

namespace Codo.Windsor.Mvc
{
	using System.Web.Mvc;

	/// <summary>
	/// Adds a global HandleErrorAttribute to the global filter set.
	/// </summary>
	public class GlobalFilterMvcConfigurer : IMvcConfigurer
	{
		/// <summary>
		/// Perform the configuration.
		/// </summary>
		public void Configure()
		{
			GlobalFilterCollection filters = GlobalFilters.Filters;

			filters.Add(new HandleErrorAttribute());
		}
	}
}

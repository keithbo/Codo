namespace Codo.Windsor.Mvc
{
	using System.Web.Mvc;

	/// <summary>
	/// This IMvcConfigurer performs the standard AreaRegistration Asp.Net MVC requires
	/// to load all Area configurations.
	/// </summary>
	public class AreaMvcConfigurer : IMvcConfigurer
	{
		/// <summary>
		/// Perform the configuration.
		/// </summary>
		public void Configure()
		{
			AreaRegistration.RegisterAllAreas();
		}
	}
}

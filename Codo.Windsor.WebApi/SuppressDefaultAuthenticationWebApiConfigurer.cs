namespace Codo.Windsor.WebApi
{
	using Microsoft.Owin.Security.OAuth;
	using System.Web.Http;

	/// <summary>
	/// Suppresses Default host authentication
	/// </summary>
	public class SuppressDefaultAuthenticationWebApiConfigurer : IWebApiConfigurer
	{
		/// <summary>
		/// Perform configuration of the target HttpConfiguration
		/// </summary>
		/// <param name="configuration">HttpConfiguration</param>
		public void Configure(System.Web.Http.HttpConfiguration configuration)
		{
			// Configure Web API to use only bearer token authentication.
			configuration.SuppressDefaultHostAuthentication();
		}
	}
}

namespace Codo.Windsor.WebApi
{
	using Microsoft.Owin.Security.OAuth;
	using System.Web.Http;

	/// <summary>
	/// Configures HostAuthentication as a filter on the provided HttpConfiguration.
	/// Defaults to OAuthDefaults if no authentication type is provided.
	/// </summary>
	public class AuthenticationWebApiConfigurer : IWebApiConfigurer
	{
		/// <summary>
		/// Current authentication type.
		/// </summary>
		public string AuthenticationType
		{
			get;
			private set;
		}

		/// <summary>
		/// Constructs authentication filtering with OAuth as the default
		/// </summary>
		public AuthenticationWebApiConfigurer()
			: this(OAuthDefaults.AuthenticationType)
		{
		}

		/// <summary>
		/// Constructs authentication filtering with the provided authenticationType
		/// </summary>
		/// <param name="authenticationType"></param>
		public AuthenticationWebApiConfigurer(string authenticationType)
		{
			AuthenticationType = authenticationType;
		}

		/// <summary>
		/// Perform configuration with the given HttpConfiguration
		/// </summary>
		/// <param name="context">HttpConfiguration</param>
		public void Configure(System.Web.Http.HttpConfiguration context)
		{
			context.Filters.Add(
				new AuthenticationFilterAdapter(
					new HostAuthenticationFilter(AuthenticationType)));
		}
	}
}

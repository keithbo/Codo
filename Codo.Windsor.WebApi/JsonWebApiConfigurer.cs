namespace Codo.Windsor.WebApi
{
	using Newtonsoft.Json.Converters;
	using System.Web.Http;

	/// <summary>
	/// Configure JSON serializer settings for WebApi
	/// </summary>
	public class JsonWebApiConfigurer : IWebApiConfigurer
	{
		/// <summary>
		/// Perform the configuration with HttpConfiguration as input context
		/// </summary>
		/// <param name="configuration">HttpConfiguration</param>
		public void Configure(HttpConfiguration configuration)
		{
			configuration.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new StringEnumConverter());
		}
	}
}

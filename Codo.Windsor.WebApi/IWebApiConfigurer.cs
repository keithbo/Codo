namespace Codo.Windsor.WebApi
{
	using System.Web.Http;

	/// <summary>
	/// This interface defines the IConfigurer[HttpConfiguration] overrides
	/// necessary for Asp.Net configurers
	/// </summary>
	public interface IWebApiConfigurer : IConfigurer<HttpConfiguration>
	{
	}
}

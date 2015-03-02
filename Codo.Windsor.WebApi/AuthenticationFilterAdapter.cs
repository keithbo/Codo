namespace Codo.Windsor.WebApi
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using System.Web.Http.Filters;

	/// <summary>
	/// Adapter implementation that maps an IAuthenticationFilter source to the IFilter interface.
	/// Useful for forcing authentication schemes into a filter pipeline.
	/// </summary>
	public class AuthenticationFilterAdapter : IAuthenticationFilter, IFilter
	{
		private readonly IAuthenticationFilter _source;

		/// <summary>
		/// Constructs a new AuthenticationFilterAdapter with a source IAuthenticationFilter implementation.
		/// </summary>
		/// <param name="source">IAuthenticationFilter</param>
		public AuthenticationFilterAdapter(IAuthenticationFilter source)
		{
			this._source = source;
		}

		/// <summary>
		/// Begin an authentication request
		/// </summary>
		/// <param name="context">HttpAuthenticationContext</param>
		/// <param name="cancellationToken">CancellationToken to terminate the request</param>
		/// <returns>Task</returns>
		public Task AuthenticateAsync(HttpAuthenticationContext context, System.Threading.CancellationToken cancellationToken)
		{
			return this._source.AuthenticateAsync(context, cancellationToken);
		}

		/// <summary>
		/// Begin a challenge request
		/// </summary>
		/// <param name="context">HttpAuthenticationChallengeContext</param>
		/// <param name="cancellationToken">CancellationToken to terminate the request</param>
		/// <returns>Task</returns>
		public Task ChallengeAsync(HttpAuthenticationChallengeContext context, System.Threading.CancellationToken cancellationToken)
		{
			return this._source.ChallengeAsync(context, cancellationToken);
		}

		/// <summary>
		/// Gets the multiple status for this filter
		/// </summary>
		public bool AllowMultiple
		{
			get
			{
				return this._source.AllowMultiple;
			}
		}
	}
}

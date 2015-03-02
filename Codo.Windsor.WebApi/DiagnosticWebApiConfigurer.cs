namespace Codo.Windsor.WebApi
{
	using System.Web.Http;

	/// <summary>
	/// Configure WebApi diagnostics tracing
	/// </summary>
	public class DiagnosticWebApiConfigurer : IWebApiConfigurer
	{
		/// <summary>
		/// Enable Debug level tracing
		/// </summary>
		public bool EnableTrace { get; set; }

		/// <summary>
		/// Include error detail policy
		/// </summary>
		public bool IncludeErrorPolicy { get; set; }

		/// <summary>
		/// Force error detail policy to be local only
		/// </summary>
		public bool LocalErrorPolicyOnly { get; set; }

		/// <summary>
		/// Constructs a new DiagnosticWebApiConfigurer
		/// </summary>
		public DiagnosticWebApiConfigurer()
		{
			this.EnableTrace = false;
			this.IncludeErrorPolicy = false;
			this.LocalErrorPolicyOnly = false;
		}

		/// <summary>
		/// Perform configuration with an HttpConfiguration as input context.
		/// </summary>
		/// <param name="configuration">HttpConfiguration</param>
		public void Configure(HttpConfiguration configuration)
		{
			// To disable tracing in your application, please comment out or remove the following line of code
			// For more information, refer to: http://www.asp.net/web-api
			if (this.EnableTrace)
			{
				var traceWriter = configuration.EnableSystemDiagnosticsTracing();
				traceWriter.IsVerbose = true;
				traceWriter.MinimumLevel = System.Web.Http.Tracing.TraceLevel.Debug;
			}

			IncludeErrorDetailPolicy errorPolicy = IncludeErrorDetailPolicy.Never;
			if (this.IncludeErrorPolicy)
			{
				if (this.LocalErrorPolicyOnly)
				{
					errorPolicy = IncludeErrorDetailPolicy.LocalOnly;
				}
				else
				{
					errorPolicy = IncludeErrorDetailPolicy.Always;
				}
			}
			configuration.IncludeErrorDetailPolicy = errorPolicy;
		}
	}
}

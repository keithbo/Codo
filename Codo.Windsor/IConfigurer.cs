namespace Codo.Windsor
{
	/// <summary>
	/// IConfigurer defines a contract for a type that can be configured with no input context.
	/// </summary>
	public interface IConfigurer
	{
		/// <summary>
		/// Configure the instance.
		/// </summary>
		void Configure();
	}

	/// <summary>
	/// IConfigurer[TContext] defines a contract for a type that can be configured with
	/// an explicit input context.
	/// </summary>
	/// <typeparam name="TContext">Type of the input context</typeparam>
	public interface IConfigurer<TContext>
	{
		/// <summary>
		/// Configure the instance.
		/// </summary>
		/// <param name="context">TContext typed input context</param>
		void Configure(TContext context);
	}
}

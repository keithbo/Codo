namespace Codo.Windsor
{
	using Castle.MicroKernel.Registration;

	/// <summary>
	/// This installer will resolve and configure all TConfigurer instances found in the IWindsorContainer provided
	/// to it during installer processing.
	/// </summary>
	/// <typeparam name="TConfigurer">An implementation of IConfigurer</typeparam>
	public abstract class WindsorConfigurerInstaller<TConfigurer> : IWindsorInstaller
		where TConfigurer : IConfigurer
	{
		/// <summary>
		/// Typical installer behavior registers a number of types into the container. This installer abstraction moves that
		/// action into RegisterContainerTypes to be carried out first upon installation.
		/// </summary>
		/// <param name="container">IWinsorContainer</param>
		protected abstract void RegisterContainerTypes(Castle.Windsor.IWindsorContainer container);

		/// <summary>
		/// The standard IWindsorInstaller hook for processing installation.
		/// </summary>
		/// <param name="container">IWindsorContainer</param>
		/// <param name="store">IConfigurationStore</param>
		public void Install(Castle.Windsor.IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
		{
			this.RegisterContainerTypes(container);

			// delegate Mvc settings to dependency injected configurations
			foreach (var settingsConfiguration in container.ResolveAll<TConfigurer>())
			{
				settingsConfiguration.Configure();
			}
		}
	}

	/// <summary>
	/// This installer will resolve and configure all TConfigurer[TConfigurerContext] instances found in the IWindsorContainer provided
	/// to it during installer processing.
	/// </summary>
	/// <typeparam name="TConfigurer">An implementation of IConfigurer[TConfigurerContext]</typeparam>
	/// <typeparam name="TConfigurerContext">The context type to be supplied during configuration</typeparam>
	public abstract class ConfigurerWindsorInstaller<TConfigurer, TConfigurerContext> : IWindsorInstaller
		where TConfigurer : IConfigurer<TConfigurerContext>
		where TConfigurerContext : class
	{
		/// <summary>
		/// Typical installer behavior registers a number of types into the container. This installer abstraction moves that
		/// action into RegisterContainerTypes to be carried out first upon installation.
		/// </summary>
		/// <param name="container">IWinsorContainer</param>
		protected abstract void RegisterContainerTypes(Castle.Windsor.IWindsorContainer container);

		/// <summary>
		/// This method retrieves the TConfigurerContext instance to be supplied to IConfigurer[TConfigurerContext] instances.
		/// </summary>
		/// <param name="container">IWindsorContainer</param>
		/// <returns>TConfigurerContext</returns>
		protected abstract TConfigurerContext GetConfigurerContext(Castle.Windsor.IWindsorContainer container);

		/// <summary>
		/// The standard IWindsorInstaller hook for processing installation.
		/// </summary>
		/// <param name="container">IWindsorContainer</param>
		/// <param name="store">IConfigurationStore</param>
		public void Install(Castle.Windsor.IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
		{
			this.RegisterContainerTypes(container);

			TConfigurerContext context = this.GetConfigurerContext(container);

			// delegate Mvc settings to dependency injected configurations
			foreach (var settingsConfiguration in container.ResolveAll<TConfigurer>())
			{
				settingsConfiguration.Configure(context);
			}
		}
	}
}

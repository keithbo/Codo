namespace Codo.Windsor
{
	public interface IConfigurer
	{
		void Configure();
	}

	public interface IConfigurer<TContext>
	{
		void Configure(TContext context);
	}
}

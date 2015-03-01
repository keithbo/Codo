namespace Codo.Windsor.Mvc
{
	using System.Web.Mvc;

	public class AreaMvcConfigurer : IMvcConfigurer
	{
		public void Configure()
		{
			AreaRegistration.RegisterAllAreas();
		}
	}
}

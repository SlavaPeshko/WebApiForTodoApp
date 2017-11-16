using System.Data.Entity;
using System.Web;
using System.Web.Http;
using WebApiForTodoApp.Context;

namespace WebApiForTodoApp
{
	public class WebApiApplication : HttpApplication
	{
		protected void Application_Start()
		{
			GlobalConfiguration.Configure(WebApiConfig.Register);
			Database.SetInitializer<DatabaseContext>(new DatabaseInitializer());
			SimpleInjector.Configure();
		}
	}
}
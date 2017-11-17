using System.Data.Entity;
using Owin;
using WebApiForTodoApp.Context;

namespace WebApiForTodoApp
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			WebApiConfig.Configure(app);
			Database.SetInitializer<DatabaseContext>(new DatabaseInitializer());
		}
	}
}
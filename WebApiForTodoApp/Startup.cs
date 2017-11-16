using System.Data.Entity;
using Microsoft.Owin.Cors;
using Owin;
using WebApiForTodoApp.Context;

namespace WebApiForTodoApp
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			WebApiConfig.Configure(app);
			app.UseCors(CorsOptions.AllowAll);
			Database.SetInitializer<DatabaseContext>(new DatabaseInitializer());
		}
	}
}
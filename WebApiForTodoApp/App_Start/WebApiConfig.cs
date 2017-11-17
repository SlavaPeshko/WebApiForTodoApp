using System.Web.Http;
using System.Web.Http.ModelBinding;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using WebApiForTodoApp.Context;
using WebApiForTodoApp.Repository;
using WebApiForTodoApp.Service;

namespace WebApiForTodoApp
{
	public class WebApiConfig
	{
		public static void Configure(IAppBuilder app)
		{
			var container = new Container();

			container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

			container.Register<ITodoRepository, TodoRepository>(Lifestyle.Scoped);
			container.Register<DatabaseContext>(Lifestyle.Scoped);
			container.Register<ITodoService, TodoService>(Lifestyle.Scoped);
			container.Register<IValidationDictionary, ValidationDictionary>(Lifestyle.Scoped);
			container.Register<ModelStateDictionary>(() => new ModelStateDictionary(), Lifestyle.Scoped);

			container.Verify();

			app.Use(async (context, next) =>
			{
				using (AsyncScopedLifestyle.BeginScope(container))
				{
					await next();
				}
			});

			var config = new HttpConfiguration();

			config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute(
				"DefaultApi",
				"api/{controller}/{id}",
				new { id = RouteParameter.Optional }
			);

			config.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
			config.Formatters.JsonFormatter.SerializerSettings.Formatting =
				Formatting.Indented;
			config.Formatters.JsonFormatter.SerializerSettings.ContractResolver =
				new CamelCasePropertyNamesContractResolver();

			config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);

			config.EnableCors();

			app.UseWebApi(config);
		}
	}
}
using System.Web.Http;
using System.Web.Http.ModelBinding;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using WebApiForTodoApp.Context;
using WebApiForTodoApp.Repository;
using WebApiForTodoApp.Service;

namespace WebApiForTodoApp
{
	public class SimpleInjector
	{
		public static void Configure()
		{
			var container = new Container();

			container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

			InitializeContainer(container);

			container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

			container.Verify();

			GlobalConfiguration.Configuration.DependencyResolver =
				new SimpleInjectorWebApiDependencyResolver(container);
		}

		private static void InitializeContainer(Container container)
		{
			container.Register<ITodoRepository, TodoRepository>(Lifestyle.Scoped);
			container.Register<DatabaseContext>(Lifestyle.Scoped);
			container.Register<ITodoService, TodoService>(Lifestyle.Scoped);
			container.Register<IValidationDictionary, ValidationDictionary>(Lifestyle.Scoped);
			container.Register<ModelStateDictionary>(() => new ModelStateDictionary(), Lifestyle.Scoped);
		}
	}
}
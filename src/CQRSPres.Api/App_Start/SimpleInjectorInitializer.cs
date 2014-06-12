using System;
using System.Linq;
using System.Reflection;
using System.Web.Http.Controllers;
using CQRSPres.Api;
using Raven.Client;
using Raven.Client.Document;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;

[assembly: WebActivator.PostApplicationStartMethod(typeof(SimpleInjectorInitializer), "Initialize")]

namespace CQRSPres.Api
{
	public static class SimpleInjectorInitializer
	{
		/// <summary>Initialize the container and register it as MVC3 Dependency Resolver.</summary>
		public static void Initialize()
		{
			var container = new Container();

			var controllerTypes =
				from type in Assembly.GetExecutingAssembly().GetExportedTypes()
				where typeof(IHttpController).IsAssignableFrom(type)
				where !type.IsAbstract
				where !type.IsGenericTypeDefinition
				where type.Name.EndsWith("Controller", StringComparison.Ordinal)
				select type;

			foreach (var controllerType in controllerTypes)
			{
				container.Register(controllerType);
			}

			// Register api project bindings
			RegisterBindings(container);

			container.Verify();

			System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver =
				new SimpleInjectorWebApiDependencyResolver(container);
		}
	 
		private static void RegisterBindings(Container container)
		{
			container.RegisterSingle<DocumentStore>(WebApiApplication.DocumentStore);
		}
	}
}
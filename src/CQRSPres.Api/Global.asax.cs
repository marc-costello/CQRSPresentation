using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using CQRSPres.Api.RavenListeners;
using Raven.Client.Document;

namespace CQRSPres.Api
{
	public class WebApiApplication : System.Web.HttpApplication
	{
		public static DocumentStore DocumentStore;
		
		protected void Application_Start()
		{
			DocumentStore = new DocumentStore { Url = "http://ravendb:8080", DefaultDatabase = "CQRSPres"};
			DocumentStore.RegisterListener(new AuditableEntityListener());
			DocumentStore.Initialize();
			Application["DocumentStore"] = DocumentStore;
			
			AreaRegistration.RegisterAllAreas();
			GlobalConfiguration.Configure(WebApiConfig.Register);
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);

			SimpleInjectorInitializer.Initialize();
		}
	}
}

using System;
using System.Web.Http;
using CQRSPres.Api.Commands;
using CQRSPres.Api.Query;

namespace CQRSPres.Api.Controllers
{
	public class MyApiController : ApiController
	{		
		protected TResult Query<TResult>(Query<TResult> query)
		{
			if (query == null)
				throw new ArgumentNullException("query", "Query cannot be null");

			using (var session = WebApiApplication.DocumentStore.OpenSession())
			{
				return query.Execute(session);
			}
		}

		protected void ExecuteCommand(Command command)
		{
			if (command == null)
				throw new ArgumentNullException("command", "Command cannot be null");

			using (var session = WebApiApplication.DocumentStore.OpenSession())
			{
				command.Execute(session);
			}
		}
	}
}
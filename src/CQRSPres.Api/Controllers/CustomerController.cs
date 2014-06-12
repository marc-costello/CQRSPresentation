using System.Web.Http;
using CQRS.Domain;
using CQRSPres.Api.Commands;
using CQRSPres.Api.Query;

namespace CQRSPres.Api.Controllers
{
	public class CustomerController : MyApiController
	{
		// GET api/customer/
		public Customer Get()
		{
			return Query(new GetCustomerQuery("customers/130"));
		}

		// POST api/customer
		public void Post()
		{
			ExecuteCommand(new AddCustomerCommand("marc.costello@tombola.com", "abc123"));
		}

		[Route("api/customer/{id}/changepassword")]
		public void PostChangePassword(int id, [FromBody]string password)
		{
			var customerId = string.Format("customers/{0}", id);
			ExecuteCommand(new ChangeCustomerPasswordCommand(customerId, password));
		}
	}
}

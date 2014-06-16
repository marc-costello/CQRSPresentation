using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using CQRS.Domain;
using CQRSPres.Api.Commands;
using CQRSPres.Api.Dtos;
using CQRSPres.Api.Query;

namespace CQRSPres.Api.Controllers
{
	public class CustomerController : MyApiController
	{
		// GET api/customer
		public IEnumerable<CustomerDto> Get()
		{
			return Query(s => s.Query<Customer>().Select(c => new CustomerDto
																	{
																		Id = c.Id,
																		Email = c.Email,
																		Password = c.Password
																	}))
																	.ToList();
		}
		
		// GET api/customer/{id}
		public CustomerDto Get(int id)
		{
			return Query(new GetCustomerQuery(id));
		}

		// POST api/customer
		public void Post()
		{
			var command = new AddCustomerCommand("marc.costello@tombola.com", "abc123");
			try
			{
				ExecuteCommand(command);
				if (!command.Success)
				{
					// if command.CustomerAlreadyExists
				}
			}
			catch
			{
				// infrastructure exceptions
			}
		}

		[Route("api/customer/{id}/changepassword")]
		public void PostChangePassword(int id, [FromBody]string password)
		{
			var customerId = string.Format("customers/{0}", id);
			var command = new ChangeCustomerPasswordCommand(customerId, password);

			try
			{
				ExecuteCommand(command);
				
				if (!command.Success)
				{
					// cry
				}
			}
			catch
			{
				// infrastructure exceptions
			}
		}

		[Route("api/customer/{id}/changeaddress")]
		public void PostChangeAddress(int id, [FromBody]AddressViewModel address)
		{
			var customerId = string.Format("customers/{0}", id);
			ExecuteCommand(new ChangeCustomerAddressCommand(customerId, address));
		}
	}

	public class AddressViewModel
	{
		public string Line1 { get; set; }
		public string Line2 { get; set; }
		public string City { get; set; }
		public string County { get; set; }
		public string Country { get; set; }
	}
}

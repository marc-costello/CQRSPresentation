using CQRS.Domain;
using CQRSPres.Api.Controllers;
using Raven.Client;

namespace CQRSPres.Api.Commands
{
	public class ChangeCustomerAddressCommand : Command
	{
		private readonly string _id;
		private readonly AddressViewModel _address;

		public ChangeCustomerAddressCommand(string id, AddressViewModel address)
		{
			_id = id;
			_address = address;
		}

		public override void Execute(IDocumentSession session)
		{
			var customer = session.Load<Customer>(_id);
			var newAddress = new Address(_address.Line1, _address.Line2, _address.City, _address.County, _address.Country);

			customer.ChangeAddress(newAddress);

			session.SaveChanges();
		}
	}
}
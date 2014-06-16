using System;
using CQRS.Domain;
using CQRSPres.Api.Dtos;
using Raven.Client;

namespace CQRSPres.Api.Query
{
	internal class GetCustomerQuery : Query<CustomerDto>
	{
		private readonly string _id;

		public GetCustomerQuery(int id)
		{
			if (id == 0)
				throw new ArgumentOutOfRangeException("id", "GetCustomerCommand must be given an id greater than 0");
			
			_id = string.Format("customers/{0}", id);
		}
		
		public override CustomerDto Execute(IDocumentSession session)
		{
			var domainCustomer = session.Load<Customer>(_id);
			return new CustomerDto
			{
				Id = domainCustomer.Id,
				Email = domainCustomer.Email,
				Password = domainCustomer.Password
			};
		}
	}
}
using CQRSPres.Domain;
using Raven.Client;

namespace CQRSPres.Api.Query
{
	internal class GetCustomerQuery : Query<Customer>
	{
		private readonly string _id;

		public GetCustomerQuery(string id)
		{
			_id = id;
		}
		
		public override Customer Execute(IDocumentSession session)
		{
			return session.Load<Customer>(_id);
		}
	}
}
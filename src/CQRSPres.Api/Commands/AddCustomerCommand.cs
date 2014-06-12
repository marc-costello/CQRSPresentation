using CQRS.Domain;
using Raven.Client;

namespace CQRSPres.Api.Commands
{
	public class AddCustomerCommand : Command
	{
		private readonly string _email;
		private readonly string _password;

		public AddCustomerCommand(string email, string password)
		{
			_email = email;
			_password = password;
		}
		
		public override void Execute(IDocumentSession session)
		{
			session.Store(new Customer(_email, _password));
			session.SaveChanges();
		}
	}
}
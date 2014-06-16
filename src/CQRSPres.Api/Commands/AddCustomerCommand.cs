using System.Linq;
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

		public bool CustomerAlreadyExists { get; private set; }
		
		public override void Execute(IDocumentSession session)
		{
			CustomerAlreadyExists = session.Query<Customer>().Any(c => c.Email == _email);

			if (CustomerAlreadyExists) return;
			
			session.Store(new Customer(_email, _password));
			session.SaveChanges();
			Success = true;
		}
	}
}
using System;
using CQRS.Domain;
using Raven.Client;

namespace CQRSPres.Api.Commands
{
	public class ChangeCustomerPasswordCommand : Command
	{
		private readonly string _id;
		private readonly string _password;

		public ChangeCustomerPasswordCommand(string id, string password)
		{
			// validate all the things..

			_id = id;
			_password = password;
		}
		
		public override void Execute(IDocumentSession session)
		{
			var customer = session.Load<Customer>(_id);

			try
			{
				customer.ChangePassword(_password);
			}
			catch (InvalidOperationException)
			{
				// Catch domain exceptions, set any error properties if needed.
				return;
			}

			session.SaveChanges();
			Success = true;
		}
	}
}
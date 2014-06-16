using Raven.Client;

namespace CQRSPres.Api.Commands
{
	public abstract class Command
	{
		public bool Success { get; protected set; }

		public abstract void Execute(IDocumentSession session);
	}
}
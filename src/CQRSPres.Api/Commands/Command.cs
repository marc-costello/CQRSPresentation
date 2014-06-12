using System;
using Raven.Client;

namespace CQRSPres.Api.Commands
{
	public abstract class Command
	{
		public abstract void Execute(IDocumentSession session);
	}
}
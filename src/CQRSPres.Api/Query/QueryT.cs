using Raven.Client;

namespace CQRSPres.Api.Query
{
	public abstract class Query<TResult>
	{
		public abstract TResult Execute(IDocumentSession session);
	}
}
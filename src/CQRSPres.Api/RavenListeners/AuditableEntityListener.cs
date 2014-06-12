using System;
using CQRSPres.Domain;
using Raven.Client.Listeners;
using Raven.Json.Linq;

namespace CQRSPres.Api.RavenListeners
{
	public class AuditableEntityListener : IDocumentStoreListener
	{
		public bool BeforeStore(string key, object entityInstance, RavenJObject metadata, RavenJObject original)
		{
			var auditableEntity = entityInstance as Entity;

			if (auditableEntity == null)
				return false;

			if (original.Count == 0)
				auditableEntity.CreatedDate = DateTime.UtcNow;

			auditableEntity.ModifiedDate = DateTime.UtcNow;

			return true;
		}

		public void AfterStore(string key, object entityInstance, RavenJObject metadata)
		{
		}
	}
}
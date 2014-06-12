using System;

namespace CQRS.Domain
{
	public abstract class Entity
	{
		public string Id { get; private set; }
		public DateTime CreatedDate { get; set; }
		public DateTime ModifiedDate { get; set; }
		public DateTime? DeletedDate { get; set; }
	}
}

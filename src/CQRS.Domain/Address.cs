namespace CQRS.Domain
{
	public struct Address
	{
		public Address(string line1, string line2, string city, string county, string country) : this()
		{
			Line1 = line1;
			Line2 = line2;
			City = city;
			County = county;
			Country = country;
		}

		public string Line1 { get; private set; }
		public string Line2 { get; private set; }
		public string City { get; private set; }
		public string County { get; private set; }
		public string Country { get; private set; }
	}
}

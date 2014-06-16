namespace CQRS.Domain
{
	public class Customer : Entity
	{
		protected Customer() {}
		
		public Customer(string email, string password)
		{
			// Null checks (or other domain validations)...

			Email = email;
			Password = password;
		}

		public Customer(string email, string password, string firstName, string lastName, int age, Address address)
			: this(email, password)
		{
			// Null checks (or other domain validations)...

			FirstName = firstName;
			LastName = lastName;
			Age = age;
			Address = address;
		}

		public string FirstName { get; private set; }
		public string LastName { get; private set; }
		public string FullName { get { return FirstName + " " + LastName; } }
		public int Age { get; private set; }
		public string Email { get; private set; }
		public string Password { get; private set; }
		public Address Address { get; private set; }

		public void ChangePassword(string password)
		{
			// Password validation - must be 6 chars long and include a number?
			
			Password = password;
		}

		public void ChangeAddress(Address address)
		{
			Address = address;
		}
	}
}

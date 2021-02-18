using System;
using System.Collections.Generic;
using System.Text;

namespace BookConsoleApp
{
	class Customer
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime DateofBirth { get; set; }
		public List<Address> Addresses { get; set; }

	}

	// Adds multiple addresses object to the customer object
	class Address
	{
		public string Address1 { get; set; }
		public string Type { get; set; }
	}
}

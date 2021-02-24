using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Library.Models
{
	public class Customer
	{
		public int CustomerId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime DateofBirth { get; set; }
		public List<Address> Addresses { get; set; }

	}

	// Adds multiple addresses object to the customer object
	public class Address
	{
		public string Address1 { get; set; }
		public string Type { get; set; }
	}
}

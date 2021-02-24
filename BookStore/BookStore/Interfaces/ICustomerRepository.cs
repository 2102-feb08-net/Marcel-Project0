using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookConsoleApp;
using BookStore.Library.Models;

namespace BookStore.Library.Interfaces
{
	public interface ICustomerRepository
	{
		IEnumerable<Customer> GetCustomers(string search = null);

		Customer GetCustomerById(int id);

		void AddCustomer(Customer customer);

		void DeleteCustomer(int customerId);

		void UpdateCustomer(Customer customer);

		void Save();
	}
}

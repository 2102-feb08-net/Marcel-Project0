using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Library.Interfaces;
using NLog;

namespace DataAccess.Repository
{
	public class CustomerRepository : ICustomerRepository
	{
		private readonly BookstoreContext _dbContext;

		private static readonly ILogger s_logger = LogManager.GetCurrentClassLogger();

		public CustomerRepository(BookstoreContext dbContext)
		{
			_dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

		}

		public BookStore.Library.Models.Customer GetCustomerById(int id)
		{
			var customer = _dbContext.Customers.Find(id);
			return new BookStore.Library.Models.Customer
			{
				// References customer file under class library
				CustomerId = customer.CustomerId,
				FirstName = customer.FirstName,
				LastName = customer.LastName,
			};
		}

		public void AddCustomer(BookStore.Library.Models.Customer customer)
		{
			if (customer.CustomerId != 0)
			{

				s_logger.Info($"Adding customer");

				var entity = new Customer
				{
					FirstName = customer.FirstName,
					LastName = customer.LastName
				};
				_dbContext.Add(entity);

			}

		}

		public void DeleteCustomer(int customerId)
		{
			s_logger.Info($"Deleting customer with ID {customerId}");
			Customer entity = _dbContext.Customers.Find(customerId);
			_dbContext.Remove(entity);
		}

		public void Save()
		{
			s_logger.Info("Saving changes to the database");
			_dbContext.SaveChanges();
		}

		public IEnumerable<BookStore.Library.Models.Customer> GetCustomers(string search = null)
		{
			throw new NotImplementedException();
		}

		public void UpdateCustomer(BookStore.Library.Models.Customer customer)
		{
			throw new NotImplementedException();
		}
	}

}

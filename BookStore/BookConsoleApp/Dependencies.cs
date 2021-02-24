using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using BookStore.Library.Interfaces;
using BookStore.Library.Repository;
using DataAccess;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BookConsoleApp
{
	public class Dependencies : IDesignTimeDbContextFactory<BookstoreContext>, IDisposable
	{

		private readonly List<IDisposable> _disposables = new List<IDisposable>();

		public BookstoreContext CreateDbContext(string[] args = null)
		{
			var optionsBuilder = new DbContextOptionsBuilder<BookstoreContext>();
			var connectionString = @"Server=tcp:2102-garza-sql.database.windows.net,1433;Initial Catalog=Bookstore;Persist Security Info=False;User ID=Cel1223;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
			optionsBuilder.UseSqlServer(connectionString);

			return new BookstoreContext(optionsBuilder.Options);
		}

		public IBookRepository CreateBookRepository()
		{
			var dbContext = CreateDbContext();
			_disposables.Add(dbContext);
			return new BookRepository(dbContext);
		}

		public XmlSerializer CreateXmlSerializer()
		{
			return new XmlSerializer(typeof(List<BookStore.Library.Models.Book>));
		}

		public ICustomerRepository CreateCustomerRepository()
		{
			var dbContext = CreateDbContext();
			_disposables.Add(dbContext);
			return new CustomerRepository(dbContext);
		}

		public XmlSerializer CreateXmlSerialzier()
		{
			return new XmlSerializer(typeof(List<BookStore.Library.Models.Customer>));
		}

		public void Dispose()
		{
			throw new NotImplementedException();
		}
	}
}

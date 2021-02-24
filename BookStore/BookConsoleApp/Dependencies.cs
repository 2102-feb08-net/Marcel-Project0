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
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BookConsoleApp
{
	public class Dependencies : IDesignTimeDbContextFactory<BookstoreContext>, IDisposable
	{
		private bool _disposedValue;

		private readonly List<IDisposable> _disposables = new List<IDisposable>();

		public BookstoreContext CreateDbContext(string[] args = null)
		{
			var optionsBuilder = new DbContextOptionsBuilder<BookstoreContext>();
			var connectionString = File.ReadAllText("C:/revature/bookstore-connection-string.txt");
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


	}
}

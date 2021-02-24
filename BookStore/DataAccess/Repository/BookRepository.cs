using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Library.Interfaces;
using DataAccess;
using NLog;

namespace BookStore.Library.Repository
{
	public class BookRepository : IBookRepository
	{
		private readonly BookstoreContext _dbContext;

		private static readonly ILogger s_logger = LogManager.GetCurrentClassLogger();

		public BookRepository(BookstoreContext dbContext)
		{
			_dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
		}

		public BookStore.Library.Models.Book GetBookById(int id)
		{
			var book = _dbContext.Books.Find(id);
			return new BookStore.Library.Models.Book
			{
				Id = book.BookId,
				Title = book.Title
			};
		}

		public void AddBook(BookStore.Library.Models.Book book)
		{
			s_logger.Info($"Adding book");

			var entity = new Book
			{
				Title = book.Title
			};
			_dbContext.Add(entity);

		}

		// Deletes a book by ID
		public void DeleteBook(int bookId)
		{
			s_logger.Info($"Deleting book with ID {bookId}");
			Book entity = _dbContext.Books.Find(bookId);
			_dbContext.Remove(entity);
		}

		public void Save()
		{
			s_logger.Info("Saving changes to the database");
			_dbContext.SaveChanges();
		}

		public IEnumerable<Models.Book> GetBooks(string search = null)
		{
			throw new NotImplementedException();
		}

		public Models.Book GetBookbyId(int id)
		{
			throw new NotImplementedException();
		}
	}

}
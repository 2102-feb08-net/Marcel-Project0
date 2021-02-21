using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Library.Inventory
{
	public class BookInventory
	{
		// Defines the base class for collection. Ensures user cannot alter the collection.
		private readonly ICollection<Book> _data;

		// Initializes a new book inventory assuming a valid data source has been given
		public BookInventory(ICollection<Book> data)
		{
			_data = data ?? throw new ArgumentNullException(nameof(data));
		}

		// The input variable is inferred to be a Book object, meaning I have access to its methods and properties.
		// This lambda expression retuns a collection of books but does not execute until the object is iterated over a loop.
		public IEnumerable<Book> GetBooks(string search = null)
		{
			if (search == null)
			{
				foreach (var item in _data)
				{
					yield return item;
				}
			}
			else
			{
				foreach (var item in _data.Where(r => r.Title.Contains(search)))
				{
					yield return item;
				}
			}
		}

		// Gets book by ID
		public Book GetBookById(int id)
		{
			return _data.First(r => r.Id == id);
		}

		// Adds a book
		public void AddBook(Book book)
		{
			if (_data.Any(r => r.Id == book.Id))
			{
				throw new InvalidOperationException($"Book with ID {book.Id} already exists.");
			}
			_data.Add(book);
		}
	}
}
